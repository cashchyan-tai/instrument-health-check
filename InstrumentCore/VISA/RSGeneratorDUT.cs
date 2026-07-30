using System;

namespace Pegatron
{
    // R&S 訊號產生器作為 DUT（SMW200A、SMM100A、CLGD 等）
    // 只有發射能力（VSG），無接收能力（VSA）
    public class RSGeneratorDUT : VisaEquipment, IDUTInstrument
    {
        public bool CanTransmit => true;
        public bool CanReceive => false;

        public RSGeneratorDUT() : base()
        {
            this.Name = "RSGenerator";
        }

        public new bool ConnectLan(string ip, int timeout = 2500)
        {
            IPAddress = ip;
            // Allow callers to pass a full VISA resource string (e.g. "TCPIP0::<ip>::hislip0::INSTR")
            // to work around instruments/VISA stacks that don't like the default "TCPIP::<ip>::INST0::INSTR" form.
            m_sConnectionString = ip.Contains("::") ? ip : "TCPIP::" + ip + "::INST0::INSTR";
            SetVisaType(EVisaType.LAN);
            return base.ConnectDevice(m_sConnectionString, timeout);
        }

        public new void DisconnectDevice() => base.DisconnectDevice();
        public new bool GetIDN() => base.GetIDN();
        public new bool IsConnected() => base.IsConnected();
        public new void Reset() => base.Reset();

        // ── VSG ──────────────────────────────────────────────────────────────

        // routNum selects which RF path to drive: "1" for path A, "2" for path B on a
        // dual-path SMW. Single-path SMW callers always pass "1".
        public void SetupVSGChannel(double freqMHz, int rfNum, string portLetter, string routNum)
        {
            Reset();
            WriteScpi_s("SOUR:CORR:STAT 0");
            WriteScpi_s($"SOUR{routNum}:FREQ:CW {freqMHz} MHz");
        }

        public void SetupVSGPower(double powerDBm, string routNum)
        {
            WriteScpi_s($"SOUR{routNum}:POW:POW {powerDBm}");
        }

        public void TransmitOn(string routNum)
        {
            WriteScpi_s($"OUTP{routNum}:STAT 1");
        }

        public void TransmitOff(string routNum)
        {
            WriteScpi_s($"OUTP{routNum}:STAT 0");
        }

        // ── VSA (不支援) ──────────────────────────────────────────────────────

        public void SetupVSAMode(string routNum)
            => throw new NotSupportedException($"{Name} 不支援 VSA 接收模式");

        public void SetupVSAChannel(int rfNum, string portLetter, string routNum)
            => throw new NotSupportedException($"{Name} 不支援 VSA 接收模式");

        public void SetupVSAFrequency(double freqMHz, string routNum)
            => throw new NotSupportedException($"{Name} 不支援 VSA 接收模式");

        public void PrepareVSAMeasurement(double sgPowerDBm, string routNum)
            => throw new NotSupportedException($"{Name} 不支援 VSA 接收模式");

        public void InitiateVSACapture()
            => throw new NotSupportedException($"{Name} 不支援 VSA 接收模式");

        public string ReadVSAPower()
            => throw new NotSupportedException($"{Name} 不支援 VSA 接收模式");
    }
}
