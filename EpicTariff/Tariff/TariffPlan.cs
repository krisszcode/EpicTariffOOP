using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff.Data
{
    public abstract class TariffPlan
    {
        public TariffPlan()
        {

        }

        public TariffPlan(string name, int tariff, int internet, int minutes, int foreignMinutes)
        {
            Name = name;
            Tariff = tariff;
            Internet = internet;
            Minutes = minutes;
            ForeignMinutes = foreignMinutes;
        }

        public string Name { get; set; }
        public int Tariff { get; set; }
        public int Internet { get; set; }
        public int Minutes { get; set; }
        public int ForeignMinutes { get; set; }

        public abstract int MinuteCharge(Client client, int requestedMinutes);
        public abstract int ForeignMinuteCharge(Client client, int requestedForeignMinutes);
        public abstract int MobileInternetCharge(Client client, int requestedInternet);
        public abstract Client LoseMoney(Client client);
        public abstract void GetMoney(Client client);

        public override string ToString()
        {
            return $"{Name}\nTariff: {Tariff}\nInternet: {Internet}\nMinutes: {Minutes}\nForeignMinutes: {ForeignMinutes}\n";
        }
    }
}