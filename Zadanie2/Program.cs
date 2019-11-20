using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;
using Zadanie1.Tests;


namespace Zadanie2
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("Podaj sposób wstępnego wypełniania repozytorium danymi:\n" +
                 "1 - Serializacja JSON \n" + "2 - Deserializacja JSON \n" + "3 - Serializacja CSV \n" +
                 "4 - Wyjscie\n");


                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        DataContext data1 = new DataContext();
                        WypelnianieStalymi stale1 = new WypelnianieStalymi();
                        DataRepository repository1 = new DataRepository(data1, stale1);
                        repository1.FillData();
                        DataService service1 = new DataService(repository1);
                        SerializationJSON serialization = new SerializationJSON();
                        serialization.SerializeJSON(repository1);
                        break;
                    case 2:
                        DataContext data2 = new DataContext();
                        PusteWypelnienie pusteWypelnienie = new PusteWypelnienie();
                        DataRepository repository2 = new DataRepository(data2, pusteWypelnienie);
                        repository2.FillData();
                        DataService service2 = new DataService(repository2);

                        Console.WriteLine("Przed deserializacja: ");
                        service2.Wyswietl(service2.WszystkiePozycjeWykazu());
                        service2.Wyswietl(service2.WszystkiePozycjeKatalogu());
                        service2.Wyswietl(service2.WszystkiePozycjeOpisStanu());


                        DeserializationJSON deserialization = new DeserializationJSON();
                        deserialization.DeserializeJSON(data2);

                        Console.WriteLine("Po deserializacji: ");

                        service2.Wyswietl(service2.WszystkiePozycjeWykazu());
                        service2.Wyswietl(service2.WszystkiePozycjeKatalogu());
                        service2.Wyswietl(service2.WszystkiePozycjeOpisStanu());
                        service2.Wyswietl(service2.WszystkiePozycjeZdarzen());
                        break;
                    case 3:
                        DataContext data3 = new DataContext();
                        WypelnianieStalymi stale3 = new WypelnianieStalymi();
                        DataRepository repository3 = new DataRepository(data3, stale3);
                        repository3.FillData();
                        DataService service3 = new DataService(repository3);
                        CustomSerialization customSerialization = new CustomSerialization();
                        customSerialization.SerializeCSV(repository3);
                        break;
                    case 4:
                        Console.WriteLine("Koniec programu");
                        break;
                    default:
                        Console.WriteLine("Błędny wybór");
                        break;

                }
            } while (choice != 3);
        }
    }
}
