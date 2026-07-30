namespace InstrumentHealthCheck
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabDevices = new System.Windows.Forms.TabPage();
            this.deviceConnectionPanel1 = new InstrumentHealthCheck.UI.DeviceConnectionPanel();
            this.tabPortSwitch = new System.Windows.Forms.TabPage();
            this.portSwitchPanel1 = new InstrumentHealthCheck.UI.PortSwitchPanel();
            this.tabMain.SuspendLayout();
            this.tabDevices.SuspendLayout();
            this.tabPortSwitch.SuspendLayout();
            this.SuspendLayout();
            //
            // tabMain
            //
            this.tabMain.Controls.Add(this.tabDevices);
            this.tabMain.Controls.Add(this.tabPortSwitch);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(760, 540);
            this.tabMain.TabIndex = 0;
            //
            // tabDevices
            //
            this.tabDevices.Controls.Add(this.deviceConnectionPanel1);
            this.tabDevices.Location = new System.Drawing.Point(4, 24);
            this.tabDevices.Name = "tabDevices";
            this.tabDevices.Padding = new System.Windows.Forms.Padding(3);
            this.tabDevices.Size = new System.Drawing.Size(752, 512);
            this.tabDevices.TabIndex = 1;
            this.tabDevices.Text = "設備連線";
            this.tabDevices.UseVisualStyleBackColor = true;
            //
            // deviceConnectionPanel1
            //
            this.deviceConnectionPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceConnectionPanel1.Location = new System.Drawing.Point(3, 3);
            this.deviceConnectionPanel1.Name = "deviceConnectionPanel1";
            this.deviceConnectionPanel1.Size = new System.Drawing.Size(746, 506);
            this.deviceConnectionPanel1.TabIndex = 0;
            //
            // tabPortSwitch
            //
            this.tabPortSwitch.Controls.Add(this.portSwitchPanel1);
            this.tabPortSwitch.Location = new System.Drawing.Point(4, 24);
            this.tabPortSwitch.Name = "tabPortSwitch";
            this.tabPortSwitch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPortSwitch.Size = new System.Drawing.Size(752, 512);
            this.tabPortSwitch.TabIndex = 0;
            this.tabPortSwitch.Text = "Port / Switch 設定";
            this.tabPortSwitch.UseVisualStyleBackColor = true;
            //
            // portSwitchPanel1
            //
            this.portSwitchPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portSwitchPanel1.Location = new System.Drawing.Point(3, 3);
            this.portSwitchPanel1.Name = "portSwitchPanel1";
            this.portSwitchPanel1.Size = new System.Drawing.Size(746, 506);
            this.portSwitchPanel1.TabIndex = 0;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 540);
            this.Controls.Add(this.tabMain);
            this.MinimumSize = new System.Drawing.Size(650, 450);
            this.Name = "MainForm";
            this.Text = "Instrument Health Check";
            this.tabMain.ResumeLayout(false);
            this.tabDevices.ResumeLayout(false);
            this.tabPortSwitch.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabDevices;
        private InstrumentHealthCheck.UI.DeviceConnectionPanel deviceConnectionPanel1;
        private System.Windows.Forms.TabPage tabPortSwitch;
        private InstrumentHealthCheck.UI.PortSwitchPanel portSwitchPanel1;
    }
}
