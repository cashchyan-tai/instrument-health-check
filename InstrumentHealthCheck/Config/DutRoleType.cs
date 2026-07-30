namespace InstrumentHealthCheck.Config
{
    public enum DutRoleType
    {
        // DUT receives (behaves like a Spectrum/Signal Analyzer) -> reference side must transmit (Signal Generator)
        SignalAnalyzer,

        // DUT transmits (behaves like a Signal Generator) -> reference side must receive (Spectrum Analyzer)
        SignalGenerator
    }
}
