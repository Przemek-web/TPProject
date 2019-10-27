using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext();
            WypelnianieStalymi dataFiller = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(dataContext,dataFiller);
            dataRepository.fillData();
            IEnumerable<OpisStanu> czytelnicy = dataRepository.getAllOpisStanu();
            foreach (OpisStanu czytelnik in czytelnicy) {
                Console.Write(czytelnik);
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
