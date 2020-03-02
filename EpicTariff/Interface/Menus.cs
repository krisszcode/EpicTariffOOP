using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using EpicTariff.Data;

namespace EpicTariff.Interface
{
    public class Menus
    {
        public List<Client> clients = new List<Client>();
        public bool ClientSubMenu(List<Client> clients)
        {
        Here:
            InputOutput inpuoup = new InputOutput();
            ClientProvider clientprov = new ClientProvider();
            inpuoup.Writer("1. Kliens létrehozása");
            inpuoup.Writer("2. Kliensek listázása");
            inpuoup.Writer("3. Kliensek módosítása");
            inpuoup.Writer("4. Kliensek törlése");
            string chos = inpuoup.Reader();
            while (true)
            {
                switch (chos)
                {
                    case "1":
                        Console.Clear();
                        clientprov.CreateClient(clients);
                        Thread.Sleep(2020);
                        Console.Clear();
                        goto Here;
                    case "2":
                        Console.Clear();
                        clientprov.ListClients(clients);
                        inpuoup.Writer("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        goto Here;
                    case "3":
                        Console.Clear();
                        clientprov.ListClients(clients);
                        clientprov.UpdateClient(clients);
                        Thread.Sleep(2020);
                        Console.Clear();
                        goto Here;
                    case "4":
                        Console.Clear();
                        clientprov.ListClients(clients);
                        clientprov.RemoveAClient(clients);
                        Thread.Sleep(2020);
                        Console.Clear();
                        goto Here;
                    case "0":
                        Console.Clear();
                        return false;
                    default:
                        Console.WriteLine("Wrong option...");
                        Thread.Sleep(2020);
                        Console.Clear();
                        goto Here;
                }

            }
        }

        public bool TariffSubMenu(List<Client> clients)
        {
        Here:
            InputOutput inpuoup = new InputOutput();
            ClientProvider clientprov = new ClientProvider();
            TariffProvider tarprov = new TariffProvider();
            inpuoup.Writer("1. Tarifák kilistázása");
            inpuoup.Writer("2. Tarfia hozzárendelése ügyfélhez");
            inpuoup.Writer("3. Tarifa módosítása");
            inpuoup.Writer("4. Tarfia megvonása ügyféltől");
            inpuoup.Writer("5. Mobilinternet kérés");
            inpuoup.Writer("6. Perc kérés");
            inpuoup.Writer("7. Külföldi perc kérés");
            string chos = inpuoup.Reader();
            while (true)
            {
                switch (chos)
                {
                    case "1":
                        Console.Clear();
                        tarprov.ListTariff();
                        inpuoup.Writer("Press any key to continue!");
                        Console.ReadKey();
                        Console.Clear();
                        goto Here;
                    case "2":
                        Console.Clear();
                        clientprov.ListClients(clients);
                        tarprov.TariffToClient(clients);
                        Thread.Sleep(2020);
                        Console.Clear();
                        goto Here;
                    case "3":
                        Console.Clear();
                        clientprov.ListClients(clients);
                        tarprov.ModifyTariff(clients);
                        Thread.Sleep(2020);
                        Console.Clear();
                        goto Here;
                    case "4":
                        Console.Clear();
                        clientprov.ListClients(clients);
                        tarprov.RemoveTariff(clients);
                        Thread.Sleep(2020);
                        Console.Clear();
                        goto Here;
                    case "5":
                        Console.Clear();
                        clientprov.ListClients(clients);
                        tarprov.RequestInternet(clients);
                        Thread.Sleep(2020);
                        Console.Clear();
                        goto Here;
                    case "6":
                        Console.Clear();
                        clientprov.ListClients(clients);
                        tarprov.RequestMinutes(clients);
                        Thread.Sleep(2020);
                        Console.Clear();
                        goto Here;
                    case "7":
                        Console.Clear();
                        clientprov.ListClients(clients);
                        tarprov.RequestForeignMinutes(clients);
                        Thread.Sleep(2020);
                        Console.Clear();
                        goto Here;
                    case "0":
                        Console.Clear();
                        return false;
                    default:
                        Console.WriteLine("Wrong option...");
                        Thread.Sleep(2020);
                        Console.Clear();
                        goto Here;
                }
            }
        }

        public bool Menu(List<Client> clients)
        {
            XmlHandler xml = new XmlHandler();
            InputOutput inpuoup = new InputOutput();
            inpuoup.Writer("1. Kliensek kezelése");
            inpuoup.Writer("2. Díjcsomagok kezelése");

            string chos = inpuoup.Reader();
            while (true)
            {
                switch (chos)
                {
                    case "1":
                        Console.Clear();
                        ClientSubMenu(clients);
                        return true;
                    case "2":
                        Console.Clear();
                        TariffSubMenu(clients);
                        return true;
                    case "0":
                        xml.SaveToXml(clients);
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Wrong option...");
                        Thread.Sleep(2020);
                        Console.Clear();
                        return true;
                }
            }
        }
    }
}
