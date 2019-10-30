using System;
using System.Collections.Generic;
using System.Linq;
namespace Zadanie1
{
    class Program
    {
         static DataContext data = new DataContext();
         static WypelnianieStalymi stale = new WypelnianieStalymi();
         static WypelnianieZPliku plik = new WypelnianieZPliku();
         static DataRepository repository;
         static DataService service;
         static int check;
        static void Main(string[] args)
        {
            /*    DataContext dataContext = new DataContext();
                //WypelnianieStalymi dataFiller = new WypelnianieStalymi();
                WypelnianieZPliku dataFiller = new WypelnianieZPliku();

                DataRepository dataRepository = new DataRepository(dataContext, dataFiller);
                dataRepository.FillData();
                foreach(Wykaz w in dataRepository.GetAllWykaz())
                {
                    Console.Write(w);
                    Console.WriteLine();
                }
                foreach (Katalog k in dataRepository.GetAllKatalog())
                {
                    Console.Write(k);
                    Console.WriteLine();
                }
                foreach (OpisStanu o in dataRepository.GetAllOpisStanu())
                {
                    Console.Write(o);
                    Console.WriteLine();
                }
                Console.Read(); */

            //DataService dS = new DataService(dataRepository);
            //dS.DodajWykaz(123, "Jarek", "Smorawa");
            //dS.DodajWykaz(12, "Andrzej", "Smorawa");
            //dS.DodajKatalog(1, "Lord Of The Rings");
            //dS.KupKsiazke("Lord Of The Rings", "LOTR1");     
            //Console.Write(dS.WypozyczKsiazke(12, "Lord Of The Rings"));
            ////Console.Write(dS.ReturnBook(12, "LOTR1"));
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

            //dS.Wyswietl(dS.WszystkiePozycjeKatalogu());

            Console.WriteLine("Podaj sposób wstępnego wypełniania repozytorium danymi:\n" +
             "1 - Wypełnianie stałymi \n" + "2 - Wypełnianie z pliku \n");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                     repository= new DataRepository(data, stale);
                     repository.FillData();
                     service = new DataService(repository);
                     break;
                case 2:
                    repository = new DataRepository(data, plik);
                    repository.FillData();
                    service = new DataService(repository);
                    break;
                default:
                    Console.WriteLine("Błędny wybór");
                    break;

            }



            do
            {
                Console.WriteLine("Wybierz czynnosc: \n" +
               "1 - Dodaj Katalog \n" + "2 - Dodaj Wykaz \n" + "3 - Kup książkę \n" +
               "4 - Zwróć książkę \n" + "5 - Wypożycz książkę \n" + "6 - Wyswietl czytelników \n" +
               "7 - Wyswietl katalogi \n" + "8 - Wyswietl egzemplarze \n" + "9 - Wyswietl wszystkie zdarzenia \n" +
               "10 - Zakoncz");


                check = Convert.ToInt32(Console.ReadLine());

                switch (check)
                {
                    case 1:
                        Console.WriteLine("Podaj nazwe:");
                        string nazwa = Console.ReadLine();
                        Console.WriteLine("Podaj klucz:");
                        int klucz = Convert.ToInt32(Console.ReadLine());

                        if (service.DodajKatalog(klucz, nazwa) == true)
                        {
                            Console.WriteLine("Pomyślnie dodano katalog");
                        }
                        else
                        {
                            Console.WriteLine("Nie udało się dodać katalogu");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Podaj PESEL");
                        long pesel = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Podaj imię:");
                        string imie = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko: ");
                        string nazwisko = Console.ReadLine();
                        if (service.DodajWykaz(pesel, imie, nazwisko) == true)
                        {
                            Console.WriteLine("Pomyslnie dodano nowego czytelnika");
                        } else
                        {
                            Console.WriteLine("Nie udało dodać się czytelnika");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Podaj nazwe ksiazki:");
                        string nazwaKsiazki = Console.ReadLine();
                        Console.WriteLine("Podaj pozycje katalogową:");
                        string pozycjaKatalogowa = Console.ReadLine();
                        if(service.KupKsiazke(nazwaKsiazki,pozycjaKatalogowa) == true)
                        {
                            Console.WriteLine("Kupno książki zakończone sukcesem");
                        } else
                        {
                            Console.WriteLine("Nie udało się kupić książki");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Podaj PESEL");
                        long PESEL = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Podaj pozycje katalogową:");
                        string pozyja = Console.ReadLine();
                        if(service.ZwrocKsiazke(PESEL, pozyja) == true)
                        {
                            Console.WriteLine("Operacja zwrotu ksiązki zakończona sukcesem");
                        } else
                        {
                            Console.WriteLine("Nie udało się zwrócić książki");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Podaj PESEL");
                        long peselw = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Podaj nazwe ksiazki:");
                        string ksiazka = Console.ReadLine();
                        if(service.WypozyczKsiazke(peselw, ksiazka) ==true)
                        {
                            Console.WriteLine("Wypozyczenie książki zakończone sukcesem");
                        } else
                        {
                            Console.WriteLine("Nie udalo się wypozyczyć książki");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Oto lista wszystkich czytelników:");
                        service.Wyswietl(service.WszystkiePozycjeWykazu());
                        break;
                    case 7:
                        Console.WriteLine("Oto wszystkie katalogi:");
                        service.Wyswietl(service.WszystkiePozycjeKatalogu());
                        break;
                    case 8:
                        Console.WriteLine("Oto wszystkie egzemplarze: ");
                        service.Wyswietl(service.WszystkiePozycjeOpisStanu());
                        break;
                    case 9:
                        Console.WriteLine("Oto wszystkie zdarzenia:");
                        service.Wyswietl(service.WszystkiePozycjeZdarzen());
                        break;
                    case 10:
                        Console.WriteLine("Koniec");
                        break;
                   

                }
            } while (check != 10);


        }
    }
}
