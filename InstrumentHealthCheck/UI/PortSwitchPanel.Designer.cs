namespace InstrumentHealthCheck.UI
{
    partial class PortSwitchPanel
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
            this.grpSwitch = new System.Windows.Forms.GroupBox();
            this.lblSwitchStatus = new System.Windows.Forms.Label();
            this.btnConnectSwitch = new System.Windows.Forms.Button();
            this.txtSwitchIp = new System.Windows.Forms.TextBox();
            this.lblIp = new System.Windows.Forms.Label();
            this.cboSwitchVendor = new System.Windows.Forms.ComboBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.chkUseSwitch = new System.Windows.Forms.CheckBox();
            this.grpPorts = new System.Windows.Forms.GroupBox();
            this.btnRemovePort = new System.Windows.Forms.Button();
            this.btnAddPort = new System.Windows.Forms.Button();
            this.dgvPorts = new System.Windows.Forms.DataGridView();
            this.grpSwitch.SuspendLayout();
            this.grpPorts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorts)).BeginInit();
            this.SuspendLayout();
            //
            // grpSwitch
            //
            this.grpSwitch.Controls.Add(this.lblSwitchStatus);
            this.grpSwitch.Controls.Add(this.btnConnectSwitch);
            this.grpSwitch.Controls.Add(this.txtSwitchIp);
            this.grpSwitch.Controls.Add(this.lblIp);
            this.grpSwitch.Controls.Add(this.cboSwitchVendor);
            this.grpSwitch.Controls.Add(this.lblVendor);
            this.grpSwitch.Controls.Add(this.chkUseSwitch);
            this.grpSwitch.Location = new System.Drawing.Point(12, 12);
            this.grpSwitch.Name = "grpSwitch";
            this.grpSwitch.Size = new System.Drawing.Size(680, 90);
            this.grpSwitch.TabIndex = 0;
            this.grpSwitch.TabStop = false;
            this.grpSwitch.Text = "Switch 設定";
            //
            // lblSwitchStatus
            //
            this.lblSwitchStatus.AutoSize = true;
            this.lblSwitchStatus.Location = new System.Drawing.Point(490, 55);
            this.lblSwitchStatus.Name = "lblSwitchStatus";
            this.lblSwitchStatus.Size = new System.Drawing.Size(60, 15);
            this.lblSwitchStatus.TabIndex = 6;
            this.lblSwitchStatus.Text = "-";
            //
            // btnConnectSwitch
            //
            this.btnConnectSwitch.Location = new System.Drawing.Point(390, 49);
            this.btnConnectSwitch.Name = "btnConnectSwitch";
            this.btnConnectSwitch.Size = new System.Drawing.Size(90, 27);
            this.btnConnectSwitch.TabIndex = 5;
            this.btnConnectSwitch.Text = "連線測試";
            this.btnConnectSwitch.UseVisualStyleBackColor = true;
            this.btnConnectSwitch.Click += new System.EventHandler(this.btnConnectSwitch_Click);
            //
            // txtSwitchIp
            //
            this.txtSwitchIp.Location = new System.Drawing.Point(240, 51);
            this.txtSwitchIp.Name = "txtSwitchIp";
            this.txtSwitchIp.Size = new System.Drawing.Size(140, 23);
            this.txtSwitchIp.TabIndex = 4;
            //
            // lblIp
            //
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(210, 55);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(22, 15);
            this.lblIp.TabIndex = 3;
            this.lblIp.Text = "IP:";
            //
            // cboSwitchVendor
            //
            this.cboSwitchVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSwitchVendor.Items.AddRange(new object[] {
            "Woken (2-port)",
            "Rapidtek (SP6T)"});
            this.cboSwitchVendor.Location = new System.Drawing.Point(70, 50);
            this.cboSwitchVendor.Name = "cboSwitchVendor";
            this.cboSwitchVendor.Size = new System.Drawing.Size(130, 23);
            this.cboSwitchVendor.TabIndex = 2;
            //
            // lblVendor
            //
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(16, 54);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(38, 15);
            this.lblVendor.TabIndex = 1;
            this.lblVendor.Text = "廠牌:";
            //
            // chkUseSwitch
            //
            this.chkUseSwitch.AutoSize = true;
            this.chkUseSwitch.Location = new System.Drawing.Point(16, 22);
            this.chkUseSwitch.Name = "chkUseSwitch";
            this.chkUseSwitch.Size = new System.Drawing.Size(300, 19);
            this.chkUseSwitch.TabIndex = 0;
            this.chkUseSwitch.Text = "使用 Switch Box（取消勾選 = 直接接線 / 無 Switch）";
            this.chkUseSwitch.UseVisualStyleBackColor = true;
            this.chkUseSwitch.CheckedChanged += new System.EventHandler(this.chkUseSwitch_CheckedChanged);
            //
            // grpPorts
            //
            this.grpPorts.Controls.Add(this.btnRemovePort);
            this.grpPorts.Controls.Add(this.btnAddPort);
            this.grpPorts.Controls.Add(this.dgvPorts);
            this.grpPorts.Location = new System.Drawing.Point(12, 112);
            this.grpPorts.Name = "grpPorts";
            this.grpPorts.Size = new System.Drawing.Size(680, 280);
            this.grpPorts.TabIndex = 1;
            this.grpPorts.TabStop = false;
            this.grpPorts.Text = "Port 清單";
            //
            // btnRemovePort
            //
            this.btnRemovePort.Location = new System.Drawing.Point(100, 240);
            this.btnRemovePort.Name = "btnRemovePort";
            this.btnRemovePort.Size = new System.Drawing.Size(90, 28);
            this.btnRemovePort.TabIndex = 2;
            this.btnRemovePort.Text = "刪除選取";
            this.btnRemovePort.UseVisualStyleBackColor = true;
            this.btnRemovePort.Click += new System.EventHandler(this.btnRemovePort_Click);
            //
            // btnAddPort
            //
            this.btnAddPort.Location = new System.Drawing.Point(12, 240);
            this.btnAddPort.Name = "btnAddPort";
            this.btnAddPort.Size = new System.Drawing.Size(80, 28);
            this.btnAddPort.TabIndex = 1;
            this.btnAddPort.Text = "新增 Port";
            this.btnAddPort.UseVisualStyleBackColor = true;
            this.btnAddPort.Click += new System.EventHandler(this.btnAddPort_Click);
            //
            // dgvPorts
            //
            this.dgvPorts.AllowUserToAddRows = false;
            this.dgvPorts.AllowUserToDeleteRows = false;
            this.dgvPorts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPorts.Location = new System.Drawing.Point(12, 22);
            this.dgvPorts.Name = "dgvPorts";
            this.dgvPorts.RowHeadersWidth = 30;
            this.dgvPorts.Size = new System.Drawing.Size(656, 210);
            this.dgvPorts.TabIndex = 0;
            //
            // PortSwitchPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpPorts);
            this.Controls.Add(this.grpSwitch);
            this.Name = "PortSwitchPanel";
            this.Size = new System.Drawing.Size(710, 410);
            this.grpSwitch.ResumeLayout(false);
            this.grpSwitch.PerformLayout();
            this.grpPorts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorts)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpSwitch;
        private System.Windows.Forms.Label lblSwitchStatus;
        private System.Windows.Forms.Button btnConnectSwitch;
        private System.Windows.Forms.TextBox txtSwitchIp;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.ComboBox cboSwitchVendor;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.CheckBox chkUseSwitch;
        private System.Windows.Forms.GroupBox grpPorts;
        private System.Windows.Forms.Button btnRemovePort;
        private System.Windows.Forms.Button btnAddPort;
        private System.Windows.Forms.DataGridView dgvPorts;
    }
}
