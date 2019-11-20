using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml;
using Zadanie1;
using System.IO;

namespace Zadanie2
{
    public class SerializationJSON
    {
        private void SerializeJSONWykaz(IEnumerable<Wykaz> wykaz, string path)
        {
            string json = JsonConvert.SerializeObject(wykaz, Newtonsoft.Json.Formatting.Indented,
            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            File.WriteAllText(@path, json);
        }

        private void SerializeJSONKatalog(IEnumerable<Katalog> katalog, string path)
        {
            string json = JsonConvert.SerializeObject(katalog, Newtonsoft.Json.Formatting.Indented,
            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            File.WriteAllText(@path, json);
        }


        private void SerializeJSONOpisStanu(IEnumerable<OpisStanu> opisStanu, string path)
        {
            string json = JsonConvert.SerializeObject(opisStanu, Newtonsoft.Json.Formatting.Indented,
            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            File.WriteAllText(@path, json);
        }


        private void SerializeJSONZdarzenie(IEnumerable<Zdarzenie> zdarzenie, string path)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string strJson = JsonConvert.SerializeObject(zdarzenie, settings);
            File.WriteAllText(@path, strJson);
        }


        public void SerializeJSON(DataRepository data)
        {
            SerializeJSONWykaz(data.GetAllWykaz(), "Wykaz.json");
            SerializeJSONKatalog(data.GetAllKatalog(), "Katalog.json");
            SerializeJSONOpisStanu(data.GetAllOpisStanu(), "OpisStanu.json");
            SerializeJSONZdarzenie(data.GetAllZdarzenie(), "Zdarzenie.json");
        }
    }
}
