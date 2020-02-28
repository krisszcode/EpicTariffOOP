using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff
{
    class MobilXL : TariffPlan
    {
        public MobilXL(string name = "MobilXL", int tariff = 60, int internet = 100, int minutes = 300, int foreignMinutes = 200)
           : base(name, tariff, internet, minutes, foreignMinutes)
        {

        }
        public override int ForeignMinuteCharge(Client client, int requestedForeignMinutes)
        {
            throw new NotImplementedException();
        }

        public override int MinuteCharge()
        {
            throw new NotImplementedException();
        }

        public override int MobileInternetCharge(Client client, int requestedInternet)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
