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
          
            
            int check;

            do
            {
                Console.WriteLine("Podaj swoja opcje: ");
                Console.WriteLine("1-SerializacjaJSON, 2- SerializacjaWłasnaCSV 3- DeserializacjaJSON, 4- DeserializacjaWłasnaCSV, 5- Koniec");
                check = Convert.ToInt32(Console.ReadLine());



                switch (check)
                {
                    case 1:
                        C c = new C(DateTime.UtcNow, 14.32F, "tekstC", null);
                        B b = new B(DateTime.UtcNow, 5.0F, "tekstB", c);
                        A a = new A(DateTime.UtcNow, 3.14F, "tekstA", b);
                        c.A = a;

                            
                        SerializationJSON serializationJSON = new SerializationJSON();
                        serializationJSON.SerializeJsonA(a, "A.json");
                        serializationJSON.SerializeJsonB(b, "B.json");
                        serializationJSON.SerializeJsonC(c, "C.json");
                        

                        break;
                    case 2:
                        
                         C c_a = new C(DateTime.UtcNow, 14.32F, "tekstC", null);
                        B b_a = new B(DateTime.UtcNow, 5.0F, "tekstB", c_a);
                        A a_a = new A(DateTime.UtcNow, 3.14F, "tekstA", b_a);
                        c_a.A = a_a;




                       SerializationCSV.SerializeA(a_a, "A.csv");

                        C c_b = new C(DateTime.UtcNow, 14.32F, "tekstC", null);
                        B b_b = new B(DateTime.UtcNow, 5.0F, "tekstB", c_b);
                        A a_b = new A(DateTime.UtcNow, 3.14F, "tekstA", b_b);
                        c_b.A = a_b;
                        SerializationCSV.SerializeB(b_b, "B.csv");

                        C c_c = new C(DateTime.UtcNow, 14.32F, "tekstC", null);
                        B b_c = new B(DateTime.UtcNow, 5.0F, "tekstB", c_c);
                        A a_c = new A(DateTime.UtcNow, 3.14F, "tekstA", b_c);
                        c_c.A = a_c;

                        SerializationCSV.SerializeC(c_c, "C.csv");
                        break;
                    case 3:
                        DeserializationJSON deserializationJSON = new DeserializationJSON();
                        A a_new = deserializationJSON.DeserializeJsonA("A.json");
                        B b_new = deserializationJSON.DeserializeJsonB("B.json");
                        C c_new = deserializationJSON.DeserializeJsonC("C.json");

                        Console.WriteLine("Zdeserializowany obiekt A:");
                        Console.WriteLine(a_new);
                        Console.WriteLine("\n \n");
                        Console.WriteLine("Zdeserializowany obiekt B:");
                        Console.WriteLine(b_new);
                        Console.WriteLine("\n \n");
                        Console.WriteLine("Zdeserializowany obiekt C:");
                        Console.WriteLine(c_new);
                        Console.WriteLine("\n \n");
                      
                       
                        break;
                   
                    case 4:
                        A newa = DeserializationCSV.DeserializeA("A.csv");
                        B newb = DeserializationCSV.DeserializeB("B.csv");
                        C newc = DeserializationCSV.DeserializeC("C.csv");

                        Console.WriteLine(newa == newa.B.C.A);
                        Console.WriteLine(newb == newb.C.A.B);
                        Console.WriteLine(newc == newc.A.B.C);
                        Console.WriteLine(newc.Equals(newc.A.B.C));

                       
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
