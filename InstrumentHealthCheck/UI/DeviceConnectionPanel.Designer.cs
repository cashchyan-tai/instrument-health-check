namespace InstrumentHealthCheck.UI
{
    partial class DeviceConnectionPanel
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.grpDut = new System.Windows.Forms.GroupBox();
            this.lblDutStatus = new System.Windows.Forms.Label();
            this.btnConnectDut = new System.Windows.Forms.Button();
            this.txtDutIp = new System.Windows.Forms.TextBox();
            this.lblDutIp = new System.Windows.Forms.Label();
            this.cboDutRole = new System.Windows.Forms.ComboBox();
            this.lblDutRole = new System.Windows.Forms.Label();
            this.grpRef = new System.Windows.Forms.GroupBox();
            this.lblRefStatus = new System.Windows.Forms.Label();
            this.btnConnectRef = new System.Windows.Forms.Button();
            this.txtRefIp = new System.Windows.Forms.TextBox();
            this.lblRefIp = new System.Windows.Forms.Label();
            this.grpDut.SuspendLayout();
            this.grpRef.SuspendLayout();
            this.SuspendLayout();
            //
            // grpDut
            //
            this.grpDut.Controls.Add(this.lblDutStatus);
            this.grpDut.Controls.Add(this.btnConnectDut);
            this.grpDut.Controls.Add(this.txtDutIp);
            this.grpDut.Controls.Add(this.lblDutIp);
            this.grpDut.Controls.Add(this.cboDutRole);
            this.grpDut.Controls.Add(this.lblDutRole);
            this.grpDut.Location = new System.Drawing.Point(12, 12);
            this.grpDut.Name = "grpDut";
            this.grpDut.Size = new System.Drawing.Size(680, 110);
            this.grpDut.TabIndex = 0;
            this.grpDut.TabStop = false;
            this.grpDut.Text = "待測物 (DUT)";
            //
            // lblDutStatus
            //
            this.lblDutStatus.AutoSize = true;
            this.lblDutStatus.Location = new System.Drawing.Point(16, 65);
            this.lblDutStatus.Name = "lblDutStatus";
            this.lblDutStatus.Size = new System.Drawing.Size(46, 15);
            this.lblDutStatus.TabIndex = 5;
            this.lblDutStatus.Text = "未連線";
            //
            // btnConnectDut
            //
            this.btnConnectDut.Location = new System.Drawing.Point(545, 21);
            this.btnConnectDut.Name = "btnConnectDut";
            this.btnConnectDut.Size = new System.Drawing.Size(90, 27);
            this.btnConnectDut.TabIndex = 4;
            this.btnConnectDut.Text = "連線";
            this.btnConnectDut.UseVisualStyleBackColor = true;
            this.btnConnectDut.Click += new System.EventHandler(this.btnConnectDut_Click);
            //
            // txtDutIp
            //
            this.txtDutIp.Location = new System.Drawing.Point(395, 22);
            this.txtDutIp.Name = "txtDutIp";
            this.txtDutIp.Size = new System.Drawing.Size(140, 23);
            this.txtDutIp.TabIndex = 3;
            //
            // lblDutIp
            //
            this.lblDutIp.AutoSize = true;
            this.lblDutIp.Location = new System.Drawing.Point(365, 26);
            this.lblDutIp.Name = "lblDutIp";
            this.lblDutIp.Size = new System.Drawing.Size(22, 15);
            this.lblDutIp.TabIndex = 2;
            this.lblDutIp.Text = "IP:";
            //
            // cboDutRole
            //
            this.cboDutRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDutRole.Items.AddRange(new object[] {
            "R&S 頻譜分析儀 (SA-like，接收)",
            "R&S 訊號產生器 (SG-like，發射)"});
            this.cboDutRole.Location = new System.Drawing.Point(90, 22);
            this.cboDutRole.Name = "cboDutRole";
            this.cboDutRole.Size = new System.Drawing.Size(260, 23);
            this.cboDutRole.TabIndex = 1;
            this.cboDutRole.SelectedIndexChanged += new System.EventHandler(this.cboDutRole_SelectedIndexChanged);
            //
            // lblDutRole
            //
            this.lblDutRole.AutoSize = true;
            this.lblDutRole.Location = new System.Drawing.Point(16, 26);
            this.lblDutRole.Name = "lblDutRole";
            this.lblDutRole.Size = new System.Drawing.Size(64, 15);
            this.lblDutRole.TabIndex = 0;
            this.lblDutRole.Text = "DUT 類型:";
            //
            // grpRef
            //
            this.grpRef.Controls.Add(this.lblRefStatus);
            this.grpRef.Controls.Add(this.btnConnectRef);
            this.grpRef.Controls.Add(this.txtRefIp);
            this.grpRef.Controls.Add(this.lblRefIp);
            this.grpRef.Location = new System.Drawing.Point(12, 132);
            this.grpRef.Name = "grpRef";
            this.grpRef.Size = new System.Drawing.Size(680, 110);
            this.grpRef.TabIndex = 1;
            this.grpRef.TabStop = false;
            this.grpRef.Text = "對打參考儀器";
            //
            // lblRefStatus
            //
            this.lblRefStatus.AutoSize = true;
            this.lblRefStatus.Location = new System.Drawing.Point(16, 65);
            this.lblRefStatus.Name = "lblRefStatus";
            this.lblRefStatus.Size = new System.Drawing.Size(46, 15);
            this.lblRefStatus.TabIndex = 3;
            this.lblRefStatus.Text = "未連線";
            //
            // btnConnectRef
            //
            this.btnConnectRef.Location = new System.Drawing.Point(200, 21);
            this.btnConnectRef.Name = "btnConnectRef";
            this.btnConnectRef.Size = new System.Drawing.Size(90, 27);
            this.btnConnectRef.TabIndex = 2;
            this.btnConnectRef.Text = "連線";
            this.btnConnectRef.UseVisualStyleBackColor = true;
            this.btnConnectRef.Click += new System.EventHandler(this.btnConnectRef_Click);
            //
            // txtRefIp
            //
            this.txtRefIp.Location = new System.Drawing.Point(46, 22);
            this.txtRefIp.Name = "txtRefIp";
            this.txtRefIp.Size = new System.Drawing.Size(140, 23);
            this.txtRefIp.TabIndex = 1;
            //
            // lblRefIp
            //
            this.lblRefIp.AutoSize = true;
            this.lblRefIp.Location = new System.Drawing.Point(16, 26);
            this.lblRefIp.Name = "lblRefIp";
            this.lblRefIp.Size = new System.Drawing.Size(22, 15);
            this.lblRefIp.TabIndex = 0;
            this.lblRefIp.Text = "IP:";
            //
            // DeviceConnectionPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpRef);
            this.Controls.Add(this.grpDut);
            this.Name = "DeviceConnectionPanel";
            this.Size = new System.Drawing.Size(710, 260);
            this.grpDut.ResumeLayout(false);
            this.grpDut.PerformLayout();
            this.grpRef.ResumeLayout(false);
            this.grpRef.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpDut;
        private System.Windows.Forms.Label lblDutStatus;
        private System.Windows.Forms.Button btnConnectDut;
        private System.Windows.Forms.TextBox txtDutIp;
        private System.Windows.Forms.Label lblDutIp;
        private System.Windows.Forms.ComboBox cboDutRole;
        private System.Windows.Forms.Label lblDutRole;
        private System.Windows.Forms.GroupBox grpRef;
        private System.Windows.Forms.Label lblRefStatus;
        private System.Windows.Forms.Button btnConnectRef;
        private System.Windows.Forms.TextBox txtRefIp;
        private System.Windows.Forms.Label lblRefIp;
    }
}
