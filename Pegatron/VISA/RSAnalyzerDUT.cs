using System;

namespace Pegatron
{
    // R&S Spectrum/Signal Analyzer 作為 DUT（如 FSW8）
    // 只有接收能力（VSA），無發射能力（VSG）
    public class RSAnalyzerDUT : SpectrumAnalyzer, IDUTInstrument
    {
        public bool CanTransmit => false;
        public bool CanReceive => true;

        public RSAnalyzerDUT() : base()
        {
            this.Name = "RSAnalyzer";
        }

        // ── VSA ──────────────────────────────────────────────────────────────

        public void SetupVSAMode(string routNum)
        {
            Reset();
            WriteScpi("INIT:CONT OFF");
            WriteScpi("CALC:MARK:STAT ON");
            WriteScpi("FREQ:SPAN 100 kHz");
            WriteScpi("BAND:RES 1 kHz");
        }

        // 單 port，忽略 channel 參數
        public void SetupVSAChannel(int rfNum, string portLetter, string routNum) { }

        public void SetupVSAFrequency(double freqMHz, string routNum)
        {
            WriteScpi($"FREQ:CENT {freqMHz} MHz");
        }

        public void PrepareVSAMeasurement(double sgPowerDBm, string routNum)
        {
            WriteScpi($"DISP:WIND:TRAC:Y:RLEV {sgPowerDBm + 5} dBm");
        }

        public void InitiateVSACapture()
        {
            WriteScpi("INIT;*WAI");
            WriteScpi("CALC:MARK1:MAX");
        }

        public string ReadVSAPower()
        {
            return QueryScpi("CALC:MARK:Y?");
        }

        // ── VSG (不支援) ──────────────────────────────────────────────────────

        public void SetupVSGChannel(double freqMHz, int rfNum, string portLetter, string routNum)
            => throw new NotSupportedException($"{Name} 不支援 VSG 發射模式");

        public void SetupVSGPower(double powerDBm, string routNum)
            => throw new NotSupportedException($"{Name} 不支援 VSG 發射模式");

        public void TransmitOn(string routNum)
            => throw new NotSupportedException($"{Name} 不支援 VSG 發射模式");

        public void TransmitOff(string routNum)
            => throw new NotSupportedException($"{Name} 不支援 VSG 發射模式");
    }
}
