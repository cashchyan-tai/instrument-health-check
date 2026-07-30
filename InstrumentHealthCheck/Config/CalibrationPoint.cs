using System.Collections.Generic;

namespace InstrumentHealthCheck.Config
{
    public class CalibrationPoint
    {
        public double FrequencyMHz { get; set; }
        public List<double> LossDbPerPort { get; set; } = new List<double>();
    }
}
