using System;
using System.Text;


namespace Pegatron
{
    public enum EVisaType
    {
        NONE,
        LAN,
        SOCK,
        GPIB,
        RS232
    }

    public enum ECRLF
    {
        NONE,
        CR,
        LF,
        CRLF,
        CUSTOM
    }

    public class VisaEquipment
    {
        protected EVisaType m_eVisaType = EVisaType.NONE;
        protected string m_sConnectionString = null;
        protected int m_nViSession = -9999;
        protected bool m_bIsConnected = false;
        protected string m_sCRLF = null;
        protected ECRLF m_eCRLF = ECRLF.NONE;

        public string IPAddress = null;

        public string IDN { get; set; }
        public string Name { get; set; }
        public string Vendor { get; set; }
        public string Model { get; set; }
        public string SN { get; set; }
        public string Firmware { get; set; }

        // public string SimSend = null;
        // public string SimRecv = null;
        //public SimulateValues Sim = new SimulateValues();

        protected VisaEquipment()
        {
            InitializeVisa();
        }

        protected VisaEquipment(EVisaType eType)
        {
            InitializeVisa();
            SetVisaType(eType);
        }

        protected void InitializeVisa()
        {
            m_sConnectionString = null;
            m_nViSession = -9999;
            SetVisaType(EVisaType.NONE);
            m_bIsConnected = false;
            SetCRLF(ECRLF.LF);
        }

        //public void LinkedDevOption(ref DevOption oDOpt)
        //{
        //    DevOpt = oDOpt;
        //}

        //public void LinkedLogForm(ref DbgCommLogForm oForm)
        //{
        //    LogForm = oForm;
        //    HasLogForm = true;
        //}

        //public void LinkedErrForm(ref DbgErrorForm oForm)
        //{
        //    this.ErrForm = oForm;
        //    HasErrForm = true;
        //}

        protected void SetVisaType(EVisaType eType)
        {
            m_eVisaType = eType;
        }

        public EVisaType GetVisaType()
        {
            return m_eVisaType;
        }

        public bool ConnectLan(string sIpAddress, int nTimeOut)
        {
            IPAddress = sIpAddress;
            if (sIpAddress.Contains("::"))
                m_sConnectionString = sIpAddress;
            else
                m_sConnectionString = "TCPIP::" + sIpAddress + "::INST0::INSTR";

            if (m_sConnectionString.ToUpper().Contains("::SOCKET"))
                SetVisaType(EVisaType.SOCK);
            else
                SetVisaType(EVisaType.LAN);

            return ConnectDevice(m_sConnectionString, nTimeOut);
        }

        public bool ConnectGpib(string sGpibAddress, int nTimeOut)
        {
            m_sConnectionString = "GPIB0::" + sGpibAddress + "::INSTR";
            SetVisaType(EVisaType.GPIB);
            return ConnectDevice(m_sConnectionString, nTimeOut);
        }

        public bool ConnectSocket(string sIpAddress, string sPort)
        {
            m_sConnectionString = "TCPIP0::" + sIpAddress + "::" + sPort + "::SOCKET";
            SetVisaType(EVisaType.SOCK);
            return ConnectDevice(m_sConnectionString, 100000);
        }


        public void DisconnectDevice()
        {
            //DebugEngine.LogWrite("DISC : Disconnect");

            m_sConnectionString = null;
            m_nViSession = -9999;

            IDN = null;
            Name = null;
            Vendor = null;
            Model = null;
            SN = null;
            Firmware = null;
            m_bIsConnected = false;

            SetVisaType(EVisaType.NONE);
            SetCRLF(ECRLF.LF);

            VIsa.Close(m_nViSession);
        }

        public void EnableTermChar()
        {
            if (GetVisaType() == EVisaType.SOCK)
            {
                //DebugEngine.LogWrite();

                VIsa.viSetAttribute(m_nViSession, ViAttr.VI_ATTR_TERMCHAR_EN, VIsa.VI_TRUE);
                VIsa.viSetAttribute(m_nViSession, ViAttr.VI_ATTR_RD_BUF_OPER_MODE, 1);
            }
        }
        public void DisableTermChar()
        {
            if (GetVisaType() == EVisaType.SOCK)
            {
                //DebugEngine.LogWrite();

                VIsa.viSetAttribute(m_nViSession, ViAttr.VI_ATTR_TERMCHAR_EN, VIsa.VI_FALSE);
                VIsa.viSetAttribute(m_nViSession, ViAttr.VI_ATTR_ASRL_END_IN, 0);
            }
        }

        protected bool ConnectDevice(string sRes, int nTimeOut)
        {
            //DebugEngine.LogWrite("CONN : {0}, {1}", sRes, nTimeOut);
            //if (HasLogForm) { LogForm.Logging(String.Format("[{0}] : Conecting {1}", Name, sRes)); }

            //if (DevOpt.Simulate == true) { m_bIsConnected = true; return true; }

            bool bRet = VIsa.Open(sRes, nTimeOut, ref m_nViSession);
            if (bRet == true)
            {
                //DebugEngine.LogWrite("CONN : {0}, {1} success", sRes, nTimeOut);
                //if (HasLogForm) { LogForm.Logging(String.Format("[{0}] : Connected", Name)); }

                if (GetVisaType() == EVisaType.SOCK)
                {
                    EnableTermChar();
                }

                m_bIsConnected = true;

                WriteScpi_us("*CLS");
            }
            else
            {
                //DebugEngine.LogWrite("CONN : {0}, {1} failure", sRes, nTimeOut);
                //if (HasLogForm) { LogForm.Logging(String.Format("[ERRO] : {0} connection fail", Name)); }

                m_bIsConnected = false;
                m_sConnectionString = null;
                SetVisaType(EVisaType.NONE);
                return false;
            }
            return true;
        }
        public void SetCRLF(ECRLF eCrlf)
        {
            //DebugEngine.LogWrite("{0}", eCrlf);

            if (eCrlf == ECRLF.CR) { m_sCRLF = "\r"; }
            else if (eCrlf == ECRLF.LF) { m_sCRLF = "\n"; }
            else if (eCrlf == ECRLF.CRLF) { m_sCRLF = "\r\n"; }
            else if (eCrlf == ECRLF.NONE) { m_sCRLF = ""; }
            else if (eCrlf == ECRLF.CUSTOM) { m_sCRLF = ""; }

            m_eCRLF = eCrlf;
        }

        public void SetCustomCRLF(string sCrlf)
        {
            //DebugEngine.LogWrite(sCrlf);

            SetCRLF(ECRLF.CUSTOM);
            m_sCRLF = sCrlf;
        }

        public ECRLF GetCRLF()
        {
            return m_eCRLF;
        }

        public string GetCRLFString()
        {
            return m_sCRLF;
        }

        public bool IsConnected()
        {
            return m_bIsConnected;
        }

        public bool ErrorCheck()
        {
            string sRecv = null;
            bool bIsSucces = false;
            if (WriteErrorCheck())
            {
                sRecv = ReadErrorCheck(ref bIsSucces);

                if (sRecv.Contains("No error") == true)
                {
                    return true;
                }
                else
                {
                    //LogForm.Logging("[ERRO] - TEXT : Remote Error");
                    // this.ErrForm.Error("Remote Error", sRecv.Replace("\n", ""));
                    //this.ErrForm.Error(Errors.ERR_SA_HAS_ERROR, sRecv.Replace("\n", ""));
                    return false;
                }
            }

            return false;
        }

        public bool WriteErrorCheck()
        {
            string sSend = "SYST:ERR?";

            //if (HasLogForm)
            //{
            //LogForm.Logging($"[{Name}-] - SEND : " + sSend);
            //}

            if (IsConnected() == false)
            {
                //DebugEngine.LogWrite("SEND : {0} <Not Connected error>", sSend);
                return false;
            }

            lock (VIsa.scpiLock)
            {
                try
                {
                    // sSend += m_sCRLF;

                    int retSize = -1;
                    ViStatus status = VIsa.viWrite(m_nViSession, new StringBuilder().Append(sSend).Append(m_sCRLF).ToString(), sSend.Length + m_sCRLF.Length, ref retSize);

                    //DebugEngine.LogWrite("SEND : {0} <{1}>", sSend, status);

                    if (status == ViStatus.VI_SUCCESS)
                    {
                        return true;
                    }

                    return false;
                }
                catch { }
                finally { }

                //DebugEngine.LogWrite("SEND : {0} <Exception Occured>", sSend);

                return false;
            }
        }

        public string ReadErrorCheck(ref bool bIsSuccess)
        {

            if (IsConnected() == false)
            {
                //DebugEngine.LogWrite("RECV : <Not Connected error>");

                bIsSuccess = false;

                //if (HasLogForm) { LogForm.Logging("[ERRO] - SCPI : <Not Connected error>"); }
                return null;
            }

            lock (VIsa.scpiLock)
            {
                try
                {
                    int nRetSize = -1;
                    bIsSuccess = false;
                    string sRecvScpi = null;

                    int numberofBytesToRead = 500;
                    StringBuilder sCompleteBuffer = new StringBuilder();
                    StringBuilder sReadBuffer = new StringBuilder(numberofBytesToRead);

                    ViStatus stauts = VIsa.viRead(m_nViSession, sReadBuffer, sReadBuffer.Length, ref nRetSize);

                    if (stauts == ViStatus.VI_SUCCESS)
                    {
                        sReadBuffer.Length = nRetSize;
                        sCompleteBuffer.Append(sReadBuffer);
                        sRecvScpi = sCompleteBuffer.ToString().Replace("\n", "").Replace("\r", "");
                        bIsSuccess = true;

                        //DebugEngine.LogWrite("RECV : {0} <{1}>", sRecvScpi, stauts);

                        //if (HasLogForm)
                        //{
                        //    if (sRecvScpi.ToString().Contains("No error") == false)
                        //    {
                        //        LogForm.Logging("[ERRO] - SCPI : " + sRecvScpi);
                        //    }
                        //}
                        return sRecvScpi;
                    }
                    else if (stauts == ViStatus.VI_SUCCESS_TERM_CHAR && GetVisaType() == EVisaType.SOCK)
                    {
                        sReadBuffer.Length = nRetSize;
                        sCompleteBuffer.Append(sReadBuffer);
                        sRecvScpi = sCompleteBuffer.ToString().Replace("\n", "").Replace("\r", "");
                        bIsSuccess = true;

                        //DebugEngine.LogWrite("RECV : {0} <{1}>", sRecvScpi, stauts);
                        //if (HasLogForm)
                        //{
                        //    if (sRecvScpi.ToString().Contains("No error") == false)
                        //    {
                        //        LogForm.Logging("[ERRO] - SCPI : " + sRecvScpi);
                        //    }
                        //}
                        return sRecvScpi;
                    }
                    else if (stauts == ViStatus.VI_SUCCESS_MAX_CNT)
                    {
                        while (stauts != ViStatus.VI_SUCCESS)
                        {
                            stauts = VIsa.viRead(m_nViSession, sReadBuffer, numberofBytesToRead, ref nRetSize); sReadBuffer.Length = nRetSize;
                            sCompleteBuffer.Append(sReadBuffer);
                            if (stauts == 0) { break; }
                            else if (stauts == ViStatus.VI_SUCCESS_MAX_CNT) { continue; }
                            else { break; }
                        }

                        sRecvScpi = sCompleteBuffer.ToString();

                        //DebugEngine.LogWrite("RECV : {0} <{1}>", sRecvScpi, stauts);
                        //if (HasLogForm)
                        //{
                        //    if (sRecvScpi.ToString().Contains("No error") == false)
                        //    {
                        //        LogForm.Logging("[ERRO] - SCPI : " + sRecvScpi);
                        //    }
                        //}
                        return sRecvScpi;
                    }
                    else
                    {
                        bIsSuccess = false;

                        //DebugEngine.LogWrite("RECV : {0} <{1}>", sRecvScpi, stauts);
                        //if (HasLogForm) { LogForm.Logging("[ERRO] - SCPI : <Status error>"); }
                        return null;
                    }
                }
                catch { }
                finally { }

                bIsSuccess = false;
                //DebugEngine.LogWrite("RECV : <Exception Occured>");
                //if (HasLogForm) { LogForm.Logging("[ERRO] - SCPI : <Exception error>"); }
                return null;
            }
        }




        protected bool WriteScpi_us(string sSend)
        {
            //if (DevOpt.Simulate == true)
            //{
            //    SimulateSend(sSend);
            //    return true;
            //}

            //if (HasLogForm)
            //{
            //    LogForm.Logging($"[{Name}-] - SEND : " + sSend);
            //}

            if (IsConnected() == false)
            {
                //DebugEngine.LogWrite("SEND : {0} <Not Connected error>", sSend);
                return false;
            }

            lock (VIsa.scpiLock)
            {
                try
                {
                    // sSend += m_sCRLF;

                    int retSize = -1;
                    ViStatus status = VIsa.viWrite(m_nViSession, new StringBuilder().Append(sSend).Append(m_sCRLF).ToString(), sSend.Length + m_sCRLF.Length, ref retSize);

                    //DebugEngine.LogWrite("SEND : {0} <{1}>", sSend, status);

                    if (status == ViStatus.VI_SUCCESS)
                    {
                        return true;
                    }

                    return false;
                }
                catch { }
                finally { }

                //DebugEngine.LogWrite("SEND : {0} <Exception Occured>", sSend);

                return false;
            }
        }

        protected bool WriteScpi_s(string sSend)
        {
            //if (DevOpt.Simulate == true)
            //{
            //    SimulateSend(sSend);
            //    return true;
            //}

            //if (HasLogForm)
            //{
            //    LogForm.Logging($"[{Name}-] - SEND : " + sSend);
            //}

            if (IsConnected() == false)
            {
                //DebugEngine.LogWrite("SEND : {0} <Not Connected error>", sSend);
                return false;
            }


            lock (VIsa.scpiLock)
            {
                try
                {
                    // sSend += m_sCRLF;

                    int retSize = -1;
                    ViStatus status = VIsa.viWrite(m_nViSession, new StringBuilder().Append(sSend).Append(m_sCRLF).ToString(), sSend.Length + m_sCRLF.Length, ref retSize);

                    //DebugEngine.LogWrite("SEND : {0} <{1}>", sSend, status);

                    if (status == ViStatus.VI_SUCCESS)
                    {
                        ErrorCheck();
                        return true;
                    }

                    return false;
                }
                catch { }
                finally { }

                //DebugEngine.LogWrite("SEND : {0} <Exception Occured>", sSend);

                return false;
            }
        }

        // protected bool WriteScpi_Trigger(string sSend, bool bLogOn = true)
        // {
        //     if (HasLogForm && bLogOn)
        //     {
        //         LogForm.Logging("[TRIG] - SEND : " + sSend);
        //     }
        // 
        //     if (IsConnected() == false)
        //     {
        //         DebugEngine.LogWrite("SEND : {0} <Not Connected error>", sSend);
        //         return false;
        //     }
        // 
        //     lock (VIsa.scpiLock)
        //     {
        //         try
        //         {
        //             // sSend += m_sCRLF;
        // 
        //             int retSize = -1;
        //             ViStatus status = VIsa.viWrite(m_nViSession, new StringBuilder().Append(sSend).Append(m_sCRLF).ToString(), sSend.Length + m_sCRLF.Length, ref retSize);
        // 
        //             if (bLogOn) { DebugEngine.LogWrite("SEND : {0} <{1}>", sSend, status); }
        // 
        //             if (status == ViStatus.VI_SUCCESS)
        //             {
        //                 return true;
        //             }
        // 
        //             return false;
        //         }
        //         catch { }
        //         finally { }
        // 
        //         if (bLogOn) { DebugEngine.LogWrite("SEND : {0} <Exception Occured>", sSend); }
        // 
        //         return false;
        //     }
        // }

        // protected bool WriteScpiUTF8(string sSend)
        // {
        //     if (HasLogForm)
        //     {
        //         LogForm.Logging($"[{Name}-] - SEND : " + sSend);
        //     }
        // 
        //     if (IsConnected() == false)
        //     {
        //         DebugEngine.LogWrite("SEND : {0} <Not Connected error>", sSend);
        //         return false;
        //     }
        // 
        //     lock (VIsa.scpiLock)
        //     {
        //         try
        //         {
        //             // sSend += m_sCRLF;
        //             byte[] byteData = Encoding.UTF8.GetBytes(sSend);
        // 
        //             int retSize = -1;
        //             // ViStatus status = VIsa.viWrite(m_nViSession, new StringBuilder().Append(sSend).Append(m_sCRLF).ToString(), sSend.Length + m_sCRLF.Length, ref retSize);
        //             ViStatus status = VIsa.viWriteByte(m_nViSession, byteData, byteData.Length, ref retSize);
        //             DebugEngine.LogWrite("SEND : {0} <{1}>", sSend, status);
        // 
        //             if (status == ViStatus.VI_SUCCESS)
        //             {
        //                 return true;
        //             }
        // 
        //             return false;
        //         }
        //         catch { }
        //         finally { }
        // 
        //         DebugEngine.LogWrite("SEND : {0} <Exception Occured>", sSend);
        // 
        //         return false;
        //     }
        // }

        protected string ReadScpi(ref bool bIsSuccess)
        {
            //if (DevOpt.Simulate == true)
            //{
            //    return SimulateRecv();
            //    // Sim.Send = null;
            //    if (HasLogForm) { LogForm.Logging($"[{Name}*] - RECV : " + Sim.Recv); }
            //    // return Sim.Recv;
            //}

            if (IsConnected() == false)
            {
                //DebugEngine.LogWrite("RECV : <Not Connected error>");

                bIsSuccess = false;

                //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : "); }
                return null;
            }

            lock (VIsa.scpiLock)
            {
                try
                {
                    int nRetSize = -1;
                    bIsSuccess = false;
                    string sRecvScpi = null;

                    int numberofBytesToRead = 500;
                    StringBuilder sCompleteBuffer = new StringBuilder();
                    StringBuilder sReadBuffer = new StringBuilder(numberofBytesToRead);

                    ViStatus stauts = VIsa.viRead(m_nViSession, sReadBuffer, sReadBuffer.Length, ref nRetSize);

                    if (stauts == ViStatus.VI_SUCCESS)
                    {
                        sReadBuffer.Length = nRetSize;
                        sCompleteBuffer.Append(sReadBuffer);
                        sRecvScpi = sCompleteBuffer.ToString().Replace("\n", "").Replace("\r", "");
                        bIsSuccess = true;

                        //DebugEngine.LogWrite("RECV : {0} <{1}>", sRecvScpi, stauts);

                        //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : " + sRecvScpi); }
                        return sRecvScpi;
                    }
                    else if (stauts == ViStatus.VI_SUCCESS_TERM_CHAR && GetVisaType() == EVisaType.SOCK)
                    {
                        sReadBuffer.Length = nRetSize;
                        sCompleteBuffer.Append(sReadBuffer);
                        sRecvScpi = sCompleteBuffer.ToString().Replace("\n", "").Replace("\r", "");
                        bIsSuccess = true;

                        //DebugEngine.LogWrite("RECV : {0} <{1}>", sRecvScpi, stauts);
                        //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : " + sRecvScpi); }
                        return sRecvScpi;
                    }
                    else if (stauts == ViStatus.VI_SUCCESS_MAX_CNT)
                    {
                        while (stauts != ViStatus.VI_SUCCESS)
                        {
                            stauts = VIsa.viRead(m_nViSession, sReadBuffer, numberofBytesToRead, ref nRetSize); sReadBuffer.Length = nRetSize;
                            sCompleteBuffer.Append(sReadBuffer);
                            if (stauts == 0) { break; }
                            else if (stauts == ViStatus.VI_SUCCESS_MAX_CNT) { continue; }
                            else { break; }
                        }

                        sRecvScpi = sCompleteBuffer.ToString();

                        //DebugEngine.LogWrite("RECV : {0} <{1}>", sRecvScpi, stauts);
                        //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : " + sRecvScpi); }
                        return sRecvScpi;
                    }
                    else
                    {
                        bIsSuccess = false;

                        //DebugEngine.LogWrite("RECV : {0} <{1}>", sRecvScpi, stauts);
                        //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : "); }
                        return null;
                    }
                }
                catch { }
                finally { }

                bIsSuccess = false;
                //DebugEngine.LogWrite("RECV : <Exception Occured>");
                //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : "); }
                return null;
            }
        }

        // protected string ReadScpi_Trigger(ref bool bIsSuccess, bool bLogOn = true)
        // {
        // 
        //     if (IsConnected() == false)
        //     {
        //         DebugEngine.LogWrite("RECV : <Not Connected error>");
        // 
        //         bIsSuccess = false;
        // 
        //         if (HasLogForm && bLogOn) { LogForm.Logging("[TRIG] - RECV : "); }
        //         return null;
        //     }
        // 
        //     lock (VIsa.scpiLock)
        //     {
        //         try
        //         {
        //             int nRetSize = -1;
        //             bIsSuccess = false;
        //             string sRecvScpi = null;
        // 
        //             int numberofBytesToRead = 500;
        //             StringBuilder sCompleteBuffer = new StringBuilder();
        //             StringBuilder sReadBuffer = new StringBuilder(numberofBytesToRead);
        // 
        //             ViStatus stauts = VIsa.viRead(m_nViSession, sReadBuffer, sReadBuffer.Length, ref nRetSize);
        // 
        //             if (stauts == ViStatus.VI_SUCCESS)
        //             {
        //                 sReadBuffer.Length = nRetSize;
        //                 sCompleteBuffer.Append(sReadBuffer);
        //                 sRecvScpi = sCompleteBuffer.ToString().Replace("\n", "").Replace("\r", "");
        //                 bIsSuccess = true;
        // 
        //                 if (bLogOn) { DebugEngine.LogWrite("RECV : {0} <{1}>", sRecvScpi, stauts); }
        // 
        //                 if (HasLogForm && bLogOn) { LogForm.Logging("[TRIG] - RECV : " + sRecvScpi); }
        //                 return sRecvScpi;
        //             }
        //             else if (stauts == ViStatus.VI_SUCCESS_TERM_CHAR && this.GetVisaType() == EVisaType.SOCK)
        //             {
        //                 sReadBuffer.Length = nRetSize;
        //                 sCompleteBuffer.Append(sReadBuffer);
        //                 sRecvScpi = sCompleteBuffer.ToString().Replace("\n", "").Replace("\r", "");
        //                 bIsSuccess = true;
        // 
        //                 if (bLogOn) { DebugEngine.LogWrite("RECV : {0} <{1}>", sRecvScpi, stauts); }
        //                 if (HasLogForm && bLogOn) { LogForm.Logging("[TRIG] - RECV : " + sRecvScpi); }
        //                 return sRecvScpi;
        //             }
        //             else if (stauts == ViStatus.VI_SUCCESS_MAX_CNT)
        //             {
        //                 while (stauts != ViStatus.VI_SUCCESS)
        //                 {
        //                     stauts = VIsa.viRead(m_nViSession, sReadBuffer, numberofBytesToRead, ref nRetSize); sReadBuffer.Length = nRetSize;
        //                     sCompleteBuffer.Append(sReadBuffer);
        //                     if (stauts == 0) { break; }
        //                     else if (stauts == ViStatus.VI_SUCCESS_MAX_CNT) { continue; }
        //                     else { break; }
        //                 }
        // 
        //                 sRecvScpi = sCompleteBuffer.ToString();
        // 
        //                 if (bLogOn) { DebugEngine.LogWrite("RECV : {0} <{1}>", sRecvScpi, stauts); }
        //                 if (HasLogForm && bLogOn) { LogForm.Logging("[TRIG] - RECV : " + sRecvScpi); }
        //                 return sRecvScpi;
        //             }
        //             else
        //             {
        //                 bIsSuccess = false;
        // 
        //                 if (bLogOn) { DebugEngine.LogWrite("RECV : {0} <{1}>", sRecvScpi, stauts); }
        //                 if (HasLogForm && bLogOn) { LogForm.Logging("[TRIG] - RECV : "); }
        //                 return null;
        //             }
        //         }
        //         catch { }
        //         finally { }
        // 
        //         bIsSuccess = false;
        //         if (bLogOn) { DebugEngine.LogWrite("RECV : <Exception Occured>"); }
        //         // if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : "); }
        //         return null;
        //     }
        // }

        protected byte[] ReadScpiByteIEEE(ref bool bIsSuccess)
        {
            if (IsConnected() == false)
            {
                //DebugEngine.LogWrite("RECV : <BYTE - Not Connected error>");

                bIsSuccess = false;
                //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : "); }
                return null;
            }

            // #41234

            lock (VIsa.scpiLock)
            {
                byte[] byReadFirst = new byte[1];
                int nRetSize = 0;

                // #
                ViStatus status = VIsa.viReadByte(m_nViSession, byReadFirst, byReadFirst.Length, ref nRetSize);

                if (status != ViStatus.VI_SUCCESS && status != ViStatus.VI_SUCCESS_MAX_CNT)
                {
                    //DebugEngine.LogWrite("RECV : <BYTE - {0} error>", status);

                    bIsSuccess = false;
                    //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : "); }
                    return null;
                }

                if (byReadFirst[0] != '#')
                {
                    //DebugEngine.LogWrite("RECV : {0} <BYTE - {1} Cannot find '#'>", (char)byReadFirst[0], status);

                    bIsSuccess = false;
                    //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : "); }
                    return null;
                }

                //DebugEngine.LogWrite("RECV : {0} <BYTE - ReadCnt {1} / {2}>", (char)byReadFirst[0], byReadFirst.Length, status);


                // 4
                byte[] byReadFirstSize = new byte[1];
                status = VIsa.viReadByte(m_nViSession, byReadFirstSize, byReadFirstSize.Length, ref nRetSize);
                if (status != ViStatus.VI_SUCCESS && status != ViStatus.VI_SUCCESS_MAX_CNT)
                {
                    //DebugEngine.LogWrite("RECV : <BYTE - {0} error>", status);

                    bIsSuccess = false;
                    //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : "); }
                    return null;
                }

                //DebugEngine.LogWrite("RECV : {0} <BYTE - ReadCnt {1} / {2}>", (char)byReadFirstSize[0], byReadFirstSize.Length, status);

                int nLengthCharCount = 0;
                string sTemp = ((char)byReadFirstSize[0]).ToString();
                if (int.TryParse(sTemp, out nLengthCharCount) == false)
                {
                    bIsSuccess = false;
                    //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : "); }
                    return null;
                }


                // 1234
                byte[] byReadDataLength = new byte[nLengthCharCount];
                status = VIsa.viReadByte(m_nViSession, byReadDataLength, byReadDataLength.Length, ref nRetSize);
                if (status != ViStatus.VI_SUCCESS && status != ViStatus.VI_SUCCESS_MAX_CNT)
                {
                    //DebugEngine.LogWrite("RECV : <BYTE - {0} error>", status);

                    bIsSuccess = false;
                    //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : "); }
                    return null;
                }

                int nSizeOfData = -9999;

                StringBuilder sTempSize = new StringBuilder();
                for (int i = 0; i < nLengthCharCount; i++)
                {
                    sTempSize.Append((char)byReadDataLength[i]);
                }

                //DebugEngine.LogWrite("RECV : {0} <BYTE - ReadCnt {1} / {2}>", sTempSize, byReadDataLength.Length, status);



                if (int.TryParse(sTempSize.ToString(), out nSizeOfData) != true)
                {
                    bIsSuccess = false;
                    //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : "); }
                    return null;
                }
                if (nSizeOfData == 0)
                {
                    bIsSuccess = false;
                    //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : "); }
                    return null;
                }


                // data
                byte[] byData = new byte[nSizeOfData];
                status = VIsa.viReadByte(m_nViSession, byData, byData.Length, ref nRetSize);
                if (status != ViStatus.VI_SUCCESS && status != ViStatus.VI_SUCCESS_MAX_CNT)
                {
                    //DebugEngine.LogWrite("RECV : <BYTE - {0} error>", status);

                    bIsSuccess = false;
                    //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : "); }
                    return null;
                }

                //DebugEngine.LogWrite("RECV : <BYTE - ReadCnt {0} / {1}>", byData.Length, status);


                byte[] byLast = new byte[1];
                status = VIsa.viReadByte(m_nViSession, byLast, byLast.Length, ref nRetSize);
                if (status != ViStatus.VI_SUCCESS && status != ViStatus.VI_SUCCESS_MAX_CNT)
                {
                    //DebugEngine.LogWrite("RECV : <BYTE - {0} error>", status);

                    bIsSuccess = false;
                    //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : "); }
                    return null;
                }

                //DebugEngine.LogWrite("RECV : <BYTE - ReadCnt {0} / {1}>", byLast.Length, status);


                byte[] byteReturn = new byte[1 + 1 + nLengthCharCount + nSizeOfData];
                byteReturn[0] = byReadFirst[0];
                byteReturn[1] = byReadFirstSize[0];

                for (int i = 0; i < nLengthCharCount; i++)
                {
                    byteReturn[i + 1 + 1] = byReadDataLength[i];
                }

                for (int i = 0; i < byData.Length; i++)
                {
                    byteReturn[i + 1 + 1 + nLengthCharCount] = byData[i];
                }

                bIsSuccess = true;
                //if (HasLogForm) { LogForm.Logging($"[{Name}-] - RECV : BYTE " + byteReturn.Length); }
                return byteReturn;
            }
        }

        protected byte[] ReadScpiByteIEEEBase(ref bool bIsSuccess)
        {
            return ReadScpiByteIEEE(ref bIsSuccess);
        }

        protected string QueryScpi_us(string sSend)
        {
            string sRecv = null;
            bool bIsSucces = false;
            if (WriteScpi_us(sSend))
            {
                sRecv = ReadScpi(ref bIsSucces);

                return sRecv;
            }

            return sRecv;
        }

        protected string QueryScpi_s(string sSend)
        {
            string sRecv = null;
            bool bIsSucces = false;
            if (WriteScpi_us(sSend))
            {
                sRecv = ReadScpi(ref bIsSucces);

                ErrorCheck();
                return sRecv;
            }

            return sRecv;
        }

        // protected string QueryScpi_Trigger(string sSend, bool bLogOn = true)
        // {
        //     string sRecv = null;
        //     bool bIsSucces = false;
        //     if (WriteScpi_Trigger(sSend , bLogOn))
        //     {
        //         sRecv = ReadScpi_Trigger(ref bIsSucces, bLogOn);
        // 
        //         return sRecv;
        //     }
        // 
        //     return sRecv;
        // }

        public bool GetIDN()
        {
            IDN = QueryScpi_s("*IDN?");
            if (!string.IsNullOrEmpty(IDN))
            {
                string[] sArr = IDN.ToUpper().Split(',');
                if (sArr.Length > 0) { Vendor = sArr[0]; }
                if (sArr.Length > 1) { Model = sArr[1]; }
                if (sArr.Length > 2) { SN = sArr[2]; }
                if (sArr.Length > 3) { Firmware = sArr[3]; }

                return true;
            }

            return false;
        }

        public string GetModel()
        {
            string sIdn = QueryScpi_us("*IDN?");
            if (string.IsNullOrEmpty(sIdn) == false)
            {
                string[] sRet = sIdn.Split(',');
                if (sRet.Length > 2)
                {
                    return sRet[1];
                }
            }
            return "None";
        }

        //private void SimulateSend(string sSend)
        //{
            //if (DevOpt.Simulate == true)
            //{
            //    if (HasLogForm)
            //    {
            //        LogForm.Logging($"[{Name}*] - SEND : " + sSend);
            //    }

            //    Sim.SetSend(Name, sSend);
            //}
        //}

        //private string SimulateRecv()
        //{
        //    Sim.Send = null;
        //    //if (HasLogForm) { LogForm.Logging($"[{Name}*] - RECV : " + Sim.Recv); }
        //    return Sim.Recv;
        //}

        public void Reset()
        {
            WriteScpi_us("*RST");
        }
    }

    //public enum ESimMeasMode
    //{
    //    None,
    //    Ref,
    //    Tx,
    //    Rx
    //}

    //public class SimulateValues
    //{
    //    public ESimMeasMode Mode = ESimMeasMode.None;
    //    public double SimFreq = -99999;
    //    public double SimLevel = -99999;
    //    public double SimRef = -99999;
    //    public string Recv = null;
    //    public string Send = null;
    //    Random rand = new Random();

    //    public void SetSend(string sEquip, string sSend)
    //    {


    //        Recv = null;
    //        Send = sSend;

    //        if (sEquip == "CMW")
    //        {
    //            if (Send.Contains("*IDN?") == true) { Recv = "Rohde&Schwarz,SCMW,1201.0002k50/164935,3.7.172"; }
    //            if (Send.Contains("*OPC?") == true) { Recv = "1"; }
    //            if (Send.Contains("SENS:BASE:TEMP:OPER:INT?") == true) { Recv = "4.418125E+001"; }
    //            if (Send.Contains("CALibration:BASE:LATest:SPECific? FSC") == true) { Recv = "\"\",\"\""; }
    //            if (Send.Contains("FETC:GPRF:MEAS:POW:AVER?") == true)
    //            {
    //                SimFreq = SimFreq * 0.0000001;
    //                System.Threading.Thread.Sleep(50);
    //                if (Mode == ESimMeasMode.Rx)
    //                {
    //                    // double randDbl = 0;
    //                    // randDbl = rand.NextDouble();
    //                    // Recv = "0," + (SimLevel - randDbl - (SimFreq * SimFreq * 0.00001) * -1).ToString();

    //                    double randDbl = 0;
    //                    randDbl = Math.Abs(rand.NextDouble() - 0.6);
    //                    // Recv = (SimLevel + randDbl - (SimFreq * SimFreq * 0.00001) * +1).ToString();
    //                    Recv = "0," + (SimLevel - SimRef - randDbl).ToString();
    //                }
    //            }
    //            if (Send.Contains("SOUR:GPRF:GEN:STAT?") == true) { Recv = "ONOFF"; }
    //            if (Send.Contains("FETC:GPRF:MEAS:POW:STAT?") == true) { Recv = "RDY"; }

    //        }
    //        else if (sEquip == "VSG")
    //        {
    //            if (Send.Contains("*IDN?") == true) { Recv = "Rohde-Schwarz,SSG,1311601044101316,3.15"; }
    //            if (Send.Contains("*OPC?") == true) { Recv = "1"; }
    //        }
    //        else if (sEquip == "VSA")
    //        {
    //            if (Send.Contains("*IDN?") == true) { Recv = "Rohde-Schwarz,SSA,1311601044101316,3.15"; }
    //            if (Send.Contains("*OPC?") == true) { Recv = "1"; }
    //            if (Send.Contains("CALC:MARK:X1?") == true) { Recv = ""; }
    //            if (Send.Contains("CALC:MARK:Y1?") == true)
    //            {
    //                SimFreq = SimFreq * 0.0000001;
    //                System.Threading.Thread.Sleep(20);
    //                if (Mode == ESimMeasMode.Ref)
    //                {
    //                    double randDbl = 0;
    //                    randDbl = rand.NextDouble();
    //                    Recv = (SimLevel + randDbl * -1).ToString();
    //                }
    //                else if (Mode == ESimMeasMode.Tx)
    //                {
    //                    double randDbl = 0;
    //                    randDbl = Math.Abs(rand.NextDouble() - 0.6);
    //                    // Recv = (SimLevel + randDbl - (SimFreq * SimFreq * 0.00001) * +1).ToString();
    //                    Recv = (SimLevel - SimRef - randDbl).ToString();
    //                }
    //            }
    //        }

    //    }
    //}

}
