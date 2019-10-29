using System;
using System.Collections.Generic;

namespace Zadanie1
{
    public class DataService
    {
        private DataRepository dataRepository;

        public DataService(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public bool DodajKatalog(int klucz, string nazwa)
        {
            if (dataRepository.GetKatalog(klucz) == null)
            {
                dataRepository.AddKatalog(new Katalog(klucz, nazwa));
                return true;
            }
            else return false;
        }

        public bool DodajWykaz(long pesel, string imie, string nazwisko)
        {
            if (dataRepository.GetWykaz(pesel) == null)
            {
                dataRepository.AddWykaz(new Wykaz(pesel, imie, nazwisko));
                return true;
            }
            else return false;
        }

        public bool KupKsiazke(string nazwaKsiazki, string pozycjaKatalogowa)
        {
            if (dataRepository.GetOpisStanu(pozycjaKatalogowa) == null && dataRepository.GetKatalog(nazwaKsiazki) != null)
            {
                dataRepository.AddOpisStanu(new OpisStanu(dataRepository.GetKatalog(nazwaKsiazki), false, pozycjaKatalogowa));
                dataRepository.AddZdarzenie(new Zakup(dataRepository.GetOpisStanu(pozycjaKatalogowa),DateTime.Now));
                return true;
            }
            else return false;
        }

        public bool WypozyczKsiazke(long pesel, string nazwaKsiazki)
        {
            if (dataRepository.GetWykaz(pesel) != null && dataRepository.GetKatalog(nazwaKsiazki) != null)
            {
                if (dataRepository.GetAvailableBook(nazwaKsiazki) == null) return false;
                else
                {
                    dataRepository.AddZdarzenie(new Wypozyczenie(DateTime.Now, DateTime.Now.AddDays(30),
                            dataRepository.GetWykaz(pesel), dataRepository.GetAvailableBook(nazwaKsiazki)));
                    dataRepository.UpdateOpisStanu(dataRepository.GetAvailableBook(nazwaKsiazki));
                    return true;
                }
            }
            else return false;
        }
        public bool ZwrocKsiazke(long pesel, string pozycjaKatalogowa)
        {
            if (dataRepository.GetWykaz(pesel) != null && dataRepository.GetOpisStanu(pozycjaKatalogowa) != null)
            {
                if (dataRepository.GetOpisStanu(pozycjaKatalogowa).CzyWypozyczona == false) return false;
                else
                {
                    dataRepository.AddZdarzenie(new Oddanie(DateTime.Now, dataRepository.GetWykaz(pesel),
                            dataRepository.GetOpisStanu(pozycjaKatalogowa)));
                    dataRepository.UpdateOpisStanu(dataRepository.GetOpisStanu(pozycjaKatalogowa));
                    return true;
                }
            }
            else return false;
        }

        public IEnumerable<Katalog> WszystkiePozycjeKatalogu()
        {
            return dataRepository.GetAllKatalog();
        }

        public IEnumerable<Wykaz> WszystkiePozycjeWykazu()
        {
            return dataRepository.GetAllWykaz();
        }

        public IEnumerable<Zdarzenie> WszystkiePozycjeZdarzen()
        {
            return dataRepository.GetAllZdarzenie();
        }

        public IEnumerable<OpisStanu> WszystkiePozycjeOpisStanu()
        {
            return dataRepository.GetAllOpisStanu();
        }

        public void Wyswietl<T>(IEnumerable<T> kolekcja)
        {
            foreach (object wartosc in kolekcja)
            {
                Console.WriteLine(wartosc);
            }
        }
    }
}
