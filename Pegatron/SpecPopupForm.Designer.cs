namespace Pegatron
{
    partial class SpecPopupForm
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
            this.tlpPopupMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnIQxstream = new System.Windows.Forms.Button();
            this.btnRSFSW = new System.Windows.Forms.Button();
            this.btnRSGenerator = new System.Windows.Forms.Button();
            this.btnIQxelM8W = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.tlpPopupMain.SuspendLayout();
            this.SuspendLayout();
            //
            // tlpPopupMain
            //
            this.tlpPopupMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tlpPopupMain.ColumnCount = 2;
            this.tlpPopupMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPopupMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPopupMain.Controls.Add(this.lblMsg, 0, 0);
            this.tlpPopupMain.Controls.Add(this.btnDefault, 0, 1);
            this.tlpPopupMain.Controls.Add(this.btnIQxstream, 1, 1);
            this.tlpPopupMain.Controls.Add(this.btnRSFSW, 0, 2);
            this.tlpPopupMain.Controls.Add(this.btnRSGenerator, 1, 2);
            this.tlpPopupMain.Controls.Add(this.btnIQxelM8W, 0, 3);
            this.tlpPopupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPopupMain.Location = new System.Drawing.Point(0, 0);
            this.tlpPopupMain.Name = "tlpPopupMain";
            this.tlpPopupMain.RowCount = 4;
            this.tlpPopupMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpPopupMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpPopupMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpPopupMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpPopupMain.Size = new System.Drawing.Size(320, 156);
            this.tlpPopupMain.TabIndex = 0;
            //
            // lblMsg
            //
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsg.AutoSize = true;
            this.tlpPopupMain.SetColumnSpan(this.lblMsg, 2);
            this.lblMsg.ForeColor = System.Drawing.Color.White;
            this.lblMsg.Location = new System.Drawing.Point(15, 0);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Padding = new System.Windows.Forms.Padding(0, 7, 0, 7);
            this.lblMsg.Size = new System.Drawing.Size(290, 30);
            this.lblMsg.TabIndex = 4;
            this.lblMsg.Text = "Select spec file type:";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // btnDefault
            //
            this.btnDefault.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDefault.Location = new System.Drawing.Point(18, 43);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(124, 23);
            this.btnDefault.TabIndex = 0;
            this.btnDefault.Text = "IQxel (Default)";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            //
            // btnIQxstream
            //
            this.btnIQxstream.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIQxstream.Location = new System.Drawing.Point(178, 43);
            this.btnIQxstream.Name = "btnIQxstream";
            this.btnIQxstream.Size = new System.Drawing.Size(124, 23);
            this.btnIQxstream.TabIndex = 1;
            this.btnIQxstream.Text = "IQxstream-M";
            this.btnIQxstream.UseVisualStyleBackColor = true;
            this.btnIQxstream.Click += new System.EventHandler(this.btnIQxstream_Click);
            //
            // btnRSFSW
            //
            this.btnRSFSW.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRSFSW.Location = new System.Drawing.Point(18, 83);
            this.btnRSFSW.Name = "btnRSFSW";
            this.btnRSFSW.Size = new System.Drawing.Size(124, 23);
            this.btnRSFSW.TabIndex = 2;
            this.btnRSFSW.Text = "R&&S FSW (Analyzer)";
            this.btnRSFSW.UseVisualStyleBackColor = true;
            this.btnRSFSW.Click += new System.EventHandler(this.btnRSFSW_Click);
            //
            // btnRSGenerator
            //
            this.btnRSGenerator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRSGenerator.Location = new System.Drawing.Point(178, 83);
            this.btnRSGenerator.Name = "btnRSGenerator";
            this.btnRSGenerator.Size = new System.Drawing.Size(124, 23);
            this.btnRSGenerator.TabIndex = 3;
            this.btnRSGenerator.Text = "R&&S Generator";
            this.btnRSGenerator.UseVisualStyleBackColor = true;
            this.btnRSGenerator.Click += new System.EventHandler(this.btnRSGenerator_Click);
            //
            // btnIQxelM8W
            //
            this.btnIQxelM8W.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIQxelM8W.Location = new System.Drawing.Point(18, 120);
            this.btnIQxelM8W.Name = "btnIQxelM8W";
            this.btnIQxelM8W.Size = new System.Drawing.Size(124, 23);
            this.btnIQxelM8W.TabIndex = 4;
            this.btnIQxelM8W.Text = "IQXEL-M8W";
            this.btnIQxelM8W.UseVisualStyleBackColor = true;
            this.btnIQxelM8W.Click += new System.EventHandler(this.btnIQxelM8W_Click);
            //
            // SpecPopupForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 156);
            this.Controls.Add(this.tlpPopupMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SpecPopupForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Specification";
            this.TopMost = true;
            this.tlpPopupMain.ResumeLayout(false);
            this.tlpPopupMain.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPopupMain;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnIQxstream;
        private System.Windows.Forms.Button btnRSFSW;
        private System.Windows.Forms.Button btnRSGenerator;
        private System.Windows.Forms.Button btnIQxelM8W;
        private System.Windows.Forms.Label lblMsg;
    }
}
