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
            /* SerializationJSON serializationJSON = new SerializationJSON();
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
             Console.WriteLine(a1 = a1.B.C.A); */

            C c = new C(DateTime.Now, 14.32F, "tekstC", null);
            B b = new B(DateTime.Now, 5.0F, "tekstB", c);
            A a = new A(DateTime.Now, 3.14F, "tekstA", b);
            c.A = a;

            Console.WriteLine(c.A.Sa1);
            Console.WriteLine(c.A.Fa1);
            int check;


            do
            {
                Console.WriteLine("Podaj swoja opcje: ");
                Console.WriteLine("1-SerializacjaJSON, 2- SerializacjaWłasnaCSV 3- DeserializacjaJSON, 4- DeserializacjaWłasnaCSV, 5- Koniec");
                check = Convert.ToInt32(Console.ReadLine());



                switch (check)
                {
                    case 1:
                        SerializationJSON serializationJSON = new SerializationJSON();
                        serializationJSON.SerializeJsonA(a, "A.json");
                        serializationJSON.SerializeJsonB(b, "B.json");
                        serializationJSON.SerializeJsonC(c, "C.json");
                        Console.WriteLine(c.A.Sa1);

                        break;
                    case 2:
                        //SerializationCSV customSerialization = new SerializationCSV();
                        //FileStream s = new FileStream("test.csv", FileMode.Append, FileAccess.Write);

                        //FileStream s = new FileStream("test.csv", FileMode.Create, FileAccess.Write);
                        SerializationCSV.SerializeA(a, "A.csv");


                        //Console.Read();
                        break;
                    case 3:
                        DeserializationJSON deserializationJSON = new DeserializationJSON();
                        A a_new = deserializationJSON.DeserializeJsonA("A.json");
                        B b_new = deserializationJSON.DeserializeJsonB("B.json");
                        C c_new = deserializationJSON.DeserializeJsonC("C.json");

                        Console.WriteLine("Zdeserializowany obiekt A:");
                        Console.WriteLine(a_new);
                        Console.WriteLine("\nPrzerwa \n");
                        Console.WriteLine("Zdeserializowany obiekt B:");
                        Console.WriteLine(b_new);
                        Console.WriteLine("\nPrzerwa \n");
                        Console.WriteLine("Zdeserializowany obiekt C:");
                        Console.WriteLine(c_new);
                        Console.WriteLine("\nPrzerwa \n");
                        Console.WriteLine(c_new.A.Sa1);
                        Console.WriteLine(c_new.A.Fa1);
                        break;
                    //Console.WriteLine("\nPrzerwa \n");
                    //Console.WriteLine(b_new.C.Fc1);
                    //Console.WriteLine(b_new.C.Sc1);
                    //Console.WriteLine("\nPrzerwa \n");
                    //Console.WriteLine(a_new.B.Fb1);
                    //Console.WriteLine(a_new.B.Sb1);
                    case 4:
                        A a1 = DeserializationCSV.DeserializeA("A.csv");
                        //Console.WriteLine(a1.B);
                        Console.WriteLine(a1 == a1.B.C.A);

                        break;
                    case 5:
                        Console.WriteLine("Koniec programu");
                        break;

                }
            }
            while (check != 5);
        }

    }
}
