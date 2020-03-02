using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EpicTariff.Data
{
    class JsonHandler
    {
        static string json = File.ReadAllText("clients.json");
        Client clientList = JsonConvert.DeserializeObject<Client>(json);

    }
}
