using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff
{
    class MobilS : TariffPlan
    {
        public MobilS(string name = "MobilS", int tariff = 10, int internet = 1, int minutes = 60, int foreignMinutes = 30)
            : base(name, tariff, internet, minutes, foreignMinutes)
        {
            
        }
        public override int ForeignMinuteCharge(Client client, int requestedForeignMinutes)
        {             
            if (client.Income < requestedForeignMinutes * 0.22)
            {
                throw new NotEnoughMoney();
            }
            client.Income -= requestedForeignMinutes * 022;
            return client.Package.ForeignMinutes += requestedForeignMinutes;
        }

        public override int MinuteCharge(Client client, int requestedMinutes)
        {
            //return client.Income - requestedForeignMinutes * 0.22;
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
