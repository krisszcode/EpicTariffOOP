using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff
{
    class MobilL : TariffPlan
    {
        public MobilL(string name = "MobilL", int tariff = 40, int basicInternet = 10, int basicMinutes = 200, int basicForeignMinutes = 100)
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
