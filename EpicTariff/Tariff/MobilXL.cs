using System;
using System.Collections.Generic;
using System.Text;
using EpicTariff.Sexception;

namespace EpicTariff.Data
{
    public class MobilXL : TariffPlan
    {
        public MobilXL(string name = "MobilXL", int tariff = 60, int internet = 100, int minutes = 300, int foreignMinutes = 200)
           : base(name, tariff, internet, minutes, foreignMinutes)
        {

        }

        public override int ForeignMinuteCharge(Client client, int requestedForeignMinutes)
        {
            if (client.Income < requestedForeignMinutes * 0.15)
            {
                throw new NotEnoughMoney();
            }
            client.Income -= requestedForeignMinutes * 0.15;
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
            if (client.Income < requestedMinutes * 0.10)
            {
                throw new NotEnoughMoney();
            }
            client.Income -= requestedMinutes * 0.10;
            return client.Package.Minutes += requestedMinutes;
        }

        public override int MobileInternetCharge(Client client, int requestedInternet)
        {
            if (client.Income < requestedInternet * 0.17)
            {
                throw new NotEnoughMoney();
            }
            client.Income -= requestedInternet * 0.17;
            return client.Package.Internet += requestedInternet;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
