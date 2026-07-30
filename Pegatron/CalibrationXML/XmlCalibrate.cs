using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Pegatron
{
    public class XmlCalibrate
    {
        private XmlNode Node;
        public List<XmlCalibrateData> DATA = new List<XmlCalibrateData>();
        public string m_sHasRef = null;
        public string m_sRefDate = null;
        public List<int> allCSVFreq = null;

        public bool HasReference
        {
            get
            {
                if (string.IsNullOrEmpty(m_sHasRef) == true) { return false; }

                if (string.Compare(this.m_sHasRef, "TRUE", true) == 0) { return true; }
                else { return false; }
            }
            set
            {
                if (value == true) { this.m_sHasRef = "TRUE"; }
                else { this.m_sHasRef = "FALSE"; }
                if (this.Node.Attributes["HAS_REF"] != null)
                    this.Node.Attributes["HAS_REF"].Value = this.m_sHasRef;
            }
        }

        public string ReferenceDate
        {
            get
            {
                if (string.IsNullOrEmpty(m_sRefDate))
                    return "";
                else
                    return m_sRefDate;
            }
            set
            {
                m_sRefDate = value;
                if (this.Node.Attributes["REF_DATE"] != null)
                    this.Node.Attributes["REF_DATE"].Value = this.m_sRefDate;
            }
        }

        public void Initialize(XmlNode oNode)
        {
            this.Node = oNode;
            this.DATA.Clear();
            this.m_sHasRef = null;
            this.m_sRefDate = null;
            if (this.Node != null)
            {
                if (this.Node.Attributes["HAS_REF"] != null) { this.m_sHasRef = this.Node.Attributes["HAS_REF"].Value; }
                if (this.Node.Attributes["REF_DATE"] != null) { this.m_sRefDate = this.Node.Attributes["REF_DATE"].Value; }
                XmlNodeList ListPortNodes = this.Node.SelectNodes("DATA");
                for (int nNode = 0; nNode < ListPortNodes.Count; nNode++)
                {
                    this.DATA.Add(new XmlCalibrateData(ListPortNodes[nNode]));
                }
            }
        }

        public void ClearData(ref XmlConfig oXml)
        {
            this.DATA.Clear();
            this.Node.RemoveAll();
            XmlAttribute restoreHasRef = oXml.XMLData.CreateAttribute("HAS_REF");
            restoreHasRef.Value = this.m_sHasRef;

            XmlAttribute restoreRefDate = oXml.XMLData.CreateAttribute("REF_DATE");
            restoreRefDate.Value = this.m_sRefDate;

            this.Node.Attributes.Append(restoreHasRef);
            this.Node.Attributes.Append(restoreRefDate);
        }

        //public bool isCalibrated(TestData testdata, ref XmlConfig configXML)
        //{
        //    if (!HasReference) return HasReference;

        //    //getFreqList(testdata);
        //    getFreqList();
        //    List<int> allXMLFreq = new List<int>();
        //    allXMLFreq.AddRange(DATA.Select(item => item.Frequency));
        //    allXMLFreq.RemoveAll(i => i == 0);
        //    allXMLFreq = allXMLFreq.Distinct().ToList();
        //    allXMLFreq.Sort();
        //    HasReference = allCSVFreq.SequenceEqual(allXMLFreq);
        //    configXML.XMLSave();

        //    return HasReference;
        //}

        public List<int> getFreqList()//(TestData testdata))
        {
            allCSVFreq = new List<int>();
            //allCSVFreq.AddRange(testdata.VSGHighPowerAccuracy.Frequency);
            //allCSVFreq.AddRange(testdata.VSGLowPowerAccuracy.Frequency);
            //allCSVFreq.AddRange(testdata.VSAPowerAccuracy.Frequency);
            //allCSVFreq.AddRange(testdata.FrequencyAccuracy.Frequency);
            //allCSVFreq.RemoveAll(i => i == 0);          //remove 0
            //allCSVFreq = allCSVFreq.Distinct().ToList();//remove duplicate
            //allCSVFreq.Sort();

            for (int i = 400; i <= 20000; i += 100)
                allCSVFreq.Add(i);

            return allCSVFreq;
        }

        public void AddData(ref XmlConfig oXml, string dblFreq, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8)
        {
            XmlElement newData = oXml.XMLData.CreateElement("DATA");
            XmlAttribute newFreq = oXml.XMLData.CreateAttribute("FREQ"); newFreq.Value = dblFreq;
            XmlAttribute newPort1A = oXml.XMLData.CreateAttribute("Port1A"); newPort1A.Value = p1;
            XmlAttribute newPort1B = oXml.XMLData.CreateAttribute("Port1B"); newPort1B.Value = p2;
            XmlAttribute newPort2A = oXml.XMLData.CreateAttribute("Port2A"); newPort2A.Value = p3;
            XmlAttribute newPort2B = oXml.XMLData.CreateAttribute("Port2B"); newPort2B.Value = p4;
            XmlAttribute newPort3A = oXml.XMLData.CreateAttribute("Port3A"); newPort3A.Value = p5;
            XmlAttribute newPort3B = oXml.XMLData.CreateAttribute("Port3B"); newPort3B.Value = p6;
            XmlAttribute newPort4A = oXml.XMLData.CreateAttribute("Port4A"); newPort4A.Value = p7;
            XmlAttribute newPort4B = oXml.XMLData.CreateAttribute("Port4B"); newPort4B.Value = p8;
            newData.SetAttributeNode(newFreq);
            newData.SetAttributeNode(newPort1A);
            newData.SetAttributeNode(newPort1B);
            newData.SetAttributeNode(newPort2A);
            newData.SetAttributeNode(newPort2B);
            newData.SetAttributeNode(newPort3A);
            newData.SetAttributeNode(newPort3B);
            newData.SetAttributeNode(newPort4A);
            newData.SetAttributeNode(newPort4B);
            this.Node.AppendChild(newData);

            this.DATA.Add(new XmlCalibrateData(newData));
        }

        public double getPowerLoss(int freq, int numPort, int alphaPort)
        {
            string portLetter = alphaPort == 0 ? "A" : "B";
            string portNum = "Port" + (numPort + 1) + portLetter;

            for (int i = 0; i < DATA.Count; i++)
            {
                if (DATA[i].Frequency == freq)
                    return DATA[i][portNum];
                else if (DATA[i].Frequency > freq)//calculate interpolation
                {
                    if (i == 0)
                        return DATA[i][portNum];

                    double freq1 = DATA[i - 1].Frequency;
                    double loss1 = DATA[i - 1][portNum];
                    double freq2 = DATA[i].Frequency;
                    double loss2 = DATA[i][portNum];

                    double loss = loss1 + (freq - freq1) * (loss2 - loss1) / (freq2 - freq1);
                    return loss;
                }
            }

            return DATA[DATA.Count - 1][portNum];
        }
    }
}
