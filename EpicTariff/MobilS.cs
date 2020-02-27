using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff
{
    class MobilS : TariffPlan
    {
        public MobilS(string name = "MobilS", int tariff = 10, int basicInternet = 1, int basicMinutes = 60, int basicForeignMinutes = 30)
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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
