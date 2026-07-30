using DocumentFormat.OpenXml;
using Pegatron.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Timer = System.Windows.Forms.Timer;

namespace Pegatron
{
    public partial class CalibrationForm : Form
    {
        private DiagramPopupForm diagramPopupForm;
        private LitepointHealthCheck LHC;
        public Thread calThread;

        private DataTable dtSGDUT;
        private DataTable dtSADUT;

        private bool isSGDUT = true;
        private bool isSADUT = false;
        private bool isSGSA = false;
        private bool isCalibrating = false;

        private static readonly string SGSALogFolder = Path.Combine(Application.StartupPath, "Calibration", "SGSA_HealthCheck");
        public CalibrationForm(LitepointHealthCheck lhc)
        {
            InitializeComponent();
            TopLevel = false;
            LHC = lhc;
        }

        private void CalibrationForm_Load(object sender, EventArgs e)
        {
            initializeDTSGDUT();
            initializeDTSADUT();

            if (!string.IsNullOrEmpty(LHC.DUTCommTester.Model) && LHC.DUTCommTester.Model.Contains("IQXSTREAM-M"))
                cbIQxstream.Checked = true;
            
            SelectSGDUTTab();
        }

        private void SelectSGDUTTab()
        {
            if(dtSGDUT?.Rows.Count != 0)
            {
                numericUpDownStartFreq.Value = int.Parse(dtSGDUT.Rows[0][0].ToString());
                numericUpDownEndFreq.Value = int.Parse(dtSGDUT.Rows[dtSGDUT.Rows.Count - 1][0].ToString());
            }

            dataGridViewCalTable.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dataGridViewCalTable.DataSource = dtSGDUT;
            for (int i = 0; i < dataGridViewCalTable.Columns.Count; i++)
            {
                dataGridViewCalTable.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridViewCalTable.Columns[i].MinimumWidth = 60;
                //dataGridViewCalTable.Columns[i].Width = 60;
            }

            if (LHC.ConfigCAL.SGDUTHasReference)
            {
                labelneedsCalibration.Text = "Completed";
                labelneedsCalibration.ForeColor = Color.LimeGreen;
            }
            else
            {
                labelneedsCalibration.Text = "Required";
                labelneedsCalibration.ForeColor = Color.Red;
            }

            if (string.IsNullOrEmpty(LHC.ConfigCAL.SGDUTReferenceDate))
                labelLastCal.Text = "-";
            else
                labelLastCal.Text = LHC.ConfigCAL.SGDUTReferenceDate;

            dataGridViewCalTable.ClearSelection();
        }
        private void SelectSADUTTab()
        {
            if (dtSADUT.Rows.Count != 0)
            {
                numericUpDownStartFreq.Value = int.Parse(dtSADUT.Rows[0][0].ToString());
                numericUpDownEndFreq.Value = int.Parse(dtSADUT.Rows[dtSADUT.Rows.Count - 1][0].ToString());
            }

            dataGridViewCalTable.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dataGridViewCalTable.DataSource = dtSADUT;
            for (int i = 0; i < dataGridViewCalTable.Columns.Count; i++)
            {
                dataGridViewCalTable.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridViewCalTable.Columns[i].MinimumWidth = 60;
                //dataGridViewCalTable.Columns[i].Width = 60;
            }

            if (LHC.ConfigCAL.SADUTHasReference)
            {
                labelneedsCalibration.Text = "Completed";
                labelneedsCalibration.ForeColor = Color.LimeGreen;
            }
            else
            {
                labelneedsCalibration.Text = "Required";
                labelneedsCalibration.ForeColor = Color.Red;
            }

            if (string.IsNullOrEmpty(LHC.ConfigCAL.SADUTReferenceDate))
                labelLastCal.Text = "-";
            else
                labelLastCal.Text = LHC.ConfigCAL.SADUTReferenceDate;

            dataGridViewCalTable.ClearSelection();
        }

        private void SelectSGSATab()
        {
            btnApply.Visible = false;
            btnConnectionDiagramPanel.Visible = false;
            panelSGSASettings.Visible = true;
            dataGridViewCalTable.Visible = false;
            panelSGSAChartArea.Visible = true;

            lblCal.Text = "Sweeps Recorded:";
            lblLastCal.Text = "Last Measured:";
            if (!isCalibrating)
                lblSGSAStatus.Text = "Ready.";

            LoadSGSATrend();

            labelneedsCalibration.Focus();
        }

        private void initializeDTSGDUT()
        {
            dtSGDUT = new DataTable();
            dtSGDUT.Columns.Add("Frequency MHz");
            dtSGDUT.Columns.Add("Port 1A\ndB");
            dtSGDUT.Columns.Add("Port 1B\ndB");
            dtSGDUT.Columns.Add("Port 2A\ndB");
            dtSGDUT.Columns.Add("Port 2B\ndB");
            dtSGDUT.Columns.Add("Port 3A\ndB");
            dtSGDUT.Columns.Add("Port 3B\ndB");
            dtSGDUT.Columns.Add("Port 4A\ndB");
            dtSGDUT.Columns.Add("Port 4B\ndB");

            foreach (string[] freq in LHC.ConfigCAL.CalibrateSGtoDUT)
                dtSGDUT.Rows.Add(freq);
        }

        private void initializeDTSADUT()
        {
            dtSADUT = new DataTable();
            dtSADUT.Columns.Add("Frequency MHz");
            dtSADUT.Columns.Add("Port 1A\ndB");
            dtSADUT.Columns.Add("Port 1B\ndB");
            dtSADUT.Columns.Add("Port 2A\ndB");
            dtSADUT.Columns.Add("Port 2B\ndB");
            dtSADUT.Columns.Add("Port 3A\ndB");
            dtSADUT.Columns.Add("Port 3B\ndB");
            dtSADUT.Columns.Add("Port 4A\ndB");
            dtSADUT.Columns.Add("Port 4B\ndB");

            foreach (string[] freq in LHC.ConfigCAL.CalibrateSAtoDUT)
                dtSADUT.Rows.Add(freq);
        }

        private void tabSGDUT_Click(object sender, EventArgs e)
        {
            if (!isSGDUT)
            {
                btnConnectionDiagram.BackgroundImage = Properties.Resources.CalSGDUT;
                tabSADUT.BackColor = Color.Gray;
                tabSGSA.BackColor = Color.Gray;
                tabSGDUT.BackColor = Color.FromArgb(32, 32, 32);
                tabSADUT.Margin = new Padding(0, 10, 0, 0);
                tabSGSA.Margin = new Padding(0, 10, 0, 0);
                tabSGDUT.Margin = new Padding(0, 0, 0, 0);
                isSADUT = false;
                isSGSA = false;
                isSGDUT = true;
                labelneedsCalibration.Focus();

                if (diagramPopupForm == null || !diagramPopupForm.Created)
                    diagramPopupForm = new DiagramPopupForm();
                diagramPopupForm.Text = "SG to DUT";
                diagramPopupForm.BackgroundImage = btnConnectionDiagram.BackgroundImage;

                leaveSGSATab();
                SelectSGDUTTab();
            }
        }

        private void tabSADUT_Click(object sender, EventArgs e)
        {
            if (!isSADUT)
            {
                btnConnectionDiagram.BackgroundImage = Properties.Resources.CalDUTSA;
                tabSGDUT.BackColor = Color.Gray;
                tabSGSA.BackColor = Color.Gray;
                tabSADUT.BackColor = Color.FromArgb(32, 32, 32);
                tabSGDUT.Margin = new Padding(0, 10, 0, 0);
                tabSGSA.Margin = new Padding(0, 10, 0, 0);
                tabSADUT.Margin = new Padding(0, 0, 0, 0);
                isSGDUT = false;
                isSGSA = false;
                isSADUT = true;
                labelneedsCalibration.Focus();

                if (diagramPopupForm == null || !diagramPopupForm.Created)
                    diagramPopupForm = new DiagramPopupForm();
                diagramPopupForm.Text = "DUT to SA";
                diagramPopupForm.BackgroundImage = btnConnectionDiagram.BackgroundImage;

                leaveSGSATab();
                SelectSADUTTab();
            }
        }

        private void tabSGSA_Click(object sender, EventArgs e)
        {
            if (!isSGSA)
            {
                tabSGDUT.BackColor = Color.Gray;
                tabSADUT.BackColor = Color.Gray;
                tabSGSA.BackColor = Color.FromArgb(32, 32, 32);
                tabSGDUT.Margin = new Padding(0, 10, 0, 0);
                tabSADUT.Margin = new Padding(0, 10, 0, 0);
                tabSGSA.Margin = new Padding(0, 0, 0, 0);
                isSGDUT = false;
                isSADUT = false;
                isSGSA = true;
                labelneedsCalibration.Focus();

                if (diagramPopupForm != null && diagramPopupForm.Created)
                    diagramPopupForm.Close();

                SelectSGSATab();
            }
        }

        // Undo the layout changes SelectSGSATab makes, so the SGDUT/SADUT tabs get their normal grid view back
        private void leaveSGSATab()
        {
            btnApply.Visible = true;
            btnConnectionDiagramPanel.Visible = true;
            panelSGSASettings.Visible = false;
            dataGridViewCalTable.Visible = true;
            panelSGSAChartArea.Visible = false;

            lblCal.Text = "Calibration:";
            lblLastCal.Text = "Last Calibrated:";
        }

        private void buttonStartCalibration_Click(object sender, EventArgs e)
        {
            labelneedsCalibration.Focus();
            if (LHC.isTesting)
                return;

            if (LHC.isDebug)
            {
                LHC.PSConnected = true;
                LHC.SGConnected = true;
                LHC.SAConnected = true;
                LHC.SwitchConnected = true;
            }

            if (isSGSA)
            {
                if (!LHC.SGConnected || !LHC.SAConnected)
                {
                    MessageBox.Show("Please make sure Signal Generator and Spectrum Analyzer is connected", "Unable to connect instrument", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (!LHC.PSConnected || !LHC.SGConnected || !LHC.SwitchConnected)
            {
                DialogResult result = MessageBox.Show("Please make sure Power Sensor, Signal Generator, and Switch Box is connected", "Unable to connect instrument", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isCalibrating)
            {
                stopCalibrating();
                return;
            }

            isCalibrating = true;
            buttonStartCalibration.BackColor = Color.Red;
            buttonStartCalibration.Text = "■ Stop";

            tabSGDUT.Enabled = false;
            tabSADUT.Enabled = false;
            tabSGSA.Enabled = false;

            calThread = new Thread(delegate ()
            {
                bool isStopped = false;
                bool switchPortSet = false;

                if (LHC.isDebug)
                    switchPortSet = true;
                else if (isSGDUT)
                    switchPortSet = LHC.SwitchBox.SetPort(LHC.SwitchBox.PortSGDUT);
                else if (isSADUT)
                    switchPortSet = LHC.SwitchBox.SetPort(LHC.SwitchBox.PortSADUT);
                else if (isSGSA)
                    switchPortSet = true; // direct cable connection, switch box is bypassed entirely

                if (switchPortSet && isSGSA)
                {
                    RunSGSASweep();
                }
                else if (switchPortSet && isSGDUT)
                {
                    //if (LHC.ConfigCAL.CalibrateSGtoDUT.allCSVFreq == null)
                    //    LHC.ConfigCAL.CalibrateSGtoDUT.getFreqList();

                    DataTable newCalibrateTable = dtSGDUT.Clone();
                    foreach (string[] row in LHC.ConfigCAL.CalibrateSGtoDUT)
                        newCalibrateTable.Rows.Add(row);

                    Invoke((MethodInvoker)(() =>
                    {
                        dataGridViewCalTable.DataSource = null;
                        dtSGDUT.Rows.Clear();
                        dtSGDUT = newCalibrateTable.Copy();
                        dataGridViewCalTable.DataSource = dtSGDUT;
                    }));

                    MessageBox.Show("Please disconnect the Power Sensor connector to perform zeroing. Click OK after it is disconnected.", "Power Sensor Zeroing");
                    initializeCal();

                    for (int port = 1; port <= 8; port++)
                    {
                        DialogResult result = new DialogResult();

                        Invoke((MethodInvoker)(() =>
                        {
                            //string portName = port + "A";
                            //if (port > 4)
                            //    portName = (port - 4) + "B";
                            //string portName = ((port + 1) / 2) + (port % 2 == 1 ? "A" : "B");
                            string portName = dataGridViewCalTable.Columns[port].Name.Substring(0, 7);

                            MessageBoxManager.Cancel = "Skip";
                            MessageBoxManager.Register();
                            result = MessageBox.Show(String.Format("Connect Power Sensor to {0}. Click OK after it is connected. Click Skip to skip this port.", portName), String.Format("Calibrating {0}", portName), MessageBoxButtons.OKCancel);
                            MessageBoxManager.Unregister();
                            //if (result != DialogResult.OK)
                            //    isStopped = true;
                        }));
                        if (result != DialogResult.OK)
                            continue;

                        foreach (DataRow row in dtSGDUT.Rows)
                            row[port] = "";

                        for (int row = 0; row < dtSGDUT.Rows.Count; row++)
                        {
                            int rowEditedVisible = 2 + row - dataGridViewCalTable.Height / dataGridViewCalTable.RowTemplate.Height;
                            if (rowEditedVisible > 0)
                                Invoke((MethodInvoker)(() => dataGridViewCalTable.FirstDisplayedScrollingRowIndex = rowEditedVisible));
                            else
                                Invoke((MethodInvoker)(() => dataGridViewCalTable.FirstDisplayedScrollingRowIndex = 0));

                            string freq = DoCalibration(dtSGDUT.Rows[row].Field<string>("Frequency MHz"));
                            dtSGDUT.Rows[row][port] = freq;
                        }
                        LHC.ConfigCAL.CSVSave(dtSGDUT, "SGDUT");
                    }

                    endCal();

                    if (!isStopped)
                        LHC.ConfigCAL.SGDUTHasReference= true;
                    else
                        LHC.ConfigCAL.SGDUTHasReference= false;
                    LHC.ConfigCAL.SGDUTReferenceDate = DateTime.Now.ToString();
                }
                else if (switchPortSet && isSADUT)
                {
                    //if (LHC.ConfigCAL.CalibrateSAtoDUT.allCSVFreq == null)
                    //    LHC.ConfigCAL.CalibrateSAtoDUT.getFreqList();

                    DataTable newCalibrateTable = dtSADUT.Clone();
                    foreach (string[] row in LHC.ConfigCAL.CalibrateSAtoDUT)
                        newCalibrateTable.Rows.Add(row);

                    Invoke((MethodInvoker)(() =>
                    {
                        dataGridViewCalTable.DataSource = null;
                        dtSADUT.Rows.Clear();
                        dtSADUT = newCalibrateTable.Copy();
                        dataGridViewCalTable.DataSource = dtSADUT;
                    }));

                    MessageBox.Show("Please disconnect the Power Sensor connector to perform zeroing. Click OK after it is disconnected.", "Power Sensor Zeroing");
                    initializeCal();

                    for (int port = 1; port <= 8; port++)
                    {
                        DialogResult result = new DialogResult();

                        Invoke((MethodInvoker)(() =>
                        {
                            //string portName = port + "A";
                            //if (port > 4)
                            //    portName = (port - 4) + "B";
                            string portName = dataGridViewCalTable.Columns[port].Name.Substring(0, 7);

                            MessageBoxManager.Cancel = "Skip";
                            MessageBoxManager.Register();
                            result = MessageBox.Show(String.Format("Connect Signal Generator to {0}. Click OK after it is connected. Click Cancel to skip this port.", portName), String.Format("Calibrating {0}", portName), MessageBoxButtons.OKCancel);
                            MessageBoxManager.Unregister();
                            //if (result != DialogResult.OK)
                            //    isStopped = true;
                        }));
                        if (result != DialogResult.OK)
                            continue;
                        
                        foreach (DataRow row in dtSADUT.Rows)
                            row[port] = "";

                        for (int row = 0; row < dtSADUT.Rows.Count; row++)
                        {
                            int rowEditedVisible = 2 + row - dataGridViewCalTable.Height / dataGridViewCalTable.RowTemplate.Height;
                            if (rowEditedVisible > 0)
                                Invoke((MethodInvoker)(() => dataGridViewCalTable.FirstDisplayedScrollingRowIndex = rowEditedVisible));
                            else
                                Invoke((MethodInvoker)(() => dataGridViewCalTable.FirstDisplayedScrollingRowIndex = 0));

                            string freq = DoCalibration(dtSADUT.Rows[row].Field<string>("Frequency MHz"));
                            dtSADUT.Rows[row][port] = freq;
                        }
                        LHC.ConfigCAL.CSVSave(dtSADUT, "SADUT");
                    }

                    endCal();

                    if (!isStopped)
                        LHC.ConfigCAL.SADUTHasReference = true;
                    else
                        LHC.ConfigCAL.SADUTHasReference= false;
                    LHC.ConfigCAL.SADUTReferenceDate= DateTime.Now.ToString();
                }
                else if (!switchPortSet)
                    MessageBox.Show("Switch box failed to set port", "Switch box query error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Invoke((MethodInvoker)(() =>
                {
                    if (isSGDUT) SelectSGDUTTab();
                    else if (isSADUT) SelectSADUTTab();
                    else if (isSGSA) SelectSGSATab();

                    isCalibrating = false;
                    buttonStartCalibration.BackColor = Color.Orange;
                    buttonStartCalibration.Text = "▶ Start";

                    tabSGDUT.Enabled = true;
                    tabSADUT.Enabled = true;
                    tabSGSA.Enabled = true;
                }));
            });
            calThread.Start();
        }

        private void stopCalibrating()
        {
            buttonStartCalibration.Enabled = false;
            Invoke((MethodInvoker)(() =>
            {
                calThread.Suspend();
                DialogResult result = MessageBox.Show("Are you sure you want to abort this calibration? The data will not be saved.", "Stop calibration", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (calThread.IsAlive)
                        calThread.Resume();
                    calThread.Abort();

                    endCal();

                    isCalibrating = false;
                    buttonStartCalibration.BackColor = Color.Orange;
                    buttonStartCalibration.Text = "▶ Start";

                    tabSGDUT.Enabled = true;
                    tabSADUT.Enabled = true;
                    tabSGSA.Enabled = true;

                    if (isSGDUT)
                    {
                        //LHC.ConfigCAL.CalibrateSGtoDUT.HasReference = false;
                        initializeDTSGDUT();
                        SelectSGDUTTab();
                    }
                    else if (isSADUT)
                    {
                        //LHC.ConfigCAL.CalibrateSAtoDUT.HasReference = false;
                        initializeDTSADUT();
                        SelectSADUTTab();
                    }
                    else if (isSGSA)
                    {
                        SelectSGSATab();
                    }
                }
                else
                    calThread.Resume();

                buttonStartCalibration.Enabled = true;
            }));
        }

        private string DoCalibration(string sFreq)
        {
            //LHC.SG.WriteScpi("SOUR:CORR:STAT 0");
            LHC.SG.WriteScpi($"SOUR1:FREQ:CW {sFreq} MHz");
            //LHC.SG.WriteScpi("SOUR1:POW:POW 0");
            //LHC.SG.QueryScpi("OUTP1:STAT 1;*OPC?");
            LHC.SG.WaitOpc();
            System.Threading.Thread.Sleep(500);  // extra wait after SG settles — increase if PS still misses
            //LHC.PS.ClearOffset();
            string dRslt = LHC.PS.GetPower(sFreq);
            //LHC.SG.QueryScpi("OUTP1:STAT 0;*OPC?");
            //LHC.SG.WriteScpi("*WAI");

            if (LHC.isDebug && dRslt == "-0")//debugging
                return "-" + new Random().NextDouble().ToString("n2");

            if (!double.TryParse(dRslt, NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double power) || power <= 0)
                return "";  // PS returned 0 / negative / timeout — leave cell empty rather than writing -∞

            double dBm = 30 + 10 * Math.Log10(power);//micro watt to dbm
            return dBm.ToString("n3");
        }

        private void initializeCal()
        {
            LHC.SG.Reset();
            LHC.SG.WriteScpi("SOUR:CORR:STAT 0");
            LHC.SG.WriteScpi("SOUR1:POW:POW 0");
            LHC.SG.QueryScpi("OUTP1:STAT 1");
            LHC.SG.WaitOpc();
            LHC.SG.WriteScpi($"SOUR1:FREQ:CW 450 MHz");//low freq preset
            LHC.PS.ClearOffset();
            LHC.PS.initializeGetPower();
            LHC.PS.SetVisaTimeout(15000);  // 15 sec — 60-sample avg at high freq can exceed default 2500ms
        }

        private void endCal()
        {
            LHC.SG.QueryScpi("OUTP1:STAT 0;*OPC?");
            LHC.SG.WriteScpi("*WAI");
        }

        // Sweeps SG output directly into SA (DUT and switch box bypassed via a direct cable) and records
        // one Loss(dB)=SGPower-SAMeasured point per frequency step. Runs on calThread.
        private void RunSGSASweep()
        {
            int startFreq = 400, endFreq = 7200, step = 100;
            double sgPower = 0;
            Invoke((MethodInvoker)(() =>
            {
                startFreq = (int)numericUpDownStartFreq.Value;
                endFreq = (int)numericUpDownEndFreq.Value;
                step = (int)numericUpDownSGSAStep.Value;
                sgPower = (double)numericUpDownSGSAPower.Value;
                lblSGSAStatus.Text = "Starting sweep...";
            }));

            int totalPoints = (endFreq - startFreq) / step + 1;
            int pointIndex = 0;

            var sweep = new List<(int freq, double loss)>();
            Series liveSeries = null;
            Invoke((MethodInvoker)(() =>
            {
                liveSeries = new Series("● Measuring...")
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    BorderDashStyle = ChartDashStyle.Dash,
                    Color = Color.Yellow,
                };
                chartSGSA.Series.Add(liveSeries);
            }));

            Random rnd = new Random();

            LHC.SG.Reset();
            LHC.SG.WriteScpi("SOUR:CORR:STAT 0");
            LHC.SG.WriteScpi($"SOUR1:POW:POW {sgPower}");
            LHC.SG.WriteScpi("OUTP1:STAT 1");
            LHC.SG.WaitOpc();

            LHC.SA.Reset();
            LHC.SA.WriteScpi("INIT:CONT OFF");
            LHC.SA.WriteScpi("CALC:MARK:STAT ON");
            LHC.SA.WriteScpi("FREQ:SPAN 100 kHz");
            LHC.SA.WriteScpi("BAND:RES 1 kHz");

            for (int freq = startFreq; freq <= endFreq; freq += step)
            {
                pointIndex++;
                int progressIndex = pointIndex;
                Invoke((MethodInvoker)(() => lblSGSAStatus.Text = $"Measuring {freq} MHz\n({progressIndex}/{totalPoints})"));

                LHC.SG.WriteScpi($"SOUR1:FREQ:CW {freq} MHz");
                LHC.SA.WriteScpi($"FREQ:CENT {freq} MHz");
                Thread.Sleep(Settings.Default.delayStep);

                LHC.SA.WriteScpi($"DISP:WIND:TRAC:Y:RLEV {sgPower + 5} dBm");
                LHC.SA.WriteScpi("INIT;*WAI");
                LHC.SA.WriteScpi("CALC:MARK1:MAX");
                string measured = LHC.SA.QueryScpi("CALC:MARK:Y?");

                if (LHC.isDebug && string.IsNullOrEmpty(measured))
                    measured = "0," + (sgPower - (0.5 + rnd.NextDouble() * 2)).ToString("0.00", CultureInfo.InvariantCulture);

                if (string.IsNullOrEmpty(measured))
                {
                    Invoke((MethodInvoker)(() => lblSGSAStatus.Text = $"Measuring {freq} MHz\n({progressIndex}/{totalPoints})\nNo SA response, skipped"));
                    continue; // SA didn't respond for this point, skip rather than plotting a bogus loss
                }

                double loss;
                try
                {
                    double measuredPower = double.Parse(measured.Trim().Split(',').Last().Trim(), CultureInfo.InvariantCulture);
                    loss = sgPower - measuredPower;
                }
                catch
                {
                    Invoke((MethodInvoker)(() => lblSGSAStatus.Text = $"Measuring {freq} MHz\n({progressIndex}/{totalPoints})\nRead error, skipped"));
                    continue;
                }

                sweep.Add((freq, loss));

                double lossCapture = loss;
                Invoke((MethodInvoker)(() =>
                {
                    liveSeries.Points.AddXY(freq, lossCapture);
                    lblSGSAStatus.Text = $"Measuring {freq} MHz\n({progressIndex}/{totalPoints})\nLoss: {lossCapture:0.00} dB";
                }));
            }

            LHC.SG.WriteScpi("OUTP1:STAT 0");

            if (sweep.Count > 0)
            {
                SaveSGSASweep(sweep);
                Invoke((MethodInvoker)(() => lblSGSAStatus.Text = $"Done. {sweep.Count}/{totalPoints} points saved."));
            }
            else
            {
                Invoke((MethodInvoker)(() => lblSGSAStatus.Text = "Sweep finished with no valid points."));
            }
        }

        private void SaveSGSASweep(List<(int freq, double loss)> sweep)
        {
            if (!Directory.Exists(SGSALogFolder))
                Directory.CreateDirectory(SGSALogFolder);

            string fileName = "SGSA_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
            var lines = new List<string> { "Frequency_MHz,Loss_dB" };
            lines.AddRange(sweep.Select(p => $"{p.freq},{p.loss.ToString("0.00", CultureInfo.InvariantCulture)}"));

            File.WriteAllLines(Path.Combine(SGSALogFolder, fileName), lines);
        }

        // Reloads every recorded sweep file as its own overlaid series, so degradation over time is visible at a glance
        private void LoadSGSATrend()
        {
            chartSGSA.Series.Clear();
            lstSGSASweeps.Items.Clear();

            if (!Directory.Exists(SGSALogFolder))
            {
                labelneedsCalibration.Text = "0";
                labelLastCal.Text = "-";
                return;
            }

            List<string> files = Directory.GetFiles(SGSALogFolder, "SGSA_*.csv").OrderBy(f => f).ToList();

            foreach (string file in files)
            {
                // Name must stay unique per file (seconds-resolution) even though LegendText only shows minutes
                Series series = new Series(Path.GetFileNameWithoutExtension(file))
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2,
                    LegendText = ParseTimestampLabel(file),
                };

                foreach (string line in File.ReadLines(file).Skip(1))
                {
                    string[] cols = line.Split(',');
                    if (cols.Length < 2)
                        continue;

                    if (double.TryParse(cols[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double freq)
                        && double.TryParse(cols[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double loss))
                        series.Points.AddXY(freq, loss);
                }

                chartSGSA.Series.Add(series);
                lstSGSASweeps.Items.Add(ParseTimestampLabel(file), true); // list index tracks 1:1 with chartSGSA.Series index
            }

            labelneedsCalibration.Text = files.Count.ToString();
            labelLastCal.Text = files.Count > 0 ? ParseTimestampLabel(files.Last()) : "-";
        }

        // Checking/unchecking a row shows/hides that sweep's line on the chart - more reliable than
        // hit-testing tiny legend glyphs, and doubles as a list of what's currently plotted.
        private void lstSGSASweeps_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index < 0 || e.Index >= chartSGSA.Series.Count)
                return;

            chartSGSA.Series[e.Index].Enabled = e.NewValue == CheckState.Checked;
            chartSGSA.Invalidate();
        }

        // Select a row (click its text, not the checkbox) then hit this to permanently delete that one sweep file
        private void btnDeleteSGSASweep_Click(object sender, EventArgs e)
        {
            int index = lstSGSASweeps.SelectedIndex;
            if (index < 0 || index >= chartSGSA.Series.Count)
            {
                MessageBox.Show("Select a sweep in the list first.", "No sweep selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Series series = chartSGSA.Series[index];
            DialogResult confirm = MessageBox.Show($"Delete this recorded sweep ({series.LegendText})?\nThis cannot be undone.", "Delete sweep", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            string filePath = Path.Combine(SGSALogFolder, series.Name + ".csv");
            if (File.Exists(filePath))
                File.Delete(filePath);

            LoadSGSATrend();
        }

        private string ParseTimestampLabel(string filePath)
        {
            string stamp = Path.GetFileNameWithoutExtension(filePath).Replace("SGSA_", "");
            if (DateTime.TryParseExact(stamp, "yyyyMMdd_HHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                return dt.ToString("yyyy-MM-dd HH:mm");
            return stamp;
        }

        private void btnClearSGSAHistory_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(SGSALogFolder))
                return;

            string[] files = Directory.GetFiles(SGSALogFolder, "SGSA_*.csv");
            if (files.Length == 0)
                return;

            DialogResult confirm = MessageBox.Show($"Delete all {files.Length} recorded SG↔SA sweeps?\nThis cannot be undone.", "Clear history", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            foreach (string file in files)
                File.Delete(file);

            LoadSGSATrend();
        }

        // NumericUpDown doesn't select-all on a mouse click (only on Tab), so typing without first
        // selecting the old text can concatenate into an invalid number that silently reverts on leave.
        private void numericUpDown_Enter(object sender, EventArgs e)
        {
            if (sender is NumericUpDown nud)
                nud.BeginInvoke((MethodInvoker)(() => nud.Select(0, nud.Text.Length)));
        }

        private void CalibrationForm_Leave(object sender, EventArgs e)
        {
            if (calThread != null && calThread.IsAlive)
                stopCalibrating();


            if (diagramPopupForm != null && diagramPopupForm.Created)
                diagramPopupForm.Close();
        }

        private void CalibrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (calThread != null && calThread.IsAlive)
                stopCalibrating();
        }

        private void backBtnForm_Click(object sender, EventArgs e)
        {
            if(!isCalibrating)
                this.Close();
        }

        private void tableLayoutPanelCalMain_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 1)
                e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#323232")), e.CellBounds);
        }

        private void btnConnectionDiagram_Click(object sender, EventArgs e)
        {
            if (diagramPopupForm == null || !diagramPopupForm.Created)
                diagramPopupForm = new DiagramPopupForm();

            if (isSADUT)
                diagramPopupForm.Text = "DUT to SA";
            else
                diagramPopupForm.Text = "SG to DUT";
            diagramPopupForm.BackgroundImage = btnConnectionDiagram.BackgroundImage;
            diagramPopupForm.Show();
            diagramPopupForm.BringToFront();
        }

        private void CalibrationForm_Resize(object sender, EventArgs e)
        {
            int picHeight = tableLayoutPanelSideBar.Width * 9 / 16;
            int marginTopBot = (tableLayoutPanelSideBar.GetRowHeights()[tableLayoutPanelSideBar.GetCellPosition(btnConnectionDiagramPanel).Row] - picHeight) / 2 - 4;
            btnConnectionDiagramPanel.Padding = new Padding(2, marginTopBot, 2, marginTopBot);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (numericUpDownStartFreq.Value > numericUpDownEndFreq.Value)
            {
                MessageBox.Show("Start frequency cannot be lower than end frequncy", "Alert");
                return;
            }

            if (isSGDUT)
            {
                rerangeTable(dtSGDUT);
                LHC.ConfigCAL.CSVSave(dtSGDUT, "SGDUT");
                initializeDTSGDUT();
                SelectSGDUTTab();
            }
            else
            {
                rerangeTable(dtSADUT);
                LHC.ConfigCAL.CSVSave(dtSADUT, "SADUT");
                initializeDTSADUT();
                SelectSADUTTab();
            }
        }

        private void rerangeTable(DataTable dt)
        {
            List<int> list = Enumerable.Range(0, (Int32)(numericUpDownEndFreq.Value - numericUpDownStartFreq.Value) / 100 + 1).Select(i => (Int32)numericUpDownStartFreq.Value + i * 100).ToList();

            foreach (DataRow row in dt.AsEnumerable().ToList())
            {
                int value = int.Parse(row[0].ToString());
                if (!list.Contains(value))
                    dt.Rows.Remove(row);
                else
                    list.Remove(value);
            }

            foreach (int i in list)
                dt.Rows.Add(new object[] { i.ToString() });
        }

        private void cbIQxstream_CheckedChanged(object sender, EventArgs e)
        {
            for(int i = 1; i <= 8; i++)
            {
                if (cbIQxstream.Checked)
                {
                    dtSGDUT.Columns[i].ColumnName = dtSGDUT.Columns[i].ColumnName.Replace("B\n", " B2\n").Replace("A\n", " B1\n");
                    dtSADUT.Columns[i].ColumnName = dtSADUT.Columns[i].ColumnName.Replace("B\n", " B2\n").Replace("A\n", " B1\n");
                }
                else
                {
                    dtSGDUT.Columns[i].ColumnName = dtSGDUT.Columns[i].ColumnName.Replace(" B2\n", "B\n").Replace(" B1\n", "A\n");
                    dtSADUT.Columns[i].ColumnName = dtSADUT.Columns[i].ColumnName.Replace(" B2\n", "B\n").Replace(" B1\n", "A\n");
                }
            }

            if (isSGDUT) SelectSGDUTTab();
            else if (isSADUT) SelectSADUTTab();
        }
    }
}
