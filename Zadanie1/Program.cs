using System;

namespace Zadanie1
{
    class Program
    {
         //static DataContext data = new DataContext();
         //static WypelnianieStalymi stale = new WypelnianieStalymi();
         //static WypelnianieZPliku plik = new WypelnianieZPliku();
         //static DataRepository repository;
         //static DataService service;
         //static int check;
        static void Main(string[] args)
        {

            //Console.WriteLine("Podaj sposób wstępnego wypełniania repozytorium danymi:\n" +
            // "1 - Wypełnianie stałymi \n" + "2 - Wypełnianie z pliku \n");

            //int choice = Convert.ToInt32(Console.ReadLine());
            //switch(choice)
            //{
            //    case 1:
            //         repository= new DataRepository(data, stale);
            //         repository.FillData();
            //         service = new DataService(repository);
            //         break;
            //    case 2:
            //        repository = new DataRepository(data, plik);
            //        repository.FillData();
            //        service = new DataService(repository);
            //        break;
            //    default:
            //        Console.WriteLine("Błędny wybór");
            //        break;

            //}



            //do
            //{
            //    Console.WriteLine("Wybierz czynnosc: \n" +
            //   "1 - Dodaj Katalog \n" + "2 - Dodaj Wykaz \n" + "3 - Kup książkę \n" +
            //   "4 - Zwróć książkę \n" + "5 - Wypożycz książkę \n" + "6 - Wyswietl czytelników \n" +
            //   "7 - Wyswietl katalogi \n" + "8 - Wyswietl egzemplarze \n" + "9 - Wyswietl wszystkie zdarzenia \n" +
            //   "10 - Wyswietl zdarzenia pomiędzy datami \n" + "11 - Wszystkie zdarzenia danego czytelnika \n" + "12 - Zakończ");


            //    check = Convert.ToInt32(Console.ReadLine());

            //    switch (check)
            //    {
            //        case 1:
            //            Console.WriteLine("Podaj nazwe:");
            //            string nazwa = Console.ReadLine();
            //            Console.WriteLine("Podaj klucz:");
            //            int klucz = Convert.ToInt32(Console.ReadLine());

            //            if (service.DodajKatalog(klucz, nazwa) == true)
            //            {
            //                Console.WriteLine("Pomyślnie dodano katalog");
            //            }
            //            else
            //            {
            //                Console.WriteLine("Nie udało się dodać katalogu");
            //            }
            //            break;
            //        case 2:
            //            Console.WriteLine("Podaj PESEL");
            //            long pesel = Convert.ToInt64(Console.ReadLine());
            //            Console.WriteLine("Podaj imię:");
            //            string imie = Console.ReadLine();
            //            Console.WriteLine("Podaj nazwisko: ");
            //            string nazwisko = Console.ReadLine();
            //            if (service.DodajWykaz(pesel, imie, nazwisko) == true)
            //            {
            //                Console.WriteLine("Pomyslnie dodano nowego czytelnika");
            //            } else
            //            {
            //                Console.WriteLine("Nie udało dodać się czytelnika");
            //            }
            //            break;
            //        case 3:
            //            Console.WriteLine("Podaj nazwe ksiazki:");
            //            string nazwaKsiazki = Console.ReadLine();
            //            Console.WriteLine("Podaj pozycje katalogową:");
            //            string pozycjaKatalogowa = Console.ReadLine();
            //            if(service.KupKsiazke(nazwaKsiazki,pozycjaKatalogowa) == true)
            //            {
            //                Console.WriteLine("Kupno książki zakończone sukcesem");
            //            } else
            //            {
            //                Console.WriteLine("Nie udało się kupić książki");
            //            }
            //            break;
            //        case 4:
            //            Console.WriteLine("Podaj PESEL");
            //            long PESEL = Convert.ToInt64(Console.ReadLine());
            //            Console.WriteLine("Podaj pozycje katalogową:");
            //            string pozyja = Console.ReadLine();
            //            if(service.ZwrocKsiazke(PESEL, pozyja) == true)
            //            {
            //                Console.WriteLine("Operacja zwrotu ksiązki zakończona sukcesem");
            //            } else
            //            {
            //                Console.WriteLine("Nie udało się zwrócić książki");
            //            }
            //            break;
            //        case 5:
            //            Console.WriteLine("Podaj PESEL");
            //            long peselw = Convert.ToInt64(Console.ReadLine());
            //            Console.WriteLine("Podaj nazwe ksiazki:");
            //            string ksiazka = Console.ReadLine();
            //            if(service.WypozyczKsiazke(peselw, ksiazka) ==true)
            //            {
            //                Console.WriteLine("Wypozyczenie książki zakończone sukcesem");
            //            } else
            //            {
            //                Console.WriteLine("Nie udalo się wypozyczyć książki");
            //            }
            //            break;

            //        case 6:
            //            Console.WriteLine("Oto lista wszystkich czytelników:");
            //            service.Wyswietl(service.WszystkiePozycjeWykazu());
            //            break;
            //        case 7:
            //            Console.WriteLine("Oto wszystkie katalogi:");
            //            service.Wyswietl(service.WszystkiePozycjeKatalogu());
            //            break;
            //        case 8:
            //            Console.WriteLine("Oto wszystkie egzemplarze: ");
            //            service.Wyswietl(service.WszystkiePozycjeOpisStanu());
            //            break;
            //        case 9:
            //            Console.WriteLine("Oto wszystkie zdarzenia:");
            //            service.Wyswietl(service.WszystkiePozycjeZdarzen());
            //            break;
            //        case 10:
            //            Console.WriteLine("Podaj date początkową w formacie rr-mm-dd");
            //            DateTime dataPoczatkowa = DateTime.Parse(Console.ReadLine());
            //            Console.WriteLine("Podaj date koncową w formacie rr-mm-dd");
            //            DateTime dataKoncowa = DateTime.Parse(Console.ReadLine());
            //            service.Wyswietl(service.ZdarzeniaPomiedzyDatami(dataPoczatkowa, dataKoncowa));
            //            break;
            //        case 11:
            //            Console.WriteLine("Podaj PESEL: ");
            //            long clientPesel = Convert.ToInt64(Console.ReadLine());
            //            service.Wyswietl(service.ZdarzeniaDlaElementuWykazu(clientPesel));
            //            break;
            //        case 12:
            //            Console.WriteLine("Koniec");
            //            break;



            //    }
            //} while (check != 12);


        }
    }
}
