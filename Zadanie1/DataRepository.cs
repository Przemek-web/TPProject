using System.Collections.Generic;

namespace Zadanie1
{
    class DataRepository
    {
        private DataContext dataContext;
        private DataFiller dataFiller;

        public DataRepository(DataContext dataContext, DataFiller dataFiller)
        {
            this.dataContext = dataContext;
            this.dataFiller = dataFiller;
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
            return dataContext.zdarzenie;
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
            dataContext.zdarzenie.Add(zdarzenie);
        }

        public void AddOpisStanu(OpisStanu opisStanu)
        {
            dataContext.egzemplarze.Add(opisStanu);
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

    }
}
