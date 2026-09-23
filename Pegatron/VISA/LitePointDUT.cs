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

        // Hard ceiling on commanded VSG output power, independent of what a spec CSV or manual
        // entry requests. +5 dBm is the highest level LitePoint's own calibration certificate
        // verifies for the M8W7G (VSG High Power Accuracy tops out at +5 dBm); clamping here keeps
        // every code path - spec-driven test loops and the manual LP VSG panel alike - inside that
        // verified envelope instead of trusting each caller not to exceed it.
        public const double MaxVsgPowerDbm = 5.0;

        public void SetupVSGPower(double powerDBm, string routNum)
        {
            if (powerDBm > MaxVsgPowerDbm)
                powerDBm = MaxVsgPowerDbm;

            WriteScpi(_spec.scpiDUTSetVSGPow
                .Replace("xx", powerDBm.ToString())
                .Replace("zz", routNum));

            // WAVE:EXEC (scpiDUTSetVSGOutputState) plays whatever waveform is currently built -
            // without generating one first there's nothing to play, so RF stays silent even
            // though every SCPI call reports success. 0 Hz modulation offset = plain CW at the
            // carrier frequency already set via scpiDUTSetVSGFreq.
            string waveGen = string.IsNullOrWhiteSpace(_spec.scpiDUTSetVSGWaveGen)
                ? "VSGzz;WAVE:GEN:CWAV 0Hz,0Deg"
                : _spec.scpiDUTSetVSGWaveGen;
            WriteScpi(waveGen.Replace("zz", routNum));

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
