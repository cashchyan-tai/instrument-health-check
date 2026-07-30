using System;

namespace Pegatron
{
    public interface IDUTInstrument
    {
        string Name { get; set; }
        string Model { get; set; }
        string IDN { get; set; }
        string Vendor { get; set; }
        string SN { get; set; }
        string Firmware { get; set; }

        bool CanTransmit { get; }
        bool CanReceive { get; }

        bool ConnectLan(string ip, int timeout = 2500);
        void DisconnectDevice();
        bool GetIDN();
        bool IsConnected();
        void Reset();

        // VSA: DUT 接收 SG 訊號並量測功率
        void SetupVSAMode(string routNum);
        void SetupVSAChannel(int rfNum, string portLetter, string routNum);
        void SetupVSAFrequency(double freqMHz, string routNum);
        void PrepareVSAMeasurement(double sgPowerDBm, string routNum);
        void InitiateVSACapture();
        string ReadVSAPower();

        // VSG: DUT 發射訊號供 SA 量測
        void SetupVSGChannel(double freqMHz, int rfNum, string portLetter, string routNum);
        void SetupVSGPower(double powerDBm, string routNum);
        void TransmitOn(string routNum);
        void TransmitOff(string routNum);
    }
}
