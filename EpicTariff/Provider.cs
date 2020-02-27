using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EpicTariff 
{
    public class Provider
    {
        InputOutput inpuoup = new InputOutput();

        public int GenerateID(List<Client> clients)
        {
            int last = clients.Count;
            last++;
            return last;
        }
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
            cl.ID = GenerateID(clients);
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

        public void ListClients(List<Client> clients)
        {
            foreach (var client in clients)
            {
                inpuoup.Writer(client.ToString());
            }
        }

        public List<Client> UpdateClient(List<Client> clients)
        {
            Error:
            string attribute = "";
            try
            {
                Console.WriteLine("Give me what you want to rewrite(Name, Income): ");
                attribute = inpuoup.Reader().ToUpper();
                if(attribute != "NAME" && attribute != "INCOME")
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                inpuoup.Writer("You must write a Name or an Income");
                goto Error;
            }
                      
            int ID = 0;
            ListClients(clients);
            List<int> ids = new List<int>();
            foreach (var client in clients)
            {
                ids.Add(client.ID);
            }
            try
            {
                inpuoup.Writer("Which ID of a client you want to rewrite?");
                ID = int.Parse(inpuoup.Reader());
                foreach (var client in clients)
                {
                    if (!ids.Contains(ID))
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                inpuoup.Writer("Not valid input");
                goto Error;
            }
            try
            {
                switch (attribute)
                {
                    case "NAME":
                        inpuoup.Writer("what you want to rewrite?");
                        string newName = inpuoup.Reader();
                        foreach (var client in clients)
                        {
                            if (client.ID == ID)
                            {
                                client.Name = newName;
                            }
                        }
                        break;
                    case "INCOME":
                        inpuoup.Writer("what you want to rewrite?");
                        int newIncome = int.Parse(inpuoup.Reader());
                        foreach (var client in clients)
                        {
                            if (client.ID == ID)
                            {
                                client.Income = newIncome;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong option...");
                        Thread.Sleep(500);
                        Console.Clear();
                        break;
                }
            }
            catch (Exception)
            {
                inpuoup.Writer("Not valid input");
            }

            return clients;
        }
        
    }
}
