using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Zadanie2
{
    public class Program
    {
        static void Main(string[] args)
        {   
            SerializationJSON serializationJSON = new SerializationJSON();
            C c = new C(DateTime.Now, 14.32F, "tutaj",null);
            B b = new B(DateTime.Now, 5.0F, "zapraszam", c);
            A a = new A(DateTime.Now, 3.14F, "morenka",b);
            c.A = a;
            // JSON // 
            //serializationJSON.SerializeJsonA(a, "A.json");
            //DeserializationJSON deserializationJSON = new DeserializationJSON();
            //A a_new = deserializationJSON.DeserializeJsonA("A.json");
            //Console.Write(a_new);

            // CSV //
            SerializationCSV.SerializeA(a, "A.csv");

            A a1 = DeserializationCSV.DeserializeA("A.csv");
            Console.WriteLine(a1 = a1.B.C.A);
        }
    }

   
}
