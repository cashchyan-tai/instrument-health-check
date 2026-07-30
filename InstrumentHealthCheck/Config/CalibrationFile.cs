using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace InstrumentHealthCheck.Config
{
    // Plain CSV, two sections separated by a blank line. Column position (not the header
    // text) determines which port a value belongs to, so renaming a port never shifts data:
    //
    // SG_TO_DUT
    // FREQ_MHZ,Port1,Port2
    // 400,-1.20,-1.30
    //
    // DUT_TO_SA
    // FREQ_MHZ,Port1,Port2
    // 400,-1.20,-1.30
    public static class CalibrationFile
    {
        private const string SgToDutMarker = "SG_TO_DUT";
        private const string DutToSaMarker = "DUT_TO_SA";

        public static CalibrationSet Load(string path)
        {
            var set = new CalibrationSet();
            string[] lines = File.ReadAllLines(path);

            CalibrationTable current = null;
            bool skipHeader = false;

            foreach (string rawLine in lines)
            {
                string line = rawLine.Trim();
                if (line.Length == 0) { current = null; continue; }

                if (line.Equals(SgToDutMarker, StringComparison.OrdinalIgnoreCase))
                {
                    current = set.ReferenceToDut;
                    skipHeader = true;
                    continue;
                }
                if (line.Equals(DutToSaMarker, StringComparison.OrdinalIgnoreCase))
                {
                    current = set.DutToReference;
                    skipHeader = true;
                    continue;
                }

                if (current == null) continue;
                if (skipHeader) { skipHeader = false; continue; }

                string[] cols = line.Split(',');
                if (cols.Length < 2) continue;
                if (!double.TryParse(cols[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double freq))
                    continue;

                var point = new CalibrationPoint { FrequencyMHz = freq };
                for (int i = 1; i < cols.Length; i++)
                {
                    double.TryParse(cols[i], NumberStyles.Float, CultureInfo.InvariantCulture, out double loss);
                    point.LossDbPerPort.Add(loss);
                }

                current.Points.Add(point);
            }

            return set;
        }

        public static void Save(string path, CalibrationSet set, IList<string> portNames)
        {
            var lines = new List<string>();
            AppendTable(lines, SgToDutMarker, set.ReferenceToDut, portNames);
            lines.Add("");
            AppendTable(lines, DutToSaMarker, set.DutToReference, portNames);

            File.WriteAllLines(path, lines);
        }

        private static void AppendTable(List<string> lines, string marker, CalibrationTable table, IList<string> portNames)
        {
            lines.Add(marker);
            lines.Add("FREQ_MHZ," + string.Join(",", portNames));

            foreach (CalibrationPoint point in table.Points.OrderBy(p => p.FrequencyMHz))
            {
                var cols = new List<string> { point.FrequencyMHz.ToString(CultureInfo.InvariantCulture) };
                cols.AddRange(point.LossDbPerPort.Select(loss => loss.ToString(CultureInfo.InvariantCulture)));
                lines.Add(string.Join(",", cols));
            }
        }
    }
}
