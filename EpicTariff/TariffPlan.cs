using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff
{
    public abstract class TariffPlan
    {
        public TariffPlan()
        {

        }

        public TariffPlan(string name, int tariff, int basicInternet, int basicMinutes, int basicForeignMinutes)
        {
            Name = name;
            Tariff = tariff;
            BasicInternet = basicInternet;
            BasicMinutes = basicMinutes;
            BasicForeignMinutes = basicForeignMinutes;
        }
        public string Name { get; set; }
        public int Tariff { get; set; }
        public double BasicInternet { get; set; }
        public int BasicMinutes { get; set; }
        public int BasicForeignMinutes { get; set; }

       
        public abstract int MinuteCharge();
        public abstract int ForeignMinuteCharge();
        public abstract double MobileInternetCharge();

        public override string ToString()
        {
            return $"{Name}\nTariff: {Tariff}\nBasicInternet: {BasicInternet}\nBasicMinutes: {BasicMinutes}\nBasicForeignMinutes: {BasicForeignMinutes}\n";
        }
    }
}