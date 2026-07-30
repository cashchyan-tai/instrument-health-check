namespace InstrumentHealthCheck.Config
{
    public class CalibrationSet
    {
        // Loss when the reference Signal Generator drives the DUT (DUT is SA-like).
        public CalibrationTable ReferenceToDut { get; } = new CalibrationTable();

        // Loss when the DUT drives the reference Spectrum Analyzer (DUT is SG-like).
        public CalibrationTable DutToReference { get; } = new CalibrationTable();
    }
}
