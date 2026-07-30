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
    }
}
