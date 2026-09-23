using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace InstrumentHealthCheck
{
    public partial class MainForm : Form
    {
        // True only when this process was launched by LitePointHealthCheck's switch button;
        // a standalone run (e.g. during development) shouldn't relaunch it on close.
        private readonly bool _launchedFromLp;

        public MainForm() : this(false)
        {
        }

        public MainForm(bool launchedFromLp)
        {
            InitializeComponent();
            _launchedFromLp = launchedFromLp;
            testPanel1.Initialize(portSwitchPanel1, deviceConnectionPanel1, calibrationPanel1);
            FormClosing += MainForm_FormClosing;
        }

        private void tabMain_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Port list can change on the Port/Switch tab at any time; refresh whichever
            // tab depends on it so it never shows a stale port set.
            if (tabMain.SelectedTab == tabCalibration)
                calibrationPanel1.SyncPorts(portSwitchPanel1.GetSettings().Ports);
            else if (tabMain.SelectedTab == tabTest)
                testPanel1.SyncPorts(portSwitchPanel1.GetSettings().Ports);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            deviceConnectionPanel1.DisconnectAll();
            portSwitchPanel1.DisconnectAll();

            if (!_launchedFromLp)
                return;

            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LitePointHealthCheck.exe");
            if (File.Exists(exePath))
            {
                Process.Start(exePath);
            }
            else
            {
                MessageBox.Show(
                    "找不到 LitePointHealthCheck.exe，請確認兩個程式的執行檔已放在同一個資料夾。\n" + exePath,
                    "找不到程式", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
