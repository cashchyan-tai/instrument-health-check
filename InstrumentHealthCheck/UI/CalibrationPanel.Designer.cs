namespace InstrumentHealthCheck.UI
{
    partial class CalibrationPanel
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
            this.lblFile = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.tabDirection = new System.Windows.Forms.TabControl();
            this.tabSgToDut = new System.Windows.Forms.TabPage();
            this.dgvSgToDut = new System.Windows.Forms.DataGridView();
            this.btnAddRowSg = new System.Windows.Forms.Button();
            this.btnRemoveRowSg = new System.Windows.Forms.Button();
            this.tabDutToSa = new System.Windows.Forms.TabPage();
            this.dgvDutToSa = new System.Windows.Forms.DataGridView();
            this.btnAddRowSa = new System.Windows.Forms.Button();
            this.btnRemoveRowSa = new System.Windows.Forms.Button();
            this.tabDirection.SuspendLayout();
            this.tabSgToDut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSgToDut)).BeginInit();
            this.tabDutToSa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDutToSa)).BeginInit();
            this.SuspendLayout();
            //
            // lblFile
            //
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(12, 17);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(89, 15);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "尚未載入校正檔";
            //
            // btnLoad
            //
            this.btnLoad.Location = new System.Drawing.Point(400, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(90, 27);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "載入...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(500, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 27);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "另存...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnNew
            //
            this.btnNew.Location = new System.Drawing.Point(600, 10);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(90, 27);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "清空";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            //
            // tabDirection
            //
            this.tabDirection.Controls.Add(this.tabSgToDut);
            this.tabDirection.Controls.Add(this.tabDutToSa);
            this.tabDirection.Location = new System.Drawing.Point(12, 48);
            this.tabDirection.Name = "tabDirection";
            this.tabDirection.SelectedIndex = 0;
            this.tabDirection.Size = new System.Drawing.Size(680, 400);
            this.tabDirection.TabIndex = 4;
            //
            // tabSgToDut
            //
            this.tabSgToDut.Controls.Add(this.dgvSgToDut);
            this.tabSgToDut.Controls.Add(this.btnAddRowSg);
            this.tabSgToDut.Controls.Add(this.btnRemoveRowSg);
            this.tabSgToDut.Location = new System.Drawing.Point(4, 24);
            this.tabSgToDut.Name = "tabSgToDut";
            this.tabSgToDut.Padding = new System.Windows.Forms.Padding(6);
            this.tabSgToDut.Size = new System.Drawing.Size(672, 372);
            this.tabSgToDut.TabIndex = 0;
            this.tabSgToDut.Text = "SG → DUT";
            this.tabSgToDut.UseVisualStyleBackColor = true;
            //
            // dgvSgToDut
            //
            this.dgvSgToDut.AllowUserToAddRows = false;
            this.dgvSgToDut.AllowUserToDeleteRows = false;
            this.dgvSgToDut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSgToDut.Location = new System.Drawing.Point(6, 6);
            this.dgvSgToDut.Name = "dgvSgToDut";
            this.dgvSgToDut.RowHeadersWidth = 30;
            this.dgvSgToDut.Size = new System.Drawing.Size(660, 330);
            this.dgvSgToDut.TabIndex = 0;
            this.dgvSgToDut.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSgToDut_CellEndEdit);
            //
            // btnAddRowSg
            //
            this.btnAddRowSg.Location = new System.Drawing.Point(6, 342);
            this.btnAddRowSg.Name = "btnAddRowSg";
            this.btnAddRowSg.Size = new System.Drawing.Size(100, 28);
            this.btnAddRowSg.TabIndex = 1;
            this.btnAddRowSg.Text = "新增頻率點";
            this.btnAddRowSg.UseVisualStyleBackColor = true;
            this.btnAddRowSg.Click += new System.EventHandler(this.btnAddRowSg_Click);
            //
            // btnRemoveRowSg
            //
            this.btnRemoveRowSg.Location = new System.Drawing.Point(112, 342);
            this.btnRemoveRowSg.Name = "btnRemoveRowSg";
            this.btnRemoveRowSg.Size = new System.Drawing.Size(100, 28);
            this.btnRemoveRowSg.TabIndex = 2;
            this.btnRemoveRowSg.Text = "刪除選取列";
            this.btnRemoveRowSg.UseVisualStyleBackColor = true;
            this.btnRemoveRowSg.Click += new System.EventHandler(this.btnRemoveRowSg_Click);
            //
            // tabDutToSa
            //
            this.tabDutToSa.Controls.Add(this.dgvDutToSa);
            this.tabDutToSa.Controls.Add(this.btnAddRowSa);
            this.tabDutToSa.Controls.Add(this.btnRemoveRowSa);
            this.tabDutToSa.Location = new System.Drawing.Point(4, 24);
            this.tabDutToSa.Name = "tabDutToSa";
            this.tabDutToSa.Padding = new System.Windows.Forms.Padding(6);
            this.tabDutToSa.Size = new System.Drawing.Size(672, 372);
            this.tabDutToSa.TabIndex = 1;
            this.tabDutToSa.Text = "DUT → SA";
            this.tabDutToSa.UseVisualStyleBackColor = true;
            //
            // dgvDutToSa
            //
            this.dgvDutToSa.AllowUserToAddRows = false;
            this.dgvDutToSa.AllowUserToDeleteRows = false;
            this.dgvDutToSa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDutToSa.Location = new System.Drawing.Point(6, 6);
            this.dgvDutToSa.Name = "dgvDutToSa";
            this.dgvDutToSa.RowHeadersWidth = 30;
            this.dgvDutToSa.Size = new System.Drawing.Size(660, 330);
            this.dgvDutToSa.TabIndex = 0;
            this.dgvDutToSa.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDutToSa_CellEndEdit);
            //
            // btnAddRowSa
            //
            this.btnAddRowSa.Location = new System.Drawing.Point(6, 342);
            this.btnAddRowSa.Name = "btnAddRowSa";
            this.btnAddRowSa.Size = new System.Drawing.Size(100, 28);
            this.btnAddRowSa.TabIndex = 1;
            this.btnAddRowSa.Text = "新增頻率點";
            this.btnAddRowSa.UseVisualStyleBackColor = true;
            this.btnAddRowSa.Click += new System.EventHandler(this.btnAddRowSa_Click);
            //
            // btnRemoveRowSa
            //
            this.btnRemoveRowSa.Location = new System.Drawing.Point(112, 342);
            this.btnRemoveRowSa.Name = "btnRemoveRowSa";
            this.btnRemoveRowSa.Size = new System.Drawing.Size(100, 28);
            this.btnRemoveRowSa.TabIndex = 2;
            this.btnRemoveRowSa.Text = "刪除選取列";
            this.btnRemoveRowSa.UseVisualStyleBackColor = true;
            this.btnRemoveRowSa.Click += new System.EventHandler(this.btnRemoveRowSa_Click);
            //
            // CalibrationPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabDirection);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblFile);
            this.Name = "CalibrationPanel";
            this.Size = new System.Drawing.Size(710, 460);
            this.tabDirection.ResumeLayout(false);
            this.tabSgToDut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSgToDut)).EndInit();
            this.tabDutToSa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDutToSa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TabControl tabDirection;
        private System.Windows.Forms.TabPage tabSgToDut;
        private System.Windows.Forms.DataGridView dgvSgToDut;
        private System.Windows.Forms.Button btnAddRowSg;
        private System.Windows.Forms.Button btnRemoveRowSg;
        private System.Windows.Forms.TabPage tabDutToSa;
        private System.Windows.Forms.DataGridView dgvDutToSa;
        private System.Windows.Forms.Button btnAddRowSa;
        private System.Windows.Forms.Button btnRemoveRowSa;
    }
}
