using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff
{
    class MobilL : TariffPlan
    {
        public MobilL(string name = "MobilL", int tariff = 40, int internet = 10, int minutes = 200, int foreignMinutes = 100)
           : base(name, tariff, internet, minutes, foreignMinutes)
        {

        }
       

        public override int ForeignMinuteCharge(Client client, int requestedForeignMinutes)
        {
            throw new NotImplementedException();
        }

        public override int MinuteCharge(Client client, int requestedMinutes)
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
