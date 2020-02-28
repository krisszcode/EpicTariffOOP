using System;
using System.Collections.Generic;
using System.Text;

namespace EpicTariff
{
    public class TariffProvider
    {
        InputOutput inpuoup = new InputOutput();

        public void ListTariff()
        {
            MobilS s = new MobilS();
            MobilM m = new MobilM();
            MobilL l = new MobilL();
            MobilXL xl = new MobilXL();

            inpuoup.Writer(s.ToString());
            inpuoup.Writer(m.ToString());
            inpuoup.Writer(l.ToString());
            inpuoup.Writer(xl.ToString());
        }
        public List<Client> ClientNotExistAndNotSubscribed(List<Client> clients, int id)
        {
            List<int> ids = new List<int>();
            foreach (var client in clients)
            {
                ids.Add(client.ID);
                if (client.ID == id && client.IsSubscribed == true)
                {
                    throw new Exception();
                }
            }
            if (!ids.Contains(id))
            {
                throw new Exception();
            }
            
            return clients;
        }

        public List<Client> TariffToClient(List<Client> clients)
        {
            try
            {
                inpuoup.Writer("Give me a client's ID: ");
                int id = int.Parse(inpuoup.Reader());
                ClientNotExistAndNotSubscribed(clients, id);
                AddTariff(clients, id, "Which tariff goes to the client? ");
            }
            
            catch (Exception)
            {
                inpuoup.Writer("ID not exist or subscribed");
            }
            return clients;
        }

        public List<Client> ClientNotExistAndSubscribed(List<Client> clients, int id)
        {
            List<int> ids = new List<int>();
            foreach (var client in clients)
            {
                ids.Add(client.ID);
                if (client.ID == id && client.IsSubscribed == false)
                {
                    throw new Exception();
                }
            }
            if (!ids.Contains(id))
            {
                throw new Exception();
            }
            return clients;
        }

        //Módosítás csak akkor lehet, ha már létezik díjcsomagja az ügyfélnek, akinek van ID-ja
        public List<Client> ModifyTariff(List<Client> clients)
        {
            try
            {
                inpuoup.Writer("Give me a client's ID: ");
                int id = int.Parse(inpuoup.Reader());
                ClientNotExistAndSubscribed(clients, id);
                AddTariff(clients, id, "What is the new Tariff? (MobilM/S/L/XL) ");
            }
            catch (Exception)
            {
                inpuoup.Writer("Bad ID or not subscribed or wrong choose");
            }
            return clients;
        }

        public List<Client> AddTariff(List<Client> clients, int id, string desc)
        {
            foreach (var client in clients)
            {
                if (id == client.ID)
                {
                    inpuoup.Writer(desc);
                    string nachos = inpuoup.Reader();
                    TariffPlan s = new MobilS();
                    TariffPlan m = new MobilM();
                    TariffPlan l = new MobilL();
                    TariffPlan xl = new MobilXL();
                    switch (nachos)
                    {
                        case "MobilS":
                            client.Package = s;
                            if (client.IsSubscribed == false)
                            {
                                client.IsSubscribed = true;
                            }                            
                            break;
                        case "MobilM":
                            client.Package = m;
                            if (client.IsSubscribed == false)
                            {
                                client.IsSubscribed = true;
                            }
                            break;
                        case "MobilL":
                            client.Package = l;
                            if (client.IsSubscribed == false)
                            {
                                client.IsSubscribed = true;
                            }
                            break;
                        case "MobilXL":
                            client.Package = xl;
                            if (client.IsSubscribed == false)
                            {
                                client.IsSubscribed = true;
                            }
                            break;
                        default:
                            throw new Exception();
                    }
                }
            }
            return clients;
        }
        public List<Client> RemoveTariff(List<Client> clients)
        {
            try
            {
                inpuoup.Writer("Give me a client's ID: ");
                int id = int.Parse(inpuoup.Reader());
                ClientNotExistAndSubscribed(clients, id);
                foreach (var client in clients)
                {
                    if(client.ID == id)
                    {
                        client.IsSubscribed = false;
                        client.Package = null;
                    }
                }
            }
            catch (Exception)
            {
                inpuoup.Writer("ID not exist or not subscribed");
            }
            return clients;
        }
        public List<Client> RequestMinutes(List<Client> clients)
        {
            try
            {
                inpuoup.Writer("Give me a client's ID: ");
                int id = int.Parse(inpuoup.Reader());
                ClientNotExistAndSubscribed(clients, id);
                inpuoup.Writer("Give me the minutes:");
                int plusMinutes = int.Parse(inpuoup.Reader());
                foreach (var client in clients)
                {
                    if(client.ID == id)
                    {
                        client.Package.Minutes += plusMinutes;
                    }
                }
            }
            catch (Exception)
            {
                inpuoup.Writer("ID not exist or not subscribed");
            }
            return clients;
        }

        public List<Client> RequestInternet(List<Client> clients)
        {
            try
            {
                inpuoup.Writer("Give me a client's ID: ");
                int id = int.Parse(inpuoup.Reader());
                ClientNotExistAndSubscribed(clients, id);
                inpuoup.Writer("Give me the minutes:");
                int plusInternet = int.Parse(inpuoup.Reader());
                foreach (var client in clients)
                {
                    if (client.ID == id)
                    {
                        client.Package.Internet += plusInternet;
                    }
                }
            }
            catch (Exception)
            {
                inpuoup.Writer("ID not exist or not subscribed");
            }
            return clients;
        }

        public List<Client> RequestForeignMinutes(List<Client> clients)
        {
            try
            {
                inpuoup.Writer("Give me a client's ID: ");
                int id = int.Parse(inpuoup.Reader());
                ClientNotExistAndSubscribed(clients, id);
                inpuoup.Writer("Give me the minutes:");
                int plusForeignMinutes = int.Parse(inpuoup.Reader());
                foreach (var client in clients)
                {
                    if (client.ID == id)
                    {
                        client.Package.ForeignMinutes += plusForeignMinutes;
                    }
                }
            }
            catch (Exception)
            {
                inpuoup.Writer("ID not exist or not subscribed");
            }
            return clients;
        }

    }
}
