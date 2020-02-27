using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace EpicTariff
{
    public class XmlHandler
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        public void SaveToXml(List<Client> clients)
        {
            
            XElement root = new XElement("Clients");
            foreach (var client in clients)
            {
                if (client.IsSubscribed == true)
                {
                    root.Add(
                    new XElement("Client",
                        new XElement("ID", client.ID),
                        new XElement("Name", client.Name),
                        new XElement("IsSubscribed", client.IsSubscribed),
                        new XElement("Income", client.Income),
                        new XElement("Plan",
                            new XElement("PlanName", client.Package.Name),
                            new XElement("Tariff", client.Package.Tariff),
                            new XElement("BasicInternet", client.Package.BasicForeignMinutes),
                            new XElement("BasicMinutes", client.Package.BasicMinutes),
                            new XElement("ForeignMinutes", client.Package.BasicForeignMinutes)
                        )));
                }
                else
                {
                    root.Add(
                    new XElement("Client",
                        new XElement("ID", client.ID),
                        new XElement("Name", client.Name),
                        new XElement("IsSubscribed", client.IsSubscribed),
                        new XElement("Income", client.Income),
                        new XElement("Plan",client.Package
                        )));
                }
            }
            Directory.CreateDirectory(path + "/Tariffplan");
            root.Save(path + "/Tariffplan/clients.xml");
        }
        public void LoadfromXML(List<Client> clients)
        {
            XElement element = XElement.Load(path + "/Tariffplan/clients.xml"); // creating xelement object from client.xml

            var clientNodes = element.Elements("Client"); // initializing client nodes as elements of root node 'client'

            foreach (var node in clientNodes) // iterating through client nodes
            {
                Client client = new Client(); // instantiating client object and assigning value to its parameters
                client.ID = Int32.Parse(node.Element("ID").Value);
                client.Name = node.Element("Name").Value;
                client.IsSubscribed = bool.Parse(node.Element("IsSubscribed").Value);
                client.Income = Int32.Parse(node.Element("Income").Value);

                if (client.IsSubscribed)
                {
                    var mobilnodes = element.Elements("Plan");
                    if (node.Element("Plan").Element("PlanName").Value == "MobilS")
                    {
                        TariffPlan s = new MobilS();
                        foreach (var mobilnode in mobilnodes)
                        {
                            s.Name = mobilnode.Element("PlanName").Value;
                            s.Tariff = Int32.Parse(mobilnode.Element("Tariff").Value);
                            s.BasicInternet = Int32.Parse(mobilnode.Element("BasicInternet").Value);
                            s.BasicMinutes = Int32.Parse(mobilnode.Element("BasicMinutes").Value);
                            s.BasicForeignMinutes = Int32.Parse(mobilnode.Element("ForeignMinutes").Value);
                        }
                        client.Package = s;
                    }
                    else if (node.Element("Plan").Element("PlanName").Value == "MobilM")
                    {
                        TariffPlan m = new MobilM();
                        foreach (var mobilnode in mobilnodes)
                        {
                            m.Name = mobilnode.Element("PlanName").Value;
                            m.Tariff = Int32.Parse(mobilnode.Element("Tariff").Value);
                            m.BasicInternet = Int32.Parse(mobilnode.Element("BasicInternet").Value);
                            m.BasicMinutes = Int32.Parse(mobilnode.Element("BasicMinutes").Value);
                            m.BasicForeignMinutes = Int32.Parse(mobilnode.Element("ForeignMinutes").Value);
                        }
                        client.Package = m;
                    }
                    else if (node.Element("Plan").Element("PlanName").Value == "MobilL")
                    {
                        TariffPlan l = new MobilL();
                        foreach (var mobilnode in mobilnodes)
                        {
                            l.Name = mobilnode.Element("PlanName").Value;
                            l.Tariff = Int32.Parse(mobilnode.Element("Tariff").Value);
                            l.BasicInternet = Int32.Parse(mobilnode.Element("BasicInternet").Value);
                            l.BasicMinutes = Int32.Parse(mobilnode.Element("BasicMinutes").Value);
                            l.BasicForeignMinutes = Int32.Parse(mobilnode.Element("ForeignMinutes").Value);
                        }
                        client.Package = l;
                    }
                    else if (node.Element("Plan").Element("PlanName").Value == "MobilXL")
                    {
                        TariffPlan xl = new MobilL();
                        foreach (var mobilnode in mobilnodes)
                        {
                            xl.Name = mobilnode.Element("PlanName").Value;
                            xl.Tariff = Int32.Parse(mobilnode.Element("Tariff").Value);
                            xl.BasicInternet = Int32.Parse(mobilnode.Element("BasicInternet").Value);
                            xl.BasicMinutes = Int32.Parse(mobilnode.Element("BasicMinutes").Value);
                            xl.BasicForeignMinutes = Int32.Parse(mobilnode.Element("ForeignMinutes").Value);
                        }
                        client.Package = xl;
                    }
                    
                }
                clients.Add(client);
            }
        }
    }
}
