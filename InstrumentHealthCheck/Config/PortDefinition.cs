namespace InstrumentHealthCheck.Config
{
    public class PortDefinition
    {
        public string Name { get; set; }

        // Only meaningful when a physical switch is in use; ignored in direct-cable mode.
        public int PhysicalPortNumber { get; set; }

        public PortDefinition() { }

        public PortDefinition(string name, int physicalPortNumber)
        {
            Name = name;
            PhysicalPortNumber = physicalPortNumber;
        }
    }
}
