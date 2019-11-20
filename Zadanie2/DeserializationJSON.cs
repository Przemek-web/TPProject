using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie2
{
    public class DeserializationJSON
    {  
        private void DeserializeJSONWykaz(DataContext datacontext, string path)
        {
            string json = File.ReadAllText(@path);

            datacontext.czytelnicy = JsonConvert.DeserializeObject<List<Wykaz>>(json, new JsonSerializerSettings 
            { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

        }

        private void DeserializeJSONKatalog(DataContext datacontext, string path)
        {
            string json = File.ReadAllText(@path);
            IEnumerable<Katalog> import = JsonConvert.DeserializeObject<IEnumerable<Katalog>>(json, new JsonSerializerSettings 
            { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            int i = 0;
            foreach (Katalog tmp in import)
            {
                datacontext.katalogi.Add(i, tmp);
                i++;
            }

        } 

        private void DeserializeJSONOpisStanu(DataContext datacontext, string path)
        {
            string json = File.ReadAllText(@path);
            datacontext.egzemplarze = JsonConvert.DeserializeObject<List<OpisStanu>>(json, new JsonSerializerSettings
            { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

        }

        private void DeserializeJSONZdarzenie(DataContext datacontext, string path)
        {
            string json = File.ReadAllText(@path);

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            datacontext.zdarzenia = JsonConvert.DeserializeObject<ObservableCollection<Zdarzenie>>(json, settings);

        }

        public void DeserializeJSON(DataContext datacontext)
        {
            DeserializeJSONWykaz(datacontext,"Wykaz.json");
            DeserializeJSONKatalog(datacontext,"Katalog.json");
            DeserializeJSONOpisStanu(datacontext,"OpisStanu.json");
            DeserializeJSONZdarzenie(datacontext,"Zdarzenie.json");
        }
    }
}
