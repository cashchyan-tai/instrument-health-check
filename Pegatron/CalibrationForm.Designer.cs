namespace Pegatron
{
    partial class CalibrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalibrationForm));
            this.tableLayoutPanelCalMain = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewCalTable = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelSideBar = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelCalData = new System.Windows.Forms.TableLayoutPanel();
            this.labelneedsCalibration = new System.Windows.Forms.Label();
            this.labelLastCal = new System.Windows.Forms.Label();
            this.lblCal = new System.Windows.Forms.Label();
            this.lblLastCal = new System.Windows.Forms.Label();
            this.buttonStartCalibration = new System.Windows.Forms.Button();
            this.btnConnectionDiagramPanel = new System.Windows.Forms.Panel();
            this.btnConnectionDiagram = new System.Windows.Forms.Button();
            this.panelBackBtn = new System.Windows.Forms.Panel();
            this.tableLayoutPanelBackBtn = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxBackBtn = new System.Windows.Forms.PictureBox();
            this.lblBackBtn = new System.Windows.Forms.Label();
            this.tableLayoutPanelTabs = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownEndFreq = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStartFreq = new System.Windows.Forms.NumericUpDown();
            this.lblFreqRange = new System.Windows.Forms.Label();
            this.tabSADUT = new System.Windows.Forms.Button();
            this.tabSGDUT = new System.Windows.Forms.Button();
            this.tabSGSA = new System.Windows.Forms.Button();
            this.lbtDash = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.cbIQxstream = new System.Windows.Forms.CheckBox();
            this.chartSGSA = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelSGSAChartArea = new System.Windows.Forms.TableLayoutPanel();
            this.panelSGSASweepListContainer = new System.Windows.Forms.TableLayoutPanel();
            this.lstSGSASweeps = new System.Windows.Forms.CheckedListBox();
            this.btnDeleteSGSASweep = new System.Windows.Forms.Button();
            this.panelSGSASettings = new System.Windows.Forms.TableLayoutPanel();
            this.lblSGSAPower = new System.Windows.Forms.Label();
            this.numericUpDownSGSAPower = new System.Windows.Forms.NumericUpDown();
            this.lblSGSAStep = new System.Windows.Forms.Label();
            this.numericUpDownSGSAStep = new System.Windows.Forms.NumericUpDown();
            this.btnClearSGSAHistory = new System.Windows.Forms.Button();
            this.lblSGSAStatus = new System.Windows.Forms.Label();
            this.tableLayoutPanelCalMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSGSA)).BeginInit();
            this.panelSGSAChartArea.SuspendLayout();
            this.panelSGSASweepListContainer.SuspendLayout();
            this.tableLayoutPanelSideBar.SuspendLayout();
            this.tableLayoutPanelCalData.SuspendLayout();
            this.btnConnectionDiagramPanel.SuspendLayout();
            this.panelBackBtn.SuspendLayout();
            this.tableLayoutPanelBackBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackBtn)).BeginInit();
            this.tableLayoutPanelTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartFreq)).BeginInit();
            this.panelSGSASettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSGSAPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSGSAStep)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelCalMain
            // 
            this.tableLayoutPanelCalMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayoutPanelCalMain.ColumnCount = 2;
            this.tableLayoutPanelCalMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelCalMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanelCalMain.Controls.Add(this.dataGridViewCalTable, 1, 1);
            this.tableLayoutPanelCalMain.Controls.Add(this.panelSGSAChartArea, 1, 1);
            this.tableLayoutPanelCalMain.Controls.Add(this.tableLayoutPanelSideBar, 0, 1);
            this.tableLayoutPanelCalMain.Controls.Add(this.panelBackBtn, 0, 0);
            this.tableLayoutPanelCalMain.Controls.Add(this.tableLayoutPanelTabs, 1, 0);
            this.tableLayoutPanelCalMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCalMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelCalMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelCalMain.Name = "tableLayoutPanelCalMain";
            this.tableLayoutPanelCalMain.RowCount = 2;
            this.tableLayoutPanelCalMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelCalMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCalMain.Size = new System.Drawing.Size(1100, 480);
            this.tableLayoutPanelCalMain.TabIndex = 168;
            // 
            // dataGridViewCalTable
            // 
            this.dataGridViewCalTable.AllowUserToAddRows = false;
            this.dataGridViewCalTable.AllowUserToDeleteRows = false;
            this.dataGridViewCalTable.AllowUserToResizeColumns = false;
            this.dataGridViewCalTable.AllowUserToResizeRows = false;
            this.dataGridViewCalTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCalTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dataGridViewCalTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCalTable.CausesValidation = false;
            this.dataGridViewCalTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCalTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCalTable.ColumnHeadersHeight = 35;
            this.dataGridViewCalTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCalTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCalTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCalTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewCalTable.EnableHeadersVisualStyles = false;
            this.dataGridViewCalTable.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dataGridViewCalTable.Location = new System.Drawing.Point(165, 50);
            this.dataGridViewCalTable.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewCalTable.Name = "dataGridViewCalTable";
            this.dataGridViewCalTable.ReadOnly = true;
            this.dataGridViewCalTable.RowHeadersVisible = false;
            this.dataGridViewCalTable.RowHeadersWidth = 51;
            this.dataGridViewCalTable.RowTemplate.ReadOnly = true;
            this.dataGridViewCalTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewCalTable.ShowCellErrors = false;
            this.dataGridViewCalTable.ShowCellToolTips = false;
            this.dataGridViewCalTable.ShowEditingIcon = false;
            this.dataGridViewCalTable.ShowRowErrors = false;
            this.dataGridViewCalTable.Size = new System.Drawing.Size(935, 430);
            this.dataGridViewCalTable.TabIndex = 46;
            //
            // chartSGSA
            //
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            chartArea1.Name = "ChartAreaSGSA";
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            chartArea1.AxisX.Title = "Frequency (MHz)";
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.Title = "Loss (dB)";
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chartSGSA.ChartAreas.Add(chartArea1);
            legend1.Name = "LegendSGSA";
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            legend1.ForeColor = System.Drawing.Color.White;
            this.chartSGSA.Legends.Add(legend1);
            this.chartSGSA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.chartSGSA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartSGSA.Location = new System.Drawing.Point(165, 50);
            this.chartSGSA.Margin = new System.Windows.Forms.Padding(0);
            this.chartSGSA.Name = "chartSGSA";
            this.chartSGSA.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            this.chartSGSA.Size = new System.Drawing.Size(935, 430);
            this.chartSGSA.TabIndex = 51;
            this.chartSGSA.Text = "chartSGSA";
            //
            // panelSGSAChartArea
            //
            this.panelSGSAChartArea.ColumnCount = 2;
            this.panelSGSAChartArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78F));
            this.panelSGSAChartArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.panelSGSAChartArea.Controls.Add(this.chartSGSA, 0, 0);
            this.panelSGSAChartArea.Controls.Add(this.panelSGSASweepListContainer, 1, 0);
            this.panelSGSAChartArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSGSAChartArea.Location = new System.Drawing.Point(165, 50);
            this.panelSGSAChartArea.Margin = new System.Windows.Forms.Padding(0);
            this.panelSGSAChartArea.Name = "panelSGSAChartArea";
            this.panelSGSAChartArea.RowCount = 1;
            this.panelSGSAChartArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSGSAChartArea.Size = new System.Drawing.Size(935, 430);
            this.panelSGSAChartArea.TabIndex = 174;
            this.panelSGSAChartArea.Visible = false;
            //
            // panelSGSASweepListContainer
            //
            this.panelSGSASweepListContainer.ColumnCount = 1;
            this.panelSGSASweepListContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSGSASweepListContainer.Controls.Add(this.lstSGSASweeps, 0, 0);
            this.panelSGSASweepListContainer.Controls.Add(this.btnDeleteSGSASweep, 0, 1);
            this.panelSGSASweepListContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSGSASweepListContainer.Location = new System.Drawing.Point(732, 0);
            this.panelSGSASweepListContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panelSGSASweepListContainer.Name = "panelSGSASweepListContainer";
            this.panelSGSASweepListContainer.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.panelSGSASweepListContainer.RowCount = 2;
            this.panelSGSASweepListContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSGSASweepListContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelSGSASweepListContainer.Size = new System.Drawing.Size(203, 430);
            this.panelSGSASweepListContainer.TabIndex = 175;
            //
            // lstSGSASweeps
            //
            this.lstSGSASweeps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lstSGSASweeps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSGSASweeps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSGSASweeps.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lstSGSASweeps.ForeColor = System.Drawing.Color.White;
            this.lstSGSASweeps.FormattingEnabled = true;
            this.lstSGSASweeps.IntegralHeight = false;
            this.lstSGSASweeps.Location = new System.Drawing.Point(4, 0);
            this.lstSGSASweeps.Margin = new System.Windows.Forms.Padding(0);
            this.lstSGSASweeps.Name = "lstSGSASweeps";
            this.lstSGSASweeps.Size = new System.Drawing.Size(199, 400);
            this.lstSGSASweeps.TabIndex = 0;
            this.lstSGSASweeps.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstSGSASweeps_ItemCheck);
            //
            // btnDeleteSGSASweep
            //
            this.btnDeleteSGSASweep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteSGSASweep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteSGSASweep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSGSASweep.Font = new System.Drawing.Font("Consolas", 8F);
            this.btnDeleteSGSASweep.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSGSASweep.Location = new System.Drawing.Point(4, 400);
            this.btnDeleteSGSASweep.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteSGSASweep.Name = "btnDeleteSGSASweep";
            this.btnDeleteSGSASweep.AutoEllipsis = true;
            this.btnDeleteSGSASweep.Size = new System.Drawing.Size(199, 30);
            this.btnDeleteSGSASweep.TabIndex = 1;
            this.btnDeleteSGSASweep.Text = "Delete Selected";
            this.btnDeleteSGSASweep.UseVisualStyleBackColor = true;
            this.btnDeleteSGSASweep.Click += new System.EventHandler(this.btnDeleteSGSASweep_Click);
            //
            // tableLayoutPanelSideBar
            // 
            this.tableLayoutPanelSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tableLayoutPanelSideBar.ColumnCount = 1;
            this.tableLayoutPanelSideBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSideBar.Controls.Add(this.tableLayoutPanelCalData, 0, 0);
            this.tableLayoutPanelSideBar.Controls.Add(this.buttonStartCalibration, 0, 2);
            this.tableLayoutPanelSideBar.Controls.Add(this.btnConnectionDiagramPanel, 0, 1);
            this.tableLayoutPanelSideBar.Controls.Add(this.panelSGSASettings, 0, 1);
            this.tableLayoutPanelSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSideBar.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanelSideBar.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelSideBar.Name = "tableLayoutPanelSideBar";
            this.tableLayoutPanelSideBar.RowCount = 3;
            this.tableLayoutPanelSideBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanelSideBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelSideBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSideBar.Size = new System.Drawing.Size(165, 430);
            this.tableLayoutPanelSideBar.TabIndex = 1;
            // 
            // tableLayoutPanelCalData
            // 
            this.tableLayoutPanelCalData.ColumnCount = 1;
            this.tableLayoutPanelCalData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCalData.Controls.Add(this.labelneedsCalibration, 0, 1);
            this.tableLayoutPanelCalData.Controls.Add(this.labelLastCal, 0, 3);
            this.tableLayoutPanelCalData.Controls.Add(this.lblCal, 0, 0);
            this.tableLayoutPanelCalData.Controls.Add(this.lblLastCal, 0, 2);
            this.tableLayoutPanelCalData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCalData.Location = new System.Drawing.Point(0, 10);
            this.tableLayoutPanelCalData.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tableLayoutPanelCalData.Name = "tableLayoutPanelCalData";
            this.tableLayoutPanelCalData.RowCount = 4;
            this.tableLayoutPanelCalData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelCalData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelCalData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelCalData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelCalData.Size = new System.Drawing.Size(165, 140);
            this.tableLayoutPanelCalData.TabIndex = 47;
            // 
            // labelneedsCalibration
            // 
            this.labelneedsCalibration.AutoSize = true;
            this.labelneedsCalibration.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.labelneedsCalibration.ForeColor = System.Drawing.Color.Red;
            this.labelneedsCalibration.Location = new System.Drawing.Point(3, 21);
            this.labelneedsCalibration.Name = "labelneedsCalibration";
            this.labelneedsCalibration.Size = new System.Drawing.Size(81, 20);
            this.labelneedsCalibration.TabIndex = 2;
            this.labelneedsCalibration.Text = "Required";
            // 
            // labelLastCal
            // 
            this.labelLastCal.AutoSize = true;
            this.labelLastCal.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.labelLastCal.ForeColor = System.Drawing.Color.Gray;
            this.labelLastCal.Location = new System.Drawing.Point(3, 91);
            this.labelLastCal.Name = "labelLastCal";
            this.labelLastCal.Size = new System.Drawing.Size(18, 20);
            this.labelLastCal.TabIndex = 3;
            this.labelLastCal.Text = "-";
            // 
            // lblCal
            // 
            this.lblCal.AutoSize = true;
            this.lblCal.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblCal.ForeColor = System.Drawing.Color.White;
            this.lblCal.Location = new System.Drawing.Point(3, 0);
            this.lblCal.Name = "lblCal";
            this.lblCal.Size = new System.Drawing.Size(117, 20);
            this.lblCal.TabIndex = 0;
            this.lblCal.Text = "Calibration:";
            // 
            // lblLastCal
            // 
            this.lblLastCal.AutoSize = true;
            this.lblLastCal.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblLastCal.ForeColor = System.Drawing.Color.White;
            this.lblLastCal.Location = new System.Drawing.Point(3, 70);
            this.lblLastCal.Name = "lblLastCal";
            this.lblLastCal.Size = new System.Drawing.Size(153, 20);
            this.lblLastCal.TabIndex = 1;
            this.lblLastCal.Text = "Last Calibrated:";
            // 
            // buttonStartCalibration
            // 
            this.buttonStartCalibration.AutoSize = true;
            this.buttonStartCalibration.BackColor = System.Drawing.Color.Orange;
            this.buttonStartCalibration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStartCalibration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStartCalibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartCalibration.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.buttonStartCalibration.Location = new System.Drawing.Point(0, 374);
            this.buttonStartCalibration.Margin = new System.Windows.Forms.Padding(0);
            this.buttonStartCalibration.Name = "buttonStartCalibration";
            this.buttonStartCalibration.Size = new System.Drawing.Size(165, 56);
            this.buttonStartCalibration.TabIndex = 48;
            this.buttonStartCalibration.Text = "▶ CALIBRATE";
            this.buttonStartCalibration.UseVisualStyleBackColor = false;
            this.buttonStartCalibration.Click += new System.EventHandler(this.buttonStartCalibration_Click);
            // 
            // btnConnectionDiagramPanel
            // 
            this.btnConnectionDiagramPanel.AutoSize = true;
            this.btnConnectionDiagramPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConnectionDiagramPanel.Controls.Add(this.btnConnectionDiagram);
            this.btnConnectionDiagramPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnectionDiagramPanel.Location = new System.Drawing.Point(0, 150);
            this.btnConnectionDiagramPanel.Margin = new System.Windows.Forms.Padding(0);
            this.btnConnectionDiagramPanel.Name = "btnConnectionDiagramPanel";
            this.btnConnectionDiagramPanel.Size = new System.Drawing.Size(165, 224);
            this.btnConnectionDiagramPanel.TabIndex = 49;
            // 
            // btnConnectionDiagram
            // 
            this.btnConnectionDiagram.AutoSize = true;
            this.btnConnectionDiagram.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConnectionDiagram.BackColor = System.Drawing.Color.White;
            this.btnConnectionDiagram.BackgroundImage = global::Pegatron.Properties.Resources.CalSGDUT;
            this.btnConnectionDiagram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConnectionDiagram.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnectionDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnectionDiagram.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConnectionDiagram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectionDiagram.Image = global::Pegatron.Properties.Resources.enlarge_icon_small;
            this.btnConnectionDiagram.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConnectionDiagram.Location = new System.Drawing.Point(0, 0);
            this.btnConnectionDiagram.Name = "btnConnectionDiagram";
            this.btnConnectionDiagram.Size = new System.Drawing.Size(165, 224);
            this.btnConnectionDiagram.TabIndex = 50;
            this.btnConnectionDiagram.UseVisualStyleBackColor = false;
            this.btnConnectionDiagram.Click += new System.EventHandler(this.btnConnectionDiagram_Click);
            //
            // panelSGSASettings
            //
            this.panelSGSASettings.ColumnCount = 1;
            this.panelSGSASettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSGSASettings.Controls.Add(this.lblSGSAPower, 0, 0);
            this.panelSGSASettings.Controls.Add(this.numericUpDownSGSAPower, 0, 1);
            this.panelSGSASettings.Controls.Add(this.lblSGSAStep, 0, 2);
            this.panelSGSASettings.Controls.Add(this.numericUpDownSGSAStep, 0, 3);
            this.panelSGSASettings.Controls.Add(this.btnClearSGSAHistory, 0, 4);
            this.panelSGSASettings.Controls.Add(this.lblSGSAStatus, 0, 5);
            this.panelSGSASettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSGSASettings.Location = new System.Drawing.Point(0, 150);
            this.panelSGSASettings.Margin = new System.Windows.Forms.Padding(0);
            this.panelSGSASettings.Name = "panelSGSASettings";
            this.panelSGSASettings.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.panelSGSASettings.RowCount = 6;
            this.panelSGSASettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.panelSGSASettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelSGSASettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.panelSGSASettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelSGSASettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelSGSASettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSGSASettings.Size = new System.Drawing.Size(165, 224);
            this.panelSGSASettings.TabIndex = 173;
            this.panelSGSASettings.Visible = false;
            //
            // lblSGSAPower
            //
            this.lblSGSAPower.AutoSize = true;
            this.lblSGSAPower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSGSAPower.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblSGSAPower.ForeColor = System.Drawing.Color.White;
            this.lblSGSAPower.Location = new System.Drawing.Point(6, 4);
            this.lblSGSAPower.Name = "lblSGSAPower";
            this.lblSGSAPower.Size = new System.Drawing.Size(153, 22);
            this.lblSGSAPower.TabIndex = 0;
            this.lblSGSAPower.Text = "SG Power (dBm):";
            //
            // numericUpDownSGSAPower
            //
            this.numericUpDownSGSAPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownSGSAPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownSGSAPower.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDownSGSAPower.Font = new System.Drawing.Font("Consolas", 10F);
            this.numericUpDownSGSAPower.ForeColor = System.Drawing.Color.White;
            this.numericUpDownSGSAPower.Location = new System.Drawing.Point(6, 26);
            this.numericUpDownSGSAPower.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownSGSAPower.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.numericUpDownSGSAPower.Name = "numericUpDownSGSAPower";
            this.numericUpDownSGSAPower.Size = new System.Drawing.Size(153, 27);
            this.numericUpDownSGSAPower.TabIndex = 1;
            this.numericUpDownSGSAPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownSGSAPower.Enter += new System.EventHandler(this.numericUpDown_Enter);
            //
            // lblSGSAStep
            //
            this.lblSGSAStep.AutoSize = true;
            this.lblSGSAStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSGSAStep.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblSGSAStep.ForeColor = System.Drawing.Color.White;
            this.lblSGSAStep.Location = new System.Drawing.Point(6, 54);
            this.lblSGSAStep.Name = "lblSGSAStep";
            this.lblSGSAStep.Size = new System.Drawing.Size(153, 22);
            this.lblSGSAStep.TabIndex = 2;
            this.lblSGSAStep.Text = "Step (MHz):";
            //
            // numericUpDownSGSAStep
            //
            this.numericUpDownSGSAStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownSGSAStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownSGSAStep.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDownSGSAStep.Font = new System.Drawing.Font("Consolas", 10F);
            this.numericUpDownSGSAStep.ForeColor = System.Drawing.Color.White;
            this.numericUpDownSGSAStep.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownSGSAStep.Location = new System.Drawing.Point(6, 76);
            this.numericUpDownSGSAStep.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownSGSAStep.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownSGSAStep.Name = "numericUpDownSGSAStep";
            this.numericUpDownSGSAStep.Size = new System.Drawing.Size(153, 27);
            this.numericUpDownSGSAStep.TabIndex = 3;
            this.numericUpDownSGSAStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownSGSAStep.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownSGSAStep.Enter += new System.EventHandler(this.numericUpDown_Enter);
            //
            // btnClearSGSAHistory
            //
            this.btnClearSGSAHistory.AutoEllipsis = true;
            this.btnClearSGSAHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearSGSAHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearSGSAHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSGSAHistory.Font = new System.Drawing.Font("Consolas", 8F);
            this.btnClearSGSAHistory.ForeColor = System.Drawing.Color.White;
            this.btnClearSGSAHistory.Location = new System.Drawing.Point(6, 104);
            this.btnClearSGSAHistory.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnClearSGSAHistory.Name = "btnClearSGSAHistory";
            this.btnClearSGSAHistory.Padding = new System.Windows.Forms.Padding(0);
            this.btnClearSGSAHistory.Size = new System.Drawing.Size(153, 24);
            this.btnClearSGSAHistory.TabIndex = 5;
            this.btnClearSGSAHistory.Text = "Clear All";
            this.btnClearSGSAHistory.UseVisualStyleBackColor = true;
            this.btnClearSGSAHistory.Click += new System.EventHandler(this.btnClearSGSAHistory_Click);
            //
            // lblSGSAStatus
            //
            this.lblSGSAStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSGSAStatus.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lblSGSAStatus.ForeColor = System.Drawing.Color.Yellow;
            this.lblSGSAStatus.Location = new System.Drawing.Point(6, 132);
            this.lblSGSAStatus.Name = "lblSGSAStatus";
            this.lblSGSAStatus.Size = new System.Drawing.Size(153, 88);
            this.lblSGSAStatus.TabIndex = 6;
            this.lblSGSAStatus.Text = "Ready.";
            //
            // panelBackBtn
            // 
            this.panelBackBtn.AutoSize = true;
            this.panelBackBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelBackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelBackBtn.Controls.Add(this.tableLayoutPanelBackBtn);
            this.panelBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelBackBtn.Location = new System.Drawing.Point(0, 0);
            this.panelBackBtn.Margin = new System.Windows.Forms.Padding(0);
            this.panelBackBtn.Name = "panelBackBtn";
            this.panelBackBtn.Padding = new System.Windows.Forms.Padding(0, 0, 1, 2);
            this.panelBackBtn.Size = new System.Drawing.Size(165, 50);
            this.panelBackBtn.TabIndex = 166;
            this.panelBackBtn.Click += new System.EventHandler(this.backBtnForm_Click);
            // 
            // tableLayoutPanelBackBtn
            // 
            this.tableLayoutPanelBackBtn.AutoSize = true;
            this.tableLayoutPanelBackBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelBackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tableLayoutPanelBackBtn.ColumnCount = 4;
            this.tableLayoutPanelBackBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanelBackBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelBackBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanelBackBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanelBackBtn.Controls.Add(this.pictureBoxBackBtn, 1, 0);
            this.tableLayoutPanelBackBtn.Controls.Add(this.lblBackBtn, 2, 0);
            this.tableLayoutPanelBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanelBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBackBtn.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelBackBtn.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelBackBtn.Name = "tableLayoutPanelBackBtn";
            this.tableLayoutPanelBackBtn.RowCount = 1;
            this.tableLayoutPanelBackBtn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBackBtn.Size = new System.Drawing.Size(164, 48);
            this.tableLayoutPanelBackBtn.TabIndex = 166;
            this.tableLayoutPanelBackBtn.Click += new System.EventHandler(this.backBtnForm_Click);
            // 
            // pictureBoxBackBtn
            // 
            this.pictureBoxBackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pictureBoxBackBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxBackBtn.BackgroundImage")));
            this.pictureBoxBackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBackBtn.Location = new System.Drawing.Point(27, 0);
            this.pictureBoxBackBtn.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxBackBtn.Name = "pictureBoxBackBtn";
            this.pictureBoxBackBtn.Size = new System.Drawing.Size(32, 48);
            this.pictureBoxBackBtn.TabIndex = 0;
            this.pictureBoxBackBtn.TabStop = false;
            this.pictureBoxBackBtn.Click += new System.EventHandler(this.backBtnForm_Click);
            // 
            // lblBackBtn
            // 
            this.lblBackBtn.AutoSize = true;
            this.lblBackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBackBtn.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblBackBtn.ForeColor = System.Drawing.Color.White;
            this.lblBackBtn.Location = new System.Drawing.Point(62, 0);
            this.lblBackBtn.Name = "lblBackBtn";
            this.lblBackBtn.Size = new System.Drawing.Size(69, 48);
            this.lblBackBtn.TabIndex = 1;
            this.lblBackBtn.Text = "Back";
            this.lblBackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBackBtn.Click += new System.EventHandler(this.backBtnForm_Click);
            // 
            // tableLayoutPanelTabs
            // 
            this.tableLayoutPanelTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelTabs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelTabs.ColumnCount = 10;
            this.tableLayoutPanelTabs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTabs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTabs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTabs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTabs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTabs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelTabs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelTabs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelTabs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelTabs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTabs.Controls.Add(this.numericUpDownEndFreq, 7, 0);
            this.tableLayoutPanelTabs.Controls.Add(this.numericUpDownStartFreq, 5, 0);
            this.tableLayoutPanelTabs.Controls.Add(this.lblFreqRange, 4, 0);
            this.tableLayoutPanelTabs.Controls.Add(this.tabSADUT, 1, 0);
            this.tableLayoutPanelTabs.Controls.Add(this.tabSGDUT, 0, 0);
            this.tableLayoutPanelTabs.Controls.Add(this.tabSGSA, 2, 0);
            this.tableLayoutPanelTabs.Controls.Add(this.lbtDash, 6, 0);
            this.tableLayoutPanelTabs.Controls.Add(this.btnApply, 8, 0);
            this.tableLayoutPanelTabs.Controls.Add(this.cbIQxstream, 9, 0);
            this.tableLayoutPanelTabs.Location = new System.Drawing.Point(175, 0);
            this.tableLayoutPanelTabs.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tableLayoutPanelTabs.Name = "tableLayoutPanelTabs";
            this.tableLayoutPanelTabs.RowCount = 1;
            this.tableLayoutPanelTabs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTabs.Size = new System.Drawing.Size(925, 50);
            this.tableLayoutPanelTabs.TabIndex = 168;
            // 
            // numericUpDownEndFreq
            // 
            this.numericUpDownEndFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownEndFreq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownEndFreq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownEndFreq.Font = new System.Drawing.Font("Consolas", 10F);
            this.numericUpDownEndFreq.ForeColor = System.Drawing.Color.White;
            this.numericUpDownEndFreq.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownEndFreq.Location = new System.Drawing.Point(611, 11);
            this.numericUpDownEndFreq.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownEndFreq.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDownEndFreq.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownEndFreq.Name = "numericUpDownEndFreq";
            this.numericUpDownEndFreq.Size = new System.Drawing.Size(100, 27);
            this.numericUpDownEndFreq.TabIndex = 169;
            this.numericUpDownEndFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownEndFreq.Value = new decimal(new int[] {
            7200,
            0,
            0,
            0});
            this.numericUpDownEndFreq.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // numericUpDownStartFreq
            // 
            this.numericUpDownStartFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownStartFreq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownStartFreq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownStartFreq.Font = new System.Drawing.Font("Consolas", 10F);
            this.numericUpDownStartFreq.ForeColor = System.Drawing.Color.White;
            this.numericUpDownStartFreq.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownStartFreq.Location = new System.Drawing.Point(481, 11);
            this.numericUpDownStartFreq.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownStartFreq.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDownStartFreq.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownStartFreq.Name = "numericUpDownStartFreq";
            this.numericUpDownStartFreq.Size = new System.Drawing.Size(100, 27);
            this.numericUpDownStartFreq.TabIndex = 168;
            this.numericUpDownStartFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownStartFreq.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numericUpDownStartFreq.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // lblFreqRange
            // 
            this.lblFreqRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFreqRange.AutoSize = true;
            this.lblFreqRange.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblFreqRange.ForeColor = System.Drawing.Color.White;
            this.lblFreqRange.Location = new System.Drawing.Point(316, 0);
            this.lblFreqRange.Name = "lblFreqRange";
            this.lblFreqRange.Size = new System.Drawing.Size(162, 50);
            this.lblFreqRange.TabIndex = 166;
            this.lblFreqRange.Text = "Frequrency Range:";
            this.lblFreqRange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabSADUT
            // 
            this.tabSADUT.AutoSize = true;
            this.tabSADUT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tabSADUT.BackColor = System.Drawing.Color.Gray;
            this.tabSADUT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabSADUT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSADUT.FlatAppearance.BorderSize = 0;
            this.tabSADUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabSADUT.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.tabSADUT.ForeColor = System.Drawing.Color.White;
            this.tabSADUT.Location = new System.Drawing.Point(100, 10);
            this.tabSADUT.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tabSADUT.MinimumSize = new System.Drawing.Size(0, 41);
            this.tabSADUT.Name = "tabSADUT";
            this.tabSADUT.Size = new System.Drawing.Size(100, 41);
            this.tabSADUT.TabIndex = 165;
            this.tabSADUT.Text = "DUT to SA";
            this.tabSADUT.UseVisualStyleBackColor = false;
            this.tabSADUT.Click += new System.EventHandler(this.tabSADUT_Click);
            // 
            // tabSGDUT
            // 
            this.tabSGDUT.AutoSize = true;
            this.tabSGDUT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tabSGDUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tabSGDUT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabSGDUT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSGDUT.FlatAppearance.BorderSize = 0;
            this.tabSGDUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabSGDUT.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.tabSGDUT.ForeColor = System.Drawing.Color.White;
            this.tabSGDUT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabSGDUT.Location = new System.Drawing.Point(0, 0);
            this.tabSGDUT.Margin = new System.Windows.Forms.Padding(0);
            this.tabSGDUT.MinimumSize = new System.Drawing.Size(0, 41);
            this.tabSGDUT.Name = "tabSGDUT";
            this.tabSGDUT.Size = new System.Drawing.Size(100, 50);
            this.tabSGDUT.TabIndex = 164;
            this.tabSGDUT.Text = "SG to DUT";
            this.tabSGDUT.UseVisualStyleBackColor = false;
            this.tabSGDUT.Click += new System.EventHandler(this.tabSGDUT_Click);
            //
            // tabSGSA
            //
            this.tabSGSA.AutoSize = true;
            this.tabSGSA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tabSGSA.BackColor = System.Drawing.Color.Gray;
            this.tabSGSA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabSGSA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSGSA.FlatAppearance.BorderSize = 0;
            this.tabSGSA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabSGSA.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.tabSGSA.ForeColor = System.Drawing.Color.White;
            this.tabSGSA.Location = new System.Drawing.Point(200, 10);
            this.tabSGSA.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tabSGSA.MinimumSize = new System.Drawing.Size(0, 41);
            this.tabSGSA.Name = "tabSGSA";
            this.tabSGSA.Size = new System.Drawing.Size(100, 41);
            this.tabSGSA.TabIndex = 172;
            this.tabSGSA.Text = "SG ↔ SA";
            this.tabSGSA.UseVisualStyleBackColor = false;
            this.tabSGSA.Click += new System.EventHandler(this.tabSGSA_Click);
            //
            // lbtDash
            // 
            this.lbtDash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbtDash.AutoSize = true;
            this.lbtDash.Font = new System.Drawing.Font("Consolas", 10F);
            this.lbtDash.ForeColor = System.Drawing.Color.White;
            this.lbtDash.Location = new System.Drawing.Point(584, 0);
            this.lbtDash.Name = "lbtDash";
            this.lbtDash.Size = new System.Drawing.Size(24, 50);
            this.lbtDash.TabIndex = 167;
            this.lbtDash.Text = "-";
            this.lbtDash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnApply.AutoSize = true;
            this.btnApply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApply.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(726, 11);
            this.btnApply.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(59, 28);
            this.btnApply.TabIndex = 170;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cbIQxstream
            // 
            this.cbIQxstream.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbIQxstream.AutoSize = true;
            this.cbIQxstream.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbIQxstream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbIQxstream.ForeColor = System.Drawing.Color.White;
            this.cbIQxstream.Location = new System.Drawing.Point(816, 8);
            this.cbIQxstream.Margin = new System.Windows.Forms.Padding(0);
            this.cbIQxstream.Name = "cbIQxstream";
            this.cbIQxstream.Size = new System.Drawing.Size(103, 33);
            this.cbIQxstream.TabIndex = 171;
            this.cbIQxstream.Text = "IQxstream View";
            this.cbIQxstream.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbIQxstream.UseVisualStyleBackColor = true;
            this.cbIQxstream.CheckedChanged += new System.EventHandler(this.cbIQxstream_CheckedChanged);
            // 
            // CalibrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1100, 480);
            this.Controls.Add(this.tableLayoutPanelCalMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1100, 480);
            this.Name = "CalibrationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Calibration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalibrationForm_FormClosing);
            this.Load += new System.EventHandler(this.CalibrationForm_Load);
            this.Leave += new System.EventHandler(this.CalibrationForm_Leave);
            this.Resize += new System.EventHandler(this.CalibrationForm_Resize);
            this.tableLayoutPanelCalMain.ResumeLayout(false);
            this.tableLayoutPanelCalMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSGSA)).EndInit();
            this.panelSGSAChartArea.ResumeLayout(false);
            this.panelSGSASweepListContainer.ResumeLayout(false);
            this.tableLayoutPanelSideBar.ResumeLayout(false);
            this.tableLayoutPanelSideBar.PerformLayout();
            this.tableLayoutPanelCalData.ResumeLayout(false);
            this.tableLayoutPanelCalData.PerformLayout();
            this.btnConnectionDiagramPanel.ResumeLayout(false);
            this.btnConnectionDiagramPanel.PerformLayout();
            this.panelBackBtn.ResumeLayout(false);
            this.panelBackBtn.PerformLayout();
            this.tableLayoutPanelBackBtn.ResumeLayout(false);
            this.tableLayoutPanelBackBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackBtn)).EndInit();
            this.tableLayoutPanelTabs.ResumeLayout(false);
            this.tableLayoutPanelTabs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartFreq)).EndInit();
            this.panelSGSASettings.ResumeLayout(false);
            this.panelSGSASettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSGSAPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSGSAStep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewCalTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCalData;
        private System.Windows.Forms.Label labelneedsCalibration;
        private System.Windows.Forms.Label labelLastCal;
        private System.Windows.Forms.Label lblCal;
        private System.Windows.Forms.Label lblLastCal;
        private System.Windows.Forms.Button buttonStartCalibration;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCalMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSideBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTabs;
        private System.Windows.Forms.Button tabSADUT;
        private System.Windows.Forms.Button tabSGDUT;
        private System.Windows.Forms.Button tabSGSA;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSGSA;
        private System.Windows.Forms.TableLayoutPanel panelSGSAChartArea;
        private System.Windows.Forms.TableLayoutPanel panelSGSASweepListContainer;
        private System.Windows.Forms.CheckedListBox lstSGSASweeps;
        private System.Windows.Forms.Button btnDeleteSGSASweep;
        private System.Windows.Forms.TableLayoutPanel panelSGSASettings;
        private System.Windows.Forms.Label lblSGSAPower;
        private System.Windows.Forms.NumericUpDown numericUpDownSGSAPower;
        private System.Windows.Forms.Label lblSGSAStep;
        private System.Windows.Forms.NumericUpDown numericUpDownSGSAStep;
        private System.Windows.Forms.Button btnClearSGSAHistory;
        private System.Windows.Forms.Label lblSGSAStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBackBtn;
        private System.Windows.Forms.PictureBox pictureBoxBackBtn;
        private System.Windows.Forms.Label lblBackBtn;
        private System.Windows.Forms.Panel panelBackBtn;
        private System.Windows.Forms.Panel btnConnectionDiagramPanel;
        private System.Windows.Forms.Button btnConnectionDiagram;
        private System.Windows.Forms.Label lblFreqRange;
        private System.Windows.Forms.Label lbtDash;
        private System.Windows.Forms.NumericUpDown numericUpDownStartFreq;
        private System.Windows.Forms.NumericUpDown numericUpDownEndFreq;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.CheckBox cbIQxstream;
    }
}