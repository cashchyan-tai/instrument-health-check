using System.Windows.Forms;

namespace Pegatron
{
    partial class LitepointHealthCheck
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LitepointHealthCheck));
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sidePanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelDelayTextBox = new System.Windows.Forms.TableLayoutPanel();
            this.panelStep = new System.Windows.Forms.Panel();
            this.numericUpDownStep = new System.Windows.Forms.NumericUpDown();
            this.panelInitialize = new System.Windows.Forms.Panel();
            this.numericUpDownInitialize = new System.Windows.Forms.NumericUpDown();
            this.panelLPVSG = new System.Windows.Forms.Panel();
            this.lblLPVSGTitle = new System.Windows.Forms.Label();
            this.lblLPVSGFreq = new System.Windows.Forms.Label();
            this.numericLPVSGFreq = new System.Windows.Forms.NumericUpDown();
            this.lblLPVSGFreqUnit = new System.Windows.Forms.Label();
            this.lblLPVSGLevel = new System.Windows.Forms.Label();
            this.numericLPVSGLevel = new System.Windows.Forms.NumericUpDown();
            this.lblLPVSGLevelUnit = new System.Windows.Forms.Label();
            this.lblLPVSGPort = new System.Windows.Forms.Label();
            this.cbLPVSGPort = new System.Windows.Forms.ComboBox();
            this.btnLPVSGOn = new System.Windows.Forms.Button();
            this.btnLPVSGOff = new System.Windows.Forms.Button();
            this.lblSerialNoValue = new System.Windows.Forms.Label();
            this.lblModelValue = new System.Windows.Forms.Label();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblSerialNo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblManufacturerValue = new System.Windows.Forms.Label();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.lblTimeValue = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblPassRate = new System.Windows.Forms.Label();
            this.lblDurationTimer = new System.Windows.Forms.Label();
            this.lblPassRateValue = new System.Windows.Forms.Label();
            this.calibrationPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblSADUTCalDate = new System.Windows.Forms.Label();
            this.lblSGDUTCalDate = new System.Windows.Forms.Label();
            this.lblSGDUT = new System.Windows.Forms.Label();
            this.lblSADUT = new System.Windows.Forms.Label();
            this.btnLoadCal = new System.Windows.Forms.Button();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.calFilePanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblCalFileName = new System.Windows.Forms.Label();
            this.btnClearCalibration = new System.Windows.Forms.Button();
            this.panelStartStop = new System.Windows.Forms.Panel();
            this.cbRout = new System.Windows.Forms.ComboBox();
            this.lblRout = new System.Windows.Forms.Label();
            this.btnSetupImage = new System.Windows.Forms.Button();
            this.loadingConnectPic = new System.Windows.Forms.PictureBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.labelTestDelay = new System.Windows.Forms.Label();
            this.tableLayoutPanelDelayHeader = new System.Windows.Forms.TableLayoutPanel();
            this.labelStep = new System.Windows.Forms.Label();
            this.labelInitialize = new System.Windows.Forms.Label();
            this.dataGridTestResult = new System.Windows.Forms.DataGridView();
            this.panelConnectivity = new System.Windows.Forms.TableLayoutPanel();
            this.lblPSConnectivity = new System.Windows.Forms.Label();
            this.lblSAConnectivity = new System.Windows.Forms.Label();
            this.lblSGConnectivity = new System.Windows.Forms.Label();
            this.lblDUTConnectivity = new System.Windows.Forms.Label();
            this.picRefreshBtn = new System.Windows.Forms.PictureBox();
            this.lblSwitchConnectivity = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDebugStart = new System.Windows.Forms.Button();
            this.lblDebug = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panelCSV = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoadSpecFile = new System.Windows.Forms.Button();
            this.lblSpecAddress = new System.Windows.Forms.Label();
            this.btnGenerateNewTemplate = new System.Windows.Forms.Button();
            this.dialogOpenSpecFile = new System.Windows.Forms.OpenFileDialog();
            this.timerDuration = new System.Windows.Forms.Timer(this.components);
            this.dialogOpenCalFile = new System.Windows.Forms.OpenFileDialog();
            this.mainPanel.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.tableLayoutPanelDelayTextBox.SuspendLayout();
            this.panelStep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).BeginInit();
            this.panelInitialize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitialize)).BeginInit();
            this.panelLPVSG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLPVSGFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLPVSGLevel)).BeginInit();
            this.calibrationPanel.SuspendLayout();
            this.calFilePanel.SuspendLayout();
            this.panelStartStop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingConnectPic)).BeginInit();
            this.tableLayoutPanelDelayHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTestResult)).BeginInit();
            this.panelConnectivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshBtn)).BeginInit();
            this.panelCSV.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mainPanel.ColumnCount = 2;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.sidePanel, 0, 1);
            this.mainPanel.Controls.Add(this.dataGridTestResult, 1, 1);
            this.mainPanel.Controls.Add(this.panelConnectivity, 0, 2);
            this.mainPanel.Controls.Add(this.panelCSV, 0, 0);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 3;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainPanel.Size = new System.Drawing.Size(1012, 790);
            this.mainPanel.TabIndex = 0;
            // 
            // sidePanel
            // 
            this.sidePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sidePanel.AutoSize = true;
            this.sidePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sidePanel.ColumnCount = 2;
            this.sidePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41F));
            this.sidePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59F));
            this.sidePanel.Controls.Add(this.tableLayoutPanelDelayTextBox, 1, 11);
            this.sidePanel.Controls.Add(this.panelLPVSG, 0, 12);
            this.sidePanel.Controls.Add(this.lblSerialNoValue, 1, 2);
            this.sidePanel.Controls.Add(this.lblModelValue, 1, 1);
            this.sidePanel.Controls.Add(this.lblManufacturer, 0, 0);
            this.sidePanel.Controls.Add(this.lblModel, 0, 1);
            this.sidePanel.Controls.Add(this.lblSerialNo, 0, 2);
            this.sidePanel.Controls.Add(this.lblDate, 0, 4);
            this.sidePanel.Controls.Add(this.lblTime, 0, 5);
            this.sidePanel.Controls.Add(this.lblManufacturerValue, 1, 0);
            this.sidePanel.Controls.Add(this.lblDateValue, 1, 4);
            this.sidePanel.Controls.Add(this.lblTimeValue, 1, 5);
            this.sidePanel.Controls.Add(this.lblDuration, 0, 6);
            this.sidePanel.Controls.Add(this.lblPassRate, 0, 7);
            this.sidePanel.Controls.Add(this.lblDurationTimer, 1, 6);
            this.sidePanel.Controls.Add(this.lblPassRateValue, 1, 7);
            this.sidePanel.Controls.Add(this.calibrationPanel, 0, 9);
            this.sidePanel.Controls.Add(this.panelStartStop, 0, 13);
            this.sidePanel.Controls.Add(this.labelTestDelay, 0, 11);
            this.sidePanel.Controls.Add(this.tableLayoutPanelDelayHeader, 1, 10);
            this.sidePanel.Location = new System.Drawing.Point(3, 44);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.RowCount = 14;
            this.sidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.sidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.sidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.sidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.sidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.sidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.sidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.sidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.sidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.sidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.sidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.sidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.sidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.sidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.sidePanel.Size = new System.Drawing.Size(294, 703);
            this.sidePanel.TabIndex = 0;
            this.sidePanel.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // tableLayoutPanelDelayTextBox
            // 
            this.tableLayoutPanelDelayTextBox.ColumnCount = 2;
            this.tableLayoutPanelDelayTextBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDelayTextBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDelayTextBox.Controls.Add(this.panelStep, 1, 0);
            this.tableLayoutPanelDelayTextBox.Controls.Add(this.panelInitialize, 0, 0);
            this.tableLayoutPanelDelayTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDelayTextBox.Location = new System.Drawing.Point(120, 450);
            this.tableLayoutPanelDelayTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelDelayTextBox.Name = "tableLayoutPanelDelayTextBox";
            this.tableLayoutPanelDelayTextBox.RowCount = 1;
            this.tableLayoutPanelDelayTextBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDelayTextBox.Size = new System.Drawing.Size(174, 45);
            this.tableLayoutPanelDelayTextBox.TabIndex = 1;
            // 
            // panelStep
            // 
            this.panelStep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStep.Controls.Add(this.numericUpDownStep);
            this.panelStep.Location = new System.Drawing.Point(90, 6);
            this.panelStep.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.panelStep.Name = "panelStep";
            this.panelStep.Padding = new System.Windows.Forms.Padding(14, 7, 1, 7);
            this.panelStep.Size = new System.Drawing.Size(78, 33);
            this.panelStep.TabIndex = 21;
            // 
            // numericUpDownStep
            // 
            this.numericUpDownStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownStep.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownStep.Font = new System.Drawing.Font("Consolas", 10F);
            this.numericUpDownStep.ForeColor = System.Drawing.Color.White;
            this.numericUpDownStep.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownStep.Location = new System.Drawing.Point(14, 7);
            this.numericUpDownStep.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownStep.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownStep.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownStep.Name = "numericUpDownStep";
            this.numericUpDownStep.Size = new System.Drawing.Size(61, 23);
            this.numericUpDownStep.TabIndex = 20;
            this.numericUpDownStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownStep.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownStep.ValueChanged += new System.EventHandler(this.numericUpDownStep_ValueChanged);
            // 
            // panelInitialize
            // 
            this.panelInitialize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInitialize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInitialize.Controls.Add(this.numericUpDownInitialize);
            this.panelInitialize.Location = new System.Drawing.Point(6, 6);
            this.panelInitialize.Margin = new System.Windows.Forms.Padding(6, 6, 3, 6);
            this.panelInitialize.Name = "panelInitialize";
            this.panelInitialize.Padding = new System.Windows.Forms.Padding(14, 7, 1, 7);
            this.panelInitialize.Size = new System.Drawing.Size(78, 33);
            this.panelInitialize.TabIndex = 20;
            // 
            // numericUpDownInitialize
            // 
            this.numericUpDownInitialize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownInitialize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownInitialize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownInitialize.Font = new System.Drawing.Font("Consolas", 10F);
            this.numericUpDownInitialize.ForeColor = System.Drawing.Color.White;
            this.numericUpDownInitialize.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownInitialize.Location = new System.Drawing.Point(14, 7);
            this.numericUpDownInitialize.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownInitialize.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownInitialize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownInitialize.Name = "numericUpDownInitialize";
            this.numericUpDownInitialize.Size = new System.Drawing.Size(61, 23);
            this.numericUpDownInitialize.TabIndex = 20;
            this.numericUpDownInitialize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownInitialize.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownInitialize.ValueChanged += new System.EventHandler(this.numericUpDownInitialize_ValueChanged);
            // 
            // panelLPVSG
            // 
            this.panelLPVSG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLPVSG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.panelLPVSG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sidePanel.SetColumnSpan(this.panelLPVSG, 2);
            this.panelLPVSG.Controls.Add(this.lblLPVSGTitle);
            this.panelLPVSG.Controls.Add(this.lblLPVSGFreq);
            this.panelLPVSG.Controls.Add(this.numericLPVSGFreq);
            this.panelLPVSG.Controls.Add(this.lblLPVSGFreqUnit);
            this.panelLPVSG.Controls.Add(this.lblLPVSGLevel);
            this.panelLPVSG.Controls.Add(this.numericLPVSGLevel);
            this.panelLPVSG.Controls.Add(this.lblLPVSGLevelUnit);
            this.panelLPVSG.Controls.Add(this.lblLPVSGPort);
            this.panelLPVSG.Controls.Add(this.cbLPVSGPort);
            this.panelLPVSG.Controls.Add(this.btnLPVSGOn);
            this.panelLPVSG.Controls.Add(this.btnLPVSGOff);
            this.panelLPVSG.Location = new System.Drawing.Point(0, 495);
            this.panelLPVSG.Margin = new System.Windows.Forms.Padding(0);
            this.panelLPVSG.Name = "panelLPVSG";
            this.panelLPVSG.Size = new System.Drawing.Size(294, 145);
            this.panelLPVSG.TabIndex = 30;
            // 
            // lblLPVSGTitle
            // 
            this.lblLPVSGTitle.AutoSize = true;
            this.lblLPVSGTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.lblLPVSGTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLPVSGTitle.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.lblLPVSGTitle.ForeColor = System.Drawing.Color.Cyan;
            this.lblLPVSGTitle.Location = new System.Drawing.Point(0, 0);
            this.lblLPVSGTitle.Name = "lblLPVSGTitle";
            this.lblLPVSGTitle.Size = new System.Drawing.Size(224, 17);
            this.lblLPVSGTitle.TabIndex = 0;
            this.lblLPVSGTitle.Text = "── LP VSG Manual Control ──";
            this.lblLPVSGTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLPVSGFreq
            // 
            this.lblLPVSGFreq.AutoSize = true;
            this.lblLPVSGFreq.BackColor = System.Drawing.Color.Transparent;
            this.lblLPVSGFreq.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblLPVSGFreq.ForeColor = System.Drawing.Color.White;
            this.lblLPVSGFreq.Location = new System.Drawing.Point(4, 24);
            this.lblLPVSGFreq.Name = "lblLPVSGFreq";
            this.lblLPVSGFreq.Size = new System.Drawing.Size(48, 18);
            this.lblLPVSGFreq.TabIndex = 1;
            this.lblLPVSGFreq.Text = "Freq:";
            this.lblLPVSGFreq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericLPVSGFreq
            // 
            this.numericLPVSGFreq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericLPVSGFreq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericLPVSGFreq.DecimalPlaces = 3;
            this.numericLPVSGFreq.Font = new System.Drawing.Font("Consolas", 9F);
            this.numericLPVSGFreq.ForeColor = System.Drawing.Color.White;
            this.numericLPVSGFreq.Location = new System.Drawing.Point(60, 22);
            this.numericLPVSGFreq.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.numericLPVSGFreq.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLPVSGFreq.Name = "numericLPVSGFreq";
            this.numericLPVSGFreq.Size = new System.Drawing.Size(145, 25);
            this.numericLPVSGFreq.TabIndex = 2;
            this.numericLPVSGFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericLPVSGFreq.Value = new decimal(new int[] {
            2412,
            0,
            0,
            0});
            // 
            // lblLPVSGFreqUnit
            // 
            this.lblLPVSGFreqUnit.AutoSize = true;
            this.lblLPVSGFreqUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblLPVSGFreqUnit.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblLPVSGFreqUnit.ForeColor = System.Drawing.Color.LightGray;
            this.lblLPVSGFreqUnit.Location = new System.Drawing.Point(208, 24);
            this.lblLPVSGFreqUnit.Name = "lblLPVSGFreqUnit";
            this.lblLPVSGFreqUnit.Size = new System.Drawing.Size(32, 18);
            this.lblLPVSGFreqUnit.TabIndex = 3;
            this.lblLPVSGFreqUnit.Text = "MHz";
            this.lblLPVSGFreqUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLPVSGLevel
            // 
            this.lblLPVSGLevel.AutoSize = true;
            this.lblLPVSGLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblLPVSGLevel.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblLPVSGLevel.ForeColor = System.Drawing.Color.White;
            this.lblLPVSGLevel.Location = new System.Drawing.Point(4, 50);
            this.lblLPVSGLevel.Name = "lblLPVSGLevel";
            this.lblLPVSGLevel.Size = new System.Drawing.Size(56, 18);
            this.lblLPVSGLevel.TabIndex = 4;
            this.lblLPVSGLevel.Text = "Level:";
            this.lblLPVSGLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericLPVSGLevel
            // 
            this.numericLPVSGLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericLPVSGLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericLPVSGLevel.DecimalPlaces = 1;
            this.numericLPVSGLevel.Font = new System.Drawing.Font("Consolas", 9F);
            this.numericLPVSGLevel.ForeColor = System.Drawing.Color.White;
            this.numericLPVSGLevel.Location = new System.Drawing.Point(60, 48);
            this.numericLPVSGLevel.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericLPVSGLevel.Minimum = new decimal(new int[] {
            130,
            0,
            0,
            -2147483648});
            this.numericLPVSGLevel.Name = "numericLPVSGLevel";
            this.numericLPVSGLevel.Size = new System.Drawing.Size(145, 25);
            this.numericLPVSGLevel.TabIndex = 5;
            this.numericLPVSGLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLPVSGLevelUnit
            // 
            this.lblLPVSGLevelUnit.AutoSize = true;
            this.lblLPVSGLevelUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblLPVSGLevelUnit.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblLPVSGLevelUnit.ForeColor = System.Drawing.Color.LightGray;
            this.lblLPVSGLevelUnit.Location = new System.Drawing.Point(208, 50);
            this.lblLPVSGLevelUnit.Name = "lblLPVSGLevelUnit";
            this.lblLPVSGLevelUnit.Size = new System.Drawing.Size(32, 18);
            this.lblLPVSGLevelUnit.TabIndex = 6;
            this.lblLPVSGLevelUnit.Text = "dBm";
            this.lblLPVSGLevelUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLPVSGPort
            // 
            this.lblLPVSGPort.AutoSize = true;
            this.lblLPVSGPort.BackColor = System.Drawing.Color.Transparent;
            this.lblLPVSGPort.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblLPVSGPort.ForeColor = System.Drawing.Color.White;
            this.lblLPVSGPort.Location = new System.Drawing.Point(4, 76);
            this.lblLPVSGPort.Name = "lblLPVSGPort";
            this.lblLPVSGPort.Size = new System.Drawing.Size(48, 18);
            this.lblLPVSGPort.TabIndex = 7;
            this.lblLPVSGPort.Text = "Port:";
            this.lblLPVSGPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbLPVSGPort
            // 
            this.cbLPVSGPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbLPVSGPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLPVSGPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLPVSGPort.Font = new System.Drawing.Font("Consolas", 9F);
            this.cbLPVSGPort.ForeColor = System.Drawing.Color.White;
            this.cbLPVSGPort.FormattingEnabled = true;
            this.cbLPVSGPort.Items.AddRange(new object[] {
            "RF1A",
            "RF1B",
            "RF2A",
            "RF2B",
            "RF3A",
            "RF3B",
            "RF4A",
            "RF4B"});
            this.cbLPVSGPort.Location = new System.Drawing.Point(60, 74);
            this.cbLPVSGPort.Name = "cbLPVSGPort";
            this.cbLPVSGPort.Size = new System.Drawing.Size(228, 26);
            this.cbLPVSGPort.TabIndex = 8;
            // 
            // btnLPVSGOn
            // 
            this.btnLPVSGOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnLPVSGOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLPVSGOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLPVSGOn.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnLPVSGOn.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnLPVSGOn.Location = new System.Drawing.Point(4, 102);
            this.btnLPVSGOn.Name = "btnLPVSGOn";
            this.btnLPVSGOn.Size = new System.Drawing.Size(136, 34);
            this.btnLPVSGOn.TabIndex = 9;
            this.btnLPVSGOn.Text = "RF ON";
            this.btnLPVSGOn.UseVisualStyleBackColor = false;
            this.btnLPVSGOn.Click += new System.EventHandler(this.btnLPVSGOn_Click);
            // 
            // btnLPVSGOff
            // 
            this.btnLPVSGOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnLPVSGOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLPVSGOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLPVSGOff.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnLPVSGOff.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnLPVSGOff.Location = new System.Drawing.Point(148, 102);
            this.btnLPVSGOff.Name = "btnLPVSGOff";
            this.btnLPVSGOff.Size = new System.Drawing.Size(138, 34);
            this.btnLPVSGOff.TabIndex = 10;
            this.btnLPVSGOff.Text = "RF OFF";
            this.btnLPVSGOff.UseVisualStyleBackColor = false;
            this.btnLPVSGOff.Click += new System.EventHandler(this.btnLPVSGOff_Click);
            // 
            // lblSerialNoValue
            // 
            this.lblSerialNoValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSerialNoValue.AutoSize = true;
            this.lblSerialNoValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSerialNoValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSerialNoValue.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNoValue.ForeColor = System.Drawing.Color.White;
            this.lblSerialNoValue.Location = new System.Drawing.Point(126, 96);
            this.lblSerialNoValue.Margin = new System.Windows.Forms.Padding(6);
            this.lblSerialNoValue.Name = "lblSerialNoValue";
            this.lblSerialNoValue.Size = new System.Drawing.Size(162, 33);
            this.lblSerialNoValue.TabIndex = 10;
            this.lblSerialNoValue.Text = "-";
            this.lblSerialNoValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSerialNoValue.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblModelValue
            // 
            this.lblModelValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModelValue.AutoSize = true;
            this.lblModelValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblModelValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblModelValue.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelValue.ForeColor = System.Drawing.Color.White;
            this.lblModelValue.Location = new System.Drawing.Point(126, 51);
            this.lblModelValue.Margin = new System.Windows.Forms.Padding(6);
            this.lblModelValue.Name = "lblModelValue";
            this.lblModelValue.Size = new System.Drawing.Size(162, 33);
            this.lblModelValue.TabIndex = 9;
            this.lblModelValue.Text = "-";
            this.lblModelValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblModelValue.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblManufacturer.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblManufacturer.ForeColor = System.Drawing.Color.White;
            this.lblManufacturer.Location = new System.Drawing.Point(3, 2);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(108, 40);
            this.lblManufacturer.TabIndex = 2;
            this.lblManufacturer.Text = "Manufacturer:";
            this.lblManufacturer.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblModel
            // 
            this.lblModel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblModel.AutoSize = true;
            this.lblModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblModel.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblModel.ForeColor = System.Drawing.Color.White;
            this.lblModel.Location = new System.Drawing.Point(3, 57);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(63, 20);
            this.lblModel.TabIndex = 3;
            this.lblModel.Text = "Model:";
            this.lblModel.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblSerialNo
            // 
            this.lblSerialNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSerialNo.AutoSize = true;
            this.lblSerialNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSerialNo.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblSerialNo.ForeColor = System.Drawing.Color.White;
            this.lblSerialNo.Location = new System.Drawing.Point(3, 102);
            this.lblSerialNo.Name = "lblSerialNo";
            this.lblSerialNo.Size = new System.Drawing.Size(99, 20);
            this.lblSerialNo.TabIndex = 4;
            this.lblSerialNo.Text = "Serial No:";
            this.lblSerialNo.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDate.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(3, 162);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(108, 20);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Start Date:";
            this.lblDate.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(3, 207);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(108, 20);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Start Time:";
            this.lblTime.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblManufacturerValue
            // 
            this.lblManufacturerValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblManufacturerValue.AutoSize = true;
            this.lblManufacturerValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblManufacturerValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblManufacturerValue.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManufacturerValue.ForeColor = System.Drawing.Color.White;
            this.lblManufacturerValue.Location = new System.Drawing.Point(126, 6);
            this.lblManufacturerValue.Margin = new System.Windows.Forms.Padding(6);
            this.lblManufacturerValue.Name = "lblManufacturerValue";
            this.lblManufacturerValue.Size = new System.Drawing.Size(162, 33);
            this.lblManufacturerValue.TabIndex = 8;
            this.lblManufacturerValue.Text = "-";
            this.lblManufacturerValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblManufacturerValue.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblDateValue
            // 
            this.lblDateValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateValue.AutoSize = true;
            this.lblDateValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDateValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDateValue.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateValue.ForeColor = System.Drawing.Color.White;
            this.lblDateValue.Location = new System.Drawing.Point(126, 156);
            this.lblDateValue.Margin = new System.Windows.Forms.Padding(6);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(162, 33);
            this.lblDateValue.TabIndex = 11;
            this.lblDateValue.Text = "-";
            this.lblDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDateValue.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblTimeValue
            // 
            this.lblTimeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeValue.AutoSize = true;
            this.lblTimeValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTimeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTimeValue.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeValue.ForeColor = System.Drawing.Color.White;
            this.lblTimeValue.Location = new System.Drawing.Point(126, 201);
            this.lblTimeValue.Margin = new System.Windows.Forms.Padding(6);
            this.lblTimeValue.Name = "lblTimeValue";
            this.lblTimeValue.Size = new System.Drawing.Size(162, 33);
            this.lblTimeValue.TabIndex = 12;
            this.lblTimeValue.Text = "-";
            this.lblTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTimeValue.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblDuration
            // 
            this.lblDuration.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDuration.AutoSize = true;
            this.lblDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDuration.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblDuration.ForeColor = System.Drawing.Color.White;
            this.lblDuration.Location = new System.Drawing.Point(3, 252);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(90, 20);
            this.lblDuration.TabIndex = 16;
            this.lblDuration.Text = "Duration:";
            this.lblDuration.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblPassRate
            // 
            this.lblPassRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPassRate.AutoSize = true;
            this.lblPassRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPassRate.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblPassRate.ForeColor = System.Drawing.Color.White;
            this.lblPassRate.Location = new System.Drawing.Point(3, 297);
            this.lblPassRate.Name = "lblPassRate";
            this.lblPassRate.Size = new System.Drawing.Size(99, 20);
            this.lblPassRate.TabIndex = 15;
            this.lblPassRate.Text = "Pass Rate:";
            this.lblPassRate.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblDurationTimer
            // 
            this.lblDurationTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDurationTimer.AutoSize = true;
            this.lblDurationTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDurationTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDurationTimer.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurationTimer.ForeColor = System.Drawing.Color.White;
            this.lblDurationTimer.Location = new System.Drawing.Point(126, 246);
            this.lblDurationTimer.Margin = new System.Windows.Forms.Padding(6);
            this.lblDurationTimer.Name = "lblDurationTimer";
            this.lblDurationTimer.Size = new System.Drawing.Size(162, 33);
            this.lblDurationTimer.TabIndex = 17;
            this.lblDurationTimer.Text = "00:00.000";
            this.lblDurationTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDurationTimer.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblPassRateValue
            // 
            this.lblPassRateValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPassRateValue.AutoSize = true;
            this.lblPassRateValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPassRateValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPassRateValue.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassRateValue.ForeColor = System.Drawing.Color.White;
            this.lblPassRateValue.Location = new System.Drawing.Point(126, 291);
            this.lblPassRateValue.Margin = new System.Windows.Forms.Padding(6);
            this.lblPassRateValue.Name = "lblPassRateValue";
            this.lblPassRateValue.Size = new System.Drawing.Size(162, 33);
            this.lblPassRateValue.TabIndex = 18;
            this.lblPassRateValue.Text = "-/-";
            this.lblPassRateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPassRateValue.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // calibrationPanel
            // 
            this.calibrationPanel.AutoSize = true;
            this.calibrationPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.calibrationPanel.ColumnCount = 4;
            this.sidePanel.SetColumnSpan(this.calibrationPanel, 2);
            this.calibrationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.calibrationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.calibrationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.calibrationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.calibrationPanel.Controls.Add(this.lblSADUTCalDate, 3, 2);
            this.calibrationPanel.Controls.Add(this.lblSGDUTCalDate, 1, 2);
            this.calibrationPanel.Controls.Add(this.lblSGDUT, 0, 2);
            this.calibrationPanel.Controls.Add(this.lblSADUT, 2, 2);
            this.calibrationPanel.Controls.Add(this.btnLoadCal, 0, 1);
            this.calibrationPanel.Controls.Add(this.btnCalibrate, 0, 0);
            this.calibrationPanel.Controls.Add(this.calFilePanel, 1, 1);
            this.calibrationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibrationPanel.Location = new System.Drawing.Point(0, 340);
            this.calibrationPanel.Margin = new System.Windows.Forms.Padding(0);
            this.calibrationPanel.Name = "calibrationPanel";
            this.calibrationPanel.RowCount = 3;
            this.calibrationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.calibrationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.calibrationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.calibrationPanel.Size = new System.Drawing.Size(294, 85);
            this.calibrationPanel.TabIndex = 19;
            // 
            // lblSADUTCalDate
            // 
            this.lblSADUTCalDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSADUTCalDate.AutoSize = true;
            this.lblSADUTCalDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSADUTCalDate.Font = new System.Drawing.Font("Consolas", 7F);
            this.lblSADUTCalDate.ForeColor = System.Drawing.Color.Yellow;
            this.lblSADUTCalDate.Location = new System.Drawing.Point(195, 59);
            this.lblSADUTCalDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblSADUTCalDate.Name = "lblSADUTCalDate";
            this.lblSADUTCalDate.Size = new System.Drawing.Size(14, 26);
            this.lblSADUTCalDate.TabIndex = 14;
            this.lblSADUTCalDate.Text = "-";
            this.lblSADUTCalDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSGDUTCalDate
            // 
            this.lblSGDUTCalDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSGDUTCalDate.AutoSize = true;
            this.lblSGDUTCalDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSGDUTCalDate.Font = new System.Drawing.Font("Consolas", 7F);
            this.lblSGDUTCalDate.ForeColor = System.Drawing.Color.Yellow;
            this.lblSGDUTCalDate.Location = new System.Drawing.Point(49, 59);
            this.lblSGDUTCalDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblSGDUTCalDate.Name = "lblSGDUTCalDate";
            this.lblSGDUTCalDate.Size = new System.Drawing.Size(14, 26);
            this.lblSGDUTCalDate.TabIndex = 11;
            this.lblSGDUTCalDate.Text = "-";
            this.lblSGDUTCalDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSGDUT
            // 
            this.lblSGDUT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSGDUT.AutoSize = true;
            this.lblSGDUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSGDUT.Font = new System.Drawing.Font("Consolas", 7F);
            this.lblSGDUT.ForeColor = System.Drawing.Color.Yellow;
            this.lblSGDUT.Location = new System.Drawing.Point(0, 59);
            this.lblSGDUT.Margin = new System.Windows.Forms.Padding(0);
            this.lblSGDUT.Name = "lblSGDUT";
            this.lblSGDUT.Size = new System.Drawing.Size(49, 26);
            this.lblSGDUT.TabIndex = 15;
            this.lblSGDUT.Text = "SG-DUT:";
            this.lblSGDUT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSADUT
            // 
            this.lblSADUT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSADUT.AutoSize = true;
            this.lblSADUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSADUT.Font = new System.Drawing.Font("Consolas", 7F);
            this.lblSADUT.ForeColor = System.Drawing.Color.Yellow;
            this.lblSADUT.Location = new System.Drawing.Point(146, 59);
            this.lblSADUT.Margin = new System.Windows.Forms.Padding(0);
            this.lblSADUT.Name = "lblSADUT";
            this.lblSADUT.Size = new System.Drawing.Size(49, 26);
            this.lblSADUT.TabIndex = 16;
            this.lblSADUT.Text = "SA-DUT:";
            this.lblSADUT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLoadCal
            // 
            this.btnLoadCal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoadCal.AutoSize = true;
            this.btnLoadCal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoadCal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnLoadCal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadCal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadCal.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.btnLoadCal.ForeColor = System.Drawing.Color.LightGray;
            this.btnLoadCal.Location = new System.Drawing.Point(1, 34);
            this.btnLoadCal.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoadCal.Name = "btnLoadCal";
            this.btnLoadCal.Size = new System.Drawing.Size(47, 25);
            this.btnLoadCal.TabIndex = 19;
            this.btnLoadCal.Text = "Load";
            this.btnLoadCal.UseVisualStyleBackColor = false;
            this.btnLoadCal.Click += new System.EventHandler(this.btnLoadCal_Click);
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCalibrate.AutoSize = true;
            this.btnCalibrate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCalibrate.BackColor = System.Drawing.Color.Gold;
            this.calibrationPanel.SetColumnSpan(this.btnCalibrate, 4);
            this.btnCalibrate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalibrate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalibrate.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalibrate.Location = new System.Drawing.Point(99, 3);
            this.btnCalibrate.Margin = new System.Windows.Forms.Padding(0);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(96, 27);
            this.btnCalibrate.TabIndex = 12;
            this.btnCalibrate.Text = "Calibration";
            this.btnCalibrate.UseVisualStyleBackColor = false;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // calFilePanel
            // 
            this.calFilePanel.ColumnCount = 2;
            this.calibrationPanel.SetColumnSpan(this.calFilePanel, 3);
            this.calFilePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.calFilePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.calFilePanel.Controls.Add(this.lblCalFileName, 0, 0);
            this.calFilePanel.Controls.Add(this.btnClearCalibration, 1, 0);
            this.calFilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calFilePanel.Location = new System.Drawing.Point(49, 34);
            this.calFilePanel.Margin = new System.Windows.Forms.Padding(0);
            this.calFilePanel.Name = "calFilePanel";
            this.calFilePanel.RowCount = 1;
            this.calFilePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.calFilePanel.Size = new System.Drawing.Size(245, 25);
            this.calFilePanel.TabIndex = 20;
            // 
            // lblCalFileName
            // 
            this.lblCalFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCalFileName.AutoEllipsis = true;
            this.lblCalFileName.AutoSize = true;
            this.lblCalFileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblCalFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCalFileName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCalFileName.Font = new System.Drawing.Font("Consolas", 7F);
            this.lblCalFileName.ForeColor = System.Drawing.Color.LightGray;
            this.lblCalFileName.Location = new System.Drawing.Point(0, 0);
            this.lblCalFileName.Margin = new System.Windows.Forms.Padding(0);
            this.lblCalFileName.Name = "lblCalFileName";
            this.lblCalFileName.Size = new System.Drawing.Size(245, 25);
            this.lblCalFileName.TabIndex = 18;
            this.lblCalFileName.Text = "-";
            this.lblCalFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCalFileName.TextChanged += new System.EventHandler(this.lblCalFileName_TextChanged);
            // 
            // btnClearCalibration
            // 
            this.btnClearCalibration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnClearCalibration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearCalibration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearCalibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCalibration.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.btnClearCalibration.ForeColor = System.Drawing.Color.LightGray;
            this.btnClearCalibration.Location = new System.Drawing.Point(245, 0);
            this.btnClearCalibration.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearCalibration.Name = "btnClearCalibration";
            this.btnClearCalibration.Size = new System.Drawing.Size(1, 25);
            this.btnClearCalibration.TabIndex = 19;
            this.btnClearCalibration.Text = "✖";
            this.btnClearCalibration.UseVisualStyleBackColor = false;
            this.btnClearCalibration.Click += new System.EventHandler(this.btnClearCalibration_Click);
            // 
            // panelStartStop
            // 
            this.panelStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStartStop.AutoSize = true;
            this.panelStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sidePanel.SetColumnSpan(this.panelStartStop, 2);
            this.panelStartStop.Controls.Add(this.cbRout);
            this.panelStartStop.Controls.Add(this.lblRout);
            this.panelStartStop.Controls.Add(this.btnSetupImage);
            this.panelStartStop.Controls.Add(this.loadingConnectPic);
            this.panelStartStop.Controls.Add(this.btnStartStop);
            this.panelStartStop.Location = new System.Drawing.Point(0, 640);
            this.panelStartStop.Margin = new System.Windows.Forms.Padding(0);
            this.panelStartStop.Name = "panelStartStop";
            this.panelStartStop.Padding = new System.Windows.Forms.Padding(90, 8, 90, 8);
            this.panelStartStop.Size = new System.Drawing.Size(294, 63);
            this.panelStartStop.TabIndex = 13;
            // 
            // cbRout
            // 
            this.cbRout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbRout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbRout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRout.Font = new System.Drawing.Font("Consolas", 6.5F);
            this.cbRout.ForeColor = System.Drawing.Color.White;
            this.cbRout.FormattingEnabled = true;
            this.cbRout.Items.AddRange(new object[] {
            "",
            "1",
            "12",
            "11",
            "13",
            "14"});
            this.cbRout.Location = new System.Drawing.Point(41, 29);
            this.cbRout.Margin = new System.Windows.Forms.Padding(0);
            this.cbRout.MaxDropDownItems = 5;
            this.cbRout.Name = "cbRout";
            this.cbRout.Size = new System.Drawing.Size(42, 21);
            this.cbRout.TabIndex = 173;
            this.cbRout.Visible = false;
            this.cbRout.TextChanged += new System.EventHandler(this.cbRout_TextChanged);
            // 
            // lblRout
            // 
            this.lblRout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRout.AutoSize = true;
            this.lblRout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRout.Font = new System.Drawing.Font("Consolas", 7F);
            this.lblRout.ForeColor = System.Drawing.Color.White;
            this.lblRout.Location = new System.Drawing.Point(39, 15);
            this.lblRout.Margin = new System.Windows.Forms.Padding(0);
            this.lblRout.Name = "lblRout";
            this.lblRout.Size = new System.Drawing.Size(42, 14);
            this.lblRout.TabIndex = 174;
            this.lblRout.Text = "ROUT:";
            this.lblRout.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblRout.Visible = false;
            // 
            // btnSetupImage
            // 
            this.btnSetupImage.AutoSize = true;
            this.btnSetupImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSetupImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSetupImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetupImage.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Bold);
            this.btnSetupImage.ForeColor = System.Drawing.Color.LightGray;
            this.btnSetupImage.Image = ((System.Drawing.Image)(resources.GetObject("btnSetupImage.Image")));
            this.btnSetupImage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSetupImage.Location = new System.Drawing.Point(227, 29);
            this.btnSetupImage.Name = "btnSetupImage";
            this.btnSetupImage.Size = new System.Drawing.Size(67, 26);
            this.btnSetupImage.TabIndex = 172;
            this.btnSetupImage.Text = "Setup";
            this.btnSetupImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSetupImage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSetupImage.UseVisualStyleBackColor = false;
            this.btnSetupImage.Click += new System.EventHandler(this.btnSetupImage_Click);
            // 
            // loadingConnectPic
            // 
            this.loadingConnectPic.BackColor = System.Drawing.Color.Silver;
            this.loadingConnectPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loadingConnectPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loadingConnectPic.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.loadingConnectPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadingConnectPic.Image = global::Pegatron.Properties.Resources.loadanimation;
            this.loadingConnectPic.InitialImage = global::Pegatron.Properties.Resources.loadanimation;
            this.loadingConnectPic.Location = new System.Drawing.Point(90, 8);
            this.loadingConnectPic.Margin = new System.Windows.Forms.Padding(90, 8, 90, 8);
            this.loadingConnectPic.Name = "loadingConnectPic";
            this.loadingConnectPic.Size = new System.Drawing.Size(114, 47);
            this.loadingConnectPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingConnectPic.TabIndex = 171;
            this.loadingConnectPic.TabStop = false;
            this.loadingConnectPic.Visible = false;
            this.loadingConnectPic.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // btnStartStop
            // 
            this.btnStartStop.AutoSize = true;
            this.btnStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartStop.BackColor = System.Drawing.Color.LimeGreen;
            this.btnStartStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStop.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.btnStartStop.Location = new System.Drawing.Point(90, 8);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(90, 8, 90, 8);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(114, 47);
            this.btnStartStop.TabIndex = 1;
            this.btnStartStop.Text = "▶ START";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // labelTestDelay
            // 
            this.labelTestDelay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTestDelay.AutoSize = true;
            this.labelTestDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTestDelay.Font = new System.Drawing.Font("Consolas", 10F);
            this.labelTestDelay.ForeColor = System.Drawing.Color.White;
            this.labelTestDelay.Location = new System.Drawing.Point(3, 462);
            this.labelTestDelay.Name = "labelTestDelay";
            this.labelTestDelay.Size = new System.Drawing.Size(108, 20);
            this.labelTestDelay.TabIndex = 20;
            this.labelTestDelay.Text = "Test Delay:";
            // 
            // tableLayoutPanelDelayHeader
            // 
            this.tableLayoutPanelDelayHeader.ColumnCount = 2;
            this.tableLayoutPanelDelayHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDelayHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDelayHeader.Controls.Add(this.labelStep, 0, 0);
            this.tableLayoutPanelDelayHeader.Controls.Add(this.labelInitialize, 0, 0);
            this.tableLayoutPanelDelayHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDelayHeader.Location = new System.Drawing.Point(120, 425);
            this.tableLayoutPanelDelayHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelDelayHeader.Name = "tableLayoutPanelDelayHeader";
            this.tableLayoutPanelDelayHeader.RowCount = 1;
            this.tableLayoutPanelDelayHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDelayHeader.Size = new System.Drawing.Size(174, 25);
            this.tableLayoutPanelDelayHeader.TabIndex = 0;
            // 
            // labelStep
            // 
            this.labelStep.AutoSize = true;
            this.labelStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStep.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelStep.ForeColor = System.Drawing.Color.White;
            this.labelStep.Location = new System.Drawing.Point(87, 0);
            this.labelStep.Margin = new System.Windows.Forms.Padding(0);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(87, 25);
            this.labelStep.TabIndex = 17;
            this.labelStep.Text = "Step";
            this.labelStep.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelInitialize
            // 
            this.labelInitialize.AutoSize = true;
            this.labelInitialize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelInitialize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInitialize.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelInitialize.ForeColor = System.Drawing.Color.White;
            this.labelInitialize.Location = new System.Drawing.Point(0, 0);
            this.labelInitialize.Margin = new System.Windows.Forms.Padding(0);
            this.labelInitialize.Name = "labelInitialize";
            this.labelInitialize.Size = new System.Drawing.Size(87, 25);
            this.labelInitialize.TabIndex = 16;
            this.labelInitialize.Text = "Initialize";
            this.labelInitialize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dataGridTestResult
            // 
            this.dataGridTestResult.AllowUserToAddRows = false;
            this.dataGridTestResult.AllowUserToDeleteRows = false;
            this.dataGridTestResult.AllowUserToResizeRows = false;
            this.dataGridTestResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTestResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dataGridTestResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTestResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridTestResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridTestResult.Location = new System.Drawing.Point(300, 44);
            this.dataGridTestResult.Margin = new System.Windows.Forms.Padding(0, 4, 9, 5);
            this.dataGridTestResult.Name = "dataGridTestResult";
            this.dataGridTestResult.ReadOnly = true;
            this.dataGridTestResult.RowHeadersVisible = false;
            this.dataGridTestResult.RowHeadersWidth = 51;
            this.dataGridTestResult.RowTemplate.Height = 24;
            this.dataGridTestResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridTestResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTestResult.ShowCellErrors = false;
            this.dataGridTestResult.ShowCellToolTips = false;
            this.dataGridTestResult.ShowEditingIcon = false;
            this.dataGridTestResult.ShowRowErrors = false;
            this.dataGridTestResult.Size = new System.Drawing.Size(703, 701);
            this.dataGridTestResult.TabIndex = 1;
            this.dataGridTestResult.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridTestResult_CellFormatting);
            this.dataGridTestResult.Leave += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // panelConnectivity
            // 
            this.panelConnectivity.AutoSize = true;
            this.panelConnectivity.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelConnectivity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panelConnectivity.ColumnCount = 11;
            this.mainPanel.SetColumnSpan(this.panelConnectivity, 2);
            this.panelConnectivity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.panelConnectivity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.panelConnectivity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.panelConnectivity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.panelConnectivity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.panelConnectivity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.panelConnectivity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelConnectivity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.panelConnectivity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.panelConnectivity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.panelConnectivity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.panelConnectivity.Controls.Add(this.lblPSConnectivity, 4, 0);
            this.panelConnectivity.Controls.Add(this.lblSAConnectivity, 3, 0);
            this.panelConnectivity.Controls.Add(this.lblSGConnectivity, 2, 0);
            this.panelConnectivity.Controls.Add(this.lblDUTConnectivity, 1, 0);
            this.panelConnectivity.Controls.Add(this.picRefreshBtn, 0, 0);
            this.panelConnectivity.Controls.Add(this.lblSwitchConnectivity, 5, 0);
            this.panelConnectivity.Controls.Add(this.button1, 7, 0);
            this.panelConnectivity.Controls.Add(this.button2, 8, 0);
            this.panelConnectivity.Controls.Add(this.btnDebugStart, 9, 0);
            this.panelConnectivity.Controls.Add(this.lblDebug, 6, 0);
            this.panelConnectivity.Controls.Add(this.button3, 10, 0);
            this.panelConnectivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConnectivity.Location = new System.Drawing.Point(0, 750);
            this.panelConnectivity.Margin = new System.Windows.Forms.Padding(0);
            this.panelConnectivity.Name = "panelConnectivity";
            this.panelConnectivity.RowCount = 1;
            this.panelConnectivity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelConnectivity.Size = new System.Drawing.Size(1012, 40);
            this.panelConnectivity.TabIndex = 2;
            this.panelConnectivity.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblPSConnectivity
            // 
            this.lblPSConnectivity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPSConnectivity.AutoSize = true;
            this.lblPSConnectivity.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPSConnectivity.ForeColor = System.Drawing.Color.Red;
            this.lblPSConnectivity.Location = new System.Drawing.Point(199, 9);
            this.lblPSConnectivity.Name = "lblPSConnectivity";
            this.lblPSConnectivity.Size = new System.Drawing.Size(30, 22);
            this.lblPSConnectivity.TabIndex = 19;
            this.lblPSConnectivity.Text = "PS";
            this.lblPSConnectivity.ForeColorChanged += new System.EventHandler(this.ConnectivityUpdated);
            this.lblPSConnectivity.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblSAConnectivity
            // 
            this.lblSAConnectivity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSAConnectivity.AutoSize = true;
            this.lblSAConnectivity.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSAConnectivity.ForeColor = System.Drawing.Color.Red;
            this.lblSAConnectivity.Location = new System.Drawing.Point(149, 9);
            this.lblSAConnectivity.Name = "lblSAConnectivity";
            this.lblSAConnectivity.Size = new System.Drawing.Size(30, 22);
            this.lblSAConnectivity.TabIndex = 2;
            this.lblSAConnectivity.Text = "SA";
            this.lblSAConnectivity.ForeColorChanged += new System.EventHandler(this.ConnectivityUpdated);
            this.lblSAConnectivity.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblSGConnectivity
            // 
            this.lblSGConnectivity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSGConnectivity.AutoSize = true;
            this.lblSGConnectivity.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSGConnectivity.ForeColor = System.Drawing.Color.Red;
            this.lblSGConnectivity.Location = new System.Drawing.Point(99, 9);
            this.lblSGConnectivity.Name = "lblSGConnectivity";
            this.lblSGConnectivity.Size = new System.Drawing.Size(30, 22);
            this.lblSGConnectivity.TabIndex = 0;
            this.lblSGConnectivity.Text = "SG";
            this.lblSGConnectivity.ForeColorChanged += new System.EventHandler(this.ConnectivityUpdated);
            this.lblSGConnectivity.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // lblDUTConnectivity
            // 
            this.lblDUTConnectivity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDUTConnectivity.AutoSize = true;
            this.lblDUTConnectivity.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDUTConnectivity.ForeColor = System.Drawing.Color.Red;
            this.lblDUTConnectivity.Location = new System.Drawing.Point(44, 9);
            this.lblDUTConnectivity.Name = "lblDUTConnectivity";
            this.lblDUTConnectivity.Size = new System.Drawing.Size(40, 22);
            this.lblDUTConnectivity.TabIndex = 1;
            this.lblDUTConnectivity.Text = "DUT";
            this.lblDUTConnectivity.ForeColorChanged += new System.EventHandler(this.ConnectivityUpdated);
            this.lblDUTConnectivity.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // picRefreshBtn
            // 
            this.picRefreshBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picRefreshBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.picRefreshBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRefreshBtn.Image = global::Pegatron.Properties.Resources.refresh_2_24;
            this.picRefreshBtn.InitialImage = null;
            this.picRefreshBtn.Location = new System.Drawing.Point(12, 12);
            this.picRefreshBtn.Margin = new System.Windows.Forms.Padding(0);
            this.picRefreshBtn.Name = "picRefreshBtn";
            this.picRefreshBtn.Size = new System.Drawing.Size(15, 15);
            this.picRefreshBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRefreshBtn.TabIndex = 172;
            this.picRefreshBtn.TabStop = false;
            this.picRefreshBtn.Click += new System.EventHandler(this.picRefreshBtn_Click);
            // 
            // lblSwitchConnectivity
            // 
            this.lblSwitchConnectivity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSwitchConnectivity.AutoSize = true;
            this.lblSwitchConnectivity.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwitchConnectivity.ForeColor = System.Drawing.Color.Red;
            this.lblSwitchConnectivity.Location = new System.Drawing.Point(246, 9);
            this.lblSwitchConnectivity.Name = "lblSwitchConnectivity";
            this.lblSwitchConnectivity.Size = new System.Drawing.Size(70, 22);
            this.lblSwitchConnectivity.TabIndex = 19;
            this.lblSwitchConnectivity.Text = "Switch";
            this.lblSwitchConnectivity.ForeColorChanged += new System.EventHandler(this.ConnectivityUpdated);
            this.lblSwitchConnectivity.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(735, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 34);
            this.button1.TabIndex = 173;
            this.button1.Text = "Port 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(795, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 34);
            this.button2.TabIndex = 174;
            this.button2.Text = "Port 3";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDebugStart
            // 
            this.btnDebugStart.BackColor = System.Drawing.SystemColors.Control;
            this.btnDebugStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDebugStart.Font = new System.Drawing.Font("Consolas", 6.5F);
            this.btnDebugStart.Location = new System.Drawing.Point(855, 3);
            this.btnDebugStart.Name = "btnDebugStart";
            this.btnDebugStart.Size = new System.Drawing.Size(54, 34);
            this.btnDebugStart.TabIndex = 175;
            this.btnDebugStart.Text = "Debug";
            this.btnDebugStart.UseVisualStyleBackColor = false;
            this.btnDebugStart.Click += new System.EventHandler(this.btnDebugStart_Click);
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDebug.ForeColor = System.Drawing.Color.Gold;
            this.lblDebug.Location = new System.Drawing.Point(327, 0);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(402, 40);
            this.lblDebug.TabIndex = 176;
            this.lblDebug.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDebug.Click += new System.EventHandler(this.lblDebug_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(915, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 177;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panelCSV
            // 
            this.panelCSV.AutoSize = true;
            this.panelCSV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelCSV.ColumnCount = 3;
            this.mainPanel.SetColumnSpan(this.panelCSV, 2);
            this.panelCSV.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.panelCSV.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.panelCSV.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelCSV.Controls.Add(this.btnLoadSpecFile, 1, 0);
            this.panelCSV.Controls.Add(this.lblSpecAddress, 2, 0);
            this.panelCSV.Controls.Add(this.btnGenerateNewTemplate, 0, 0);
            this.panelCSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCSV.Location = new System.Drawing.Point(0, 0);
            this.panelCSV.Margin = new System.Windows.Forms.Padding(0);
            this.panelCSV.Name = "panelCSV";
            this.panelCSV.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.panelCSV.RowCount = 1;
            this.panelCSV.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelCSV.Size = new System.Drawing.Size(1012, 40);
            this.panelCSV.TabIndex = 3;
            this.panelCSV.Click += new System.EventHandler(this.dataGridTestResult_Leave);
            // 
            // btnLoadSpecFile
            // 
            this.btnLoadSpecFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadSpecFile.AutoSize = true;
            this.btnLoadSpecFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoadSpecFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnLoadSpecFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadSpecFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadSpecFile.Font = new System.Drawing.Font("Consolas", 9F);
            this.btnLoadSpecFile.ForeColor = System.Drawing.Color.LightGray;
            this.btnLoadSpecFile.Location = new System.Drawing.Point(228, 9);
            this.btnLoadSpecFile.Margin = new System.Windows.Forms.Padding(0, 9, 8, 4);
            this.btnLoadSpecFile.Name = "btnLoadSpecFile";
            this.btnLoadSpecFile.Size = new System.Drawing.Size(172, 27);
            this.btnLoadSpecFile.TabIndex = 2;
            this.btnLoadSpecFile.Text = "Load Spec File";
            this.btnLoadSpecFile.UseVisualStyleBackColor = false;
            this.btnLoadSpecFile.Click += new System.EventHandler(this.btnLoadSpecFile_Click);
            // 
            // lblSpecAddress
            // 
            this.lblSpecAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpecAddress.AutoEllipsis = true;
            this.lblSpecAddress.AutoSize = true;
            this.lblSpecAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblSpecAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSpecAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSpecAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSpecAddress.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblSpecAddress.ForeColor = System.Drawing.Color.LightGray;
            this.lblSpecAddress.Location = new System.Drawing.Point(416, 9);
            this.lblSpecAddress.Margin = new System.Windows.Forms.Padding(8, 9, 0, 4);
            this.lblSpecAddress.Name = "lblSpecAddress";
            this.lblSpecAddress.Size = new System.Drawing.Size(588, 27);
            this.lblSpecAddress.TabIndex = 0;
            this.lblSpecAddress.Text = "-";
            this.lblSpecAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSpecAddress.TextChanged += new System.EventHandler(this.lblSpecAddress_TextChanged);
            this.lblSpecAddress.Click += new System.EventHandler(this.lblSpecAddress_Click);
            // 
            // btnGenerateNewTemplate
            // 
            this.btnGenerateNewTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateNewTemplate.AutoSize = true;
            this.btnGenerateNewTemplate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGenerateNewTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnGenerateNewTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateNewTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateNewTemplate.Font = new System.Drawing.Font("Consolas", 9F);
            this.btnGenerateNewTemplate.ForeColor = System.Drawing.Color.LightGray;
            this.btnGenerateNewTemplate.Location = new System.Drawing.Point(8, 9);
            this.btnGenerateNewTemplate.Margin = new System.Windows.Forms.Padding(0, 9, 8, 4);
            this.btnGenerateNewTemplate.Name = "btnGenerateNewTemplate";
            this.btnGenerateNewTemplate.Size = new System.Drawing.Size(212, 27);
            this.btnGenerateNewTemplate.TabIndex = 1;
            this.btnGenerateNewTemplate.Text = "Generate Spec Template";
            this.btnGenerateNewTemplate.UseVisualStyleBackColor = false;
            this.btnGenerateNewTemplate.Click += new System.EventHandler(this.btnGenerateNewTemplate_Click);
            // 
            // dialogOpenSpecFile
            // 
            this.dialogOpenSpecFile.DefaultExt = "csv";
            this.dialogOpenSpecFile.Filter = "CSV files (*.csv)|*.csv";
            this.dialogOpenSpecFile.RestoreDirectory = true;
            this.dialogOpenSpecFile.ShowHelp = true;
            this.dialogOpenSpecFile.Title = "Load Specification.csv file";
            // 
            // timerDuration
            // 
            this.timerDuration.Tick += new System.EventHandler(this.timerDuration_Tick);
            // 
            // dialogOpenCalFile
            // 
            this.dialogOpenCalFile.DefaultExt = "csv";
            this.dialogOpenCalFile.Filter = "CSV files (*.csv)|*.csv";
            this.dialogOpenCalFile.RestoreDirectory = true;
            this.dialogOpenCalFile.ShowHelp = true;
            this.dialogOpenCalFile.Title = "Load CalibrationData.csv file";
            // 
            // LitepointHealthCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1012, 790);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(18, 750);
            this.Name = "LitepointHealthCheck";
            this.Opacity = 0D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Litepoint Health Check";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LitepointHealthCheck_FormClosing);
            this.Load += new System.EventHandler(this.LitepointHealthCheck_Load);
            this.Leave += new System.EventHandler(this.LitepointHealthCheck_Leave);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            this.tableLayoutPanelDelayTextBox.ResumeLayout(false);
            this.panelStep.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).EndInit();
            this.panelInitialize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitialize)).EndInit();
            this.panelLPVSG.ResumeLayout(false);
            this.panelLPVSG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLPVSGFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLPVSGLevel)).EndInit();
            this.calibrationPanel.ResumeLayout(false);
            this.calibrationPanel.PerformLayout();
            this.calFilePanel.ResumeLayout(false);
            this.calFilePanel.PerformLayout();
            this.panelStartStop.ResumeLayout(false);
            this.panelStartStop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingConnectPic)).EndInit();
            this.tableLayoutPanelDelayHeader.ResumeLayout(false);
            this.tableLayoutPanelDelayHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTestResult)).EndInit();
            this.panelConnectivity.ResumeLayout(false);
            this.panelConnectivity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshBtn)).EndInit();
            this.panelCSV.ResumeLayout(false);
            this.panelCSV.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.TableLayoutPanel sidePanel;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblSerialNo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblManufacturerValue;
        private System.Windows.Forms.Label lblModelValue;
        private System.Windows.Forms.Label lblSerialNoValue;
        private System.Windows.Forms.Label lblDateValue;
        private System.Windows.Forms.Label lblTimeValue;
        private System.Windows.Forms.DataGridView dataGridTestResult;
        private Panel panelStartStop;
        private PictureBox loadingConnectPic;
        private Button btnStartStop;
        private TableLayoutPanel panelConnectivity;
        private Label lblSAConnectivity;
        private Label lblSGConnectivity;
        private Label lblDUTConnectivity;
        private PictureBox picRefreshBtn;
        private TableLayoutPanel panelCSV;
        private Label lblSpecAddress;
        private Button btnGenerateNewTemplate;
        private Button btnLoadSpecFile;
        private OpenFileDialog dialogOpenSpecFile;
        private Label lblDuration;
        private Label lblPassRate;
        private Label lblDurationTimer;
        private Label lblPassRateValue;
        private Timer timerDuration;
        private Label lblSwitchConnectivity;
        private Label lblPSConnectivity;
        private TableLayoutPanel calibrationPanel;
        private Label lblSGDUTCalDate;
        private Button btnCalibrate;
        private Label lblSADUTCalDate;
        private OpenFileDialog dialogOpenCalFile;
        private Label lblSGDUT;
        private Label lblSADUT;
        private Label lblCalFileName;
        private Button btnLoadCal;
        private Button button1;
        private Button button2;
        private Button btnDebugStart;
        private Label lblDebug;
        private TableLayoutPanel calFilePanel;
        private Button btnClearCalibration;
        private Button btnSetupImage;
        private Label labelTestDelay;
        private TableLayoutPanel tableLayoutPanelDelayHeader;
        private TableLayoutPanel tableLayoutPanelDelayTextBox;
        private Label labelStep;
        private Label labelInitialize;
        private Panel panelInitialize;
        private NumericUpDown numericUpDownInitialize;
        private Panel panelStep;
        private NumericUpDown numericUpDownStep;
        private ComboBox cbRout;
        private Label lblRout;
        private Button button3;
        private System.Windows.Forms.Panel panelLPVSG;
        private System.Windows.Forms.Label lblLPVSGTitle;
        private System.Windows.Forms.Label lblLPVSGFreq;
        private System.Windows.Forms.NumericUpDown numericLPVSGFreq;
        private System.Windows.Forms.Label lblLPVSGFreqUnit;
        private System.Windows.Forms.Label lblLPVSGLevel;
        private System.Windows.Forms.NumericUpDown numericLPVSGLevel;
        private System.Windows.Forms.Label lblLPVSGLevelUnit;
        private System.Windows.Forms.Label lblLPVSGPort;
        private System.Windows.Forms.ComboBox cbLPVSGPort;
        private System.Windows.Forms.Button btnLPVSGOn;
        private System.Windows.Forms.Button btnLPVSGOff;
    }
}

