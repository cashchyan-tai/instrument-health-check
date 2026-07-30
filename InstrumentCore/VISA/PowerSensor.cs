using System.Threading;

namespace Pegatron
{
    public class PowerSensor : VisaEquipment
    {
        public PowerSensor() : base()
        {
            Name = "NRP";
        }

        public new bool ConnectUSB(string sConnectionString, int nTimeOut = 2500) // re-implement for simulate
        {
            //IPAddress = sIpAddress;
            //m_sConnectionString = "USB0::0x0AAD::" + sModelId + "::" + sSerialNo + "::INSTR";
            //SetVisaType(EVisaType.LAN);
            return base.ConnectDevice(sConnectionString, nTimeOut);
        }

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


        public void ClearOffset()
        {
            this.WriteScpi("CORR:OFFS 0");
            string sOff = this.QueryScpi("CORR:OFFS?");
        }

        public void SetOffset(string dOffset)
        {
            this.WriteScpi($"CORR:OFFS {dOffset}");
            string sOff = this.QueryScpi("CORR:OFFS?");
        }

        public string GetPower(string sFreq_Hz)
        {
            this.WriteScpi($"FREQ {sFreq_Hz}000000");
            this.WriteScpi("INIT");
            this.WaitOpc();

            Thread.Sleep(100);

            string sRslt = this.QueryScpi("FETC?");
            if (string.IsNullOrEmpty(sRslt) || string.IsNullOrWhiteSpace(sRslt))
                return "-0";
            return sRslt;
        }

        public void SetVisaTimeout(int ms)
        {
            VIsa.viSetAttribute(m_nViSession, ViAttr.VI_ATTR_TMO_VALUE, ms);
        }

        public void initializeGetPower()
        {
            this.WriteScpi("ABORT");
            this.WriteScpi("*CLS");
            this.WriteScpi("*RST");
            this.WriteScpi("CAL:ZERO:AUTO ONCE");
            this.WriteScpi("WAI*");
            this.WriteScpi("SENSe:TRACe:AVERage:COUNt 60");
            this.WriteScpi("SENSe:TRACe:AVERage:STATe ON");
            this.WriteScpi("INIT:CONT OFF");
        }

        public void OPC()
        {
            WriteScpi_s("*OPC");
        }

        public string ESR()
        {
            return QueryScpi_s("*ESR?");
        }

        //public void SetFrequency()
        //{
        //    // WriteScpi_s("*RST");
        //    WriteScpi_s($"SOURce1:FREQuency:CW {this.CenterFrequency}");
        //}

        //public void SetLevel()
        //{
        //    // WriteScpi_s($"LEVEL {this.ReferenceLevel}");
        //    WriteScpi_s($"SOURce1:POWer:POWer {this.ReferenceLevel}");
        //}

        //public void IQ_Enable(bool bIsHs)
        //{
        //    if (bIsHs == true) { WriteScpi_s("SOURce:BBIN:DIGital:INT HSD"); }
        //    else { WriteScpi_s("SOURce:BBIN:DIGital:INT DIG"); }
        //}

        //public bool BBInput_OnOff(bool bIsOn)
        //{
        //    int nOnOf = 0;
        //    if (bIsOn) { nOnOf = 1; }
        //    else { nOnOf = 0; }

        //    WriteScpi_s($"SOURce:BBIN:STATE {nOnOf}");


        //    WriteScpi_s("*OPC");
        //    bool bEsrCheck = false;
        //    while (bEsrCheck != true)
        //    {
        //        string sEsrVal = QueryScpi_s("*ESR?");
        //        if (sEsrVal[0] == '0') { bEsrCheck = true; }
        //    }

        //    return true;
        //}

        //public bool BBInput_OnOff_WOOPC(bool bIsOn)
        //{
        //    int nOnOf = 0;
        //    if (bIsOn) { nOnOf = 1; }
        //    else { nOnOf = 0; }

        //    WriteScpi_s($"SOURce:BBIN:STATE {nOnOf}");
        //    return true;
        //}

        //public bool IQMod_OnOff(bool bIsOn)
        //{
        //    int nOnOf = 0;
        //    if (bIsOn) { nOnOf = 1; }
        //    else { nOnOf = 0; }

        //    WriteScpi_s($"SOURce:IQ:STATE {nOnOf}");

        //    WriteScpi_s("*OPC");
        //    bool bEsrCheck = false;
        //    while (bEsrCheck != true)
        //    {
        //        string sEsrVal = QueryScpi_s("*ESR?");
        //        if (sEsrVal[0] == '0') { bEsrCheck = true; }
        //    }

        //    return true;
        //}

        //public bool RF_OnOff(bool bIsOn)
        //{
        //    int nOnOf = 0;
        //    if (bIsOn) { nOnOf = 1; }
        //    else { nOnOf = 0; }

        //    WriteScpi_s($"OUTP:STAT {nOnOf}");

        //    WriteScpi_s("*OPC");
        //    bool bEsrCheck = false;
        //    while (bEsrCheck != true)
        //    {
        //        string sEsrVal = QueryScpi_s("*ESR?");
        //        if (sEsrVal[0] == '0') { bEsrCheck = true; }
        //    }

        //    return true;
        //}

        //public bool RF_OnOff_WOOPC(bool bIsOn)
        //{
        //    int nOnOf = 0;
        //    if (bIsOn) { nOnOf = 1; }
        //    else { nOnOf = 0; }

        //    WriteScpi_s($"OUTP:STAT {nOnOf}");
        //    return true;
        //}

        public void WaitOpc()
        {
            WriteScpi_us("*OPC");
            bool bEsrCheck = false;
            while (bEsrCheck != true)
            {
                string sEsrVal = QueryScpi_us("*ESR?");
                if (string.IsNullOrEmpty(sEsrVal)) { return; }
                if (sEsrVal[0] != '0') { bEsrCheck = true; }  // non-zero = OPC bit set = measurement complete
            }
        }

        //public void IQConnectInitialize()
        //{
        //    // Reset 후, Default 상태에서 HSD 셋팅해도 안먹음
        //    //WriteScpi_us("BBIN:STAT 1");
        //    //WaitOpc();

        //    //WriteScpi_us("BBIN:STAT 0");
        //    //WaitOpc();
        //    // 장비 상태 갱신을 위해 불필요하게 위의 두 커맨드를 우선 보내고 진행

        //    WriteScpi_us("BBIN:DIG:INT HSD");
        //    WaitOpc();
        //    System.Threading.Thread.Sleep(500);
        //    string sHsd = QueryScpi_us("BBIN:CDEV?");
        //    if (sHsd.Contains("IQW") == true) { return; }

        //    WriteScpi_us("BBIN:DIG:INT DIG");
        //    WaitOpc();
        //    System.Threading.Thread.Sleep(500);
        //    string sDig = QueryScpi_us("BBIN:CDEV?");
        //    if (sDig.Contains("IQW") == true) { return; }

        //    WriteScpi_us("BBIN:DIG:INT HSD");
        //    WaitOpc();
        //    System.Threading.Thread.Sleep(500);
        //    sHsd = QueryScpi_us("BBIN:CDEV?");
        //    if (sHsd.Contains("IQW") == true) { return; }
        //}
    }
}
