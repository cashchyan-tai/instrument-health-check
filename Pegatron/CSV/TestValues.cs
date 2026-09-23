using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegatron
{
    public class TestValues
    {
        public double LowFreqLimit { get; set; }
        public double HighFreqLimit { get; set; }
        public double FreqLimit { get; set; }

        // Optional low/high band crossover for this section, read from the spec CSV. Left unset
        // (null) when a spec only needs one limit for its whole frequency range - LimitFor() then
        // always returns LowFreqLimit and HighFreqLimit is simply never consulted.
        public double? BandBoundaryMHz { get; set; }

        public double LimitFor(int frequencyMHz)
        {
            return BandBoundaryMHz.HasValue && frequencyMHz > BandBoundaryMHz.Value ? HighFreqLimit : LowFreqLimit;
        }

        private bool[,] brfChannelIsOn = new bool[4,2];   
        public bool[,] rfChannelIsOn
        {
            get { return brfChannelIsOn; }
            set { brfChannelIsOn = value; }
        }

        private List<string> sPower = new List<string>();
        public List<string> Power_Str
        {
            get { return sPower; }
            set { sPower = value; }
        }
        public List<int> Power
        {
            get { return sPower.Select(int.Parse).ToList(); }
            //set { Power_Str = Array.ConvertAll(value, ele => ele.ToString()); }
        }

        private List<string> sFrequency = new List<string>();
        public List<string> Frequency_Str
        {
            get { return sFrequency; }
            set { sFrequency = value; }
        }
        public List<int> Frequency
        {
            get { return sFrequency.Select(int.Parse).ToList(); }
            //set { Frequency_Str = Array.ConvertAll(value, ele => ele.ToString()); }
        }
    }
}
