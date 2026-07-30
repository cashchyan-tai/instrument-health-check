namespace Pegatron
{
    partial class FrequencySweepPopupForm
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.lblStop = new System.Windows.Forms.Label();
            this.txtStop = new System.Windows.Forms.TextBox();
            this.lblStep = new System.Windows.Forms.Label();
            this.txtStep = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            //
            // tlpMain
            //
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.lblMsg, 0, 0);
            this.tlpMain.Controls.Add(this.lblStart, 0, 1);
            this.tlpMain.Controls.Add(this.txtStart, 1, 1);
            this.tlpMain.Controls.Add(this.lblStop, 0, 2);
            this.tlpMain.Controls.Add(this.txtStop, 1, 2);
            this.tlpMain.Controls.Add(this.lblStep, 0, 3);
            this.tlpMain.Controls.Add(this.txtStep, 1, 3);
            this.tlpMain.Controls.Add(this.btnOK, 0, 4);
            this.tlpMain.Controls.Add(this.btnCancel, 1, 4);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpMain.Size = new System.Drawing.Size(320, 174);
            this.tlpMain.TabIndex = 0;
            //
            // lblMsg
            //
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsg.AutoSize = true;
            this.tlpMain.SetColumnSpan(this.lblMsg, 2);
            this.lblMsg.ForeColor = System.Drawing.Color.White;
            this.lblMsg.Location = new System.Drawing.Point(15, 0);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Padding = new System.Windows.Forms.Padding(0, 7, 0, 7);
            this.lblMsg.Size = new System.Drawing.Size(290, 48);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "Enter frequency sweep (MHz):";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // lblStart
            //
            this.lblStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStart.AutoSize = true;
            this.lblStart.ForeColor = System.Drawing.Color.White;
            this.lblStart.Location = new System.Drawing.Point(15, 55);
            this.lblStart.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(70, 20);
            this.lblStart.TabIndex = 1;
            this.lblStart.Text = "Start (MHz)";
            //
            // txtStart
            //
            this.txtStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStart.Location = new System.Drawing.Point(163, 51)
;
            this.txtStart.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(142, 20);
            this.txtStart.TabIndex = 2;
            //
            // lblStop
            //
            this.lblStop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStop.AutoSize = true;
            this.lblStop.ForeColor = System.Drawing.Color.White;
            this.lblStop.Location = new System.Drawing.Point(15, 85);
            this.lblStop.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(70, 20);
            this.lblStop.TabIndex = 3;
            this.lblStop.Text = "Stop (MHz)";
            //
            // txtStop
            //
            this.txtStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStop.Location = new System.Drawing.Point(163, 81);
            this.txtStop.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.txtStop.Name = "txtStop";
            this.txtStop.Size = new System.Drawing.Size(142, 20);
            this.txtStop.TabIndex = 4;
            //
            // lblStep
            //
            this.lblStep.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStep.AutoSize = true;
            this.lblStep.ForeColor = System.Drawing.Color.White;
            this.lblStep.Location = new System.Drawing.Point(15, 115);
            this.lblStep.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(70, 20);
            this.lblStep.TabIndex = 5;
            this.lblStep.Text = "Step (MHz)";
            //
            // txtStep
            //
            this.txtStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStep.Location = new System.Drawing.Point(163, 111);
            this.txtStep.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.txtStep.Name = "txtStep";
            this.txtStep.Size = new System.Drawing.Size(142, 20);
            this.txtStep.TabIndex = 6;
            //
            // btnOK
            //
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.Location = new System.Drawing.Point(18, 141);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(124, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            //
            // btnCancel
            //
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Location = new System.Drawing.Point(178, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Skip (use default)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // FrequencySweepPopupForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 174);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrequencySweepPopupForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frequency Sweep";
            this.TopMost = true;
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.TextBox txtStop;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.TextBox txtStep;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
