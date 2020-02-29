using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using EpicTariff.Interface;
using EpicTariff.Sexception;

namespace EpicTariff.Data
{
    public class ClientProvider
    {
        InputOutput inpuoup = new InputOutput();

        public int GenerateID(List<Client> clients)
        {
            Random rand = new Random();
            int id = rand.Next(1, 10000);
            List<int> ids = new List<int>();
            foreach (var client in clients)
            {
                ids.Add(id);
            }
            while (true)
            {
                if (ids.Contains(id))
                {
                    id = rand.Next(1, 10000);
                }
                else
                {
                    break;
                }
            }
            return id;
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
                    throw new BadTariff();
            }
        }
        public List<Client> CreateClient(List<Client> clients)
        {
            try
            {
                Client cl = new Client();
                cl.ID = GenerateID(clients);
                inpuoup.Writer("Give me a name: ");
                cl.Name = inpuoup.Reader();
                inpuoup.Writer("Give me an income: ");

                cl.Income = double.Parse(inpuoup.Reader());
                if (cl.Income.GetType() != typeof(double))
                {
                    throw new Exception();
                }
                inpuoup.Writer("Give me a subscription type(true/false): ");

                cl.IsSubscribed = bool.Parse(inpuoup.Reader());
                if (cl.IsSubscribed.GetType() != typeof(bool))
                {
                    throw new Exception();
                }

                if (cl.IsSubscribed == true)
                {
                    inpuoup.Writer("Choose a tariffplan (MobilS, MobilM, MobilL , MobilXL): ");
                    string chos = inpuoup.Reader();
                    TariffPlan tp = ChooseTariff(chos);
                    cl.Package = tp;
                    cl.Package.LoseMoney(cl);
                }
                inpuoup.Writer("Client added successfully!");
                clients.Add(cl);
            }
            catch (Exception)
            {
                inpuoup.Writer("Invalid income/type of subscription");
            }
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
            try
            {
                Console.WriteLine("Give me what you want to rewrite(Name, Income): ");
                string attribute = inpuoup.Reader().ToUpper();
                if (attribute != "NAME" && attribute != "INCOME")
                {
                    throw new Exception();
                }
                List<int> ids = new List<int>();
                foreach (var client in clients)
                {
                    ids.Add(client.ID);
                }
                inpuoup.Writer("Which ID of a client you want to rewrite?");
                int ID = int.Parse(inpuoup.Reader());
                foreach (var client in clients)
                {
                    if (!ids.Contains(ID))
                    {
                        throw new Exception();
                    }
                }
            
                switch (attribute)
                {
                    case "NAME":
                        inpuoup.Writer("What will be the Name?");
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
                        inpuoup.Writer("What will be the Income?");
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
                        throw new Exception();
                }
                inpuoup.Writer("Updated successfully!");
            }
            catch (Exception)
            {
                inpuoup.Writer("Not valid input");
                Thread.Sleep(2020);
            }
            
            return clients;
        }
    
        public List<Client> RemoveAClient(List<Client> clients)
        {
            try
            {
                List<int> ids = new List<int>();
                foreach (var client in clients)
                {
                    ids.Add(client.ID);
                }
                inpuoup.Writer("Give me an id to remove:");
                int id = int.Parse(inpuoup.Reader());
                if(!ids.Contains(id))
                {
                    throw new Exception();
                }
                for (int i = 0; i < clients.Count; i++)
                {
                    if (clients[i].ID == id)
                    {
                        clients.RemoveAt(i);
                    }
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
