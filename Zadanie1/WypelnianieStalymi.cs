using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class WypelnianieStalymi : DataFiller
    {
        public WypelnianieStalymi()
        {
        }

        public void Fill(DataContext context)
        {
            context.czytelnicy.Add(new Wykaz(97011301774, "Maciej", "Szymczak"));
            context.czytelnicy.Add(new Wykaz(98154576891, "Bartosz", "Nowak"));
            //context.czytelnicy.Add(new Wykaz(99223311876, "Paweł", "Kowalski"));

            context.katalogi.Add(1, new Katalog(1, "Pan Tadeusz"));
            context.katalogi.Add(2, new Katalog(2, "W pustyni i w puszczy"));
            context.katalogi.Add(3, new Katalog(3, "Dziady"));

            context.egzemplarze.Add(new OpisStanu(context.katalogi[0], false, "PT456"));
            context.egzemplarze.Add(new OpisStanu(context.katalogi[0], false, "PT328"));
            context.egzemplarze.Add(new OpisStanu(context.katalogi[1], false, "WPIWP326"));
            context.egzemplarze.Add(new OpisStanu(context.katalogi[1], false, "WPIWP328"));
            context.egzemplarze.Add(new OpisStanu(context.katalogi[2], false, "DZ64"));


            context.zdarzenie.Add(new Wypozyczenie(new DateTime(2019, 5, 8), new DateTime(2019, 11, 12), context.czytelnicy[0], context.egzemplarze[0]));
            context.zdarzenie.Add(new Wypozyczenie(new DateTime(2019, 6, 9), new DateTime(2019, 11, 11), context.czytelnicy[0], context.egzemplarze[1]));
            context.zdarzenie.Add(new Oddanie(new DateTime(2019, 10, 10), context.czytelnicy[0], context.egzemplarze[1]));

            context.zdarzenie.Add(new Wypozyczenie(new DateTime(2019, 5, 5), new DateTime(2019, 11, 11), context.czytelnicy[1], context.egzemplarze[2]));
            context.zdarzenie.Add(new Oddanie(new DateTime(2019, 9, 9), context.czytelnicy[1], context.egzemplarze[2]));

        }
    }
    }
