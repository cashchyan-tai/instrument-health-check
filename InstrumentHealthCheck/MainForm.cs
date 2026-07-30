using System.Windows.Forms;

namespace InstrumentHealthCheck
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tabMain_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Port list can change on the Port/Switch tab at any time; refresh the
            // calibration grid's columns whenever the operator switches to it so it
            // never shows a stale port set.
            if (tabMain.SelectedTab == tabCalibration)
                calibrationPanel1.SyncPorts(portSwitchPanel1.GetSettings().Ports);
        }
    }
}
