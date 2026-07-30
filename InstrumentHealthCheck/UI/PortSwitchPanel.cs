using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using InstrumentHealthCheck.Config;
// Switch/SwitchRapidtek/ISwitchBox live in InstrumentCore.dll but keep their original
// "Pegatron" namespace so the existing Pegatron app didn't need any code changes when
// they were extracted into the shared library.
using Pegatron;

namespace InstrumentHealthCheck.UI
{
    public partial class PortSwitchPanel : UserControl
    {
        private readonly BindingList<PortDefinition> _ports = new BindingList<PortDefinition>();
        private ISwitchBox _switchBox;

        public PortSwitchPanel()
        {
            InitializeComponent();
            SetupGrid();
        }

        public PortSwitchSettings GetSettings()
        {
            return new PortSwitchSettings
            {
                UseSwitch = chkUseSwitch.Checked,
                SwitchVendor = cboSwitchVendor.SelectedIndex == 1 ? SwitchVendorType.Rapidtek : SwitchVendorType.Woken,
                SwitchIp = txtSwitchIp.Text.Trim(),
                Ports = new List<PortDefinition>(_ports)
            };
        }

        public void LoadSettings(PortSwitchSettings settings)
        {
            chkUseSwitch.Checked = settings.UseSwitch;
            cboSwitchVendor.SelectedIndex = settings.SwitchVendor == SwitchVendorType.Rapidtek ? 1 : 0;
            txtSwitchIp.Text = settings.SwitchIp;

            _ports.Clear();
            foreach (PortDefinition p in settings.Ports)
                _ports.Add(p);

            UpdateSwitchModeUi();
        }

        private void SetupGrid()
        {
            dgvPorts.AutoGenerateColumns = false;
            dgvPorts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Port 名稱",
                DataPropertyName = "Name",
                Width = 220
            });
            dgvPorts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPhysicalPort",
                HeaderText = "實體 Switch Port 編號",
                DataPropertyName = "PhysicalPortNumber",
                Width = 170
            });

            cboSwitchVendor.SelectedIndex = 0;
            dgvPorts.DataSource = _ports;

            UpdateSwitchModeUi();
        }

        private void chkUseSwitch_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdateSwitchModeUi();
        }

        private void UpdateSwitchModeUi()
        {
            bool useSwitch = chkUseSwitch.Checked;
            cboSwitchVendor.Enabled = useSwitch;
            txtSwitchIp.Enabled = useSwitch;
            btnConnectSwitch.Enabled = useSwitch;
            dgvPorts.Columns["colPhysicalPort"].Visible = useSwitch;

            lblSwitchStatus.Text = useSwitch ? "尚未連線" : "無 Switch（直接接線）";
            lblSwitchStatus.ForeColor = useSwitch ? Color.Gray : Color.DarkGreen;
        }

        private void btnAddPort_Click(object sender, System.EventArgs e)
        {
            int nextPortNum = 1;
            foreach (PortDefinition p in _ports)
                if (p.PhysicalPortNumber >= nextPortNum)
                    nextPortNum = p.PhysicalPortNumber + 1;

            _ports.Add(new PortDefinition("Port" + (_ports.Count + 1), nextPortNum));
        }

        private void btnRemovePort_Click(object sender, System.EventArgs e)
        {
            if (_ports.Count <= 1)
            {
                MessageBox.Show("至少要保留一個 Port。", "無法刪除", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvPorts.CurrentRow == null) return;

            int index = dgvPorts.CurrentRow.Index;
            if (index >= 0 && index < _ports.Count)
                _ports.RemoveAt(index);
        }

        private void btnConnectSwitch_Click(object sender, System.EventArgs e)
        {
            string ip = txtSwitchIp.Text.Trim();
            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("請輸入 Switch 的 IP 位址。", "缺少 IP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _switchBox = cboSwitchVendor.SelectedIndex == 1
                ? (ISwitchBox)new SwitchRapidtek()
                : new Switch();

            lblSwitchStatus.Text = "連線中...";
            lblSwitchStatus.ForeColor = Color.Gray;
            btnConnectSwitch.Enabled = false;

            bool connected = _switchBox.Connect(ip);

            lblSwitchStatus.Text = connected
                ? string.Format("已連線 ({0} {1})", _switchBox.Vendor, _switchBox.Model)
                : "連線失敗";
            lblSwitchStatus.ForeColor = connected ? Color.DarkGreen : Color.Red;
            btnConnectSwitch.Enabled = true;
        }
    }
}
