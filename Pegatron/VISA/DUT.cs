using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegatron
{
    public class DUT : VisaEquipment
    {
        public DUT() : base()
        {
            this.Name = "IQxel";
        }

        public new bool ConnectLan(string sIpAddress, int nTimeOut = 2500) // re-implement for simulate
        {
            return base.ConnectLan(sIpAddress, nTimeOut);
        }

        public new void DisconnectDevice()
        {
            base.DisconnectDevice();
        }

        public bool WriteScpi(string format, params object[] args)
        {
            string sSend = string.Format(format, args);

            return base.WriteScpi_s(sSend);
        }

        public new bool WriteScpi(string sSend)
        {
            return base.WriteScpi_s(sSend);
        }

        public new string ReadScpi(ref bool bIsSuccess)
        {
            return base.ReadScpi(ref bIsSuccess);
        }

        public string QueryScpi(string format, params object[] args)
        {
            string sSend = string.Format(format, args);
            return base.QueryScpi_s(sSend);
        }

        public new string QueryScpi(string sSend)
        {
            return base.QueryScpi_s(sSend);
        }

    }
}
