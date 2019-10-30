using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Zadanie1
{
    public class DataRepository
    {
        private DataContext dataContext;
        private DataFiller dataFiller;

        public DataRepository(DataContext dataContext, DataFiller dataFiller)
        {
            this.dataContext = dataContext;
            this.dataFiller = dataFiller;
            dataContext.zdarzenia.CollectionChanged += ZdarzeniaChange;
        }

        // metody getAll...
        public IEnumerable<Katalog> GetAllKatalog()
        {
            return dataContext.katalogi.Values;
        }

        public IEnumerable<Wykaz> GetAllWykaz()
        {
            return dataContext.czytelnicy;
        }

        public IEnumerable<Zdarzenie> GetAllZdarzenie()
        {
            return dataContext.zdarzenia;
        }

        public IEnumerable<OpisStanu> GetAllOpisStanu()
        {
            return dataContext.egzemplarze;
        }

        //metody add...

        public void AddWykaz(Wykaz element)
        {
            dataContext.czytelnicy.Add(element);
        }

        public void AddKatalog(Katalog pozycja)
        {
            dataContext.katalogi.Add(pozycja.Klucz, pozycja);
        }

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            dataContext.zdarzenia.Add(zdarzenie);
        }

        public void AddOpisStanu(OpisStanu opisStanu)
        {
            dataContext.egzemplarze.Add(opisStanu);
        }

        public void UpdateOpisStanu(OpisStanu opisStanu)
        {
            opisStanu.CzyWypozyczona = !opisStanu.CzyWypozyczona;
        }

        public void FillData()
        {
            dataFiller.Fill(dataContext);
        }

        public Katalog GetKatalog(int klucz)
        {
            if (dataContext.katalogi.ContainsKey(klucz)) return dataContext.katalogi[klucz];
            else return null;
        }

        public Katalog GetKatalog(string nazwaKsiazki)
        {
            foreach (Katalog katalog in dataContext.katalogi.Values)
            {
                if (katalog.NazwaKsiazki.Equals(nazwaKsiazki)) return katalog;
            }
            return null;
        }

        public Wykaz GetWykaz(long pesel)
        {
            foreach (Wykaz czytelnik in dataContext.czytelnicy)
            {
                if (czytelnik.Pesel == pesel) return czytelnik;
            }
            return null;
        }

        public OpisStanu GetOpisStanu(string pozycjaKatalogowa)
        {
            foreach (OpisStanu egzemplarz in dataContext.egzemplarze)
            {
                if (egzemplarz.PozycjaKatalogowa == pozycjaKatalogowa) return egzemplarz;
            }
            return null;
        }

        public OpisStanu GetAvailableBook(string nazwaKsiazki)
        {
            foreach (OpisStanu opisStanu in dataContext.egzemplarze)
            {
                if (opisStanu.Katalog == this.GetKatalog(nazwaKsiazki) && opisStanu.CzyWypozyczona == false) return opisStanu;
            }
            return null;
        }

        public void ZdarzeniaChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Dodano nowe zdarzenie: ");
                foreach (Zdarzenie z in e.NewItems)
                {
                    Console.WriteLine(z);
                }
            }
        }


       public  IEnumerable<Zdarzenie> ReturnEventsBetweenDates(DateTime start, DateTime finish)
        {
            List<Zdarzenie> dates = new List<Zdarzenie>();

 


                foreach (Zdarzenie z in dataContext.zdarzenia)
                {
                    if (z.GetStartDate() >= start && z.GetStartDate() <= finish)
                    {
                        dates.Add(z);
                    }
                }
            return dates;
        }


        public IEnumerable<Zdarzenie> EventsForClient(Wykaz element)
        {
            List<Zdarzenie> events = new List<Zdarzenie>();
            foreach(Zdarzenie z in dataContext.zdarzenia)
            {
                if(z.GetWykaz() != null && z.GetWykaz().Equals(element))
                {
                    events.Add(z);
                }
            }
            return events;
        }

    }

   
}
