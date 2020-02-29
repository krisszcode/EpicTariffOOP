using System;
using System.Collections.Generic;
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
            xml.LoadfromXML(clients);
            bool loop = true;
            while (loop)
            {
                menu.Menu(clients);
            }
        }
    }
}
