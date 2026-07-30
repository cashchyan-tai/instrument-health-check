namespace InstrumentHealthCheck.Results
{
    public class TestResultRow
    {
        public double FrequencyMHz { get; set; }
        public double ExpectedDbm { get; set; }
        public double MeasuredDbm { get; set; }
        public double ErrorDb { get; set; }
        public bool Pass { get; set; }

        // Set when a step throws (SCPI error, unparsable reply, etc.) - Pass is always
        // false in that case and Measured/Error should be treated as not meaningful.
        public string Note { get; set; }
    }
}
