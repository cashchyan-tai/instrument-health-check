using System.Collections.Generic;

namespace InstrumentHealthCheck.Config
{
    public class PortSwitchSettings
    {
        public bool UseSwitch { get; set; }
        public SwitchVendorType SwitchVendor { get; set; } = SwitchVendorType.Woken;
        public string SwitchIp { get; set; } = "";
        public List<PortDefinition> Ports { get; set; } = new List<PortDefinition>();

        public PortSwitchSettings()
        {
            // Default matches the "no switch, cable straight into the instrument" setup.
            Ports.Add(new PortDefinition("Direct", 1));
        }
    }
}
