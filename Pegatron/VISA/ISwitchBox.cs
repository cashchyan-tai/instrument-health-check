namespace Pegatron
{
    public interface ISwitchBox
    {
        string Vendor { get; }
        string Model { get; }
        string SN { get; }
        int PortSGDUT { get; }   // port used when SG → DUT (VSA / DUT RX test)
        int PortSADUT { get; }   // port used when DUT → SA (VSG / DUT TX test)

        bool Connect(string ipStr = "", int timeout = 1500);
        void Disconnect();
        bool SetPort(int portNum);
        string currentPort();
    }
}
