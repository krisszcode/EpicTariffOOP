using System;
using System.Collections.Generic;
using System.Threading;

namespace EpicTariff
{
    public class Program
    {
        public static List<Client> clients = new List<Client>();
        static void Main(string[] args)
        {
            Program program = new Program();
            XmlHandler xml = new XmlHandler();
            xml.LoadfromXML(clients);
            bool loop = true;
            while (loop)
            {
                Menu();
            }
        }
        static bool ClientSubMenu()
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
                        clientprov.CreateClient(clients);
                        Console.Clear();
                        goto Here;
                    case "2":
                        clientprov.ListClients(clients);
                        Console.ReadKey();
                        Console.Clear();
                        goto Here;
                    case "3":
                        clientprov.UpdateClient(clients);
                        Console.ReadKey();
                        Console.Clear();
                        goto Here;
                    case "4":
                        clientprov.RemoveAClient(clients);
                        Console.ReadKey();
                        Console.Clear();
                        goto Here;
                    case "0":
                        Console.Clear();
                        return false;
                    default:
                        Console.WriteLine("Wrong option...");
                        Thread.Sleep(500);
                        Console.Clear();
                        goto Here;
                }
               
            }
        }
        static bool TariffSubMenu()
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
                        tarprov.ListTariff();
                        Console.ReadKey();
                        Console.Clear();
                        goto Here;
                    case "2":
                        clientprov.ListClients(clients);
                        tarprov.TariffToClient(clients);
                        Console.ReadKey();
                        Console.Clear();
                        goto Here;
                    case "3":
                        clientprov.ListClients(clients);
                        tarprov.ModifyTariff(clients);
                        Console.ReadKey();
                        Console.Clear();
                        goto Here;
                    case "4":
                        clientprov.ListClients(clients);
                        tarprov.RemoveTariff(clients);
                        Console.ReadKey();
                        Console.Clear();
                        goto Here;
                    case "0":
                        Console.Clear();
                        return false;
                    default:
                        Console.WriteLine("Wrong option...");
                        Thread.Sleep(500);
                        Console.Clear();
                        goto Here;
                }

            }
        }
        static bool Menu()
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
                        ClientSubMenu();
                        return true;
                    case "2":
                        TariffSubMenu();
                        return true;
                    case "0":
                        xml.SaveToXml(clients);
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Wrong option...");
                        Thread.Sleep(500);
                        return true;
                }
            }
        }
    }
}
