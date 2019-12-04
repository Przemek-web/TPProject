using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zadanie2
{
    public class DeserializationJSON
    {  
        public classA DeserializeJsonA(string path)
        {
            string json = File.ReadAllText(@path);

            classA a = JsonConvert.DeserializeObject<classA>(json, new JsonSerializerSettings 
            { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            return a;
        }

        public classB DeserializeJsonB(string path)
        {
            string json = File.ReadAllText(@path);

            classB b = JsonConvert.DeserializeObject<classB>(json, new JsonSerializerSettings
            { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            return b;
        }

        public classC DeserializeJsonC(string path)
        {
            string json = File.ReadAllText(@path);

            classC c = JsonConvert.DeserializeObject<classC>(json, new JsonSerializerSettings
            { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            return c;
        }
    }
}
