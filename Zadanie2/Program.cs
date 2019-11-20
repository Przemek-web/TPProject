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
        static DataContext data = new DataContext();
        static WypelnianieStalymi stale = new WypelnianieStalymi();
        //static WypelnianieZPliku plik = new WypelnianieZPliku();
        static DataRepository repository = new DataRepository(data, stale);
        static DataService service = new DataService(repository);
        static void Main(string[] args)
        {
            Console.WriteLine("aaaa");
            repository.FillData();
            // service.Wyswietl(service.WszystkiePozycjeWykazu());
            // service.Wyswietl(service.WszystkiePozycjeOpisStanu());
            //  service.Wyswietl(service.WszystkiePozycjeKatalogu());
            //  service.Wyswietl(service.WszystkiePozycjeZdarzen());

            Serialization serialization = new Serialization();
            serialization.SerializeJSON(repository);


        }
    }
}
