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
            classC c = new classC(DateTime.Now, 14.3F, "II", null);
            classB b = new classB(DateTime.Now, 5.1F, "Paweł", c);
            classA a = new classA(DateTime.Now, 3.8F, "Jan", b);
            c.aRef = a;

            FormatterCSV formatterCSV = new FormatterCSV();

            using (FileStream stream = File.Open("A.csv", FileMode.OpenOrCreate))
            {
                formatterCSV.Serialize(stream, a);
            }

            classA a2;

            using (FileStream stream = File.Open("A.csv", FileMode.Open))
            {
                a2 = (classA)formatterCSV.Deserialize(stream);
            }
        }
    }
}
