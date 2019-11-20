using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;
using Zadanie1.Tests;


namespace Zadanie2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            DataContext data1 = new DataContext();
            WypelnianieStalymi stale1 = new WypelnianieStalymi();
            //WypelnianieZPliku plik = new WypelnianieZPliku();
            DataRepository repository1 = new DataRepository(data1, stale1);
            repository1.FillData();
            DataService service1 = new DataService(repository1);
           
            DataContext data2 = new DataContext();
            PusteWypelnienie pusteWypelnienie = new PusteWypelnienie();
            //WypelnianieZPliku plik = new WypelnianieZPliku();
            DataRepository repository2 = new DataRepository(data2, pusteWypelnienie);

            repository2.FillData();

            DataService service2 = new DataService(repository2);



            SerializationJSON serialization = new SerializationJSON();
            //serialization.SerializeJSON(repository1);
            //service1.Wyswietl(service1.WszystkiePozycjeWykazu());
            //service1.Wyswietl(service1.WszystkiePozycjeKatalogu());
            //service1.Wyswietl(service1.WszystkiePozycjeOpisStanu());
            //service1.Wyswietl(service1.WszystkiePozycjeZdarzen());


            SerializationJSON serialization2 = new SerializationJSON();
            serialization.SerializeJSON(repository1);
            //service1.Wyswietl(service2.WszystkiePozycjeWykazu());

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



        }
    }
}
