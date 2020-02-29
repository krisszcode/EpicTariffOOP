using System;
using System.Collections.Generic;
using System.Text;
using EpicTariff.Sexception;

namespace EpicTariff.Data
{
    public class MobilS : TariffPlan
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
            client.Income -= requestedForeignMinutes * 0.22;
            return client.Package.ForeignMinutes += requestedForeignMinutes;
        }

        public override Client LoseMoney(Client client)
        {
            if (client.Income < Tariff)
            {
                throw new NotEnoughMoney();
            }
            client.Income -= Tariff;
            return client;
        }

        public override void GetMoney(Client client)
        {
            client.Income += Tariff;
        }

        public override int MinuteCharge(Client client, int requestedMinutes)
        {
            if (client.Income < requestedMinutes * 0.19)
            {
                throw new NotEnoughMoney();
            }
            client.Income -= requestedMinutes * 0.19;
            return client.Package.Minutes += requestedMinutes;
        }

        public override int MobileInternetCharge(Client client, int requestedInternet)
        {
            if (client.Income < requestedInternet * 0.33)
            {
                throw new NotEnoughMoney();
            }
            client.Income -= requestedInternet * 0.33;
            return client.Package.Internet += requestedInternet;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
