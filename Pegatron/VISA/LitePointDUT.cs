namespace Pegatron
{
    public class LitePointDUT : DUT, IDUTInstrument
    {
        private TestData _spec;

        public bool CanTransmit => true;
        public bool CanReceive => true;

        public LitePointDUT() : base() { }

        public void SetSpec(TestData spec) { _spec = spec; }

        // ── VSA ──────────────────────────────────────────────────────────────

        public void SetupVSAMode(string routNum)
        {
            Reset();
            WriteScpi(_spec.scpiDUTSetVSAMode.Replace("zz", routNum));
            WriteScpi(_spec.scpiDUTSetVSACaptureTime);
            WriteScpi(_spec.scpiDUTSetVSAImmTrigSource);
            WriteScpi("FORMat:READings:DATA ASC");
        }

        public void SetupVSAChannel(int rfNum, string portLetter, string routNum)
        {
            WriteScpi(_spec.scpiDUTSetVSAChannel
                .Replace("xx", rfNum.ToString())
                .Replace("yy", portLetter)
                .Replace("zz", routNum));
        }

        public void SetupVSAFrequency(double freqMHz, string routNum)
        {
            WriteScpi(_spec.scpiDUTSetVSAFreq
                .Replace("xx", FormatFrequencyArg(freqMHz))
                .Replace("zz", routNum));
        }

        public void PrepareVSAMeasurement(double sgPowerDBm, string routNum)
        {
            WriteScpi(_spec.scpiDUTSetVSAMode.Replace("zz", routNum));
            WriteScpi(_spec.scpiDUTSetVSAAutoRangeRefLevel);
        }

        public void InitiateVSACapture()
        {
            WriteScpi(_spec.scpiDUTSetVSAInitiateInputCapture);
            WriteScpi(_spec.scpiDUTSetVSACalcPow);
        }

        public string ReadVSAPower()
        {
            return QueryScpi(_spec.scpiDUTReadVSAPeakPow);
        }

        // ── VSG ──────────────────────────────────────────────────────────────

        public void SetupVSGChannel(double freqMHz, int rfNum, string portLetter, string routNum)
        {
            WriteScpi("*RST");
            WriteScpi(_spec.scpiDUTSetVSGMode.Replace("zz", routNum));
            WriteScpi(_spec.scpiDUTSetVSGChannel
                .Replace("xx", rfNum.ToString())
                .Replace("yy", portLetter)
                .Replace("zz", routNum));
            WriteScpi(_spec.scpiDUTSetVSGFreq
                .Replace("xx", FormatFrequencyArg(freqMHz))
                .Replace("zz", routNum));
        }

        // IQGIG-UWB's FREQ:CENT only accepts a bare Hz integer (confirmed from captured SCPI traffic:
        // 8000/7500 MHz points went out as 8000000000/7500000000, no unit suffix). Every other DUT model
        // keeps the existing "<value> MHz" text behavior driven by each spec CSV's own SCPI template.
        private string FormatFrequencyArg(double freqMHz)
        {
            if (!string.IsNullOrEmpty(Model) && Model.Contains("UWB"))
                return (freqMHz * 1e6).ToString("0");

            return freqMHz.ToString();
        }

        public void SetupVSGPower(double powerDBm, string routNum)
        {
            WriteScpi(_spec.scpiDUTSetVSGPow
                .Replace("xx", powerDBm.ToString())
                .Replace("zz", routNum));
            WriteScpi(_spec.scpiDUTSetVSGOutputState.Replace("zz", routNum));
        }

        public void TransmitOn(string routNum)
        {
            WriteScpi(_spec.scpiDUTSetVSGRFOnOffState.Replace("xx", "ON").Replace("zz", routNum));
        }

        public void TransmitOff(string routNum)
        {
            WriteScpi(_spec.scpiDUTSetVSGRFOnOffState.Replace("xx", "OFF").Replace("zz", routNum));
        }
    }
}
