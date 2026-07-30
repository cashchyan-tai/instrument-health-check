using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Pegatron
{
    public class XmlConfig
    {
        public XmlDocument XMLData = new XmlDocument();
        public string EXTERNAL_XMLNAME = "";
        public string EXTERNAL_PATH = "";
        private string INTERNAL_XMLNAME = "Pegatron.CalibrationData.xml";
        public bool HasExternalXML = false;
        public bool UseInternalXML = false;

        public XmlCalibrate CalibrateSGtoDUT = new XmlCalibrate();
        public XmlCalibrate CalibrateSAtoDUT = new XmlCalibrate();

        public XmlConfig()
        {

        }

        public void XMLStartUp(string calFilePath = "")
        {
            try
            {
                if (string.IsNullOrEmpty(calFilePath))
                    ExportInternalXML();
                else
                {
                    EXTERNAL_PATH = calFilePath;
                    EXTERNAL_XMLNAME = Path.GetFileName(calFilePath);
                }


                XMLData.PreserveWhitespace = true;

                // move cal file to program directory folder
                if (!EXTERNAL_PATH.Contains(Application.StartupPath + "\\Calibration\\"))
                {
                    if (!new DirectoryInfo(Application.StartupPath + "\\Calibration").Exists) { new DirectoryInfo(Application.StartupPath + "\\Calibration").Create(); }

                    File.Copy(EXTERNAL_PATH, IndexedFilename(Application.StartupPath + "\\Calibration\\" + EXTERNAL_XMLNAME));
                }

                // create new external xml from internal xml
                if (new System.IO.FileInfo(Application.StartupPath + "\\Calibration\\" + EXTERNAL_XMLNAME).Exists == false)
                {
                    MessageBox.Show("Unable to find " + EXTERNAL_XMLNAME + ". Creating new calibration file.", "Missing file");
                    ExportInternalXML();
                }

                ReadExternalXML();
                if (HasExternalXML == false)// create new external xml from internal if reading external xml fails
                {
                    MessageBox.Show(EXTERNAL_XMLNAME + " corrupted. Creating new calibration file.", "Error reading file");
                    ExportInternalXML();
                    ReadExternalXML();
                }

                ReadXMLContents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        string IndexedFilename(string filePath)
        {
            string filename = Path.GetFileNameWithoutExtension(filePath);
            string path = Application.StartupPath + "\\Calibration\\";
            int ix = 0;
            string newFilename = "";
            do
            {
                ix++;
                newFilename = String.Format("{0}{1}.{2}", filename, ix, "xml");
            } while (File.Exists(path + newFilename));

            EXTERNAL_XMLNAME = newFilename;
            EXTERNAL_PATH = path + newFilename;
            return EXTERNAL_PATH;
        }

        private void ExportInternalXML()
        {
            string sFileName = INTERNAL_XMLNAME;
            System.Reflection.Assembly oAsesem = System.Reflection.Assembly.GetEntryAssembly();

            XmlDocument oTempXmlDoc = new XmlDocument();

            using (Stream oStream = oAsesem.GetManifestResourceStream(sFileName))
            {
                StreamReader oReader = new StreamReader(oStream);
                oTempXmlDoc.LoadXml(oReader.ReadToEnd());
                oReader.Close();
                oStream.Close();
            }

            EXTERNAL_XMLNAME = "CalibrationData_" + DateTime.Now.ToString("yyMMdd-HHmmss") + ".xml";
            EXTERNAL_PATH = Application.StartupPath + "\\Calibration\\" + EXTERNAL_XMLNAME;

            if (!Directory.Exists(Application.StartupPath + "\\Calibration"))
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Calibration");

            using (StreamWriter sw = new StreamWriter(EXTERNAL_PATH))
            {
                oTempXmlDoc.Save(sw);
                sw.Close();
            }
        }

        private void ReadExternalXML()
        {
            string sFileName = EXTERNAL_PATH;
            try
            {
                XMLData.Load(sFileName);
                HasExternalXML = true;
            }
            catch
            {
                HasExternalXML = false;
            }
        }

        private void ReadXMLContents()
        {
            CalibrateSGtoDUT.Initialize(XMLData.SelectSingleNode("CAL/SGDUT"));
            CalibrateSAtoDUT.Initialize(XMLData.SelectSingleNode("CAL/SADUT"));
        }

        public void XMLSave()
        {
            var writer = XmlWriter.Create(Application.StartupPath + "\\Calibration\\" + EXTERNAL_XMLNAME, new XmlWriterSettings { Indent = true, NewLineOnAttributes = true });
            XMLData.Save(writer);
            writer.Close();
            //XMLData.Save(Application.StartupPath + "\\Calibration\\"  + EXTERNAL_XMLNAME);
        }
    }
}
