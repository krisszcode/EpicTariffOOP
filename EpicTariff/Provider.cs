using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff 
{
    public class Provider
    {
        InputOutput inpuoup = new InputOutput();

        public TariffPlan ChooseTariff(string nachos)
        {
            InputOutput inpuoup = new InputOutput();
            TariffPlan s = new MobilS();
            TariffPlan m = new MobilM();
            TariffPlan l = new MobilL();
            TariffPlan xl = new MobilXL();

            switch (nachos)
            {
                case "MobilS":
                    return s;
                case "MobilM":
                    return m;
                case "MobilL":
                    return l;
                case "MobilXL":
                    return xl;
                default:
                    break;
            }
            return null;
        }
        public List<Client> CreateClient(List<Client> clients)
        {
            Client cl = new Client();
            cl.ID = 1;
            inpuoup.Writer("Give me a name: ");
            cl.Name = inpuoup.Reader();
            inpuoup.Writer("Give me an income: ");
            cl.Income = double.Parse(inpuoup.Reader());
            inpuoup.Writer("Give me a subscription type(true/false): ");
            cl.IsSubscribed = bool.Parse(inpuoup.Reader());
            if (cl.IsSubscribed == true)
            {
                inpuoup.Writer("Choose a tariffplan(MobilS, MobilM, MobilL , MobilXL) ");
                string chos = inpuoup.Reader();
                TariffPlan tp = ChooseTariff(chos);
                cl.Package = tp;
            }
            clients.Add(cl);
            return clients;
        }
    }
}
