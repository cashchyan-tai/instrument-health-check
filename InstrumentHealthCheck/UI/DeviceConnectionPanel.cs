using System.Drawing;
using System.Windows.Forms;
using InstrumentHealthCheck.Config;
// IDUTInstrument/RSAnalyzerDUT/RSGeneratorDUT/SignalGenerator/SpectrumAnalyzer live in
// InstrumentCore.dll but keep their original "Pegatron" namespace so the existing
// Pegatron app didn't need any code changes when they were extracted into the library.
using Pegatron;

namespace InstrumentHealthCheck.UI
{
    public partial class DeviceConnectionPanel : UserControl
    {
        private IDUTInstrument _dut;
        private SignalGenerator _refSg;
        private SpectrumAnalyzer _refSa;

        public DeviceConnectionPanel()
        {
            InitializeComponent();
            cboDutRole.SelectedIndex = 0;
        }

        // Null until the corresponding Connect button has succeeded; a later test-execution
        // step should treat a null reference here as "not ready to test".
        public IDUTInstrument Dut => _dut;
        public SignalGenerator ReferenceSignalGenerator => _refSg;
        public SpectrumAnalyzer ReferenceSpectrumAnalyzer => _refSa;
        public DutRoleType CurrentRole => cboDutRole.SelectedIndex == 1 ? DutRoleType.SignalGenerator : DutRoleType.SignalAnalyzer;

        private void cboDutRole_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Switching role changes which concrete classes DUT/reference actually are,
            // so anything already connected under the old role is no longer valid.
            _dut = null;
            _refSg = null;
            _refSa = null;

            lblDutStatus.Text = "未連線";
            lblDutStatus.ForeColor = Color.Gray;
            lblRefStatus.Text = "未連線";
            lblRefStatus.ForeColor = Color.Gray;

            grpRef.Text = CurrentRole == DutRoleType.SignalAnalyzer
                ? "對打參考儀器：Signal Generator"
                : "對打參考儀器：Spectrum Analyzer";
        }

        private void btnConnectDut_Click(object sender, System.EventArgs e)
        {
            string ip = txtDutIp.Text.Trim();
            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("請輸入 DUT 的 IP 位址。", "缺少 IP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IDUTInstrument dut = CurrentRole == DutRoleType.SignalAnalyzer
                ? (IDUTInstrument)new RSAnalyzerDUT()
                : new RSGeneratorDUT();

            lblDutStatus.Text = "連線中...";
            lblDutStatus.ForeColor = Color.Gray;
            btnConnectDut.Enabled = false;

            bool lanOk = dut.ConnectLan(ip);
            bool idnOk = lanOk && dut.GetIDN();

            if (idnOk)
            {
                _dut = dut;
                lblDutStatus.Text = string.Format("已連線：{0} {1} (SN {2})", dut.Vendor, dut.Model, dut.SN);
                lblDutStatus.ForeColor = Color.DarkGreen;
            }
            else
            {
                _dut = null;
                lblDutStatus.Text = !lanOk
                    ? "連線失敗（TCP/VISA 無法建立連線 - 請確認 IP、儀器電源、網路，以及儀器的 LAN/VXI-11 遠端介面是否已開啟）"
                    : "已建立連線，但讀取 *IDN? 失敗（請確認儀器 SCPI 遠端控制已啟用）";
                lblDutStatus.ForeColor = Color.Red;
            }

            btnConnectDut.Enabled = true;
        }

        private void btnConnectRef_Click(object sender, System.EventArgs e)
        {
            string ip = txtRefIp.Text.Trim();
            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("請輸入對打參考儀器的 IP 位址。", "缺少 IP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblRefStatus.Text = "連線中...";
            lblRefStatus.ForeColor = Color.Gray;
            btnConnectRef.Enabled = false;

            bool lanOk, idnOk;
            string vendor = null, model = null, sn = null;

            if (CurrentRole == DutRoleType.SignalAnalyzer)
            {
                var sg = new SignalGenerator();
                lanOk = sg.ConnectLan(ip);
                idnOk = lanOk && sg.GetIDN();
                if (idnOk) { _refSg = sg; vendor = sg.Vendor; model = sg.Model; sn = sg.SN; }
                else { _refSg = null; }
            }
            else
            {
                var sa = new SpectrumAnalyzer();
                lanOk = sa.ConnectLan(ip);
                idnOk = lanOk && sa.GetIDN();
                if (idnOk) { _refSa = sa; vendor = sa.Vendor; model = sa.Model; sn = sa.SN; }
                else { _refSa = null; }
            }

            if (idnOk)
            {
                lblRefStatus.Text = string.Format("已連線：{0} {1} (SN {2})", vendor, model, sn);
                lblRefStatus.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblRefStatus.Text = !lanOk
                    ? "連線失敗（TCP/VISA 無法建立連線 - 請確認 IP、儀器電源、網路，以及儀器的 LAN/VXI-11 遠端介面是否已開啟）"
                    : "已建立連線，但讀取 *IDN? 失敗（請確認儀器 SCPI 遠端控制已啟用）";
                lblRefStatus.ForeColor = Color.Red;
            }

            btnConnectRef.Enabled = true;
        }
    }
}
