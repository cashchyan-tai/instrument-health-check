using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using System.Web;

namespace Pegatron
{
    public class TestData
    {
        public string ipSG = "";
        public string ipPS = "";
        public string ipSA = "";
        public string ipDUT = "";
        public string ipSwitch = "";            //HK: Add
        public string switchType = "";          // "Rapidtek" or "" (default = Woken)
        public string dutType = "IQxel";        // "IQxel", "IQxstream-M", "RSAnalyzer", "RSGenerator"

        public string scpiDUTSetVSGMode = "";   //HK: Add
        public string scpiDUTSetVSGChannel = "";
        //public string scpiDUTSetVSGSamplingRate = "";
        public string scpiDUTSetVSGFreq = "";
        //public string scpiDUTLoadVSGWavefile = "";
        //public string scpiDUTSetVSGWavefileState = "";
        public string scpiDUTSetVSGPow = "";
        public string scpiDUTSetVSGRFOnOffState = "";
        public string scpiDUTSetVSGOutputState = "";

        public string scpiDUTSetVSAMode = "";   //HK: Add
        public string scpiDUTSetVSAChannel = "";
        //public string scpiDUTSetVSASamplingRate = "";
        public string scpiDUTSetVSAFreq = "";
        public string scpiDUTSetVSACaptureTime = "";
        public string scpiDUTSetVSAImmTrigSource = "";
        public string scpiDUTSetVSAAutoRangeRefLevel = "";
        public string scpiDUTSetVSAInitiateInputCapture = "";
        public string scpiDUTSetVSACalcPow = "";
        public string scpiDUTReadVSAPow = "";
        public string scpiDUTReadVSAPeakPow = "";

        // RSGeneratorDUT dual-path SMW support: which SOUR/OUTP number to use for Port A / Port B.
        // Single-path SMW: leave both at "1" (default). Dual-path SMW: set Port B to "2".
        public string vsgPathA = "1";
        public string vsgPathB = "1";

        private string errMsg = "";

        public TestValues VSGHighPowerAccuracy;
        public TestValues VSGLowPowerAccuracy;
        public TestValues VSAPowerAccuracy;
        public TestValues FrequencyAccuracy;

        public string generateSpecTemplate(string specName)
        {
            Assembly oAsesem = Assembly.GetEntryAssembly();
            string fileName = IndexedFilename(specName);
            using (var stream = oAsesem.GetManifestResourceStream($"Pegatron.{specName}.csv"))
            using (var fileStream = File.Create(@".\\" + fileName))
            {
                stream.Position = 0;
                stream.CopyTo(fileStream);
            }

            MessageBox.Show("Specification file \"" + fileName + "\" created in program directory", "Specification CSV file generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return fileName;
        }

        // R&S TX spec (Specifications_RS_Generator): Frequency(MHz) row of VSG High Power Accuracy,
        // VSG Low Power Accuracy and Frequency Accuracy sections (rows 17, 32, 47).
        static readonly int[] txFrequencyRows = { 17, 32, 47 };
        // R&S RX spec (Specifications_RS_FSW): Frequency(MHz) row of VSA Power Accuracy section (row 60).
        static readonly int[] rxFrequencyRows = { 60 };

        // Expands Start/Stop/Step into an explicit Frequency(MHz) list and writes it into the
        // just-generated spec CSV, in place of the template's default frequency points.
        public void ApplyFrequencySweep(string fileName, int startFreq, int stopFreq, int stepFreq, bool isTx)
        {
            List<int> freqList = new List<int>();
            for (int f = startFreq; f <= stopFreq; f += stepFreq)
                freqList.Add(f);

            string freqLine = "Frequency(MHz)," + string.Join(",", freqList);

            List<string> lines = File.ReadAllLines(@".\\" + fileName).ToList();
            foreach (int row in (isTx ? txFrequencyRows : rxFrequencyRows))
            {
                int idx = row - 1;
                if (idx < lines.Count)
                    lines[idx] = freqLine;
            }
            File.WriteAllLines(@".\\" + fileName, lines);
        }
        string IndexedFilename(string specName)
        {
            int ix = 0;
            string filename = null;
            do
            {
                ix++;
                filename = String.Format("{0}{1}.{2}", specName, ix, "csv");
            } while (File.Exists(filename));
            return filename;
        }

        public bool Initialize(string csvAddress)
        {
            //HK: Please make if additional line is created. just in case, customer created new line and it affect whole procedure
            VSGHighPowerAccuracy = new TestValues();
            VSGLowPowerAccuracy = new TestValues();
            FrequencyAccuracy = new TestValues();
            VSAPowerAccuracy = new TestValues();

            errMsg = "";
            try
            {
                List<string> fileArray = new List<string>();
                int retries = 5;
                while (true)
                {
                    try
                    {
                        using (var reader = new StreamReader(csvAddress))
                            while (!reader.EndOfStream)
                                fileArray.Add(reader.ReadLine());
                        break;
                    }
                    catch (IOException) when (retries-- > 0)
                    {
                        System.Threading.Thread.Sleep(300);
                        fileArray.Clear();
                    }
                }

                for (int i = 0; i < fileArray.Count; i++)
                {
                    string[] curLine = fileArray[i].Split(',');
                    if (curLine[1].Contains("\""))
                    {
                        int lineCheck = 1;
                        do
                        {
                            lineCheck++;
                            curLine[1] += "," + curLine[lineCheck];
                        } while (!curLine[lineCheck].Contains("\""));
                        curLine[1] = curLine[1].Replace("\"", "");
                    }

                    string portName = "";
                    int numIndex = -1;
                    int alphaIndex = -1;

                    int row = i + 1;
                    switch (row)
                    {
                        //IP address
                        case 1:
                            ipDUT = curLine[1];
                            dutType = curLine.Length > 2 && !string.IsNullOrWhiteSpace(curLine[2]) ? curLine[2].Trim() : "IQxel";
                            break;
                        case 2:
                            ipSG = curLine[1];
                            break;
                        case 3:
                            ipSA = curLine[1];
                            break;
                        case 4:
                            ipSwitch = curLine[1];
                            switchType = curLine.Length > 2 ? curLine[2].Trim() : "";
                            break;
                        case 5:
                            ipPS = curLine[1];
                            break;

                        ////RF Channel OnOff
                        ///VSG High Power
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                            portName = curLine[0];
                            numIndex = int.Parse(portName.Substring(2, 1)) - 1;
                            alphaIndex = portName.Substring(3, 1) == "A" ? 0 : 1;
                            alphaIndex = portName.Contains("A") || portName.Contains("B1") ? 0 : 1;
                            VSGHighPowerAccuracy.rfChannelIsOn[numIndex, alphaIndex] = curLine[1] == "1" ? true : false;
                            break;

                        ///VSG Low Power
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 30:
                            portName = curLine[0];
                            numIndex = int.Parse(portName.Substring(2, 1)) - 1;
                            alphaIndex = portName.Contains("A") || portName.Contains("B1") ? 0 : 1;
                            VSGLowPowerAccuracy.rfChannelIsOn[numIndex, alphaIndex] = curLine[1] == "1" ? true : false;
                            break;

                        ///Frequency Accuracy
                        case 38:
                        case 39:
                        case 40:
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45:
                            portName = curLine[0];
                            numIndex = int.Parse(portName.Substring(2, 1)) - 1;
                            alphaIndex = portName.Contains("A") || portName.Contains("B1") ? 0 : 1;
                            FrequencyAccuracy.rfChannelIsOn[numIndex, alphaIndex] = curLine[1] == "1" ? true : false;
                            break;

                        ///VSA
                        case 51:
                        case 52:
                        case 53:
                        case 54:
                        case 55:
                        case 56:
                        case 57:
                        case 58:
                            portName = curLine[0];
                            numIndex = int.Parse(portName.Substring(2, 1)) - 1;
                            alphaIndex = portName.Contains("A") || portName.Contains("B1") ? 0 : 1;
                            VSAPowerAccuracy.rfChannelIsOn[numIndex, alphaIndex] = curLine[1] == "1" ? true : false;
                            break;

                        ////Power & Frequency
                        case 16:
                        case 17:
                        case 31:
                        case 32:
                        case 46:
                        case 47:
                        case 59:
                        case 60:
                            for (int j = 1; j < curLine.Length; j++)
                            {
                                if (string.IsNullOrEmpty(curLine[j]))
                                    break;

                                switch (row)
                                {
                                    ///VSG High Power
                                    case 16:
                                        VSGHighPowerAccuracy.Power_Str.Add(curLine[j]);
                                        break;
                                    case 17:
                                        VSGHighPowerAccuracy.Frequency_Str.Add(curLine[j]);
                                        break;
                                    ///VSG Low Power
                                    case 31:
                                        VSGLowPowerAccuracy.Power_Str.Add(curLine[j]);
                                        break;
                                    case 32:
                                        VSGLowPowerAccuracy.Frequency_Str.Add(curLine[j]);
                                        break;
                                    ///Frequency Accuracy
                                    case 46:
                                        FrequencyAccuracy.Power_Str.Add(curLine[j]);
                                        break;
                                    case 47:
                                        FrequencyAccuracy.Frequency_Str.Add(curLine[j]);
                                        break;
                                    ///VSA
                                    case 59:
                                        VSAPowerAccuracy.Power_Str.Add(curLine[j]);
                                        break;
                                    case 60:
                                        VSAPowerAccuracy.Frequency_Str.Add(curLine[j]);
                                        break;

                                    default: break;
                                }
                            }
                            break;

                        ////Acceptance Limit
                        ///VSG High Power
                        case 19:
                            VSGHighPowerAccuracy.LowFreqLimit = double.Parse(curLine[1]);
                            break;
                        case 20:
                            VSGHighPowerAccuracy.HighFreqLimit = double.Parse(curLine[1]);
                            break;
                        ///VSG Low Power
                        case 34:
                            VSGLowPowerAccuracy.LowFreqLimit = double.Parse(curLine[1]);
                            break;
                        case 35:
                            VSGLowPowerAccuracy.HighFreqLimit = double.Parse(curLine[1]);
                            break;
                        ///Frequency Accuracy
                        case 48:
                            FrequencyAccuracy.FreqLimit = double.Parse(curLine[1]);
                            break;
                        ///VSA
                        case 62:
                            VSAPowerAccuracy.LowFreqLimit = double.Parse(curLine[1]);
                            break;
                        case 63:
                            VSAPowerAccuracy.HighFreqLimit = double.Parse(curLine[1]);
                            break;

                        ////DUT Control SCPI //HK Move location
                        ///VSG Mode
                        case 67:
                            scpiDUTSetVSGMode = curLine[1];
                            break;
                        case 68:
                            scpiDUTSetVSGChannel = curLine[1];
                            break;
                        //case 69:
                        //    scpiDUTSetVSGSamplingRate = curLine[1];
                        //    break;
                        case 69:
                            scpiDUTSetVSGFreq = curLine[1];
                            break;
                        //case 71:
                        //    scpiDUTLoadVSGWavefile = curLine[1];
                        //    break;
                        //case 72:
                        //    scpiDUTSetVSGWavefileState = curLine[1];
                            //break;
                        case 70:
                            scpiDUTSetVSGPow = curLine[1];
                            break;
                        case 71:
                            scpiDUTSetVSGRFOnOffState = curLine[1];
                            break;
                        case 72:
                            scpiDUTSetVSGOutputState = curLine[1];
                            break;
                        ///VSA Mode
                        case 74:
                            scpiDUTSetVSAMode = curLine[1];
                            break;
                        case 75:
                            scpiDUTSetVSAChannel = curLine[1];
                            break;
                        //case 79:
                        //    scpiDUTSetVSASamplingRate = curLine[1];
                        //    break;
                        case 76:
                            scpiDUTSetVSAFreq = curLine[1];
                            break;
                        case 77:
                            scpiDUTSetVSACaptureTime = curLine[1];
                            break;
                        case 78:
                            scpiDUTSetVSAImmTrigSource = curLine[1];
                            break;
                        case 79:
                            scpiDUTSetVSAAutoRangeRefLevel = curLine[1];
                            break;
                        case 80:
                            scpiDUTSetVSAInitiateInputCapture = curLine[1];
                            break;
                        case 81:
                            scpiDUTSetVSACalcPow = curLine[1];
                            break;
                        case 82:
                            scpiDUTReadVSAPow = curLine[1];
                            break;
                        case 83:
                            scpiDUTReadVSAPeakPow = curLine[1];
                            break;

                        // Appended fields (kept after row 83 so existing spec files of any dutType,
                        // which all end at row 83, are unaffected)
                        case 84:
                            if (!string.IsNullOrWhiteSpace(curLine[1])) vsgPathA = curLine[1].Trim();
                            break;
                        case 85:
                            if (!string.IsNullOrWhiteSpace(curLine[1])) vsgPathB = curLine[1].Trim();
                            break;

                        default: break;
                    }

                    if (row == 5)
                        if (ipSG == ipSA || ipSG == ipDUT || ipSA == ipDUT || ipSwitch == ipSG || ipSwitch == ipSA || ipSwitch == ipDUT || ipPS == ipSG || ipPS == ipDUT || ipPS == ipSA || ipPS == ipSwitch )
                            errMsg = "Cannot have same IP address configured on multiple instruments";
                        else if (ipSG == "" || ipSA == "" || ipDUT == "" || ipSwitch == "" || ipPS == "")
                            errMsg = "IP address configured cannot be empty";

                    if (errMsg != "") throw new Exception(errMsg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Specification file format.\nError: " + ex.Message, "Error reading CSV file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
