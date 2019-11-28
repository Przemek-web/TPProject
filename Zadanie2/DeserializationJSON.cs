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
        public A DeserializeJsonA(string path)
        {
            string json = File.ReadAllText(@path);

            A a = JsonConvert.DeserializeObject<A>(json, new JsonSerializerSettings 
            { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            return a;
        }

        public B DeserializeJsonB(string path)
        {
            string json = File.ReadAllText(@path);

            B b = JsonConvert.DeserializeObject<B>(json, new JsonSerializerSettings
            { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            return b;
        }

        public C DeserializeJsonC(string path)
        {
            string json = File.ReadAllText(@path);

            C c = JsonConvert.DeserializeObject<C>(json, new JsonSerializerSettings
            { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            return c;
        }
    }
}
