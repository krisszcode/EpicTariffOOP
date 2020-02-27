using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff
{
    class MobilXL : TariffPlan
    {
        public MobilXL(string name = "MobilXL", int tariff = 60, int basicInternet = 100, int basicMinutes = 300, int basicForeignMinutes = 200)
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
