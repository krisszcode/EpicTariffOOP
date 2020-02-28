using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff
{
    class MobilM : TariffPlan
    {
        public MobilM(string name = "MobilM", int tariff = 20, int internet = 3, int minutes = 100, int foreignMinutes = 50)
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
