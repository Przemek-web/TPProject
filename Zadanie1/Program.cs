using System;
using System.Collections.Generic;
using System.Linq;
namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext();
            WypelnianieStalymi dataFiller = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(dataContext, dataFiller);
            dataRepository.FillData();
            DataService dS = new DataService(dataRepository);
            //dS.AddWykaz(123, "Jarek", "Smorawa");
            //dS.AddWykaz(12, "Andrzej", "Smorawa");
            //dS.AddKatalog(1, "Lord Of The Rings");
            //dS.BuyBook("Lord Of The Rings", "LOTR1");
            //Console.Write(dS.RentBook(123, "Lord Of The Rings"));
            //Console.Write(dS.ReturnBook(12, "LOTR1"));
            //Console.Read();
            // Console.WriteLine(dS.DodajWykaz(123, "Jarek", "Smorawa"));
            // Console.WriteLine(dS.DodajWykaz(12, "Andrzej", "Smorawa"));
            // Console.WriteLine(dS.DodajKatalog(1, "Lord Of The Rings"));
            // Console.WriteLine(dS.KupKsiazke("Lord Of The Rings", "LOTR1"));

            //Console.WriteLine(dS.)



            /**IEnumerable<Wykaz> wykazy = dS.WszystkiePozycjeWykazu();
            foreach(Wykaz w in wykazy)
            {
              Console.WriteLine(w);
            }

            IEnumerable<Katalog> katalogi = dS.WszystkiePozycjeKatalogu();
            foreach(Katalog k in katalogi)
            {
                Console.WriteLine(k);
            }

            IEnumerable<OpisStanu> opis = dS.WszystkiePozycjeOpisStanu();
            foreach(OpisStanu o in opis)
            {
                Console.WriteLine(o);
            }


            IEnumerable<Zdarzenie> zdarzenie = dS.WszystkiePozycjeZdarzen();
            foreach(Zdarzenie z in zdarzenie)
            {
                Console.WriteLine(z);
            } **/

            dS.Wyswietl(dS.WszystkiePozycjeKatalogu());

        }
    }
}
