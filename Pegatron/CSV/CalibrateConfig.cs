using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pegatron
{
    public class CalibrateConfig
    {
        public string EXTERNAL_CSVNAME = "";
        public string EXTERNAL_PATH = "";
        private string INTERNAL_CSVNAME = "Pegatron.CalibrationData.csv";
        public bool HasExternalCSV = false;
        public bool UseInternalCSV = false;

        private string[] csvData;

        public List<string[]> CalibrateSGtoDUT = new List<string[]>();
        private string s_hasRefSGDUT = "";
        private string s_dateRefSGDUT = "";

        public List<string[]> CalibrateSAtoDUT = new List<string[]>();
        private string s_hasRefSADUT = "";
        private string s_dateRefSADUT = "";

        public CalibrateConfig()
        {

        }

        public void CSVStartUp(string calFilePath = "")
        {
            try
            {
                if (string.IsNullOrEmpty(calFilePath))
                    ExportInternalCSV();
                else
                {
                    EXTERNAL_PATH = calFilePath;
                    EXTERNAL_CSVNAME = Path.GetFileName(calFilePath);
                }

                // move cal file to program directory folder
                if (!EXTERNAL_PATH.Contains(Application.StartupPath + "\\Calibration\\"))
                {
                    if (!new DirectoryInfo(Application.StartupPath + "\\Calibration").Exists) { new DirectoryInfo(Application.StartupPath + "\\Calibration").Create(); }

                    File.Copy(EXTERNAL_PATH, IndexedFilename(Application.StartupPath + "\\Calibration\\" + EXTERNAL_CSVNAME));
                }

                // create new external csv from internal csv
                if (new System.IO.FileInfo(Application.StartupPath + "\\Calibration\\" + EXTERNAL_CSVNAME).Exists == false)
                {
                    MessageBox.Show("Unable to find " + EXTERNAL_CSVNAME + ". Creating new calibration file.", "Missing file");
                    ExportInternalCSV();
                }

                ReadExternalCSV();
                if (HasExternalCSV == false)// create new external csv from internal if reading external csv fails
                {
                    MessageBox.Show(EXTERNAL_CSVNAME + " corrupted. Creating new calibration file.", "Error reading file");
                    ExportInternalCSV();
                    ReadExternalCSV();
                }

                ReadCSVContents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private string IndexedFilename(string filePath)
        {
            string filename = Path.GetFileNameWithoutExtension(filePath);
            string path = Application.StartupPath + "\\Calibration\\";
            int ix = 0;
            string newFilename = "";
            do
            {
                ix++;
                newFilename = String.Format("{0}{1}.{2}", filename, ix, "csv");
            } while (File.Exists(path + newFilename));

            EXTERNAL_CSVNAME = newFilename;
            EXTERNAL_PATH = path + newFilename;
            return EXTERNAL_PATH;
        }

        private void ExportInternalCSV()
        {
            string sFileName = INTERNAL_CSVNAME;

            EXTERNAL_CSVNAME = "CalibrationData_" + DateTime.Now.ToString("yyMMdd-HHmmss") + ".csv";
            EXTERNAL_PATH = Application.StartupPath + "\\Calibration\\" + EXTERNAL_CSVNAME;

            if (!Directory.Exists(Application.StartupPath + "\\Calibration"))
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Calibration");

            File.WriteAllText(EXTERNAL_PATH, Properties.Resources.CalibrationData);
        }

        private void ReadExternalCSV()
        {
            string sFileName = EXTERNAL_PATH;
            try
            {
                csvData = File.ReadAllLines(sFileName);
                HasExternalCSV = true;
            }
            catch
            {
                HasExternalCSV = false;
            }
        }

        private void ReadCSVContents()
        {
            CalibrateSGtoDUT = new List<string[]>();
            CalibrateSAtoDUT = new List<string[]>();

            bool isSGDUT = true;

            for(int i = 0; i < csvData.Length; i++)
            {
                string[] rows = csvData[i].Replace("\"","").Split(',');

                if (rows[0].Contains("SGDUT"))
                {
                    string[] refCols = csvData[i + 2].Replace("\"", "").Split(',');

                    SGDUTHasReference = refCols[0] == "TRUE";
                    SGDUTReferenceDate = refCols[1];

                    i += 3;
                    continue;
                }
                else if (rows[0].Contains("SADUT"))
                {
                    isSGDUT = false;
                    string[] refCols = csvData[i + 2].Replace("\"", "").Split(',');

                    SADUTHasReference = refCols[0] == "TRUE";
                    SADUTReferenceDate = refCols[1];

                    i += 3;
                    continue;
                }

                if (string.IsNullOrEmpty(rows[0]))
                    continue;

                if (isSGDUT)
                    CalibrateSGtoDUT.Add(rows);
                else
                    CalibrateSAtoDUT.Add(rows);
            }

            if (CalibrateSGtoDUT.Count == 0)
                CalibrateSGtoDUT = getFreqList();
            if (CalibrateSAtoDUT.Count == 0)
                CalibrateSAtoDUT = getFreqList();
            
            
            CSVSave();
        }

        public void CSVSave(DataTable dt = null, string tableType = "")
        {
            if (dt != null && !string.IsNullOrEmpty(tableType))
            {
                //int colNum = Int32.Parse(arrCol[0]);

                //if (tableType == "SGDUT")
                //    for (int rowFreq = 0; rowFreq < arrCol.Count - 1; rowFreq++)
                //        CalibrateSGtoDUT[rowFreq][colNum] = arrCol[rowFreq + 1];
                //else
                //    for (int rowFreq = 0; rowFreq < arrCol.Count - 1; rowFreq++)
                //        CalibrateSAtoDUT[rowFreq][colNum] = arrCol[rowFreq + 1];

                List<string[]> csvDt = new List<string[]>();
                if (dt != null && dt.Rows.Count > 0)
                    foreach (DataRow row in dt.Rows)
                        csvDt.Add(Array.ConvertAll(row.ItemArray, x => x.ToString()));

                if (tableType == "SGDUT")
                    CalibrateSGtoDUT = csvDt.OrderBy(arr => int.Parse(arr[0])).ToList();
                else if (tableType == "SADUT")
                    CalibrateSAtoDUT = csvDt.OrderBy(arr => int.Parse(arr[0])).ToList(); ;
            }

            List<string> csvString = new List<string>();

            csvString.Add("SGDUT");
            csvString.Add("HAS_REF,REF_DATE");
            csvString.Add(string.Format("{0},{1}", s_hasRefSGDUT, s_dateRefSGDUT));

            csvString.Add("FREQ,Port1A,Port1B,Port2A,Port2B,Port3A,Port3B,Port4A,Port4B");
            foreach (string[] arrRow in CalibrateSGtoDUT)
                csvString.Add(string.Join(",", arrRow));
            csvString.Add(",,,,,,,,");

            csvString.Add("SADUT");
            csvString.Add("HAS_REF,REF_DATE");
            csvString.Add(string.Format("{0},{1}", s_hasRefSADUT, s_dateRefSADUT));

            csvString.Add("FREQ,Port1A,Port1B,Port2A,Port2B,Port3A,Port3B,Port4A,Port4B");
            foreach (string[] arrRow in CalibrateSAtoDUT)
                csvString.Add(string.Join(",", arrRow));
            csvString.Add(",,,,,,,,");

            File.WriteAllLines(Application.StartupPath + "\\Calibration\\" + EXTERNAL_CSVNAME, csvString);
        }

        public bool SADUTHasReference
        {
            get
            {
                if (string.IsNullOrEmpty(s_hasRefSADUT) == true) { return false; }

                if (string.Compare(this.s_hasRefSADUT, "TRUE", true) == 0) { return true; }
                else { return false; }
            }
            set
            {
                if (value == true) { this.s_hasRefSADUT = "TRUE"; }
                else { this.s_hasRefSADUT = "FALSE"; }
            }
        }

        public string SADUTReferenceDate
        {
            get
            {
                if (string.IsNullOrEmpty(s_dateRefSADUT))
                    return "";
                else
                    return s_dateRefSADUT;
            }
            set
            {
                s_dateRefSADUT = value;
            }
        }
        public bool SGDUTHasReference
        {
            get
            {
                if (string.IsNullOrEmpty(s_hasRefSGDUT) == true) { return false; }

                if (string.Compare(this.s_hasRefSGDUT, "TRUE", true) == 0) { return true; }
                else { return false; }
            }
            set
            {
                if (value == true) { this.s_hasRefSGDUT = "TRUE"; }
                else { this.s_hasRefSGDUT = "FALSE"; }
            }
        }

        public string SGDUTReferenceDate
        {
            get
            {
                if (string.IsNullOrEmpty(s_dateRefSGDUT))
                    return "";
                else
                    return s_dateRefSGDUT;
            }
            set
            {
                s_dateRefSGDUT = value;
            }
        }

        public List<string[]> getFreqList()
        {
            List<string[]> allCSVFreq = new List<string[]>();

            for (int i = 400; i <= 20000; i += 100)
                allCSVFreq.Add(new string[] { i.ToString(),"","","","","","","","" });

            return allCSVFreq;
        }

        public double getPowerLoss(int freq, int numPort, int alphaPort, string tableType)
        {
            List<string[]> DATA = new List<string[]>();
            if (tableType == "SGDUT")
                DATA = CalibrateSGtoDUT;
            else if(tableType == "SADUT")
                DATA = CalibrateSAtoDUT;
            else
                return 0;

            int colNum = numPort * 2 + alphaPort + 1;

            // Use only rows that have a value for this column (supports partial/extended frequency ranges)
            var validData = DATA.Where(row => !string.IsNullOrEmpty(row[colNum])).ToList();
            if (validData.Count == 0)
                return 0;

            for (int i = 0; i < validData.Count; i++)
            {
                if (Int32.Parse(validData[i][0]) == freq)
                    return double.Parse(validData[i][colNum]);
                else if (Int32.Parse(validData[i][0]) > freq)//calculate interpolation
                {
                    if (i == 0)
                        return double.Parse(validData[i][colNum]);

                    double freq1 = double.Parse(validData[i - 1][0]);
                    double loss1 = double.Parse(validData[i - 1][colNum]);
                    double freq2 = double.Parse(validData[i][0]);
                    double loss2 = double.Parse(validData[i][colNum]);

                    double loss = loss1 + (freq - freq1) * (loss2 - loss1) / (freq2 - freq1);
                    return loss;
                }
            }

            return double.Parse(validData[validData.Count - 1][colNum]);
        }
    }
}
