using System;
using System.Collections.Generic;
using System.Text;
using EpicTariff.Sexception;

namespace EpicTariff.Data
{
    public class MobilL : TariffPlan
    {
        public MobilL(string name = "MobilL", int tariff = 40, int internet = 10, int minutes = 200, int foreignMinutes = 100)
           : base(name, tariff, internet, minutes, foreignMinutes)
        {

        }
       

        public override int ForeignMinuteCharge(Client client, int requestedForeignMinutes)
        {

            if (client.Income < requestedForeignMinutes * 0.18)
            {
                throw new NotEnoughMoney();
            }
            client.Income -= requestedForeignMinutes * 0.18;
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
            if (client.Income < requestedMinutes * 0.14)
            {
                throw new NotEnoughMoney();
            }
            client.Income -= requestedMinutes * 0.14;
            return client.Package.Minutes += requestedMinutes;
        }

        public override int MobileInternetCharge(Client client, int requestedInternet)
        {
            if (client.Income < requestedInternet * 0.24)
            {
                throw new NotEnoughMoney();
            }
            client.Income -= requestedInternet * 0.24;
            return client.Package.Internet += requestedInternet;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
