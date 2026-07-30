using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using InstrumentHealthCheck.Config;
using InstrumentHealthCheck.Reports;
using InstrumentHealthCheck.Results;
// IDUTInstrument/SignalGenerator/SpectrumAnalyzer live in InstrumentCore.dll but keep
// their original "Pegatron" namespace so the existing Pegatron app didn't need any code
// changes when they were extracted into the shared library.
using Pegatron;

namespace InstrumentHealthCheck.UI
{
    public partial class TestPanel : UserControl
    {
        // A single fixed RF path index; this project has no LitePoint-style dual-path
        // routing UI, so every SetupVSG*/SetupVSA* call just uses path "1".
        private const string RoutNum = "1";

        private PortSwitchPanel _portSwitchPanel;
        private DeviceConnectionPanel _devicePanel;
        private CalibrationPanel _calibrationPanel;

        private readonly BindingList<TestResultRow> _results = new BindingList<TestResultRow>();
        private volatile bool _stopRequested;
        private Thread _testThread;

        public TestPanel()
        {
            InitializeComponent();
            SetupGrid();
        }

        public void Initialize(PortSwitchPanel portSwitchPanel, DeviceConnectionPanel devicePanel, CalibrationPanel calibrationPanel)
        {
            _portSwitchPanel = portSwitchPanel;
            _devicePanel = devicePanel;
            _calibrationPanel = calibrationPanel;
        }

        public void SyncPorts(List<PortDefinition> ports)
        {
            cboPort.Items.Clear();
            foreach (PortDefinition p in ports)
                cboPort.Items.Add(p);

            if (cboPort.Items.Count > 0)
                cboPort.SelectedIndex = 0;
        }

        private void SetupGrid()
        {
            dgvResults.AutoGenerateColumns = false;
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "頻率 (MHz)", DataPropertyName = "FrequencyMHz", Width = 90 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "預期 (dBm)", DataPropertyName = "ExpectedDbm", Width = 90 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "量測 (dBm)", DataPropertyName = "MeasuredDbm", Width = 90 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "誤差 (dB)", DataPropertyName = "ErrorDb", Width = 90 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPass", HeaderText = "Pass/Fail", DataPropertyName = "Pass", Width = 80 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "備註", DataPropertyName = "Note", Width = 250 });
            dgvResults.DataSource = _results;
            dgvResults.CellFormatting += DgvResults_CellFormatting;
        }

        private void DgvResults_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvResults.Columns[e.ColumnIndex].Name == "colPass" && e.Value is bool pass)
            {
                e.Value = pass ? "P" : "F";
                e.FormattingApplied = true;
            }
        }

        private static List<double> ParseList(string text)
        {
            var list = new List<double>();
            foreach (string part in text.Split(','))
            {
                if (double.TryParse(part.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double v))
                    list.Add(v);
            }
            return list;
        }

        // Some instruments prefix replies with a status code ("0,-12.34"); take the last
        // comma-separated field either way.
        private static double ParseInstrumentReply(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                throw new FormatException("儀器沒有回應");

            string trimmed = raw.Trim();
            string lastField = trimmed.Contains(",") ? trimmed.Split(',').Last().Trim() : trimmed;

            if (!double.TryParse(lastField, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                throw new FormatException("無法解析儀器回應：" + raw);

            return value;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (_testThread != null && _testThread.IsAlive) return;

            if (_devicePanel?.Dut == null)
            {
                MessageBox.Show("請先在「設備連線」分頁連線 DUT。", "尚未連線", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DutRoleType role = _devicePanel.CurrentRole;
            bool refMissing = role == DutRoleType.SignalAnalyzer
                ? _devicePanel.ReferenceSignalGenerator == null
                : _devicePanel.ReferenceSpectrumAnalyzer == null;

            if (refMissing)
            {
                MessageBox.Show("請先在「設備連線」分頁連線對打參考儀器。", "尚未連線", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(cboPort.SelectedItem is PortDefinition port))
            {
                MessageBox.Show("請選擇要測試的 Port。", "尚未選擇 Port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<PortDefinition> currentPorts = _portSwitchPanel.GetSettings().Ports;
            int portIndex = currentPorts.IndexOf(port);
            if (portIndex < 0)
            {
                MessageBox.Show("選取的 Port 已經不存在，請重新整理 Port 清單。", "Port 已變更", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<double> freqs = ParseList(txtFreqList.Text);
            List<double> powers = ParseList(txtPowerList.Text);
            if (freqs.Count == 0 || powers.Count == 0)
            {
                MessageBox.Show("頻率清單與功率清單都要至少一個有效數字。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtTolerance.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double tolerance))
                tolerance = 1.0;

            if (!_portSwitchPanel.ActivatePort(port))
                return;

            _results.Clear();
            btnRun.Enabled = false;
            btnStop.Enabled = true;
            btnGenerateReport.Enabled = false;
            lblStatus.Text = "測試中...";
            _stopRequested = false;

            IDUTInstrument dut = _devicePanel.Dut;
            SignalGenerator refSg = _devicePanel.ReferenceSignalGenerator;
            SpectrumAnalyzer refSa = _devicePanel.ReferenceSpectrumAnalyzer;
            CalibrationSet calSet = _calibrationPanel.CalibrationData;

            _testThread = new Thread(() => RunTest(role, dut, refSg, refSa, calSet, portIndex, freqs, powers, tolerance));
            _testThread.IsBackground = true;
            _testThread.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _stopRequested = true;
        }

        private void RunTest(DutRoleType role, IDUTInstrument dut, SignalGenerator refSg, SpectrumAnalyzer refSa,
            CalibrationSet calSet, int portIndex, List<double> freqs, List<double> powers, double tolerance)
        {
            try
            {
                foreach (double freq in freqs)
                {
                    if (_stopRequested) break;

                    foreach (double power in powers)
                    {
                        if (_stopRequested) break;

                        var row = new TestResultRow { FrequencyMHz = freq, ExpectedDbm = power };

                        try
                        {
                            double measured = role == DutRoleType.SignalAnalyzer
                                ? RunSignalAnalyzerPoint(dut, refSg, calSet, portIndex, freq, power)
                                : RunSignalGeneratorPoint(dut, refSa, calSet, portIndex, freq, power);

                            row.MeasuredDbm = measured;
                            row.ErrorDb = measured - power;
                            row.Pass = Math.Abs(row.ErrorDb) <= tolerance;
                        }
                        catch (Exception ex)
                        {
                            row.Note = ex.Message;
                            row.Pass = false;
                        }

                        TestResultRow capturedRow = row;
                        BeginInvoke((MethodInvoker)(() => _results.Add(capturedRow)));
                    }
                }
            }
            finally
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    btnRun.Enabled = true;
                    btnStop.Enabled = false;
                    lblStatus.Text = _stopRequested ? "已停止" : "測試完成";
                    btnGenerateReport.Enabled = _results.Count > 0;
                }));
            }
        }

        // DUT receives (SA-like): reference SG drives it, DUT itself reports the power it saw.
        private double RunSignalAnalyzerPoint(IDUTInstrument dut, SignalGenerator refSg, CalibrationSet calSet, int portIndex, double freq, double power)
        {
            refSg.Reset();
            refSg.WriteScpi(string.Format(CultureInfo.InvariantCulture, "FREQ {0} MHz", freq));
            refSg.WriteScpi(string.Format(CultureInfo.InvariantCulture, "SOUR:POW {0} dBm", power));
            refSg.WriteScpi("OUTP ON");

            dut.SetupVSAMode(RoutNum);
            dut.SetupVSAChannel(1, "A", RoutNum);
            dut.SetupVSAFrequency(freq, RoutNum);
            dut.PrepareVSAMeasurement(power, RoutNum);
            dut.InitiateVSACapture();
            string raw = dut.ReadVSAPower();

            refSg.WriteScpi("OUTP OFF");

            double loss = calSet.ReferenceToDut.GetLoss(freq, portIndex);
            return ParseInstrumentReply(raw) - loss;
        }

        // DUT transmits (SG-like): DUT drives the reference SA, which reports the power it saw.
        private double RunSignalGeneratorPoint(IDUTInstrument dut, SpectrumAnalyzer refSa, CalibrationSet calSet, int portIndex, double freq, double power)
        {
            dut.SetupVSGChannel(freq, 1, "A", RoutNum);
            dut.SetupVSGPower(power, RoutNum);
            dut.TransmitOn(RoutNum);

            refSa.Reset();
            refSa.WriteScpi("INIT:CONT OFF");
            refSa.WriteScpi("CALC:MARK:STAT ON");
            refSa.WriteScpi(string.Format(CultureInfo.InvariantCulture, "FREQ:CENT {0} MHz", freq));
            refSa.WriteScpi("FREQ:SPAN 10 kHz");
            refSa.WriteScpi("BAND:RES 100 Hz");
            refSa.WriteScpi(string.Format(CultureInfo.InvariantCulture, "DISP:WIND:TRAC:Y:RLEV {0} dBm", power + 5));
            refSa.WriteScpi("INIT;*WAI");
            refSa.WriteScpi("CALC:MARK1:MAX");
            string raw = refSa.QueryScpi("CALC:MARK:Y?");

            dut.TransmitOff(RoutNum);

            double loss = calSet.DutToReference.GetLoss(freq, portIndex);
            return ParseInstrumentReply(raw) - loss;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (_results.Count == 0) return;
            if (!(cboPort.SelectedItem is PortDefinition port)) return;

            DutRoleType role = _devicePanel.CurrentRole;
            string html = ReportBuilder.GenerateHtml(
                _devicePanel.Dut,
                role,
                _devicePanel.ReferenceSignalGenerator,
                _devicePanel.ReferenceSpectrumAnalyzer,
                port,
                _portSwitchPanel.GetSettings().UseSwitch,
                _calibrationPanel.LoadedFilePath != null ? System.IO.Path.GetFileName(_calibrationPanel.LoadedFilePath) : null,
                _results.ToList(),
                DateTime.Now);

            try
            {
                string path = ReportBuilder.SaveReport(html, _devicePanel.Dut?.Model, DateTime.Now);
                MessageBox.Show("報告已產生：\n" + path, "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("產生報告失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
