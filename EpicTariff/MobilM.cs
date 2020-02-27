using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff
{
    class MobilM : TariffPlan
    {
        public MobilM(string name = "MobilM", int tariff = 20, int basicInternet = 3, int basicMinutes = 100, int basicForeignMinutes = 50)
            : base(name, tariff, basicInternet, basicMinutes, basicForeignMinutes)
        {

        }

        public override int ForeignMinuteCharge()
        {
            throw new NotImplementedException();
        }

        public override int MinuteCharge()
        {
            throw new NotImplementedException();
        }

        public override double MobileInternetCharge()
        {
            throw new NotImplementedException();
        }
    }
}
