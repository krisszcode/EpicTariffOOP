using System;
using System.Collections.Generic;
using System.IO;
using EpicTariff.Interface;

namespace EpicTariff.Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Client> clients = new List<Client>();
            Menus menu = new Menus();
            XmlHandler xml = new XmlHandler();
            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "/Tariffplan/clients.xml"))
            {
                xml.LoadfromXML(clients);
            }
            bool loop = true;
            while (loop)
            {
                menu.Menu(clients);
            }
        }
    }
}
