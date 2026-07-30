using System;
using System.Windows.Forms;

namespace Pegatron
{
    public partial class FrequencySweepPopupForm : Form
    {
        public int StartFreq { get; private set; }
        public int StopFreq { get; private set; }
        public int StepFreq { get; private set; }

        public FrequencySweepPopupForm(string bandLabel)
        {
            InitializeComponent();
            lblMsg.Text = "Enter " + bandLabel + " Frequency Accuracy sweep (MHz).\nLeave blank to keep the template's default frequency points.";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStart.Text) && string.IsNullOrWhiteSpace(txtStop.Text) && string.IsNullOrWhiteSpace(txtStep.Text))
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            if (!int.TryParse(txtStart.Text, out int start) ||
                !int.TryParse(txtStop.Text, out int stop) ||
                !int.TryParse(txtStep.Text, out int step) ||
                step <= 0 || start > stop)
            {
                MessageBox.Show("Please enter valid Start <= Stop and Step > 0 (MHz), or leave all three blank.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StartFreq = start;
            StopFreq = stop;
            StepFreq = step;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
