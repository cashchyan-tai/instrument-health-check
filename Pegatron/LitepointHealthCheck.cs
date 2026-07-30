using Pegatron.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Timer = System.Windows.Forms.Timer;

namespace Pegatron
{
    public partial class LitepointHealthCheck : Form
    {
        private CalibrationForm calibrationForm;
        private DiagramPopupForm setupDiagram;

        private DataTable dtTestResult;
        public TestData csvSpec = new TestData();
        public CalibrateConfig ConfigCAL = new CalibrateConfig();

        public SignalGenerator SG = new SignalGenerator();
        public IDUTInstrument DUTCommTester = new LitePointDUT();
        public PowerSensor PS = new PowerSensor();
        public SpectrumAnalyzer SA = new SpectrumAnalyzer();
        public ISwitchBox SwitchBox = new Switch();

        public bool SGConnected = false;
        public bool PSConnected = false;
        public bool DUTConnected = false;
        public bool SAConnected = false;
        public bool SwitchConnected = false;
        public bool isTesting = false;

        private Thread testThread;
        private DateTime startDT;
        private string fileName = "";
        private int totalPassTest = 0;
        private int isConnecting = 0;
        private bool switchPortSet = false;
        private string rout = "";

        public bool isDebug = false;
        public bool isVerify = false;
        public bool isPauseMode = false;
        //private bool noError = true;

        public LitepointHealthCheck()
        {
            InitializeComponent();

            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();

            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new Font("Consolas", 8F);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridTestResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle2.Font = new Font("Consolas", 8F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(4, 0, 4, 0);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            
            dataGridTestResult.DefaultCellStyle = dataGridViewCellStyle2;
            cbRout.SelectedIndex = 0;
            cbLPVSGPort.SelectedIndex = 0;
            lblDebug.Text = $"v{ProductVersion}";

            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                if (args.Name.Contains("System.Runtime.CompilerServices.Unsafe"))
                {
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "System.Runtime.CompilerServices.Unsafe.dll");
                    if (File.Exists(path))
                    {
                        return Assembly.LoadFrom(path);
                    }
                }
                return null;
            };
        }

        Timer t1 = new Timer();
        private void LitepointHealthCheck_Load(object sender, EventArgs e)
        {
            Opacity = 0;

            new Thread(delegate () { Invoke((MethodInvoker)(() => clearTable())); }).Start();
            btnSetupImage.Location = new System.Drawing.Point(panelStartStop.Width - btnSetupImage.Width - 3, btnStartStop.Location.Y + btnStartStop.Height - btnSetupImage.Height - 1);

            numericUpDownInitialize.Value = Settings.Default.delayInitialize;
            numericUpDownStep.Value = Settings.Default.delayStep;

            lblSpecAddress.Focus();

            t1.Interval = 10;  //increase opacity every 10ms
            t1.Tick += new EventHandler(fadeIn);  //change opacity 
            t1.Start();
        }
        void fadeIn(object sender, EventArgs e)
        {
            if (Opacity >= 1)
                t1.Stop();   //stops timer if form is completely displayed
            else
                Opacity += 0.05;
        }

        private void clearTable()
        {
            dtTestResult = new DataTable();
            dtTestResult.Columns.Add("Test");
            dtTestResult.Columns.Add("Setting");
            dtTestResult.Columns.Add("Reference\ndBm");
            dtTestResult.Columns.Add("Measured");
            dtTestResult.Columns.Add("Accuracy");
            dtTestResult.Columns.Add("PASS/\nFAIL");

            dataGridTestResult.DataSource = dtTestResult;

            for (int i = 0; i < dataGridTestResult.ColumnCount; i++)
            {
                dataGridTestResult.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                int fillWeight = -1;
                DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleCenter;
                switch (i)
                {
                    case 0:
                        fillWeight = 9;
                        align = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case 1:
                        fillWeight = 6;
                        align = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case 2:
                        fillWeight = 4;
                        break;
                    case 3:
                        fillWeight = 5;
                        break;
                    case 4:
                        fillWeight = 5;
                        break;
                    case 5:
                        fillWeight = 3;
                        break;
                }

                dataGridTestResult.Columns[i].FillWeight = fillWeight;
                dataGridTestResult.Columns[i].DefaultCellStyle.Alignment = align;
            }

            dataGridTestResult.ClearSelection();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            //checkExpiry();

            if (isTesting)
            {
                testThread.Abort();

                if (SGConnected)
                    SG.WriteScpi("OUTP OFF");

                timerDuration.Enabled = false;
                isTesting = false;
                btnStartStop.Text = "START";
                btnStartStop.BackColor = Color.LimeGreen;
                btnLoadSpecFile.Enabled = true;
                btnLoadCal.Enabled = true;

                DateTime finalTime = DateTime.Now;
                TimeSpan totalDuration = finalTime.Subtract(startDT);
                lblDurationTimer.Text = string.Format("{0}:{1}.{2}", totalDuration.Minutes.ToString("00"), totalDuration.Seconds.ToString("00"), totalDuration.Milliseconds.ToString("000"));
                lblPassRateValue.Text = totalPassTest + "/" + dtTestResult.Rows.Count;

                //Results.WriteResult(fileName, totalDuration, false, true);
                Results.createReport(dtTestResult, csvSpec, DUTCommTester, SG, SA, PS, SwitchBox, DateTime.Now, totalPassTest, totalDuration, true, isDebug);

                return;
            }

            if (lblSpecAddress.Text == "-")
            {
                MessageBoxManager.OK = "Load";
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("Please load a specification file to start testing", "No specifications loaded", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                MessageBoxManager.Unregister();
                if (dr == DialogResult.OK)
                    btnLoadSpecFile.PerformClick();

                return;
            }

            if (isDebug)
            {
                DUTConnected = true;
                SGConnected = true;
                SAConnected = true;
                SwitchConnected = true;
                PSConnected = true;
                lblDUTConnectivity.ForeColor = Color.LimeGreen;
                lblSGConnectivity.ForeColor = Color.LimeGreen;
                lblSAConnectivity.ForeColor = Color.LimeGreen;
                lblPSConnectivity.ForeColor = Color.LimeGreen;
                lblManufacturerValue.Text = "Rohde&Schwarz";
                lblModelValue.Text = "CMW100Test";
            }

            if (!isVerify)
            {
                if (!DUTConnected)
                {
                    MessageBox.Show("Please make sure DUT is connected", "DUT not connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (!string.IsNullOrEmpty(DUTCommTester.Model) && DUTCommTester.Model.Contains("IQXSTREAM-M"))
                {
                    //check spec file is IQXSTREAM format
                    if (!File.ReadLines(lblSpecAddress.Text).FirstOrDefault().Contains("(IQxstream-M)"))
                    {
                        MessageBox.Show("IQXSTREAM-M DUT must be tested using IQXSTREAM-M type spec file. Please select the correct spec file or generate a new one by clicking \"Generate Spec Template > IQXSTREAM-M\".", "ROUT number not entered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            if (File.ReadLines(lblSpecAddress.Text).FirstOrDefault().Contains("(IQxstream-M)") && string.IsNullOrEmpty(rout))
            {
                MessageBox.Show("Please select or enter ROUT number for IQXSTREAM-M type spec file test.", "ROUT number not entered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataRow row in dtTestResult.Rows)
            {
                row[3] = "";
                row[4] = "";
                row[5] = "";
            }

            dataGridTestResult.FirstDisplayedScrollingRowIndex = 0;
            totalPassTest = 0;
            isTesting = true;
            btnStartStop.Text = "STOP";
            btnStartStop.BackColor = Color.Red;
            btnLoadSpecFile.Enabled = false;
            btnLoadCal.Enabled = false;

            startDT = DateTime.Now;
            lblTimeValue.Text = startDT.ToString("HH:mm:ss");
            lblDateValue.Text = startDT.ToString("dd/MM/yy");

            timerDuration.Enabled = true;
            lblDurationTimer.Text = "00:00.000";

            int rowCount = 0;
            DateTime startTimeRef = DateTime.Now;

            //fileName = Results.CreateResults(DUTCommTester, SG, SA, SwitchBox, startDT);

            if (isVerify)
            {
                testThread = new Thread(delegate ()
                {
                    double loss = 0;
                    if (DUTConnected)
                        SG.Reset(); //Reset

                    ///VSG
                    //check if VSG power case is selected.
                    bool VSGPowerSelected = false;
                    bool VSGHighPowerSelected = false;
                    bool VSGLowPowerSelected = false;
                    bool VSGFrequencyAccuracySelected = false;
                    bool VSAPowerSelected = false;
                    for (int i = 0; i < 2; i++)//RF<i><j>
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (csvSpec.VSGHighPowerAccuracy.rfChannelIsOn[j, i])
                                VSGHighPowerSelected = true;
                            if (csvSpec.VSGLowPowerAccuracy.rfChannelIsOn[j, i])
                                VSGLowPowerSelected = true;
                            if (csvSpec.FrequencyAccuracy.rfChannelIsOn[j, i])
                                VSGFrequencyAccuracySelected = true;
                            if (csvSpec.VSAPowerAccuracy.rfChannelIsOn[j, i])
                                VSAPowerSelected = true;
                        }
                    }

                    if (VSGHighPowerSelected || VSGLowPowerSelected || VSGFrequencyAccuracySelected)
                    { 
                        VSGPowerSelected = true;
                        MessageBox.Show($"Verification Mode! Replace DUT with Signal Generator.", "Debug Verification");
                    }

                    if (VSGPowerSelected)
                    {
                        //debug
                        //SAConnected = true;
                        //SGConnected = true;
                        if (SAConnected && SGConnected)
                        {
                            do
                            {
                                switchPortSet = SwitchBox.SetPort(SwitchBox.PortSADUT);

                                if (!switchPortSet)
                                {
                                    DialogResult dr = MessageBox.Show("An error occured when changing the Switch Box port", "Changing port failed", MessageBoxButtons.AbortRetryIgnore);

                                    if (dr == DialogResult.Abort)
                                        goto EndLoop;
                                    else if (dr == DialogResult.Ignore)
                                        break;
                                }
                            } while (true);

                            ///VSG Power Accuracy
                            //SA Control
                            SA.Reset();
                            SA.WriteScpi("INIT:CONT OFF");                  //Single Sweep Mode
                            SA.WriteScpi("CALC:MARK:STAT ON");              //Set Marker

                            if (VSGHighPowerSelected || VSGLowPowerSelected)
                            {
                                SA.WriteScpi("FREQ:SPAN 100 kHz");          //Set Span
                                SA.WriteScpi("BAND:RES 1 kHz");             //Set RBW 
                            }

                            Thread.Sleep(Settings.Default.delayInitialize);

                            if (VSGHighPowerSelected)
                            {
                                for (int j = 0; j < 4; j++)//RF<i><j>
                                {
                                    for (int i = 0; i < 2; i++)
                                    {
                                        if (csvSpec.VSGHighPowerAccuracy.rfChannelIsOn[j, i])
                                        {
                                            string bank = "";
                                            if (i == 0)
                                                bank = "A";
                                            else
                                                bank = "B";

                                            MessageBox.Show($"Please Switch SG Connector to Port RF{j + 1}{bank}", "Debug Verification");

                                            SG.Reset();
                                            SG.WriteScpi("SOUR:CORR:STAT 0");

                                            for (int freqIndex = 0; freqIndex < csvSpec.VSGHighPowerAccuracy.Frequency_Str.Count; freqIndex++)
                                            {
                                                SG.WriteScpi($"SOUR1:FREQ:CW {csvSpec.VSGHighPowerAccuracy.Frequency_Str[freqIndex]} MHz");
                                                SA.WriteScpi($"FREQ:CENT {csvSpec.VSGHighPowerAccuracy.Frequency_Str[freqIndex]} MHz");

                                                for (int powIndex = 0; powIndex < csvSpec.VSGHighPowerAccuracy.Power_Str.Count; powIndex++)
                                                {
                                                    startTimeRef = DateTime.Now;
                                                    string sAccuracy = "-";
                                                    string measuredValue = "";

                                                    if (csvSpec.VSGHighPowerAccuracy.Power[powIndex] > 7500)
                                                        measuredValue = "Freq OutOfRange";

                                                    if (measuredValue != "Freq OutOfRange")
                                                    {
                                                        SG.WriteScpi("SOUR1:POW:POW " + csvSpec.VSGHighPowerAccuracy.Power_Str[powIndex]);
                                                        SG.WriteScpi("OUTP1:STAT 1");
                                                        Thread.Sleep(Settings.Default.delayStep); //HK: Delay after changing Power
                                                                                                  //Set SA Frequency
                                                        for (int retry = 0; retry < 6; retry++)
                                                        {
                                                        sAccuracy = "-";
                                                        SA.WriteScpi("DISP:WIND:TRAC:Y:RLEV " + (csvSpec.VSGHighPowerAccuracy.Power[powIndex] + 5) + " dBm");     //Reference level
                                                        SA.WriteScpi("INIT;*WAI");                          //Set Single Sweep
                                                        SA.WriteScpi("CALC:MARK1:MAX");                     //Set Marker Peak Search
                                                        SA.WriteScpi("CALC:MARK1:X " + (csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] * 1e6).ToString("0") + " Hz"); //Snap marker to signal freq
                                                        loss = 0;
                                                        if (lblCalFileName.Text != "-")
                                                            loss = ConfigCAL.getPowerLoss(csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex], j, i, "SADUT");  //Set Y marker reading offset

                                                        measuredValue = SA.QueryScpi("CALC:MARK:Y?");//Read Marker Level
                                                        try
                                                        {
                                                            if (isDebug && string.IsNullOrEmpty(measuredValue))
                                                                measuredValue = (csvSpec.VSGHighPowerAccuracy.Power[powIndex] - new Random().NextDouble()).ToString("n2");
                                                            if (string.IsNullOrEmpty(measuredValue))
                                                                measuredValue = "ERROR";
                                                            else
                                                            {
                                                                measuredValue = (double.Parse(measuredValue.Trim().Split(',').Last().Trim(), CultureInfo.InvariantCulture) - loss).ToString("0.00");
                                                                sAccuracy = (double.Parse(measuredValue) - csvSpec.VSGHighPowerAccuracy.Power[powIndex]).ToString("0.00");
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            measuredValue = $"E:{measuredValue?.Trim() ?? ""}";
                                                        }
                                                        if (sAccuracy != "-")
                                                        {
                                                            double retryAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                            if (csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] <= 3800 && retryAccuracy < csvSpec.VSGHighPowerAccuracy.LowFreqLimit
                                                            || csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] > 3800 && retryAccuracy < csvSpec.VSGHighPowerAccuracy.HighFreqLimit)
                                                                break;
                                                        }
                                                        }
                                                    }

                                                    string sPFResult = "F";

                                                    if (measuredValue == "Freq OutOfRange")
                                                        sPFResult = "";
                                                    else if (sAccuracy != "-")
                                                    {
                                                        double unSignedAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                        if (csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] <= 3800 && unSignedAccuracy < csvSpec.VSGHighPowerAccuracy.LowFreqLimit
                                                        || csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] > 3800 && unSignedAccuracy < csvSpec.VSGHighPowerAccuracy.HighFreqLimit)  //check if pass/fail
                                                        {
                                                            totalPassTest++;
                                                            sPFResult = "P";
                                                        }
                                                    }

                                                    Invoke((MethodInvoker)(() =>
                                                    {
                                                        dtTestResult.Rows[rowCount][3] = measuredValue;
                                                        dtTestResult.Rows[rowCount][4] = sAccuracy + " dB";
                                                        dtTestResult.Rows[rowCount][5] = sPFResult;
                                                        lblPassRateValue.Text = totalPassTest + "/" + dtTestResult.Rows.Count;

                                                        int rowEditedVisible = 3 + rowCount - dataGridTestResult.Height / dataGridTestResult.RowTemplate.Height;
                                                        if (rowEditedVisible > 0)
                                                            dataGridTestResult.FirstDisplayedScrollingRowIndex = rowEditedVisible;

                                                        //noError = Results.WriteResult(fileName, DateTime.Now.Subtract(startTimeRef), false, false, dtTestResult.Rows[rowCount]);
                                                        rowCount++;
                                                    }));
                                                    //if (!noError)
                                                    //    goto EndLoop;
                                                }
                                            }
                                        }

                                        SG.WriteScpi("OUTP1:STAT 0");
                                    }
                                }
                            }

                            if (VSGLowPowerSelected)
                            {
                                //Low Power
                                //SA.WriteScpi("DISP:WIND:TRAC:Y:RLEV -20 dBm");  //HK: Positiona change and Set Reference Level cause attenuator changing. So, fix to high power
                                for (int j = 0; j < 4; j++)//RF<i><j>
                                {
                                    for (int i = 0; i < 2; i++)
                                    {
                                        string routNum = i == 0 ? "1" : "12";
                                        if (cbRout.Visible)
                                            routNum = i == 0 ? rout : rout + "2";

                                        string portLetter = "";
                                        if (i == 0)
                                            portLetter = "A";
                                        else
                                            portLetter = "B";

                                        if (csvSpec.VSGLowPowerAccuracy.rfChannelIsOn[j, i])
                                        {
                                            MessageBox.Show($"Please Switch SG Connector to Port RF{j + 1}{portLetter}", "Debug Verification");

                                            SG.Reset();
                                            SG.WriteScpi("SOUR:CORR:STAT 0");

                                            for (int freqIndex = 0; freqIndex < csvSpec.VSGLowPowerAccuracy.Frequency_Str.Count; freqIndex++)
                                            {
                                                SG.WriteScpi($"SOUR1:FREQ:CW {csvSpec.VSGLowPowerAccuracy.Frequency_Str[freqIndex]} MHz");
                                                SA.WriteScpi($"FREQ:CENT {csvSpec.VSGLowPowerAccuracy.Frequency_Str[freqIndex]} MHz");                                                     //Set Frequency Level

                                                for (int powIndex = 0; powIndex < csvSpec.VSGLowPowerAccuracy.Power_Str.Count; powIndex++)
                                                {
                                                    startTimeRef = DateTime.Now;
                                                    string sAccuracy = "-";
                                                    string measuredValue = "";

                                                    if (csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] > 7500)
                                                        measuredValue = "Freq OutOfRange";

                                                    if (measuredValue != "Freq OutOfRange")
                                                    {
                                                        SG.WriteScpi("SOUR1:POW:POW " + csvSpec.VSGLowPowerAccuracy.Power_Str[powIndex]);
                                                        SG.WriteScpi("OUTP1:STAT 1");
                                                        Thread.Sleep(Settings.Default.delayStep);

                                                        for (int retry = 0; retry < 6; retry++)
                                                        {
                                                        sAccuracy = "-";
                                                        SA.WriteScpi("DISP:WIND:TRAC:Y:RLEV " + (csvSpec.VSGLowPowerAccuracy.Power[powIndex] + 5) + " dBm");     //Reference level
                                                        SA.WriteScpi("INIT;*WAI");                          //Set Single Sweep
                                                        SA.WriteScpi("CALC:MARK1:MAX");                     //Set Marker Peak Search
                                                        SA.WriteScpi("CALC:MARK1:X " + (csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] * 1e6).ToString("0") + " Hz"); //Snap marker to signal freq
                                                        loss = 0;
                                                        if (lblCalFileName.Text != "-")
                                                            loss = ConfigCAL.getPowerLoss(csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex], j, i, "SADUT");   //Set Y marker reading offset

                                                        measuredValue = SA.QueryScpi("CALC:MARK:Y?");//Read Marker Level
                                                        try
                                                        {
                                                            if (isDebug && string.IsNullOrEmpty(measuredValue))
                                                                measuredValue = (csvSpec.VSGLowPowerAccuracy.Power[powIndex] - new Random().NextDouble()).ToString("n2");
                                                            if (string.IsNullOrEmpty(measuredValue))
                                                                measuredValue = "ERROR";
                                                            else
                                                            {
                                                                measuredValue = (double.Parse(measuredValue.Trim().Split(',').Last().Trim(), CultureInfo.InvariantCulture) - loss).ToString("0.00");
                                                                sAccuracy = (double.Parse(measuredValue) - csvSpec.VSGLowPowerAccuracy.Power[powIndex]).ToString("0.00");
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            measuredValue = $"E:{measuredValue?.Trim() ?? ""}";
                                                        }
                                                        if (sAccuracy != "-")
                                                        {
                                                            double retryAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                            if (csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] <= 3800 && retryAccuracy < csvSpec.VSGLowPowerAccuracy.LowFreqLimit
                                                            || csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] > 3800 && retryAccuracy < csvSpec.VSGLowPowerAccuracy.HighFreqLimit)
                                                                break;
                                                        }
                                                        }
                                                    }

                                                    string sPFResult = "F";

                                                    if (measuredValue == "Freq OutOfRange")
                                                        sPFResult = "";
                                                    else if (sAccuracy != "-")
                                                    {
                                                        double unSignedAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                        if (csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] <= 3800 && unSignedAccuracy < csvSpec.VSGLowPowerAccuracy.LowFreqLimit
                                                        || csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] > 3800 && unSignedAccuracy < csvSpec.VSGLowPowerAccuracy.HighFreqLimit)//check if pass/fail
                                                        {
                                                            totalPassTest++;
                                                            sPFResult = "P";
                                                        }
                                                    }

                                                    Invoke((MethodInvoker)(() =>
                                                    {
                                                        dtTestResult.Rows[rowCount][3] = measuredValue;
                                                        dtTestResult.Rows[rowCount][4] = sAccuracy + " dB";
                                                        dtTestResult.Rows[rowCount][5] = sPFResult;
                                                        lblPassRateValue.Text = totalPassTest + "/" + dtTestResult.Rows.Count;

                                                        int rowEditedVisible = 3 + rowCount - dataGridTestResult.Height / dataGridTestResult.RowTemplate.Height;
                                                        if (rowEditedVisible > 0)
                                                            dataGridTestResult.FirstDisplayedScrollingRowIndex = rowEditedVisible;

                                                        //noError = Results.WriteResult(fileName, DateTime.Now.Subtract(startTimeRef), false, false, dtTestResult.Rows[rowCount]);
                                                        rowCount++;
                                                    }));
                                                    //if (!noError)
                                                    //    goto EndLoop;
                                                }
                                            }
                                        }

                                        SG.WriteScpi("OUTP1:STAT 0");
                                    }
                                }
                            }

                            ///VSG Frequency Accuracy
                            if (VSGFrequencyAccuracySelected)
                            {
                                SA.Reset();
                                SA.WriteScpi("INIT:CONT OFF");                  //Single Sweep Mode
                                SA.WriteScpi("CALC:MARK:STAT ON");              //Set Marker
                                SA.WriteScpi("FREQ:SPAN 10 kHz");               //Set Span
                                SA.WriteScpi("BAND:RES 100 Hz");                //Set RBW
                                SA.WriteScpi("SENS:SWE:WIND:POIN 3001");        //Set Sweep Point
                                SA.WriteScpi("CALC:MARK:MAX:PEAK");             //Get peak marker
                                Thread.Sleep(Settings.Default.delayInitialize);

                                for (int j = 0; j < 4; j++)//RF<i><j>
                                {
                                    for (int i = 0; i < 2; i++)
                                    {
                                        string routNum = i == 0 ? "1" : "12";
                                        if (cbRout.Visible)
                                            routNum = i == 0 ? rout : rout + "2";

                                        string portLetter = "";
                                        if (i == 0)
                                            portLetter = "A";
                                        else
                                            portLetter = "B";

                                        if (csvSpec.FrequencyAccuracy.rfChannelIsOn[j, i])
                                        {
                                            MessageBox.Show($"Please Switch SG Connector to Port RF{j + 1}{portLetter}", "Debug Verification");

                                            SG.Reset();
                                            SG.WriteScpi("SOUR:CORR:STAT 0");

                                            for (int freqIndex = 0; freqIndex < csvSpec.FrequencyAccuracy.Frequency_Str.Count; freqIndex++)
                                            {
                                                SG.WriteScpi($"SOUR1:FREQ:CW {csvSpec.FrequencyAccuracy.Frequency_Str[freqIndex]} MHz");
                                                SA.WriteScpi($"FREQ:CENT {csvSpec.FrequencyAccuracy.Frequency_Str[freqIndex]} MHz");                                                       //Set SA Frequency

                                                for (int powIndex = 0; powIndex < csvSpec.FrequencyAccuracy.Power_Str.Count; powIndex++)
                                                {
                                                    startTimeRef = DateTime.Now; string sAccuracy = "-";
                                                    string measuredValue = "";

                                                    if (csvSpec.FrequencyAccuracy.Frequency[freqIndex] > 7500)
                                                        measuredValue = "Freq OutOfRange";

                                                    if (measuredValue != "Freq OutOfRange")
                                                    {
                                                        SG.WriteScpi("SOUR1:POW:POW " + csvSpec.FrequencyAccuracy.Power_Str[powIndex]);
                                                        SG.WriteScpi("OUTP1:STAT 1");
                                                        Thread.Sleep(Settings.Default.delayStep); //HK: Delay after changing Power

                                                        for (int retry = 0; retry < 6; retry++)
                                                        {
                                                        sAccuracy = "-";
                                                        SA.WriteScpi("DISP:WIND:TRAC:Y:RLEV " + (csvSpec.FrequencyAccuracy.Power[powIndex] + 5) + " dBm");     //Reference level
                                                        SA.WriteScpi("INIT;*WAI");                              //Set Single Sweep
                                                        SA.WriteScpi("CALC:MARK1:MAX");                         //Set Marker Peak Search
                                                        measuredValue = SA.QueryScpi("CALC:MARK:X?");    //Read Marker Frequency
                                                        try
                                                        {
                                                            if (isDebug && string.IsNullOrEmpty(measuredValue))
                                                                measuredValue = (csvSpec.FrequencyAccuracy.Frequency[freqIndex] - new Random().NextDouble() * 0.001).ToString("n2");
                                                            if (string.IsNullOrEmpty(measuredValue))
                                                                measuredValue = "ERROR";
                                                            else
                                                            {
                                                                measuredValue = (double.Parse(measuredValue.Trim().Split(',').Last().Trim(), CultureInfo.InvariantCulture) / 1000000).ToString("0.000000");
                                                                sAccuracy = ((double.Parse(measuredValue) - csvSpec.FrequencyAccuracy.Frequency[freqIndex]) / csvSpec.FrequencyAccuracy.Frequency[freqIndex] * 1000000).ToString("0.000000");
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            measuredValue = $"E:{measuredValue?.Trim() ?? ""}";
                                                        }
                                                        if (sAccuracy != "-")
                                                        {
                                                            double retryAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                            if (retryAccuracy < csvSpec.FrequencyAccuracy.FreqLimit)
                                                                break;
                                                        }
                                                        }
                                                    }

                                                    string sPFResult = "F";

                                                    if (measuredValue == "Freq OutOfRange")
                                                        sPFResult = "";
                                                    else if (sAccuracy != "-")
                                                    {
                                                        double unSignedAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                        if (unSignedAccuracy < csvSpec.FrequencyAccuracy.FreqLimit)//check if pass/fail
                                                        {
                                                            totalPassTest++;
                                                            sPFResult = "P";
                                                        }
                                                    }

                                                    Invoke((MethodInvoker)(() =>
                                                    {
                                                        dtTestResult.Rows[rowCount][3] = measuredValue;
                                                        dtTestResult.Rows[rowCount][4] = sAccuracy + " ppm";
                                                        dtTestResult.Rows[rowCount][5] = sPFResult;
                                                        lblPassRateValue.Text = totalPassTest + "/" + dtTestResult.Rows.Count;

                                                        int rowEditedVisible = 3 + rowCount - dataGridTestResult.Height / dataGridTestResult.RowTemplate.Height;
                                                        if (rowEditedVisible > 0)
                                                            dataGridTestResult.FirstDisplayedScrollingRowIndex = rowEditedVisible;

                                                        //noError = Results.WriteResult(fileName, DateTime.Now.Subtract(startTimeRef), false, false, dtTestResult.Rows[rowCount]);
                                                        rowCount++;
                                                    }));
                                                    //if (!noError)
                                                    //    goto EndLoop;
                                                }
                                            }
                                        }

                                        SG.WriteScpi("OUTP1:STAT 0");
                                    }
                                }
                            }

                            //.WriteScpi(csvSpec.scpiDUTSetVSGWavefileState.Replace("xx", "OFF"));   //Turn off DUT wavefile play
                        }
                        else
                        {
                            MessageBox.Show("Please make sure DUT, Spectrum Analyzer and SwitchBox is conected", "VSG Power Test Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    ///VSA Power Accuracy
                    if (VSAPowerSelected)
                    {
                        if (SGConnected && SAConnected)
                        {
                            MessageBox.Show($"Verification Mode! Replace DUT with Spectrum Analyzer.", "Debug Verification");

                            do
                            {
                                switchPortSet = SwitchBox.SetPort(SwitchBox.PortSGDUT);

                                if (!switchPortSet)
                                {
                                    DialogResult dr = MessageBox.Show("An error occured when changing the Switch Box port", "Changing port failed", MessageBoxButtons.AbortRetryIgnore);

                                    if (dr == DialogResult.Abort)
                                        goto EndLoop;
                                    else if (dr == DialogResult.Ignore)
                                        break;
                                }
                            } while (true);

                            //HK: Please add if any VSA test cases is selected. if not skip below commands
                            SG.Reset();
                            SG.WriteScpi("SOUR:POW -90 dBm");
                            SG.WriteScpi("OUTP ON");

                            SA.Reset();
                            SA.WriteScpi("INIT:CONT OFF");                  //Single Sweep Mode
                            SA.WriteScpi("CALC:MARK:STAT ON");              //Set Marker
                            SA.WriteScpi("FREQ:SPAN 10 kHz");               //Set Span
                            SA.WriteScpi("BAND:RES 100 Hz");                //Set RBW      
                            SA.WriteScpi("SENS:SWE:WIND:POIN 3001");        //Set Sweep Point
                            SA.WriteScpi("CALC:MARK:MAX:PEAK");             //Get peak marker

                            Thread.Sleep(Settings.Default.delayInitialize);

                            for (int j = 0; j < 4; j++)//RF<i><j>
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    string portLetter = "";
                                    if (i == 0)
                                        portLetter = cbRout.Visible ? " B1" : "A";
                                    else
                                        portLetter = cbRout.Visible ? " B2" : "B";
                                    string routNum = i == 0 ? "1" : "12";
                                    if (cbRout.Visible)
                                        routNum = i == 0 ? rout : rout + "2";


                                    if (csvSpec.VSAPowerAccuracy.rfChannelIsOn[j, i])
                                    {
                                        MessageBox.Show($"Please Switch SA Connector to Port RF{j + 1}{portLetter}", "Debug Verification");

                                        for (int freqIndex = 0; freqIndex < csvSpec.VSAPowerAccuracy.Frequency_Str.Count; freqIndex++)
                                        {
                                            SA.WriteScpi($"FREQ:CENT {csvSpec.VSAPowerAccuracy.Frequency_Str[freqIndex]} MHz");                                                       //Set SA Frequency
                                            SG.WriteScpi($"FREQ {csvSpec.VSAPowerAccuracy.Frequency_Str[freqIndex]} MHz");                                                             //Set SG Frequency 

                                            for (int powIndex = 0; powIndex < csvSpec.VSAPowerAccuracy.Power_Str.Count; powIndex++)
                                            {
                                                startTimeRef = DateTime.Now;
                                                string sAccuracy = "-";
                                                string measuredValue = "";

                                                if (csvSpec.VSAPowerAccuracy.Frequency[freqIndex] > 7500)
                                                    measuredValue = "Freq OutOfRange";

                                                if (measuredValue != "Freq OutOfRange")
                                                {
                                                    SG.WriteScpi("SOUR:POW " + csvSpec.VSAPowerAccuracy.Power_Str[powIndex] + " dBm");  //Set SG Level
                                                    Thread.Sleep(Settings.Default.delayStep);

                                                    loss = 0;
                                                    if (lblCalFileName.Text != "-")
                                                        loss = ConfigCAL.getPowerLoss(csvSpec.VSAPowerAccuracy.Frequency[freqIndex], j, i, "SGDUT");   //Set Y marker reading offset

                                                    for (int retry = 0; retry < 6; retry++)
                                                    {
                                                    sAccuracy = "-";
                                                    SA.WriteScpi("DISP:WIND:TRAC:Y:RLEV " + (csvSpec.VSAPowerAccuracy.Power[powIndex] + 5) + " dBm");     //Reference level
                                                    SA.WriteScpi("INIT;*WAI");                              //Set Single Sweep
                                                    SA.WriteScpi("CALC:MARK1:MAX");                         //Set Marker Peak Search
                                                    measuredValue = SA.QueryScpi("CALC:MARK:Y?");    //Read Marker Power Level

                                                    try
                                                    {
                                                        if (isDebug && string.IsNullOrEmpty(measuredValue))
                                                            measuredValue = (csvSpec.VSAPowerAccuracy.Power[powIndex] - new Random().NextDouble()).ToString("n2");
                                                        if (string.IsNullOrEmpty(measuredValue))
                                                            measuredValue = "ERROR";
                                                        else //sample SA value format = "0,-1.2345678e+01";
                                                        {
                                                            measuredValue = (double.Parse(measuredValue.Trim().Split(',').Last().Trim(), CultureInfo.InvariantCulture) - loss).ToString("0.00", CultureInfo.InvariantCulture);   //remove "0,", convert exponential number format to 2 decimal place
                                                            sAccuracy = (double.Parse(measuredValue) - csvSpec.VSAPowerAccuracy.Power[powIndex]).ToString("0.00");
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        measuredValue = $"E:{measuredValue?.Trim() ?? ""}";
                                                    }
                                                    if (sAccuracy != "-")
                                                    {
                                                        double retryAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                        if (csvSpec.VSAPowerAccuracy.Frequency[freqIndex] <= 3800 && retryAccuracy < csvSpec.VSAPowerAccuracy.LowFreqLimit
                                                        || csvSpec.VSAPowerAccuracy.Frequency[freqIndex] > 3800 && retryAccuracy < csvSpec.VSAPowerAccuracy.HighFreqLimit)
                                                            break;
                                                    }
                                                    }
                                                }

                                                string sPFResult = "F";

                                                if (measuredValue == "Freq OutOfRange")
                                                    sPFResult = "";
                                                else if (sAccuracy != "-")
                                                {
                                                    double unSignedAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                    if (csvSpec.VSAPowerAccuracy.Frequency[freqIndex] <= 3800 && unSignedAccuracy < csvSpec.VSAPowerAccuracy.LowFreqLimit
                                                    || csvSpec.VSAPowerAccuracy.Frequency[freqIndex] > 3800 && unSignedAccuracy < csvSpec.VSAPowerAccuracy.HighFreqLimit)//check if pass/fail
                                                    {
                                                        totalPassTest++;
                                                        sPFResult = "P";
                                                    }
                                                }

                                                Invoke((MethodInvoker)(() =>
                                                {
                                                    dtTestResult.Rows[rowCount][3] = measuredValue;
                                                    dtTestResult.Rows[rowCount][4] = sAccuracy + " dB";
                                                    dtTestResult.Rows[rowCount][5] = sPFResult;
                                                    lblPassRateValue.Text = totalPassTest + "/" + dtTestResult.Rows.Count;

                                                    int rowEditedVisible = 3 + rowCount - dataGridTestResult.Height / dataGridTestResult.RowTemplate.Height;
                                                    if (rowEditedVisible > 0)
                                                        dataGridTestResult.FirstDisplayedScrollingRowIndex = rowEditedVisible;

                                                    //noError = Results.WriteResult(fileName, DateTime.Now.Subtract(startTimeRef), false, false, dtTestResult.Rows[rowCount]);
                                                    rowCount++;
                                                }));
                                                //if (!noError)
                                                //    goto EndLoop;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please make sure DUT, Signal Generator and SwitchBox is connected", "VSA Power Test Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                EndLoop:
                    Invoke((MethodInvoker)(() =>
                    {
                        SG.WriteScpi("OUTP OFF");

                        isTesting = false;
                        btnStartStop.Text = "START";
                        btnStartStop.BackColor = Color.LimeGreen;
                        btnLoadSpecFile.Enabled = true;
                        btnLoadCal.Enabled = true;

                        timerDuration.Enabled = false;
                        DateTime finalTime = DateTime.Now;
                        TimeSpan totalDuration = finalTime.Subtract(startDT);
                        lblDurationTimer.Text = string.Format("{0}:{1}.{2}", totalDuration.Minutes.ToString("00"), totalDuration.Seconds.ToString("00"), totalDuration.Milliseconds.ToString("000"));

                        //Results.WriteResult(fileName, totalDuration, true, false);
                        //Results.createReport(dtTestResult, csvSpec, , SG, SA, PS, SwitchBox, DateTime.Now, totalPassTest, totalDuration, false, isDebug);
                    }));
                });
            }

            else
            {
                testThread = new Thread(delegate ()
                {
                    double loss = 0;
                    if (DUTConnected)
                        DUTCommTester.Reset(); //Reset

                    ///VSG
                    //check if VSG power case is selected.
                    bool VSGPowerSelected = false;
                    bool VSGHighPowerSelected = false;
                    bool VSGLowPowerSelected = false;
                    bool VSGFrequencyAccuracySelected = false;
                    bool VSAPowerSelected = false;
                    for (int i = 0; i < 2; i++)//RF<i><j>
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (csvSpec.VSGHighPowerAccuracy.rfChannelIsOn[j, i])
                                VSGHighPowerSelected = true;
                            if (csvSpec.VSGLowPowerAccuracy.rfChannelIsOn[j, i])
                                VSGLowPowerSelected = true;
                            if (csvSpec.FrequencyAccuracy.rfChannelIsOn[j, i])
                                VSGFrequencyAccuracySelected = true;
                            if (csvSpec.VSAPowerAccuracy.rfChannelIsOn[j, i])
                                VSAPowerSelected = true;
                        }
                    }

                    if (VSGHighPowerSelected || VSGLowPowerSelected || VSGFrequencyAccuracySelected)
                        VSGPowerSelected = true;

                    if (VSGPowerSelected && !DUTCommTester.CanTransmit)
                    {
                        MessageBox.Show($"DUT ({DUTCommTester.Name}) 不支援 VSG 發射模式，跳過 VSG 測試。", "VSG 跳過", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        VSGPowerSelected = false;
                    }

                    if (VSGPowerSelected)
                    {
                        if (DUTConnected && SAConnected && SwitchConnected)
                        {
                            if (isDebug)
                                switchPortSet = true;
                            else
                                switchPortSet = SwitchBox.SetPort(SwitchBox.PortSADUT);

                            if (!switchPortSet)
                            {
                                if (!switchPortSet)
                                {
                                    MessageBox.Show("An error occured when changing the Switch Box port", "Changing port failed");
                                    goto EndLoop;
                                }
                            }

                            ///VSG Power Accuracy
                            //SA Control
                            SA.Reset();
                            SA.WriteScpi("INIT:CONT OFF");                  //Single Sweep Mode
                            SA.WriteScpi("CALC:MARK:STAT ON");              //Set Marker

                            if (VSGHighPowerSelected || VSGLowPowerSelected)
                            {
                                SA.WriteScpi("FREQ:SPAN 100 kHz");          //Set Span
                                SA.WriteScpi("BAND:RES 1 kHz");             //Set RBW 
                            }

                            Thread.Sleep(Settings.Default.delayInitialize);

                            if (VSGHighPowerSelected)
                            {
                                //HighPower
                                //SA.WriteScpi("DISP:WIND:TRAC:Y:RLEV 10 dBm");//HK: Position change and Set Reference Level cause attenuator changing. So, fix to high power

                                for (int j = 0; j < 4; j++)//RF<i><j>
                                {
                                    for (int i = 0; i < 2; i++)
                                    {
                                        string routNum = i == 0 ? "1" : "12";
                                        if (cbRout.Visible)
                                            routNum = i == 0 ? rout : rout + "2";
                                        routNum = ResolveVsgRouteNum(i, routNum);

                                        string portLetter = "";
                                        if (i == 0)
                                            portLetter = "A";
                                        else
                                            portLetter = "B";

                                        if (csvSpec.VSGHighPowerAccuracy.rfChannelIsOn[j, i])
                                        {
                                            //DUTCommTester.WriteScpi("*RST");
                                            //DUTCommTester.WriteScpi(csvSpec.scpiDUTSetVSGMode.Replace("zz", routNum));  //Set VSG mode
                                            ////Channel change first
                                            //DUTCommTester.WriteScpi(csvSpec.scpiDUTSetVSGChannel.Replace("xx", (j + 1).ToString()).Replace("yy", portLetter).Replace("zz", routNum));           //Set DUT RF Channel - output

                                            for (int freqIndex = 0; freqIndex < csvSpec.VSGHighPowerAccuracy.Frequency_Str.Count; freqIndex++)
                                            {
                                                DUTCommTester.SetupVSGChannel(csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex], j + 1, portLetter, routNum);
                                                SA.WriteScpi("FREQ:CENT " + csvSpec.VSGHighPowerAccuracy.Frequency_Str[freqIndex] + " MHz");

                                                for (int powIndex = 0; powIndex < csvSpec.VSGHighPowerAccuracy.Power_Str.Count; powIndex++)
                                                {
                                                    startTimeRef = DateTime.Now;
                                                    string sAccuracy = "-";
                                                    string measuredValue = "";

                                                    if (DUTCommTester.Model == "IQXEL-M")
                                                    {
                                                        if (csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] < 860 || csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] > 6000
                                                        || (csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] > 1000 && csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] < 1770)
                                                        || (csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] > 2660 && csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] < 3300)
                                                        || (csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] > 3800 && csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] < 4900))
                                                        {
                                                            measuredValue = "Freq OutOfRange";
                                                        }
                                                    }

                                                    if (measuredValue != "Freq OutOfRange")
                                                    {
                                                        DUTCommTester.SetupVSGPower(csvSpec.VSGHighPowerAccuracy.Power[powIndex], routNum);
                                                        DUTCommTester.TransmitOn(routNum);
                                                        Thread.Sleep(Settings.Default.delayStep); //HK: Delay after changing Power

                                                        if (isPauseMode)
                                                        {
                                                            SA.WriteScpi("INIT:CONT ON");
                                                            MessageBox.Show(
                                                                $"[VSG High Power] DUT RF ON\nPort: RF{j + 1}{portLetter}\nFreq: {csvSpec.VSGHighPowerAccuracy.Frequency_Str[freqIndex]} MHz\nPower: {csvSpec.VSGHighPowerAccuracy.Power_Str[powIndex]} dBm\n\nCheck SA for signal, then click OK to measure.",
                                                                "Debug Pause");
                                                            SA.WriteScpi("INIT:CONT OFF");
                                                        }

                                                        for (int retry = 0; retry < 6; retry++)
                                                        {
                                                        sAccuracy = "-";
                                                        SA.WriteScpi("DISP:WIND:TRAC:Y:RLEV " + (csvSpec.VSGHighPowerAccuracy.Power[powIndex] + 5) + " dBm");     //Reference level
                                                        SA.WriteScpi("INIT;*WAI");                          //Set Single Sweep
                                                        SA.WriteScpi("CALC:MARK1:MAX");                     //Set Marker Peak Search
                                                        SA.WriteScpi("CALC:MARK1:X " + (csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] * 1e6).ToString("0") + " Hz"); //Snap marker to signal freq
                                                        loss = 0;
                                                        if (lblCalFileName.Text != "-")
                                                            loss = ConfigCAL.getPowerLoss(csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex], j, i, "SADUT");  //Set Y marker reading offset

                                                        measuredValue = SA.QueryScpi("CALC:MARK:Y?");//Read Marker Level
                                                        try
                                                        {
                                                            if (isDebug && string.IsNullOrEmpty(measuredValue))
                                                                measuredValue = (csvSpec.VSGHighPowerAccuracy.Power[powIndex] - new Random().NextDouble()).ToString("n2");
                                                            if (string.IsNullOrEmpty(measuredValue))
                                                                measuredValue = "ERROR";
                                                            else
                                                            {
                                                                measuredValue = (double.Parse(measuredValue.Trim().Split(',').Last().Trim(), CultureInfo.InvariantCulture) - loss).ToString("0.00");
                                                                sAccuracy = (double.Parse(measuredValue) - csvSpec.VSGHighPowerAccuracy.Power[powIndex]).ToString("0.00");
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            measuredValue = $"E:{measuredValue?.Trim() ?? ""}";
                                                        }
                                                        if (sAccuracy != "-")
                                                        {
                                                            double retryAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                            if (csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] <= 3800 && retryAccuracy < csvSpec.VSGHighPowerAccuracy.LowFreqLimit
                                                            || csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] > 3800 && retryAccuracy < csvSpec.VSGHighPowerAccuracy.HighFreqLimit)
                                                                break;
                                                        }
                                                        }
                                                    }

                                                    string sPFResult = "F";

                                                    if (measuredValue == "Freq OutOfRange")
                                                        sPFResult = "";
                                                    else if (sAccuracy != "-")
                                                    {
                                                        double unSignedAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                        if (csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] <= 3800 && unSignedAccuracy < csvSpec.VSGHighPowerAccuracy.LowFreqLimit
                                                        || csvSpec.VSGHighPowerAccuracy.Frequency[freqIndex] > 3800 && unSignedAccuracy < csvSpec.VSGHighPowerAccuracy.HighFreqLimit)  //check if pass/fail
                                                        {
                                                            totalPassTest++;
                                                            sPFResult = "P";
                                                        }
                                                    }

                                                    Invoke((MethodInvoker)(() =>
                                                    {
                                                        dtTestResult.Rows[rowCount][3] = measuredValue;
                                                        dtTestResult.Rows[rowCount][4] = sAccuracy + " dB";
                                                        dtTestResult.Rows[rowCount][5] = sPFResult;
                                                        lblPassRateValue.Text = totalPassTest + "/" + dtTestResult.Rows.Count;

                                                        int rowEditedVisible = 3 + rowCount - dataGridTestResult.Height / dataGridTestResult.RowTemplate.Height;
                                                        if (rowEditedVisible > 0)
                                                            dataGridTestResult.FirstDisplayedScrollingRowIndex = rowEditedVisible;

                                                        //noError = Results.WriteResult(fileName, DateTime.Now.Subtract(startTimeRef), false, false, dtTestResult.Rows[rowCount]);
                                                        rowCount++;
                                                    }));
                                                    //if (!noError)
                                                    //    goto EndLoop;
                                                }
                                            }
                                        }

                                        DUTCommTester.TransmitOff(routNum);
                                    }
                                }
                            }

                            if (VSGLowPowerSelected)
                            {
                                //Low Power
                                //SA.WriteScpi("DISP:WIND:TRAC:Y:RLEV -20 dBm");  //HK: Positiona change and Set Reference Level cause attenuator changing. So, fix to high power
                                for (int j = 0; j < 4; j++)//RF<i><j>
                                {
                                    for (int i = 0; i < 2; i++)
                                    {
                                        string routNum = i == 0 ? "1" : "12";
                                        if (cbRout.Visible)
                                            routNum = i == 0 ? rout : rout + "2";
                                        routNum = ResolveVsgRouteNum(i, routNum);

                                        string portLetter = "";
                                        if (i == 0)
                                            portLetter = "A";
                                        else
                                            portLetter = "B";

                                        if (csvSpec.VSGLowPowerAccuracy.rfChannelIsOn[j, i])
                                        {
                                            for (int freqIndex = 0; freqIndex < csvSpec.VSGLowPowerAccuracy.Frequency_Str.Count; freqIndex++)
                                            {
                                                DUTCommTester.SetupVSGChannel(csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex], j + 1, portLetter, routNum);
                                                SA.WriteScpi("FREQ:CENT " + csvSpec.VSGLowPowerAccuracy.Frequency_Str[freqIndex] + " MHz");                                                     //Set Frequency Level

                                                for (int powIndex = 0; powIndex < csvSpec.VSGLowPowerAccuracy.Power_Str.Count; powIndex++)
                                                {
                                                    startTimeRef = DateTime.Now;
                                                    string sAccuracy = "-";
                                                    string measuredValue = "";

                                                    if (DUTCommTester.Model == "IQXEL-M")
                                                    {
                                                        if (csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] < 860 || csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] > 6000
                                                        || (csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] > 1000 && csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] < 1770)
                                                        || (csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] > 2660 && csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] < 3300)
                                                        || (csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] > 3800 && csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] < 4900))
                                                        {
                                                            measuredValue = "Freq OutOfRange";
                                                        }
                                                    }

                                                    if (measuredValue != "Freq OutOfRange")
                                                    {
                                                        DUTCommTester.SetupVSGPower(csvSpec.VSGLowPowerAccuracy.Power[powIndex], routNum);
                                                        DUTCommTester.TransmitOn(routNum);
                                                        Thread.Sleep(Settings.Default.delayStep);

                                                        for (int retry = 0; retry < 6; retry++)
                                                        {
                                                        sAccuracy = "-";
                                                        SA.WriteScpi("DISP:WIND:TRAC:Y:RLEV " + (csvSpec.VSGLowPowerAccuracy.Power[powIndex] + 5) + " dBm");     //Reference level
                                                        SA.WriteScpi("INIT;*WAI");                          //Set Single Sweep
                                                        SA.WriteScpi("CALC:MARK1:MAX");                     //Set Marker Peak Search
                                                        SA.WriteScpi("CALC:MARK1:X " + (csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] * 1e6).ToString("0") + " Hz"); //Snap marker to signal freq
                                                        loss = 0;
                                                        if (lblCalFileName.Text != "-")
                                                            loss = ConfigCAL.getPowerLoss(csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex], j, i, "SADUT");   //Set Y marker reading offset

                                                        measuredValue = SA.QueryScpi("CALC:MARK:Y?");//Read Marker Level
                                                        try
                                                        {
                                                            if (isDebug && string.IsNullOrEmpty(measuredValue))
                                                                measuredValue = (csvSpec.VSGLowPowerAccuracy.Power[powIndex] - new Random().NextDouble()).ToString("n2");
                                                            if (string.IsNullOrEmpty(measuredValue))
                                                                measuredValue = "ERROR";
                                                            else
                                                            {
                                                                measuredValue = (double.Parse(measuredValue.Trim().Split(',').Last().Trim(), CultureInfo.InvariantCulture) - loss).ToString("0.00");
                                                                sAccuracy = (double.Parse(measuredValue) - csvSpec.VSGLowPowerAccuracy.Power[powIndex]).ToString("0.00");
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            measuredValue = $"E:{measuredValue?.Trim() ?? ""}";
                                                        }
                                                        if (sAccuracy != "-")
                                                        {
                                                            double retryAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                            if (csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] <= 3800 && retryAccuracy < csvSpec.VSGLowPowerAccuracy.LowFreqLimit
                                                            || csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] > 3800 && retryAccuracy < csvSpec.VSGLowPowerAccuracy.HighFreqLimit)
                                                                break;
                                                        }
                                                        }
                                                    }

                                                    string sPFResult = "F";

                                                    if (measuredValue == "Freq OutOfRange")
                                                        sPFResult = "";
                                                    else if (sAccuracy != "-")
                                                    {
                                                        double unSignedAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                        if (csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] <= 3800 && unSignedAccuracy < csvSpec.VSGLowPowerAccuracy.LowFreqLimit
                                                        || csvSpec.VSGLowPowerAccuracy.Frequency[freqIndex] > 3800 && unSignedAccuracy < csvSpec.VSGLowPowerAccuracy.HighFreqLimit)//check if pass/fail
                                                        {
                                                            totalPassTest++;
                                                            sPFResult = "P";
                                                        }
                                                    }

                                                    Invoke((MethodInvoker)(() =>
                                                    {
                                                        dtTestResult.Rows[rowCount][3] = measuredValue;
                                                        dtTestResult.Rows[rowCount][4] = sAccuracy + " dB";
                                                        dtTestResult.Rows[rowCount][5] = sPFResult;
                                                        lblPassRateValue.Text = totalPassTest + "/" + dtTestResult.Rows.Count;

                                                        int rowEditedVisible = 3 + rowCount - dataGridTestResult.Height / dataGridTestResult.RowTemplate.Height;
                                                        if (rowEditedVisible > 0)
                                                            dataGridTestResult.FirstDisplayedScrollingRowIndex = rowEditedVisible;

                                                        //noError = Results.WriteResult(fileName, DateTime.Now.Subtract(startTimeRef), false, false, dtTestResult.Rows[rowCount]);
                                                        rowCount++;
                                                    }));
                                                    //if (!noError)
                                                    //    goto EndLoop;
                                                }
                                            }
                                        }

                                        DUTCommTester.TransmitOff(routNum);
                                    }
                                }
                            }

                            //DUTCommTester.WriteScpi(csvSpec.scpiDUTSetVSGWavefileState.Replace("xx", "OFF")); //Turn off DUT wavefile play

                            ///VSG Frequency Accuracy
                            if (VSGFrequencyAccuracySelected)
                            {
                                SA.Reset();
                                SA.WriteScpi("INIT:CONT OFF");                  //Single Sweep Mode
                                SA.WriteScpi("CALC:MARK:STAT ON");              //Set Marker
                                SA.WriteScpi("FREQ:SPAN 10 kHz");               //Set Span
                                SA.WriteScpi("BAND:RES 100 Hz");                //Set RBW      
                                SA.WriteScpi("SENS:SWE:WIND:POIN 3001");        //Set Sweep Point

                                //SA.WriteScpi("DISP:WIND:TRAC:Y:RLEV 10 dBm");   //HK: Positiona change and Set Reference Level cause attenuator changing. So, fix to high power
                                SA.WriteScpi("CALC:MARK:MAX:PEAK");             //Get peak marker
                                Thread.Sleep(Settings.Default.delayInitialize);

                                for (int j = 0; j < 4; j++)//RF<i><j>
                                {
                                    for (int i = 0; i < 2; i++)
                                    {
                                        string routNum = i == 0 ? "1" : "12";
                                        if (cbRout.Visible)
                                            routNum = i == 0 ? rout : rout + "2";
                                        routNum = ResolveVsgRouteNum(i, routNum);

                                        string portLetter = "";
                                        if (i == 0)
                                            portLetter = "A";
                                        else
                                            portLetter = "B";

                                        if (csvSpec.FrequencyAccuracy.rfChannelIsOn[j, i])
                                        {
                                            for (int freqIndex = 0; freqIndex < csvSpec.FrequencyAccuracy.Frequency_Str.Count; freqIndex++)
                                            {
                                                DUTCommTester.SetupVSGChannel(csvSpec.FrequencyAccuracy.Frequency[freqIndex], j + 1, portLetter, routNum);
                                                SA.WriteScpi("FREQ:CENT " + csvSpec.FrequencyAccuracy.Frequency_Str[freqIndex] + " MHz");                                                       //Set SA Frequency

                                                for (int powIndex = 0; powIndex < csvSpec.FrequencyAccuracy.Power_Str.Count; powIndex++)
                                                {
                                                    startTimeRef = DateTime.Now; string sAccuracy = "-";
                                                    string measuredValue = "";

                                                    if (DUTCommTester.Model == "IQXEL-M")
                                                    {
                                                        if (csvSpec.FrequencyAccuracy.Frequency[freqIndex] < 860 || csvSpec.FrequencyAccuracy.Frequency[freqIndex] > 6000
                                                        || (csvSpec.FrequencyAccuracy.Frequency[freqIndex] > 1000 && csvSpec.FrequencyAccuracy.Frequency[freqIndex] < 1770)
                                                        || (csvSpec.FrequencyAccuracy.Frequency[freqIndex] > 2660 && csvSpec.FrequencyAccuracy.Frequency[freqIndex] < 3300)
                                                        || (csvSpec.FrequencyAccuracy.Frequency[freqIndex] > 3800 && csvSpec.FrequencyAccuracy.Frequency[freqIndex] < 4900))
                                                        {
                                                            measuredValue = "Freq OutOfRange";
                                                        }
                                                    }

                                                    if (measuredValue != "Freq OutOfRange")
                                                    {
                                                        DUTCommTester.SetupVSGPower(csvSpec.FrequencyAccuracy.Power[powIndex], routNum);
                                                        DUTCommTester.TransmitOn(routNum);
                                                        Thread.Sleep(Settings.Default.delayStep); //HK: Delay after changing Power

                                                        for (int retry = 0; retry < 6; retry++)
                                                        {
                                                        sAccuracy = "-";
                                                        SA.WriteScpi("DISP:WIND:TRAC:Y:RLEV " + (csvSpec.FrequencyAccuracy.Power[powIndex] + 5) + " dBm");     //Reference level
                                                        SA.WriteScpi("INIT;*WAI");                              //Set Single Sweep
                                                        SA.WriteScpi("CALC:MARK1:MAX");                         //Set Marker Peak Search
                                                        measuredValue = SA.QueryScpi("CALC:MARK:X?");    //Read Marker Frequency
                                                        try
                                                        {
                                                            if (isDebug && string.IsNullOrEmpty(measuredValue))
                                                                measuredValue = (csvSpec.FrequencyAccuracy.Frequency[freqIndex] - new Random().NextDouble() * 0.001).ToString("n2");
                                                            if (string.IsNullOrEmpty(measuredValue))
                                                                measuredValue = "ERROR";
                                                            else
                                                            {
                                                                measuredValue = (double.Parse(measuredValue.Trim().Split(',').Last().Trim(), CultureInfo.InvariantCulture) / 1000000).ToString("0.000000");
                                                                sAccuracy = ((double.Parse(measuredValue) - csvSpec.FrequencyAccuracy.Frequency[freqIndex]) / csvSpec.FrequencyAccuracy.Frequency[freqIndex] * 1000000).ToString("0.000000");
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            measuredValue = $"E:{measuredValue?.Trim() ?? ""}";
                                                        }
                                                        if (sAccuracy != "-")
                                                        {
                                                            double retryAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                            if (retryAccuracy < csvSpec.FrequencyAccuracy.FreqLimit)
                                                                break;
                                                        }
                                                        }
                                                    }

                                                    string sPFResult = "F";

                                                    if (measuredValue == "Freq OutOfRange")
                                                        sPFResult = "";
                                                    else if (sAccuracy != "-")
                                                    {
                                                        double unSignedAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                        if (unSignedAccuracy < csvSpec.FrequencyAccuracy.FreqLimit)//check if pass/fail
                                                        {
                                                            totalPassTest++;
                                                            sPFResult = "P";
                                                        }
                                                    }

                                                    Invoke((MethodInvoker)(() =>
                                                    {
                                                        dtTestResult.Rows[rowCount][3] = measuredValue;
                                                        dtTestResult.Rows[rowCount][4] = sAccuracy + " ppm";
                                                        dtTestResult.Rows[rowCount][5] = sPFResult;
                                                        lblPassRateValue.Text = totalPassTest + "/" + dtTestResult.Rows.Count;

                                                        int rowEditedVisible = 3 + rowCount - dataGridTestResult.Height / dataGridTestResult.RowTemplate.Height;
                                                        if (rowEditedVisible > 0)
                                                            dataGridTestResult.FirstDisplayedScrollingRowIndex = rowEditedVisible;

                                                        //noError = Results.WriteResult(fileName, DateTime.Now.Subtract(startTimeRef), false, false, dtTestResult.Rows[rowCount]);
                                                        rowCount++;
                                                    }));
                                                    //if (!noError)
                                                    //    goto EndLoop;
                                                }
                                            }
                                        }

                                        DUTCommTester.TransmitOff(routNum);
                                    }
                                }
                            }

                            //DUTCommTester.WriteScpi(csvSpec.scpiDUTSetVSGWavefileState.Replace("xx", "OFF"));   //Turn off DUT wavefile play
                        }
                        else
                        {
                            MessageBox.Show("Please make sure DUT, Spectrum Analyzer and SwitchBox is conected", "VSG Power Test Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    ///VSA Power Accuracy
                    if (VSAPowerSelected && !DUTCommTester.CanReceive)
                    {
                        MessageBox.Show($"DUT ({DUTCommTester.Name}) 不支援 VSA 接收模式，跳過 VSA 測試。", "VSA 跳過", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        VSAPowerSelected = false;
                    }

                    if (VSAPowerSelected)
                    {
                        if (DUTConnected && SGConnected && SwitchConnected)
                        {
                            if (isDebug)
                                switchPortSet = true;
                            else
                                switchPortSet = SwitchBox.SetPort(SwitchBox.PortSGDUT);
                            if (!switchPortSet)
                            {
                                MessageBox.Show("An error occured when changing the Switch Box port", "Changing port failed");
                                goto EndLoop;
                            }
                            //HK: Please add if any VSA test cases is selected. if not skip below commands
                            SG.Reset();
                            SG.WriteScpi("SOUR:POW -90 dBm");
                            SG.WriteScpi("OUTP ON");
                            //DUTCommTester.WriteScpi(csvSpec.scpiDUTSetVSASamplingRate);                   //Set VSA Sampling rate
                            Thread.Sleep(Settings.Default.delayInitialize);

                            for (int j = 0; j < 4; j++)//RF<i><j>
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    string portLetter = i == 0 ? "A" : "B";
                                    string routNum = i == 0 ? "1" : "12";
                                    if (cbRout.Visible)
                                        routNum = i == 0 ? rout : rout + "2";

                                    DUTCommTester.SetupVSAMode(routNum);

                                    if (csvSpec.VSAPowerAccuracy.rfChannelIsOn[j, i])
                                    {
                                        DUTCommTester.SetupVSAChannel(j + 1, portLetter, routNum);

                                        for (int freqIndex = 0; freqIndex < csvSpec.VSAPowerAccuracy.Frequency_Str.Count; freqIndex++)
                                        {
                                            DUTCommTester.SetupVSAFrequency(csvSpec.VSAPowerAccuracy.Frequency[freqIndex], routNum);
                                            SG.WriteScpi("FREQ " + csvSpec.VSAPowerAccuracy.Frequency_Str[freqIndex] + " MHz");                                                             //Set SG Frequency 

                                            for (int powIndex = 0; powIndex < csvSpec.VSAPowerAccuracy.Power_Str.Count; powIndex++)
                                            {
                                                startTimeRef = DateTime.Now;
                                                string sAccuracy = "-";
                                                string measuredValue = "";

                                                if (DUTCommTester.Model == "IQXEL-M")
                                                {
                                                    if (csvSpec.VSAPowerAccuracy.Frequency[freqIndex] < 860 || csvSpec.VSAPowerAccuracy.Frequency[freqIndex] > 6000
                                                    || (csvSpec.VSAPowerAccuracy.Frequency[freqIndex] > 1000 && csvSpec.VSAPowerAccuracy.Frequency[freqIndex] < 1770)
                                                    || (csvSpec.VSAPowerAccuracy.Frequency[freqIndex] > 2660 && csvSpec.VSAPowerAccuracy.Frequency[freqIndex] < 3300)
                                                    || (csvSpec.VSAPowerAccuracy.Frequency[freqIndex] > 3800 && csvSpec.VSAPowerAccuracy.Frequency[freqIndex] < 4900))
                                                    {
                                                        measuredValue = "Freq OutOfRange";
                                                    }
                                                }

                                                if (measuredValue != "Freq OutOfRange")
                                                {
                                                    SG.WriteScpi("SOUR:POW " + csvSpec.VSAPowerAccuracy.Power_Str[powIndex] + " dBm");  //Set SG Level
                                                    DUTCommTester.PrepareVSAMeasurement(csvSpec.VSAPowerAccuracy.Power[powIndex], routNum);
                                                    Thread.Sleep(Settings.Default.delayStep);

                                                    if (isPauseMode)
                                                    {
                                                        MessageBox.Show(
                                                            $"[VSA Power] SG ON\nPort: RF{j + 1}{portLetter}\nFreq: {csvSpec.VSAPowerAccuracy.Frequency_Str[freqIndex]} MHz\nSG Power: {csvSpec.VSAPowerAccuracy.Power_Str[powIndex]} dBm\n\nCheck DUT VSA is ready, then click OK to capture.",
                                                            "Debug Pause");
                                                    }

                                                    for (int retry = 0; retry < 6; retry++)
                                                    {
                                                    sAccuracy = "-";
                                                    DUTCommTester.InitiateVSACapture();
                                                    loss = 0;
                                                    if (lblCalFileName.Text != "-")
                                                        loss = ConfigCAL.getPowerLoss(csvSpec.VSAPowerAccuracy.Frequency[freqIndex], j, i, "SGDUT");   //Set Y marker reading offset

                                                    measuredValue = DUTCommTester.ReadVSAPower();
                                                    try
                                                    {
                                                        if (isDebug && string.IsNullOrEmpty(measuredValue))
                                                            measuredValue = (csvSpec.VSAPowerAccuracy.Power[powIndex] - new Random().NextDouble()).ToString("n2");
                                                        if (string.IsNullOrEmpty(measuredValue))
                                                            measuredValue = "ERROR";
                                                        else //sample DUT value format = "0,-1.2345678e+01";
                                                        {
                                                            measuredValue = (double.Parse(measuredValue.Trim().Split(',').Last().Trim(), CultureInfo.InvariantCulture) - loss).ToString("0.00", CultureInfo.InvariantCulture);   //remove "0,", convert exponential number format to 2 decimal place
                                                            sAccuracy = (double.Parse(measuredValue) - csvSpec.VSAPowerAccuracy.Power[powIndex]).ToString("0.00");
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        measuredValue = $"E:{measuredValue?.Trim() ?? ""}";
                                                    }
                                                    if (sAccuracy != "-")
                                                    {
                                                        double retryAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                        if (csvSpec.VSAPowerAccuracy.Frequency[freqIndex] <= 3800 && retryAccuracy < csvSpec.VSAPowerAccuracy.LowFreqLimit
                                                        || csvSpec.VSAPowerAccuracy.Frequency[freqIndex] > 3800 && retryAccuracy < csvSpec.VSAPowerAccuracy.HighFreqLimit)
                                                            break;
                                                    }
                                                    }
                                                }

                                                string sPFResult = "F";

                                                if (measuredValue == "Freq OutOfRange")
                                                    sPFResult = "";
                                                else if (sAccuracy != "-")
                                                {
                                                    double unSignedAccuracy = Math.Abs(double.Parse(sAccuracy));
                                                    if (csvSpec.VSAPowerAccuracy.Frequency[freqIndex] <= 3800 && unSignedAccuracy < csvSpec.VSAPowerAccuracy.LowFreqLimit
                                                    || csvSpec.VSAPowerAccuracy.Frequency[freqIndex] > 3800 && unSignedAccuracy < csvSpec.VSAPowerAccuracy.HighFreqLimit)//check if pass/fail
                                                    {
                                                        totalPassTest++;
                                                        sPFResult = "P";
                                                    }
                                                }

                                                Invoke((MethodInvoker)(() =>
                                                {
                                                    dtTestResult.Rows[rowCount][3] = measuredValue;
                                                    dtTestResult.Rows[rowCount][4] = sAccuracy + " dB";
                                                    dtTestResult.Rows[rowCount][5] = sPFResult;
                                                    lblPassRateValue.Text = totalPassTest + "/" + dtTestResult.Rows.Count;

                                                    int rowEditedVisible = 3 + rowCount - dataGridTestResult.Height / dataGridTestResult.RowTemplate.Height;
                                                    if (rowEditedVisible > 0)
                                                        dataGridTestResult.FirstDisplayedScrollingRowIndex = rowEditedVisible;

                                                    //noError = Results.WriteResult(fileName, DateTime.Now.Subtract(startTimeRef), false, false, dtTestResult.Rows[rowCount]);
                                                    rowCount++;
                                                }));
                                                //if (!noError)
                                                //    goto EndLoop;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please make sure DUT, Signal Generator and SwitchBox is connected", "VSA Power Test Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                EndLoop:
                    if (SGConnected)
                        SG.WriteScpi("OUTP OFF");
                    Invoke((MethodInvoker)(() =>
                    {
                        isTesting = false;
                        btnStartStop.Text = "START";
                        btnStartStop.BackColor = Color.LimeGreen;
                        btnLoadSpecFile.Enabled = true;
                        btnLoadCal.Enabled = true;

                        timerDuration.Enabled = false;
                        DateTime finalTime = DateTime.Now;
                        TimeSpan totalDuration = finalTime.Subtract(startDT);
                        lblDurationTimer.Text = string.Format("{0}:{1}.{2}", totalDuration.Minutes.ToString("00"), totalDuration.Seconds.ToString("00"), totalDuration.Milliseconds.ToString("000"));

                        //Results.WriteResult(fileName, totalDuration, true, false);
                        Results.createReport(dtTestResult, csvSpec, DUTCommTester, SG, SA, PS, SwitchBox, DateTime.Now, totalPassTest, totalDuration, false, isDebug);
                    }));
                });
            }
            
            testThread.Start();
        }

        private void connectSG()
        {
            if (!SGConnected)
            {
                loadingConnectPic.Visible = true;
                isConnecting++;
                new Thread(delegate ()
                {
                    SGConnected = SG.ConnectLan(csvSpec.ipSG);
                    SG.WriteScpi("SYST:DISP:UPD ON");
                    SG.GetIDN();
                    isConnecting--;

                    Invoke((MethodInvoker)(() =>
                    {
                        if (isConnecting == 0)
                        {
                            loadingConnectPic.Visible = false;
                            btnLoadSpecFile.Enabled = true;
                        }

                        if (SGConnected)
                            lblSGConnectivity.ForeColor = Color.LimeGreen;
                        else
                            lblSGConnectivity.ForeColor = Color.Red;
                    }));
                }).Start();
            }
        }

        private void connectPS()
        {
            if (!PSConnected)
            {
                loadingConnectPic.Visible = true;
                isConnecting++;
                new Thread(delegate ()
                {
                    PSConnected = PS.ConnectUSB(csvSpec.ipPS);
                    PS.WriteScpi("SYST:DISP:UPD ON");
                    PS.GetIDN();
                    isConnecting--;

                    Invoke((MethodInvoker)(() =>
                    {
                        if (isConnecting == 0)
                        {
                            loadingConnectPic.Visible = false;
                            btnLoadSpecFile.Enabled = true;
                        }

                        if (PSConnected)
                            lblPSConnectivity.ForeColor = Color.LimeGreen;
                        else
                            lblPSConnectivity.ForeColor = Color.Red;
                    }));
                }).Start();
            }
        }

        private void connectSA()
        {
            if (!SAConnected)
            {
                loadingConnectPic.Visible = true;
                isConnecting++;
                new Thread(delegate ()
                {
                    SAConnected = SA.ConnectLan(csvSpec.ipSA);
                    SA.WriteScpi("SYST:DISP:UPD ON");
                    SA.GetIDN();
                    isConnecting--;

                    BeginInvoke((MethodInvoker)(() =>
                    {
                        if (isConnecting == 0)
                        {
                            loadingConnectPic.Visible = false;
                            btnLoadSpecFile.Enabled = true;
                        }

                        if (SAConnected)
                            lblSAConnectivity.ForeColor = Color.LimeGreen;
                        else
                            lblSAConnectivity.ForeColor = Color.Red;
                    }));
                }).Start();
            }
        }
        private void connectDUT()
        {
            if (!DUTConnected)
            {
                loadingConnectPic.Visible = true;

                lblManufacturerValue.Text = "-";
                lblModelValue.Text = "-";
                lblSerialNoValue.Text = "-";

                isConnecting++;
                new Thread(delegate ()
                {
                    if (csvSpec.dutType == "RSAnalyzer")
                        DUTCommTester = new RSAnalyzerDUT();
                    else if (csvSpec.dutType == "RSGenerator")
                        DUTCommTester = new RSGeneratorDUT();
                    else
                    {
                        var lp = new LitePointDUT();
                        lp.SetSpec(csvSpec);
                        DUTCommTester = lp;
                    }

                    DUTConnected = DUTCommTester.ConnectLan(csvSpec.ipDUT);
                    DUTCommTester.GetIDN();
                    isConnecting--;

                    BeginInvoke((MethodInvoker)(() =>
                    {
                        if (isConnecting == 0)
                        {
                            loadingConnectPic.Visible = false;
                            btnLoadSpecFile.Enabled = true;
                        }

                        if (DUTConnected)
                        {
                            lblDUTConnectivity.ForeColor = Color.LimeGreen;

                            lblManufacturerValue.Text = DUTCommTester.Vendor;
                            lblModelValue.Text = DUTCommTester.Model;
                            lblSerialNoValue.Text = DUTCommTester.SN;
                        }
                        else
                        {
                            lblDUTConnectivity.ForeColor = Color.Red;

                            lblManufacturerValue.Text = "-";
                            lblModelValue.Text = "-";
                            lblSerialNoValue.Text = "-";
                        }
                    }));
                }).Start();
            }
        }
        private void connectSwitch()
        {
            if (!SwitchConnected)
            {
                loadingConnectPic.Visible = true;
                isConnecting++;
                new Thread(delegate ()
                {
                    SwitchBox = csvSpec.switchType == "Rapidtek"
                        ? (ISwitchBox)new SwitchRapidtek()
                        : new Switch();

                    SwitchConnected = SwitchBox.Connect(csvSpec.ipSwitch);
                    if (SwitchConnected)
                    {
                        SwitchConnected = SwitchBox.SetPort(SwitchBox.PortSGDUT);
                        SwitchConnected = SwitchBox.currentPort().Contains(SwitchBox.PortSGDUT.ToString());
                        SwitchConnected = SwitchBox.SetPort(SwitchBox.PortSADUT);
                        SwitchConnected = SwitchBox.currentPort().Contains(SwitchBox.PortSADUT.ToString());
                    }

                    isConnecting--;

                    BeginInvoke((MethodInvoker)(() =>
                    {
                        if (isConnecting == 0)
                        {
                            loadingConnectPic.Visible = false;
                            btnLoadSpecFile.Enabled = true;
                        }

                        if (SwitchConnected)
                        {
                            lblSwitchConnectivity.ForeColor = Color.LimeGreen;
                            button1.Enabled = true;
                            button2.Enabled = true;
                            updateSwitchPortButtons(1);
                        }
                        else
                        {
                            lblSwitchConnectivity.ForeColor = Color.Red;
                            button1.Enabled = false;
                            button2.Enabled = false;
                        }
                    }));
                }).Start();
            }
        }

        // For a dual-path RSGeneratorDUT (SMW), Port A/B must map to SOUR1/SOUR2 (routNum),
        // not the LitePoint-style routing code. Other DUT types keep their existing routNum.
        private string ResolveVsgRouteNum(int portIndex, string defaultRoutNum)
        {
            if (DUTCommTester is RSGeneratorDUT)
                return portIndex == 0 ? csvSpec.vsgPathA : csvSpec.vsgPathB;
            return defaultRoutNum;
        }

        private void updateSwitchPortButtons(int activePort)
        {
            button1.BackColor = activePort == SwitchBox.PortSADUT ? Color.LimeGreen : SystemColors.Control;
            button1.ForeColor = activePort == SwitchBox.PortSADUT ? Color.Black : SystemColors.ControlText;
            button2.BackColor = activePort == SwitchBox.PortSGDUT ? Color.LimeGreen : SystemColors.Control;
            button2.ForeColor = activePort == SwitchBox.PortSGDUT ? Color.Black : SystemColors.ControlText;
        }

        private void LitepointHealthCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.delayInitialize = (int)numericUpDownInitialize.Value;
            Settings.Default.delayStep = (int)numericUpDownStep.Value;
            Settings.Default.Save();

            if (testThread != null && testThread.IsAlive)
                testThread.Abort();
        }

        private void picRefreshBtn_Click(object sender, EventArgs e)
        {
            if (isTesting)
                return;

            dataGridTestResult.ClearSelection();
            if (lblSpecAddress.Text == "-")
            {
                MessageBox.Show("No specification file loaded for IP address to refresh connection", "No specifications loaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isConnecting > 0) return;

            disconnectAll();

            lblSGConnectivity.ForeColor = Color.Red;
            lblPSConnectivity.ForeColor = Color.Red;
            lblSAConnectivity.ForeColor = Color.Red;
            lblDUTConnectivity.ForeColor = Color.Red;
            lblSwitchConnectivity.ForeColor = Color.Red;
            btnLoadSpecFile.Enabled = false;

            bool parseSuccess = csvSpec.Initialize(dialogOpenSpecFile.FileName);
            if (!parseSuccess)
            {
                lblSpecAddress.Text = "-";

                lblManufacturerValue.Text = "-";
                lblModelValue.Text = "-";
                lblSerialNoValue.Text = "-";

                lblDateValue.Text = "-";
                lblTimeValue.Text = "-";
                lblDurationTimer.Text = "00:00.000";
                lblPassRateValue.Text = "-/-";

                loadingConnectPic.Visible = false;
                btnLoadSpecFile.Enabled = true;
                btnLoadSpecFile.Enabled = true;

                return;
            }

            connectSG();
            connectPS();
            connectSA();
            connectDUT();
            connectSwitch();
        }

        private void disconnectAll()
        {
            if (SGConnected)
                SG.DisconnectDevice();
            if (PSConnected)
                PS.DisconnectDevice();
            if (SAConnected)
                SA.DisconnectDevice();
            if (DUTConnected)
                DUTCommTester.DisconnectDevice();
            //if (SwitchConnected)
            //    SwitchBox.Disconnect();

            SGConnected = false;
            PSConnected = false;
            SAConnected = false;
            DUTConnected = false;
            SwitchConnected = false;

            button1.Enabled = false;
            button2.Enabled = false;
            button1.BackColor = SystemColors.Control;
            button1.ForeColor = SystemColors.ControlText;
            button2.BackColor = SystemColors.Control;
            button2.ForeColor = SystemColors.ControlText;
        }
        private void btnGenerateNewTemplate_Click(object sender, EventArgs e)
        {
            SpecPopupForm popup = new SpecPopupForm();
            popup.ShowDialog();
            string generatedFileName = csvSpec.generateSpecTemplate(popup.selectedSpec);

            bool isTx = popup.selectedSpec == "Specifications_RS_Generator";
            bool isRx = popup.selectedSpec == "Specifications_RS_FSW";
            if (isTx || isRx)
            {
                FrequencySweepPopupForm sweepPopup = new FrequencySweepPopupForm(isTx ? "TX (VSG)" : "RX (VSA)");
                if (sweepPopup.ShowDialog() == DialogResult.OK)
                    csvSpec.ApplyFrequencySweep(generatedFileName, sweepPopup.StartFreq, sweepPopup.StopFreq, sweepPopup.StepFreq, isTx);
            }

            //MessageBoxManager.Yes = "Default";
            //MessageBoxManager.No = "IQXSTREAM-M";
            //MessageBoxManager.Register();
            //DialogResult dr = MessageBox.Show("Select spec file type:", "Specification File Type", MessageBoxButtons.YesNoCancel);
            //MessageBoxManager.Unregister();

            //if (dr == DialogResult.Yes)
            //    csvSpec.generateSpecTemplate();
            //else if (dr == DialogResult.No)
            //    csvSpec.generateSpecTemplate(16);
        }

        private void btnLoadSpecFile_Click(object sender, EventArgs e)
        {
            try
            {
                dialogOpenSpecFile.InitialDirectory = Application.StartupPath;
                DialogResult dialogResult = dialogOpenSpecFile.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    clearTable();

                    lblSpecAddress.Text = dialogOpenSpecFile.FileName;

                    picRefreshBtn_Click(sender, e);

                    bool showRout = File.ReadAllText(lblSpecAddress.Text).Split('\n')[0].Contains("(IQxstream-M)");
                    cbRout.Visible = showRout;
                    lblRout.Visible = showRout;

                    //Populate test specs on table
                    Thread specThread = new Thread(delegate ()
                    {
                        try
                        {
                            string testName = "VSG High Power Accuracy";

                            ///VSG Power Accuracy
                            //High Power
                            for (int j = 0; j < 4; j++)//RF<i><j>
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    if (csvSpec.VSGHighPowerAccuracy.rfChannelIsOn[j, i])
                                    {
                                        for (int freqIndex = 0; freqIndex < csvSpec.VSGHighPowerAccuracy.Frequency_Str.Count; freqIndex++)
                                        {
                                            for (int powIndex = 0; powIndex < csvSpec.VSGHighPowerAccuracy.Power_Str.Count; powIndex++)
                                            {
                                                string bank = "";
                                                if (i == 0)
                                                    bank = "A";
                                                else
                                                    bank = "B";

                                                var rowObj = new object[] { testName, "RF" + (j + 1) + bank + ", " + csvSpec.VSGHighPowerAccuracy.Frequency_Str[freqIndex] + "MHz", csvSpec.VSGHighPowerAccuracy.Power_Str[powIndex], "" };

                                                if (!string.IsNullOrEmpty(testName))
                                                    testName = "";
                                                BeginInvoke((MethodInvoker)(() =>
                                                {
                                                    dtTestResult.Rows.Add(rowObj);
                                                }));
                                            }
                                        }
                                    }
                                }
                            }

                            testName = "VSG Low Power Accuracy";
                            //Low Power
                            for (int j = 0; j < 4; j++)//RF<i><j>
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    if (csvSpec.VSGLowPowerAccuracy.rfChannelIsOn[j, i])
                                    {
                                        for (int freqIndex = 0; freqIndex < csvSpec.VSGLowPowerAccuracy.Frequency_Str.Count; freqIndex++)
                                        {
                                            for (int powIndex = 0; powIndex < csvSpec.VSGLowPowerAccuracy.Power_Str.Count; powIndex++)
                                            {
                                                string bank = "";
                                                if (i == 0)
                                                    bank = "A";
                                                else
                                                    bank = "B";

                                                var rowObj = new object[] { testName, "RF" + (j + 1) + bank + ", " + csvSpec.VSGLowPowerAccuracy.Frequency_Str[freqIndex] + "MHz", csvSpec.VSGLowPowerAccuracy.Power_Str[powIndex], "" };

                                                if (!string.IsNullOrEmpty(testName))
                                                    testName = "";
                                                BeginInvoke((MethodInvoker)(() =>
                                                {
                                                    dtTestResult.Rows.Add(rowObj);
                                                }));
                                            }
                                        }
                                    }
                                }
                            }
                            ///Frequency Accuracy
                            testName = "Frequency Accuracy";
                            //Low Power
                            for (int j = 0; j < 4; j++)//RF<i><j>
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    if (csvSpec.FrequencyAccuracy.rfChannelIsOn[j, i])
                                    {
                                        for (int freqIndex = 0; freqIndex < csvSpec.FrequencyAccuracy.Frequency_Str.Count; freqIndex++)
                                        {
                                            for (int powIndex = 0; powIndex < csvSpec.FrequencyAccuracy.Power_Str.Count; powIndex++)
                                            {
                                                string bank = "";
                                                if (i == 0)
                                                    bank = "A";
                                                else
                                                    bank = "B";

                                                var rowObj = new object[] { testName, "RF" + (j + 1) + bank + ", " + csvSpec.FrequencyAccuracy.Frequency_Str[freqIndex] + "MHz", csvSpec.FrequencyAccuracy.Power_Str[powIndex], "" };

                                                if (!string.IsNullOrEmpty(testName))
                                                    testName = "";
                                                BeginInvoke((MethodInvoker)(() =>
                                                {
                                                    dtTestResult.Rows.Add(rowObj);
                                                }));
                                            }
                                        }
                                    }
                                }
                            }

                            ///VSA Power Accuracy
                            testName = "VSA Power Accuracy";

                            for (int j = 0; j < 4; j++)//RF<i><j>
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    if (csvSpec.VSAPowerAccuracy.rfChannelIsOn[j, i])
                                    {
                                        for (int freqIndex = 0; freqIndex < csvSpec.VSAPowerAccuracy.Frequency_Str.Count; freqIndex++)
                                        {
                                            for (int powIndex = 0; powIndex < csvSpec.VSAPowerAccuracy.Power_Str.Count; powIndex++)
                                            {
                                                string bank = "";
                                                if (i == 0)
                                                    bank = "A";
                                                else
                                                    bank = "B";

                                                var rowObj = new object[] { testName, "RF" + (j + 1) + bank + ", " + csvSpec.VSAPowerAccuracy.Frequency_Str[freqIndex] + "MHz", csvSpec.VSAPowerAccuracy.Power_Str[powIndex] };

                                                if (!string.IsNullOrEmpty(testName))
                                                    testName = "";
                                                BeginInvoke((MethodInvoker)(() =>
                                                {
                                                    dtTestResult.Rows.Add(rowObj);
                                                }));
                                            }
                                        }
                                    }
                                }
                            }

                            BeginInvoke((MethodInvoker)(() => lblPassRateValue.Text = "0/" + dtTestResult.Rows.Count));
                        }
                        catch(Exception e)
                        {
                            MessageBox.Show("Error populating test data form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    });
                    specThread.Start();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loading spec file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timerDuration_Tick(object sender, EventArgs e)
        {
            TimeSpan durationNow = DateTime.Now.Subtract(startDT);
            lblDurationTimer.Text = string.Format("{0}:{1}.{2}", durationNow.Minutes.ToString("00"), durationNow.Seconds.ToString("00"), durationNow.Milliseconds.ToString("000"));
        }

        private void lblSpecAddress_TextChanged(object sender, EventArgs e)
        {
            if (lblSpecAddress.PreferredWidth > lblSpecAddress.Width)
                lblSpecAddress.Margin = new Padding(8, 3, 0, 0);
            else
                lblSpecAddress.Margin = new Padding(8, 9, 0, 4);
        }

        private void dataGridTestResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                switch (e.Value)
                {
                    case "":
                        e.CellStyle.BackColor = Color.FromArgb(48, 48, 48);
                        break;
                    case "P":
                        e.CellStyle.BackColor = Color.LimeGreen;
                        break;
                    case "F":
                        e.CellStyle.BackColor = Color.Red;
                        break;
                }
            }
        }

        private void dataGridTestResult_Leave(object sender, EventArgs e)
        {
            dataGridTestResult.ClearSelection();
            lblSpecAddress.Focus();
        }

        //private void btnCalibratrionCheck_Click(object sender, EventArgs e)
        //{
        //    if (btnCalibrationCheck.Text == "")
        //    {
        //        if (!ConfigCAL.CalibrateSGtoDUT.HasReference || !ConfigCAL.CalibrateSAtoDUT.HasReference)
        //            btnCalibrate_Click(null, null);
        //        else
        //            btnCalibrationCheck.Text = "✔";
        //    }
        //    else
        //        btnCalibrationCheck.Text = "";
        //}

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            //checkExpiry();

            if (lblCalFileName.Text == "-")
            {
                if (isTesting)
                    return;

                MessageBoxManager.Yes = "New";
                MessageBoxManager.No = "Load";
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("Calibration file not loaded. Do you want to perform a new calibration or load an existing calibration file?", "No calibration file", MessageBoxButtons.YesNoCancel);
                MessageBoxManager.Unregister();
                if (dr == DialogResult.No)//Load Existing File
                {
                    btnLoadCal.PerformClick();
                    return;
                }
                else if (dr == DialogResult.Cancel)
                    return;

                ConfigCAL.CSVStartUp();
            }
            else
                ConfigCAL.CSVStartUp(Application.StartupPath + "\\Calibration\\" + lblCalFileName.Text);

            calibrationForm = new CalibrationForm(this);
            calibrationForm.FormClosing += new FormClosingEventHandler(CalibrationFormClosing);

            mainPanel.Controls.Clear();

            mainPanel.Controls.Add(calibrationForm, 0, 0);
            mainPanel.SetColumnSpan(calibrationForm, mainPanel.ColumnCount);
            mainPanel.SetRowSpan(calibrationForm, mainPanel.RowCount);
            calibrationForm.Dock = DockStyle.Fill;
            calibrationForm.Show();
        }

        private void CalibrationFormClosing(object sender, FormClosingEventArgs e)
        {
            loadCalData();

            //calibrationForm.Hide();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(this.sidePanel, 0, 1);
            mainPanel.Controls.Add(this.dataGridTestResult, 1, 1);
            mainPanel.Controls.Add(this.panelConnectivity, 0, 2);
            mainPanel.Controls.Add(this.panelCSV, 0, 0);
            //foreach (Control ctrls in mainPanel.Controls)
            //    ctrls.Show();
        }


        private void ConnectivityUpdated(object sender, EventArgs e)
        {
            //if (DUTConnected)
            //{
            //    btnCalibrate.Enabled = true;
            //    btnCalibratrionCheck.Enabled = true;

            //    if (ConfigCAL.CalibrateSGtoDUT.HasReference && ConfigCAL.CalibrateSAtoDUT.HasReference)
            //    {
            //        lblSGDUTCalDate.Text = ConfigCAL.CalibrateSGtoDUT.ReferenceDate + "\n" + ConfigCAL.CalibrateSAtoDUT.ReferenceDate;
            //        btnCalibratrionCheck.Text = "✔";
            //    }
            //    else
            //    {
            //        lblSGDUTCalDate.Text = "-";
            //        btnCalibratrionCheck.Text = "";
            //    }
            //}
            //else
            //{
            //    btnCalibrate.Enabled = false;
            //    btnCalibratrionCheck.Enabled = false;
            //    lblSGDUTCalDate.Text = "-";
            //}            
        }

        private void SGUserCorrection(int numPort, int alphaPort)
        {
            int colNum = numPort * 2 + alphaPort + 1;

            string userCorrFreq = "CORR:CSET:DATA:FREQ ";
            string userCorrPow = "CORR:CSET:DATA:POW ";

            foreach (string[] row in ConfigCAL.CalibrateSGtoDUT)
            {
                userCorrFreq += row[0] + "MHz,";
                userCorrPow += row[colNum] + "dB, ";
            }
            userCorrFreq = userCorrFreq.Remove(userCorrFreq.Length - 1, 1); //remove last comma
            userCorrPow = userCorrPow.Remove(userCorrPow.Length - 2, 2);    //remove last comma and space

            SG.WriteScpi("SOUR:CORR OFF");
            SG.WriteScpi("SOUR:CORR:CSET '/var/user/temp3'");
            SG.WriteScpi(userCorrFreq);
            SG.WriteScpi(userCorrPow);
            SG.WriteScpi("SOUR:CORR ON");
        }

        private void btnLoadCal_Click(object sender, EventArgs e)
        {
            dialogOpenCalFile.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\Calibration";

            DialogResult dr = dialogOpenCalFile.ShowDialog();

            if (dr == DialogResult.OK)
            {
                ConfigCAL.CSVStartUp(dialogOpenCalFile.FileName);
                loadCalData();
            }
        }

        private void loadCalData()
        {
            lblCalFileName.Text = string.IsNullOrEmpty(ConfigCAL.EXTERNAL_CSVNAME) ? "-" : ConfigCAL.EXTERNAL_CSVNAME;

            lblSGDUTCalDate.Text = string.IsNullOrEmpty(ConfigCAL.SGDUTReferenceDate) ? "-" : ConfigCAL.SGDUTReferenceDate.Remove(ConfigCAL.SGDUTReferenceDate.Length - 3, 3).Replace(" ", "\n");
            lblSADUTCalDate.Text = string.IsNullOrEmpty(ConfigCAL.SADUTReferenceDate) ? "-" : ConfigCAL.SADUTReferenceDate.Remove(ConfigCAL.SADUTReferenceDate.Length - 3, 3).Replace(" ", "\n");

            //int calLastDays = 60;
            //if (ConfigCAL.CalibrateSGtoDUT.HasReference && DateTime.Now.AddDays(calLastDays) < DateTime.Parse(ConfigCAL.CalibrateSGtoDUT.ReferenceDate))
            //{
            //    ConfigCAL.CalibrateSGtoDUT.HasReference = false;
            //    ConfigCAL.CSVSave();
            //}
            //if (ConfigCAL.CalibrateSAtoDUT.HasReference && DateTime.Now.AddDays(calLastDays) < DateTime.Parse(ConfigCAL.CalibrateSAtoDUT.ReferenceDate))
            //{
            //    ConfigCAL.CalibrateSAtoDUT.HasReference = false;
            //    ConfigCAL.CSVSave();
            //}

            lblSGDUTCalDate.ForeColor = ConfigCAL.SGDUTHasReference ? Color.LimeGreen : Color.Yellow;
            lblSADUTCalDate.ForeColor = ConfigCAL.SADUTHasReference ? Color.LimeGreen : Color.Yellow;
            lblSGDUT.ForeColor = lblSGDUTCalDate.ForeColor;
            lblSADUT.ForeColor = lblSADUTCalDate.ForeColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!SwitchConnected) return;
            new Thread(delegate ()
            {
                bool ok = SwitchBox.SetPort(SwitchBox.PortSADUT);
                BeginInvoke((MethodInvoker)(() =>
                {
                    if (ok) updateSwitchPortButtons(SwitchBox.PortSADUT);
                }));
            }).Start();
        }

        private void btnDebugStart_Click(object sender, EventArgs e)
        {
            isPauseMode = !isPauseMode;

            if (isPauseMode)
                btnDebugStart.BackColor = Color.Orange;
            else
                btnDebugStart.BackColor = SystemColors.Control;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!SwitchConnected) return;
            new Thread(delegate ()
            {
                bool ok = SwitchBox.SetPort(SwitchBox.PortSGDUT);
                BeginInvoke((MethodInvoker)(() =>
                {
                    if (ok) updateSwitchPortButtons(SwitchBox.PortSGDUT);
                }));
            }).Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLPVSGOn_Click(object sender, EventArgs e)
        {
            if (!DUTConnected)
            {
                MessageBox.Show("Please connect DUT first", "DUT not connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(csvSpec.scpiDUTSetVSGMode))
            {
                MessageBox.Show("Please load a specification file first", "No spec loaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string portSel = cbLPVSGPort.SelectedItem?.ToString() ?? "RF1A";
            int j = int.Parse(portSel.Substring(2, 1)) - 1;
            string portLetter = portSel.Substring(3, 1);
            int i = portLetter == "A" ? 0 : 1;
            string routNum = i == 0 ? "1" : "12";
            if (cbRout.Visible && !string.IsNullOrEmpty(rout))
                routNum = i == 0 ? rout : rout + "2";
            routNum = ResolveVsgRouteNum(i, routNum);

            string freqStr = numericLPVSGFreq.Value.ToString("F3");
            string powStr = numericLPVSGLevel.Value.ToString("F1");

            btnLPVSGOn.Enabled = false;
            btnLPVSGOff.Enabled = false;

            new Thread(delegate ()
            {
                DUTCommTester.SetupVSGChannel(double.Parse(freqStr), j + 1, portLetter, routNum);
                DUTCommTester.SetupVSGPower(double.Parse(powStr), routNum);
                DUTCommTester.TransmitOn(routNum);

                BeginInvoke((MethodInvoker)(() =>
                {
                    btnLPVSGOn.BackColor = Color.LimeGreen;
                    btnLPVSGOn.ForeColor = Color.Black;
                    btnLPVSGOff.BackColor = Color.FromArgb(48, 48, 48);
                    btnLPVSGOff.ForeColor = Color.OrangeRed;
                    btnLPVSGOn.Enabled = true;
                    btnLPVSGOff.Enabled = true;
                }));
            }).Start();
        }

        private void btnLPVSGOff_Click(object sender, EventArgs e)
        {
            if (!DUTConnected) return;
            if (string.IsNullOrEmpty(csvSpec.scpiDUTSetVSGRFOnOffState)) return;

            string portSel = cbLPVSGPort.SelectedItem?.ToString() ?? "RF1A";
            string portLetter = portSel.Substring(3, 1);
            int i = portLetter == "A" ? 0 : 1;
            string routNum = i == 0 ? "1" : "12";
            if (cbRout.Visible && !string.IsNullOrEmpty(rout))
                routNum = i == 0 ? rout : rout + "2";
            routNum = ResolveVsgRouteNum(i, routNum);

            btnLPVSGOn.Enabled = false;
            btnLPVSGOff.Enabled = false;

            new Thread(delegate ()
            {
                DUTCommTester.TransmitOff(routNum);

                BeginInvoke((MethodInvoker)(() =>
                {
                    btnLPVSGOn.BackColor = Color.FromArgb(48, 48, 48);
                    btnLPVSGOn.ForeColor = Color.LimeGreen;
                    btnLPVSGOff.BackColor = Color.OrangeRed;
                    btnLPVSGOff.ForeColor = Color.Black;
                    btnLPVSGOn.Enabled = true;
                    btnLPVSGOff.Enabled = true;
                }));
            }).Start();
        }

        private void lblCalFileName_TextChanged(object sender, EventArgs e)
        {
            calFilePanel.ColumnStyles.Clear();

            if (lblCalFileName.Text == "-")
            {
                calFilePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                calFilePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0F));
            }
            else
            {
                calFilePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
                calFilePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            }
        }

        private void btnClearCalibration_Click(object sender, EventArgs e)
        {
            lblSGDUTCalDate.ForeColor = Color.Yellow;
            lblSADUTCalDate.ForeColor = Color.Yellow;
            lblSGDUT.ForeColor = Color.Yellow;
            lblSADUT.ForeColor = Color.Yellow;
            lblSGDUTCalDate.Text = "-";
            lblSADUTCalDate.Text = "-";
            lblCalFileName.Text = "-";
        }

        private void lblSpecAddress_Click(object sender, EventArgs e)
        {
            if (!isTesting)
                btnLoadSpecFile.PerformClick();
        }

        private void LitepointHealthCheck_Leave(object sender, EventArgs e)
        {
            if (testThread != null)
            {
                if (testThread.IsAlive)
                    testThread.Resume();
                testThread.Abort();
            }

            if (calibrationForm != null && calibrationForm.calThread != null)
            {
                if (calibrationForm.calThread.IsAlive)
                    calibrationForm.calThread.Resume();
                calibrationForm.calThread.Abort();
            }
        }

        private void checkExpiry()
        {
            string expiryDate = "17/10/2024";
            if (DateTime.Now > DateTime.ParseExact(expiryDate, "dd/MM/yyyy", CultureInfo.InvariantCulture))
            {
                MessageBox.Show("The demo duration for this software has ended, please contact your Rohde & Schwarz representative to upgrade to the full version.", "Demo version expired");
                Close();
                return;
            }
        }

        private void btnSetupImage_Click(object sender, EventArgs e)
        {
            if (setupDiagram == null || !setupDiagram.Created)
                setupDiagram = new DiagramPopupForm();

            setupDiagram.Text = "Instrument Setup";
            setupDiagram.BackgroundImage = Properties.Resources.InstrumentSetup;
            setupDiagram.Show();
            setupDiagram.BringToFront();
        }

        private void numericUpDownInitialize_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.delayInitialize = (int)numericUpDownInitialize.Value;
            Settings.Default.Save();
        }

        private void numericUpDownStep_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.delayStep = (int)numericUpDownStep.Value;
            Settings.Default.Save();
        }

        private void lblDebug_Click(object sender, EventArgs e)
        {
            if (!isDebug)
            {
                lblDebug.Text = "Debug Mode";
                btnDebugStart.Visible = true;
                isDebug = true;
            }
            else
            {
                lblDebug.Text = $"v{ProductVersion}";
                btnDebugStart.BackColor = SystemColors.Control;
                btnDebugStart.Visible = false;
                isVerify = false;
                isDebug = false;
                picRefreshBtn_Click(null, null);
            }
        }

        private void cbRout_TextChanged(object sender, EventArgs e)
        {
            rout = cbRout.Text;
        }
    }
}
