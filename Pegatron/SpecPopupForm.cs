using System;
using System.Windows.Forms;

namespace Pegatron
{
    public partial class SpecPopupForm : Form
    {
        public string selectedSpec = "Specifications";

        public SpecPopupForm()
        {
            InitializeComponent();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            selectedSpec = "Specifications";
            this.Close();
        }

        private void btnIQxstream_Click(object sender, EventArgs e)
        {
            selectedSpec = "Specifications_IQxstream_M";
            this.Close();
        }

        private void btnRSFSW_Click(object sender, EventArgs e)
        {
            selectedSpec = "Specifications_RS_FSW";
            this.Close();
        }

        private void btnRSGenerator_Click(object sender, EventArgs e)
        {
            selectedSpec = "Specifications_RS_Generator";
            this.Close();
        }

        private void btnIQxelM8W_Click(object sender, EventArgs e)
        {
            selectedSpec = "Specifications_IQXEL_M8W";
            this.Close();
        }

        private void btnOtherInstrument_Click(object sender, EventArgs e)
        {
            selectedSpec = "Specifications_Keysight_N9020A";
            this.Close();
        }

        private void btnE4438C_Click(object sender, EventArgs e)
        {
            selectedSpec = "Specifications_Keysight_E4438C";
            this.Close();
        }

        private void btnIQgigUWB_Click(object sender, EventArgs e)
        {
            selectedSpec = "Specifications_IQgig_UWB";
            this.Close();
        }
    }
}
