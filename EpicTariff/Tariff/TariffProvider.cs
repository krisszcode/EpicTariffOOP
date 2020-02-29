using System;
using System.Collections.Generic;
using System.Text;
using EpicTariff.Interface;
using EpicTariff.Sexception;

namespace EpicTariff.Data
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
                AddTariff(clients, id, "Choose a tariffplan (MobilS, MobilM, MobilL , MobilXL):  ");
                
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
                AddTariff(clients, id, "What is the new Tariff? (MobilM/MobilS/MobilL/MobilXL) ");
            }
            catch(NotEnoughMoney)
            {
                inpuoup.Writer("You dont have enough money to change your tariff to this");

            }
            catch (Exception)
            {
                inpuoup.Writer("Bad ID or not subscribed or wrong choose");
            }
            return clients;
        }

        public bool CheckMoney(TariffPlan tariff, Client client)
        {
            //client.Income + client.Package.GetMoney(client).Income >= m.LoseMoney(client).Income
            if (client.Income + client.Package.Tariff >= tariff.Tariff)
            {
                return true;
            }
            else
                return false;
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
                            if (client.IsSubscribed == false)
                            {
                                client.IsSubscribed = true;
                                client.Package = s;
                                client.Package.LoseMoney(client);
                            }
                            else
                            {
                                if (CheckMoney(s, client))
                                {
                                    client.Package.GetMoney(client);
                                    s.LoseMoney(client);
                                    client.Package = s;
                                }
                                else
                                {
                                    throw new NotEnoughMoney();
                                }
                            }
                            break;
                        case "MobilM":
                            if (client.IsSubscribed == false)
                            {
                                client.IsSubscribed = true;
                                client.Package = m;
                                client.Package.LoseMoney(client);
                            }
                            else
                            {
                                if (CheckMoney(m, client))
                                {
                                    client.Package.GetMoney(client);
                                    m.LoseMoney(client);
                                    client.Package = m;
                                }
                                else
                                {
                                    throw new NotEnoughMoney();
                                }
                            }
                            break;
                        case "MobilL":
                            if (client.IsSubscribed == false)
                            {
                                client.IsSubscribed = true;
                                client.Package = l;
                                client.Package.LoseMoney(client);
                            }
                            else
                            {
                                if (CheckMoney(l, client))
                                {
                                    client.Package.GetMoney(client);
                                    l.LoseMoney(client);
                                    client.Package = l;
                                }
                                else
                                {
                                    throw new NotEnoughMoney();
                                }
                            }
                            break;
                        case "MobilXL":
                            if (client.IsSubscribed == false)
                            {
                                client.IsSubscribed = true;
                                client.Package = xl;
                                client.Package.LoseMoney(client);
                            }
                            else
                            {
                                if (CheckMoney(xl, client))
                                {
                                    client.Package.GetMoney(client);
                                    xl.LoseMoney(client);
                                    client.Package = xl;
                                }
                                else
                                {
                                    throw new NotEnoughMoney();
                                }
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
                    if(client.ID == id && client.IsSubscribed == true)
                    {
                        client.IsSubscribed = false;
                        client.Package.GetMoney(client);
                        client.Package = null;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                inpuoup.Writer("Tariff successfully removed");
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
                        client.Package.MinuteCharge(client, plusMinutes);
                    }
                }
            }
            catch (NotEnoughMoney)
            {
                inpuoup.Writer("This client doesn't have enough money");
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
                        client.Package.MobileInternetCharge(client, plusInternet);
                    }
                }
            }
            catch (NotEnoughMoney)
            {
                inpuoup.Writer("This client doesn't have enough money");
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
                        client.Package.ForeignMinuteCharge(client, plusForeignMinutes);
                    }
                }
            }
            catch (NotEnoughMoney)
            {
                inpuoup.Writer("This client doesn't have enough money");
            }
            catch (Exception)
            {
                inpuoup.Writer("ID not exist or not subscribed");
            }
            return clients;
        }

    }
}
