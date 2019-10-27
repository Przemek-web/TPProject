using System;
using System.Collections.Generic;

namespace Zadanie1
{
    class DataService
    {
        private DataRepository dataRepository;

        public DataService(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public bool AddKatalog(int klucz, string nazwa)
        {
            if (dataRepository.GetKatalog(klucz) == null)
            {
                dataRepository.AddKatalog(new Katalog(klucz, nazwa));
                return true;
            }
            else return false;
        }

        public bool AddWykaz(long pesel, string imie, string nazwisko)
        {
            if (dataRepository.GetWykaz(pesel) == null)
            {
                dataRepository.AddWykaz(new Wykaz(pesel, imie, nazwisko));
                return true;
            }
            else return false;
        }

        public bool BuyBook(string nazwaKsiazki, string pozycjaKatalogowa)
        {
            if (dataRepository.GetOpisStanu(pozycjaKatalogowa) == null && dataRepository.GetKatalog(nazwaKsiazki) != null)
            {
                dataRepository.AddOpisStanu(new OpisStanu(dataRepository.GetKatalog(nazwaKsiazki), false, pozycjaKatalogowa));
                dataRepository.AddZdarzenie(new Zakup());
                return true;
            }
            else return false;
        }

        public bool RentBook(long pesel, string nazwaKsiazki)
        {
            if (dataRepository.GetWykaz(pesel) != null && dataRepository.GetKatalog(nazwaKsiazki) != null)
            {
                OpisStanu availableBook = dataRepository.GetAvailableBook(nazwaKsiazki);
                if (availableBook == null) return false;
                else
                {
                    dataRepository.AddZdarzenie(new Wypozyczenie(DateTime.Now, DateTime.Now.AddDays(30),
                            dataRepository.GetWykaz(pesel), availableBook));
                    return true;
                }
            }
            else return false;
        }
        public bool ReturnBook(long pesel, string pozycjaKatalogowa)
        {
            if (dataRepository.GetWykaz(pesel) != null && dataRepository.GetOpisStanu(pozycjaKatalogowa) != null)
            {
                if (dataRepository.GetOpisStanu(pozycjaKatalogowa).CzyWypozyczona == false) return false;
                else
                {
                    dataRepository.AddZdarzenie(new Oddanie(DateTime.Now, dataRepository.GetWykaz(pesel),
                            dataRepository.GetOpisStanu(pozycjaKatalogowa)));
                    return true;
                }
            }
            else return false;
        }

        public IEnumerable<Katalog> GetAllKatalog()
        {
            return dataRepository.GetAllKatalog();
        }

        public IEnumerable<Wykaz> GetAllWykaz()
        {
            return dataRepository.GetAllWykaz();
        }

        public IEnumerable<Zdarzenie> GetAllZdarzenie()
        {
            return dataRepository.GetAllZdarzenie();
        }

        public IEnumerable<OpisStanu> GetAllOpisStanu()
        {
            return dataRepository.GetAllOpisStanu();
        }
    }
}
