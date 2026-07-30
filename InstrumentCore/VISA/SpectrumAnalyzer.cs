using System;
using System.Collections.Generic;
using System.Text;

namespace Pegatron
{
    public class SpectrumAnalyzer : VisaEquipment
    {
       
        public double CenterFrequency = 4000000000;
        public double ReferenceLevel = 0;
        public double CaptureBandwidth = 10000000;
        public double MeasTime = 0.001;

        public List<string> Option = new List<string>();

        public bool IsInternal = false;
        

        public SpectrumAnalyzer() : base()
        {
            this.Name = "FPL";
        }

        public new bool ConnectLan(string sIpAddress, int nTimeOut = 2500)
        {
            IPAddress = sIpAddress;
            // Allow callers to pass a full VISA resource string (e.g. "TCPIP0::<ip>::hislip0::INSTR")
            // to work around instruments/VISA stacks that don't like the default "TCPIP::<ip>::INST0::INSTR" form.
            m_sConnectionString = sIpAddress.Contains("::") ? sIpAddress : "TCPIP::" + sIpAddress + "::INST0::INSTR";
            SetVisaType(EVisaType.LAN);
            return base.ConnectDevice(m_sConnectionString, nTimeOut);
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

        //public void GetCenterFrequency()
        //{
        //    string sRecv = QueryScpi_us("FREQ:CENT?");
        //    if (string.IsNullOrEmpty(sRecv) == false)
        //    {
        //        double dblTemp = -9999;
        //        if (double.TryParse(sRecv, out dblTemp) == true)
        //        {
        //            this.CenterFrequency = dblTemp;
        //        }
        //    }
        //}
        //public void GetReferenceLevel()
        //{
        //    string sRecv = QueryScpi_us("DISP:TRAC:Y:RLEV?");
        //    if (string.IsNullOrEmpty(sRecv) == false)
        //    {
        //        double dblTemp = -9999;
        //        if (double.TryParse(sRecv, out dblTemp) == true)
        //        {
        //            this.ReferenceLevel = dblTemp;
        //        }
        //    }  
        //}
        //public void GetCaptureBandwidth()
        //{
        //    // string sRecv = QueryScpi_s("TRACe:IQ:SRATe?");   // Sample Rate
        //    string sRecv = QueryScpi_us("TRAC:IQ:BWID?");        // ABW
        //    if (string.IsNullOrEmpty(sRecv) == false)
        //    {
        //        double dblTemp = -9999;
        //        if (double.TryParse(sRecv, out dblTemp) == true)
        //        {
        //            this.CaptureBandwidth = dblTemp;
        //        }
        //    }
        //}

        //public void GetMeasTime()
        //{
        //    string sRecv = QueryScpi_us("SENS:SWE:TIME? ");  
        //    if (string.IsNullOrEmpty(sRecv) == false)
        //    {
        //        double dblTemp = -9999;
        //        if (double.TryParse(sRecv, out dblTemp) == true)
        //        {
        //            this.MeasTime = dblTemp;
        //        }
        //    }
        //}


        //public void SetCenterFrequency()
        //{
        //    WriteScpi_s($"FREQ:CENT {this.CenterFrequency}");
        //}

        //public void SetReferenceLevel()
        //{
        //    WriteScpi_s($"DISP:TRAC:Y:RLEV {this.ReferenceLevel}");
        //}

        //public void SetCaptureBandwidth()
        //{
        //    // WriteScpi_s($"TRACe:IQ:SRATe {this.CaptureBandwidth}");  // Sampling Rate
        //    WriteScpi_s($"TRAC:IQ:BWID {this.CaptureBandwidth}");       // ABW
        //}

        //public void SetMeasTime()
        //{
        //    // WriteScpi_s($"TRACe:IQ:SRATe {this.CaptureBandwidth}");  // Sampling Rate
        //    WriteScpi_s($"SENSe:SWE:TIME {this.MeasTime}");       // ABW
        //}

        //public bool PreRecordSettingFSW()
        //{
        //    //ErrForm.Clear();
        //    WriteScpi_s("*RST");
        //    WriteScpi_s(":INST:CRE:NEW IQ, 'IQ Analyer'");
        //    SetCenterFrequency();
        //    SetReferenceLevel();
        //    SetCaptureBandwidth();
        //    SetMeasTime();

        //    WriteScpi_s(":OUTP:DIQ:STAT ON");

        //    WriteScpi_s(":LAY:REPL:WIND '1',FREQ");
        //    WriteScpi_s(":SENS:WIND1:DET1:FUNC AVER");
        //    WriteScpi_s(":DISP:WIND1:SUBW:TRAC1:MODE AVER");

        //    //if (ErrForm.ErrorQueue.Count > 0)
        //    //{
        //    //    return false;
        //    //}
        //    return true;
        //}

        //public void OPC()
        //{
        //    WriteScpi_s("*OPC");
        //}

        //public string ESR()
        //{
        //    return QueryScpi_s("*ESR?");
        //}

        //public void SetRefDirection(bool bIsInt)
        //{
        //    string sRef = "";
        //    if (bIsInt) { sRef = "INT"; }
        //    else        { sRef = "EXT"; }

        //    WriteScpi_s($"ROSC:SOUR {sRef}");
        //}

        //public bool GetRefIsInternal()
        //{
        //    // ROSC:SOUR?
        //    string sTemp = QueryScpi_us("ROSC:SOUR?");
        //    if (sTemp.Contains("INT") == true)  { IsInternal = true; return true; }
        //    else                                { IsInternal = false; return false; }
        //}


        //public bool CheckOptionForSALimit()
        //{
        //    this.Option.Clear();

        //    string sRecv = QueryScpi_us("*OPT?");
        //    if (string.IsNullOrEmpty(sRecv) == true) { return false; }

        //    sRecv = sRecv.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");

        //    string[] sEachOpt = sRecv.Split(',');
        //    for (int i=0; i<sEachOpt.Length; i++)
        //    {
        //        if (string.IsNullOrEmpty(sEachOpt[i]) == true) { continue; }

        //        this.Option.Add(sEachOpt[i]);
        //    }

        //    return true;
        //}

        //public void StartupInitialize()
        //{
        //    WriteScpi_us(":INST:CRE:NEW IQ, 'IQ Analyer'");
        //}


        //public int ULimit_Bandwidth
        //{
        //    get
        //    {
        //        if (this.IsConnected() == false) { return 1; }

        //        int nReturn = 0;
        //        if (this.Option.Contains("B512") == true)       { nReturn = 512; }
        //        else if (this.Option.Contains("B320") == true)  { nReturn = 320; }
        //        else if (this.Option.Contains("B160") == true)  { nReturn = 160; }
        //        else if (this.Option.Contains("B80") == true)   { nReturn = 80; }
        //        else if (this.Option.Contains("B40") == true)   { nReturn = 40; }
        //        else if (this.Option.Contains("B28") == true)   { nReturn = 28; }

        //        return nReturn;
        //    }
        //}


        //public int ULimit_Frequency
        //{
        //    get
        //    {
        //        if (this.IsConnected() == false) { return 1; }

        //        int nReturn = 0;
        //        if (this.IDN.Contains("FSW-8") == true)       { nReturn = 8000; }
        //        else if (this.IDN.Contains("FSW-13") == true) { nReturn = 13600; }
        //        else if (this.IDN.Contains("FSW-26") == true) { nReturn = 26500; }
        //        else if (this.IDN.Contains("FSW-43") == true) { nReturn = 43500; }
        //        else if (this.IDN.Contains("FSW-50") == true) { nReturn = 50000; }

        //        return nReturn;
        //    }
        //}
    }


}
