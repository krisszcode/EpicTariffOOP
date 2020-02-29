using System;
using System.Collections.Generic;
using System.Text;
using EpicTariff.Sexception;

namespace EpicTariff.Data
{
    public class MobilM : TariffPlan
    {
        public MobilM(string name = "MobilM", int tariff = 20, int internet = 3, int minutes = 100, int foreignMinutes = 50)
            : base(name, tariff, internet, minutes, foreignMinutes)
        {

        }

        public override int ForeignMinuteCharge(Client client, int requestedForeignMinutes)
        {
            if (client.Income < requestedForeignMinutes * 0.20)
            {
                throw new NotEnoughMoney();
            }
            client.Income -= requestedForeignMinutes * 0.20;
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
            if (client.Income < requestedMinutes * 0.16)
            {
                throw new NotEnoughMoney();
            }
            client.Income -= requestedMinutes * 0.16;
            return client.Package.Minutes += requestedMinutes;
        }

        public override int MobileInternetCharge(Client client, int requestedInternet)
        {
            if (client.Income < requestedInternet * 0.29)
            {
                throw new NotEnoughMoney();
            }
            client.Income -= requestedInternet * 0.29;
            return client.Package.Internet += requestedInternet;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
