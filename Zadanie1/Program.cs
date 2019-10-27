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
            DataService dS = new DataService(dataRepository);
            dS.AddWykaz(123, "Jarek", "Smorawa");
            dS.AddWykaz(12, "Andrzej", "Smorawa");
            dS.AddKatalog(1, "Lord Of The Rings");
            dS.BuyBook("Lord Of The Rings", "LOTR1");
            //Console.Write(dS.RentBook(123, "Lord Of The Rings"));
            //Console.Write(dS.ReturnBook(12, "LOTR1"));
            //Console.Read();
        }
    }
}
