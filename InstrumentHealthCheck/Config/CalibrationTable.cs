using System.Collections.Generic;
using System.Linq;

namespace InstrumentHealthCheck.Config
{
    public class CalibrationTable
    {
        public List<CalibrationPoint> Points { get; } = new List<CalibrationPoint>();

        // Linear interpolation between the two calibrated points bracketing freqMHz;
        // clamps to the nearest edge point outside the calibrated range. Returns 0 if
        // this port index was never calibrated (e.g. a port added after calibration).
        public double GetLoss(double freqMHz, int portIndex)
        {
            List<CalibrationPoint> valid = Points
                .Where(p => portIndex < p.LossDbPerPort.Count)
                .OrderBy(p => p.FrequencyMHz)
                .ToList();

            if (valid.Count == 0) return 0;

            for (int i = 0; i < valid.Count; i++)
            {
                if (valid[i].FrequencyMHz == freqMHz)
                    return valid[i].LossDbPerPort[portIndex];

                if (valid[i].FrequencyMHz > freqMHz)
                {
                    if (i == 0) return valid[i].LossDbPerPort[portIndex];

                    CalibrationPoint prev = valid[i - 1];
                    CalibrationPoint next = valid[i];
                    double loss1 = prev.LossDbPerPort[portIndex];
                    double loss2 = next.LossDbPerPort[portIndex];
                    return loss1 + (freqMHz - prev.FrequencyMHz) * (loss2 - loss1) / (next.FrequencyMHz - prev.FrequencyMHz);
                }
            }

            return valid[valid.Count - 1].LossDbPerPort[portIndex];
        }
    }
}
