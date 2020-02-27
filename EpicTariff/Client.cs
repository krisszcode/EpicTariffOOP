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

        public override string ToString()
        {
            if(IsSubscribed == true)
            {
                return $"Client Info:\nID: {ID}\nName: {Name}\nIsSubscribed: {IsSubscribed}\nIncome: {Income}\nTariffPlan: {Package}";
            }
            else
            {
                return $"Client Info:\nID: {ID}\nName: {Name}\nIsSubscribed: {IsSubscribed}\nIncome: {Income}\n";
            }
        }
    }

    
    
}
