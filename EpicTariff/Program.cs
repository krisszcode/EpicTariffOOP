using System;
using System.Collections.Generic;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace EpicTariff
{
    public class Program
    {
        public static List<Client> clients = new List<Client>();
        static void Main(string[] args)
        {
            Program program = new Program();
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
            Provider prov = new Provider();
            inpuoup.Writer("1. Kliens létrehozása");
            inpuoup.Writer("2. Kliensek listázása");
            inpuoup.Writer("3. Kliensek módosítása");
            string chos = inpuoup.Reader();
            while (true)
            {
                switch (chos)
                {
                    case "1":
                        prov.CreateClient(clients);
                        Console.Clear();
                        goto Here;
                    case "2":
                        Console.Clear();
                        goto Here;
                    case "3":
                        Console.Clear();
                        goto Here;
                    case "4":
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
        static void SubMenu2()
        {
            InputOutput inpuoup = new InputOutput();
            inpuoup.Writer("1. menüpont");
            inpuoup.Writer("2. menüpont");
        }
        static object Menu()
        {
            
            Provider prov = new Provider();
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

                        return true;
                    case "3":
                        return true;
                    case "4":
                        return true;
                    case "0":
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
