using System.Windows.Forms;

namespace InstrumentHealthCheck
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            testPanel1.Initialize(portSwitchPanel1, deviceConnectionPanel1, calibrationPanel1);
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
    }
}
