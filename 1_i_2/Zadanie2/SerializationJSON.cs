using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml;
using System.IO;

namespace Zadanie2
{
    public class SerializationJSON
    {  
        public void SerializeJsonA(classA a, string path)
        {
            string json = JsonConvert.SerializeObject(a, Newtonsoft.Json.Formatting.Indented,
            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            File.WriteAllText(@path, json);
        }

        public void SerializeJsonB(classB b, string path)
        {
            string json = JsonConvert.SerializeObject(b, Newtonsoft.Json.Formatting.Indented,
            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            File.WriteAllText(@path, json);
        }

        public void SerializeJsonC(classC c, string path)
        {
            string json = JsonConvert.SerializeObject(c, Newtonsoft.Json.Formatting.Indented,
            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            File.WriteAllText(@path, json);
        }
    }
}
