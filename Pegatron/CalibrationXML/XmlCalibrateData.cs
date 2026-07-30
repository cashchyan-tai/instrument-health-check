using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Pegatron
{
    public class XmlCalibrateData
    {
        private XmlNode Node;
        private string m_sFrequency = null;
        private string m_sPort1A = null;
        private string m_sPort1B = null;
        private string m_sPort2A = null;
        private string m_sPort2B = null;
        private string m_sPort3A = null;
        private string m_sPort3B = null;
        private string m_sPort4A = null;
        private string m_sPort4B = null;

        public string Frequency_Str
        {
            get { return m_sFrequency; }
            set
            {
                m_sFrequency = value;
                Node.Attributes["FREQ"].Value = m_sFrequency;
            }
        }
        public int Frequency
        {
            get
            {
                int dRet = 0;
                if (string.IsNullOrEmpty(this.m_sFrequency) == false)
                {
                    if (Int32.TryParse(this.m_sFrequency, out dRet) == true) { return dRet; }
                    else { return 0; }
                }
                else { return 0; }
            }
            set
            {
                this.m_sFrequency = value.ToString();
                this.Node.Attributes["FREQ"].Value = this.m_sFrequency;
            }
        }

        public string Port1A_Str
        {
            get { return this.m_sPort1A; }
            set
            {
                this.m_sPort1A = value;
                this.Node.Attributes["Port1A"].Value = this.m_sPort1A;
            }
        }

        public double Port1A
        {
            get
            {
                double dRet = 0;
                if (string.IsNullOrEmpty(this.m_sPort1A) == false)
                {
                    if (double.TryParse(this.m_sPort1A, out dRet) == true) { return dRet; }
                    else { return 0; }
                }
                else { return 0; }
            }
            set
            {
                this.m_sPort1A = value.ToString();
                this.Node.Attributes["Port1A"].Value = this.m_sPort1A;
            }
        }

        public string Port1B_Str
        {
            get { return this.m_sPort1B; }
            set
            {
                this.m_sPort1B = value;
                this.Node.Attributes["Port1B"].Value = this.m_sPort1B;
            }
        }

        public double Port1B
        {
            get
            {
                double dRet = 0;
                if (string.IsNullOrEmpty(this.m_sPort1B) == false)
                {
                    if (double.TryParse(this.m_sPort1B, out dRet) == true) { return dRet; }
                    else { return 0; }
                }
                else { return 0; }
            }
            set
            {
                this.m_sPort1B = value.ToString();
                this.Node.Attributes["Port1B"].Value = this.m_sPort1B;
            }
        }

        public string Port2A_Str
        {
            get { return this.m_sPort2A; }
            set
            {
                this.m_sPort2A = value;
                this.Node.Attributes["Port2A"].Value = this.m_sPort2A;
            }
        }

        public double Port2A
        {
            get
            {
                double dRet = 0;
                if (string.IsNullOrEmpty(this.m_sPort2A) == false)
                {
                    if (double.TryParse(this.m_sPort2A, out dRet) == true) { return dRet; }
                    else { return 0; }
                }
                else { return 0; }
            }
            set
            {
                this.m_sPort2A = value.ToString();
                this.Node.Attributes["Port2A"].Value = this.m_sPort2A;
            }
        }

        public string Port2B_Str
        {
            get { return this.m_sPort2B; }
            set
            {
                this.m_sPort2B = value;
                this.Node.Attributes["Port2B"].Value = this.m_sPort2B;
            }
        }

        public double Port2B
        {
            get
            {
                double dRet = 0;
                if (string.IsNullOrEmpty(this.m_sPort2B) == false)
                {
                    if (double.TryParse(this.m_sPort2B, out dRet) == true) { return dRet; }
                    else { return 0; }
                }
                else { return 0; }
            }
            set
            {
                this.m_sPort2B = value.ToString();
                this.Node.Attributes["Port2B"].Value = this.m_sPort2B;
            }
        }

        public string Port3A_Str
        {
            get { return this.m_sPort3A; }
            set
            {
                this.m_sPort3A = value;
                this.Node.Attributes["Port3A"].Value = this.m_sPort3A;
            }
        }

        public double Port3A
        {
            get
            {
                double dRet = 0;
                if (string.IsNullOrEmpty(this.m_sPort3A) == false)
                {
                    if (double.TryParse(this.m_sPort3A, out dRet) == true) { return dRet; }
                    else { return 0; }
                }
                else { return 0; }
            }
            set
            {
                this.m_sPort3A = value.ToString();
                this.Node.Attributes["Port3A"].Value = this.m_sPort3A;
            }
        }

        public string Port3B_Str
        {
            get { return this.m_sPort3B; }
            set
            {
                this.m_sPort3B = value;
                this.Node.Attributes["Port3B"].Value = this.m_sPort3B;
            }
        }

        public double Port3B
        {
            get
            {
                double dRet = 0;
                if (string.IsNullOrEmpty(this.m_sPort3B) == false)
                {
                    if (double.TryParse(this.m_sPort3B, out dRet) == true) { return dRet; }
                    else { return 0; }
                }
                else { return 0; }
            }
            set
            {
                this.m_sPort3B = value.ToString();
                this.Node.Attributes["Port3B"].Value = this.m_sPort3B;
            }
        }

        public string Port4A_Str
        {
            get { return this.m_sPort4A; }
            set
            {
                this.m_sPort4A = value;
                this.Node.Attributes["Port4A"].Value = this.m_sPort4A;
            }
        }

        public double Port4A
        {
            get
            {
                double dRet = 0;
                if (string.IsNullOrEmpty(this.m_sPort4A) == false)
                {
                    if (double.TryParse(this.m_sPort4A, out dRet) == true) { return dRet; }
                    else { return 0; }
                }
                else { return 0; }
            }
            set
            {
                this.m_sPort4A = value.ToString();
                this.Node.Attributes["Port4A"].Value = this.m_sPort4A;
            }
        }

        public string Port4B_Str
        {
            get { return this.m_sPort4B; }
            set
            {
                this.m_sPort4B = value;
                this.Node.Attributes["Port4B"].Value = this.m_sPort4B;
            }
        }

        public double Port4B
        {
            get
            {
                double dRet = 0;
                if (string.IsNullOrEmpty(this.m_sPort4B) == false)
                {
                    if (double.TryParse(this.m_sPort4B, out dRet) == true) { return dRet; }
                    else { return 0; }
                }
                else { return 0; }
            }
            set
            {
                this.m_sPort4B = value.ToString();
                this.Node.Attributes["Port4B"].Value = this.m_sPort4B;
            }
        }

        private PropertyInfo PropertyInfoByName(string name)
        {
            Type type = this.GetType();
            PropertyInfo info = type.GetProperty(name);
            return info;
        }
        public double this[string name]
        {
            get
            {
                PropertyInfo info = PropertyInfoByName(name);
                return double.Parse(info.GetValue(this, null).ToString());
            }
            //set
            //{
            //    PropertyInfo info = PropertyInfoByName(name);
            //    info.SetValue(this, value, null);
            //}
        }

        public XmlCalibrateData(XmlNode oNode)
        {
            Node = oNode;

            if (Node != null)
            {
                if (Node.Attributes["FREQ"] != null) { m_sFrequency = Node.Attributes["FREQ"].Value; }
                if (Node.Attributes["Port1A"] != null) { m_sPort1A = Node.Attributes["Port1A"].Value; }
                if (Node.Attributes["Port1B"] != null) { m_sPort1B = Node.Attributes["Port1B"].Value; }
                if (Node.Attributes["Port2A"] != null) { m_sPort2A = Node.Attributes["Port2A"].Value; }
                if (Node.Attributes["Port2B"] != null) { m_sPort2B = Node.Attributes["Port2B"].Value; }
                if (Node.Attributes["Port3A"] != null) { m_sPort3A = Node.Attributes["Port3A"].Value; }
                if (Node.Attributes["Port3B"] != null) { m_sPort3B = Node.Attributes["Port3B"].Value; }
                if (Node.Attributes["Port4A"] != null) { m_sPort4A = Node.Attributes["Port4A"].Value; }
                if (Node.Attributes["Port4B"] != null) { m_sPort4B = Node.Attributes["Port4B"].Value; }
            }
        }
    }
}
