using System;
using System.Collections.Generic;
using System.Text;

namespace Pegatron
{
    public class SignalGenerator : VisaEquipment
    {
        public double CenterFrequency = -9999;
        public double ReferenceLevel = -9999;
        public double CaptureBandwidth = -9999;

        public SignalGenerator() : base()
        {
            this.Name = "SMB";
        }

        public new bool ConnectLan(string sIpAddress, int nTimeOut = 2500) // re-implement for simulate
        {
            return base.ConnectLan(sIpAddress, nTimeOut);
        }

        //public new bool ConnectGpib(string sGpibAddress, int nTimeOut) // re-implement for simulate
        //{
        //    return base.ConnectGpib(sGpibAddress, nTimeOut);
        //}

        //public new bool ConnectSocket(string sSockAddress, string sPort) // re-implement for simulate
        //{
        //    return base.ConnectSocket(sSockAddress, sPort);
        //}

        public new void DisconnectDevice()
        {
            base.DisconnectDevice();
        }

        public bool WriteScpi(string format, params object[] args)
        {
            string sSend = string.Format(format, args);
        
            return base.WriteScpi_s(sSend);
        }

        public new bool WriteScpi(string sSend)
        {
            return base.WriteScpi_s(sSend);
        }

        // public new bool WriteScpi_Trigger(string sSend, bool bLogOn = true)
        // {
        //     return base.WriteScpi_Trigger(sSend, bLogOn);
        // }

        public new string ReadScpi(ref bool bIsSuccess)
        {
            return base.ReadScpi(ref bIsSuccess);
        }

        public string QueryScpi(string format, params object[] args)
        {
            string sSend = string.Format(format, args);
            return base.QueryScpi_s(sSend);
        }

        public new string QueryScpi(string sSend)
        {
            return base.QueryScpi_s(sSend);
        }

        // public new string QueryScpi_Trigger(string sSend, bool bLogOn = true)
        // {
        //     return base.QueryScpi_Trigger(sSend, bLogOn);
        // }


        public void OPC()
        {
            WriteScpi_s("*OPC");
        }

        public string ESR()
        {
            return QueryScpi_s("*ESR?");
        }

        public void SetFrequency()
        {
            // WriteScpi_s("*RST");
            WriteScpi_s($"SOURce1:FREQuency:CW {this.CenterFrequency}");
        }

        public void SetLevel()
        {
            // WriteScpi_s($"LEVEL {this.ReferenceLevel}");
            WriteScpi_s($"SOURce1:POWer:POWer {this.ReferenceLevel}");
        }

        public void IQ_Enable(bool bIsHs)
        {
            if (bIsHs == true)  { WriteScpi_s("SOURce:BBIN:DIGital:INT HSD");  }
            else                { WriteScpi_s("SOURce:BBIN:DIGital:INT DIG"); }
        }

        public bool BBInput_OnOff(bool bIsOn)
        {
            int nOnOf = 0;
            if (bIsOn)  { nOnOf = 1; }
            else        { nOnOf = 0; }

            WriteScpi_s($"SOURce:BBIN:STATE {nOnOf}");


            WriteScpi_s("*OPC");
            bool bEsrCheck = false;
            while (bEsrCheck != true)
            {
                string sEsrVal = QueryScpi_s("*ESR?");
                if (sEsrVal[0] != '0') { bEsrCheck = true; }
            }

            return true;
        }

        public bool BBInput_OnOff_WOOPC(bool bIsOn)
        {
            int nOnOf = 0;
            if (bIsOn) { nOnOf = 1; }
            else { nOnOf = 0; }

            WriteScpi_s($"SOURce:BBIN:STATE {nOnOf}");            
            return true;
        }

        public bool IQMod_OnOff(bool bIsOn)
        {
            int nOnOf = 0;
            if (bIsOn)  { nOnOf = 1; }
            else        { nOnOf = 0; }

            WriteScpi_s($"SOURce:IQ:STATE {nOnOf}");

            WriteScpi_s("*OPC");
            bool bEsrCheck = false;
            while (bEsrCheck != true)
            {
                string sEsrVal = QueryScpi_s("*ESR?");
                if (sEsrVal[0] != '0') { bEsrCheck = true; }
            }

            return true;
        }

        public bool RF_OnOff(bool bIsOn)
        {
            int nOnOf = 0;
            if (bIsOn)  { nOnOf = 1; }
            else        { nOnOf = 0; }

            WriteScpi_s($"OUTP:STAT {nOnOf}");

            WriteScpi_s("*OPC");
            bool bEsrCheck = false;
            while (bEsrCheck != true)
            {
                string sEsrVal = QueryScpi_s("*ESR?");
                if (sEsrVal[0] != '0') { bEsrCheck = true; }
            }

            return true;
        }

        public bool RF_OnOff_WOOPC(bool bIsOn)
        {
            int nOnOf = 0;
            if (bIsOn) { nOnOf = 1; }
            else { nOnOf = 0; }

            WriteScpi_s($"OUTP:STAT {nOnOf}");            
            return true;
        }

        public void WaitOpc()
        {
            WriteScpi_us("*OPC");
            bool bEsrCheck = false;
            while (bEsrCheck != true)
            {
                string sEsrVal = QueryScpi_us("*ESR?");
                if(string.IsNullOrEmpty(sEsrVal)) { return; }
                if (sEsrVal[0] != '0') { bEsrCheck = true; }  // non-zero = OPC bit set = operation complete
            }
        }

        public void IQConnectInitialize()
        {
            // Reset 후, Default 상태에서 HSD 셋팅해도 안먹음
            //WriteScpi_us("BBIN:STAT 1");
            //WaitOpc();
            
            //WriteScpi_us("BBIN:STAT 0");
            //WaitOpc();
            // 장비 상태 갱신을 위해 불필요하게 위의 두 커맨드를 우선 보내고 진행

            WriteScpi_us("BBIN:DIG:INT HSD");
            WaitOpc();
            System.Threading.Thread.Sleep(500);
            string sHsd = QueryScpi_us("BBIN:CDEV?");
            if (sHsd.Contains("IQW") == true) { return; }

            WriteScpi_us("BBIN:DIG:INT DIG");
            WaitOpc();
            System.Threading.Thread.Sleep(500);
            string sDig = QueryScpi_us("BBIN:CDEV?");
            if (sDig.Contains("IQW") == true) { return; }

            WriteScpi_us("BBIN:DIG:INT HSD");
            WaitOpc();
            System.Threading.Thread.Sleep(500);
            sHsd = QueryScpi_us("BBIN:CDEV?");
            if (sHsd.Contains("IQW") == true) { return; }
        }
    }
}
