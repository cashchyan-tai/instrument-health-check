namespace InstrumentHealthCheck.UI
{
    partial class TestPanel
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
            this.lblPort = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.lblTolerance = new System.Windows.Forms.Label();
            this.txtTolerance = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblFreq = new System.Windows.Forms.Label();
            this.txtFreqList = new System.Windows.Forms.TextBox();
            this.lblPower = new System.Windows.Forms.Label();
            this.txtPowerList = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            //
            // lblPort
            //
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 15);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(66, 15);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "測試 Port:";
            //
            // cboPort
            //
            this.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(90, 11);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(180, 23);
            this.cboPort.TabIndex = 1;
            //
            // lblTolerance
            //
            this.lblTolerance.AutoSize = true;
            this.lblTolerance.Location = new System.Drawing.Point(290, 15);
            this.lblTolerance.Name = "lblTolerance";
            this.lblTolerance.Size = new System.Drawing.Size(94, 15);
            this.lblTolerance.TabIndex = 2;
            this.lblTolerance.Text = "允收誤差 (±dB):";
            //
            // txtTolerance
            //
            this.txtTolerance.Location = new System.Drawing.Point(390, 11);
            this.txtTolerance.Name = "txtTolerance";
            this.txtTolerance.Size = new System.Drawing.Size(60, 23);
            this.txtTolerance.TabIndex = 3;
            this.txtTolerance.Text = "1.0";
            //
            // btnRun
            //
            this.btnRun.Location = new System.Drawing.Point(470, 10);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 27);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "開始測試";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            //
            // btnStop
            //
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(578, 10);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 27);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            //
            // lblFreq
            //
            this.lblFreq.AutoSize = true;
            this.lblFreq.Location = new System.Drawing.Point(12, 47);
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(160, 15);
            this.lblFreq.TabIndex = 6;
            this.lblFreq.Text = "頻率清單 (MHz, 逗號分隔):";
            //
            // txtFreqList
            //
            this.txtFreqList.Location = new System.Drawing.Point(180, 44);
            this.txtFreqList.Name = "txtFreqList";
            this.txtFreqList.Size = new System.Drawing.Size(300, 23);
            this.txtFreqList.TabIndex = 7;
            this.txtFreqList.Text = "400,900,2400,5000,5800";
            //
            // lblPower
            //
            this.lblPower.AutoSize = true;
            this.lblPower.Location = new System.Drawing.Point(500, 47);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(160, 15);
            this.lblPower.TabIndex = 8;
            this.lblPower.Text = "功率清單 (dBm, 逗號分隔):";
            //
            // txtPowerList
            //
            this.txtPowerList.Location = new System.Drawing.Point(500, 66);
            this.txtPowerList.Name = "txtPowerList";
            this.txtPowerList.Size = new System.Drawing.Size(168, 23);
            this.txtPowerList.TabIndex = 9;
            this.txtPowerList.Text = "-90,-50,-10";
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 80);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(34, 15);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "就緒";
            //
            // btnGenerateReport
            //
            this.btnGenerateReport.Enabled = false;
            this.btnGenerateReport.Location = new System.Drawing.Point(578, 44);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(90, 45);
            this.btnGenerateReport.TabIndex = 11;
            this.btnGenerateReport.Text = "產生報告";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            //
            // dgvResults
            //
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(12, 108);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersWidth = 30;
            this.dgvResults.Size = new System.Drawing.Size(736, 340);
            this.dgvResults.TabIndex = 12;
            //
            // TestPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtPowerList);
            this.Controls.Add(this.lblPower);
            this.Controls.Add(this.txtFreqList);
            this.Controls.Add(this.lblFreq);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtTolerance);
            this.Controls.Add(this.lblTolerance);
            this.Controls.Add(this.cboPort);
            this.Controls.Add(this.lblPort);
            this.Name = "TestPanel";
            this.Size = new System.Drawing.Size(760, 460);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Label lblTolerance;
        private System.Windows.Forms.TextBox txtTolerance;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblFreq;
        private System.Windows.Forms.TextBox txtFreqList;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.TextBox txtPowerList;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.DataGridView dgvResults;
    }
}
