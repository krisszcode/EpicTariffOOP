using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace EpicTariff.Data
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
                            new XElement("Internet", client.Package.ForeignMinutes),
                            new XElement("Minutes", client.Package.Minutes),
                            new XElement("ForeignMinutes", client.Package.ForeignMinutes)
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
                            s.Internet = Int32.Parse(mobilnode.Element("Internet").Value);
                            s.Minutes = Int32.Parse(mobilnode.Element("Minutes").Value);
                            s.ForeignMinutes = Int32.Parse(mobilnode.Element("ForeignMinutes").Value);
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
                            m.Internet = Int32.Parse(mobilnode.Element("Internet").Value);
                            m.Minutes = Int32.Parse(mobilnode.Element("Minutes").Value);
                            m.ForeignMinutes = Int32.Parse(mobilnode.Element("ForeignMinutes").Value);
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
                            l.Internet = Int32.Parse(mobilnode.Element("Internet").Value);
                            l.Minutes = Int32.Parse(mobilnode.Element("Minutes").Value);
                            l.ForeignMinutes = Int32.Parse(mobilnode.Element("ForeignMinutes").Value);
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
                            xl.Internet = Int32.Parse(mobilnode.Element("Internet").Value);
                            xl.Minutes = Int32.Parse(mobilnode.Element("Minutes").Value);
                            xl.ForeignMinutes = Int32.Parse(mobilnode.Element("ForeignMinutes").Value);
                        }
                        client.Package = xl;
                    }
                    
                }
                clients.Add(client);
            }
        }
    }
}
