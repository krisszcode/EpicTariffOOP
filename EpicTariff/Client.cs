using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff
{
    [Serializable()]

    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsSubscribed { get; set; }
        public double Income { get; set; }
        public TariffPlan Package { get; set; }
    }
}
