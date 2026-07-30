using System.IO;
using System.Net;

namespace Pegatron
{
    public class SwitchRapidtek : ISwitchBox
    {
        public string IP = "";
        public string Vendor { get; } = "Rapidtek";
        public string Model { get; } = "P5-SWB SP6T";
        public string SN { get; } = "";
        public string Name = "Switch Box (Rapidtek)";
        public int PortSGDUT { get; } = 3;
        public int PortSADUT { get; } = 1;

        private readonly string switchName;
        private readonly int httpPort;

        public SwitchRapidtek(string switchName = "A", int httpPort = 80)
        {
            this.switchName = switchName.ToUpper();
            this.httpPort = httpPort;
        }

        private string Send(string command, int timeoutMs = 3000)
        {
            try
            {
                string baseUrl = httpPort == 80 ? $"http://{IP}" : $"http://{IP}:{httpPort}";
                var request = (HttpWebRequest)WebRequest.Create($"{baseUrl}/{command}");
                request.Timeout = timeoutMs;
                request.Method = "GET";
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                    return reader.ReadToEnd().TrimEnd('\0').Trim();
            }
            catch
            {
                return "";
            }
        }

        public bool Connect(string ipStr = "", int timeout = 1500)
        {
            if (!string.IsNullOrEmpty(ipStr))
                IP = ipStr;
            if (string.IsNullOrEmpty(IP)) return false;

            string resp = Send("*IDN?", timeout);
            return !string.IsNullOrEmpty(resp);
        }

        public void Disconnect()
        {
            Send($"SP6T{switchName}:STATE:0");
        }

        public bool SetPort(int portNum)
        {
            string resp = Send($"SP6T{switchName}:STATE:{portNum}");
            return resp == "1";
        }

        public string currentPort()
        {
            return Send($"SP6T{switchName}:STATE?");
        }
    }
}
