using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IEnumerable<Katalog> getAllKatalog()
        {
            return dataContext.katalogi.Values;
        }

        public IEnumerable<Wykaz> getAllWykaz()
        {
            return dataContext.czytelnicy;
        }

        public IEnumerable<Zdarzenie> getAllZdarzenie()
        {
            return dataContext.zdarzenie;
        }

        public IEnumerable<OpisStanu> getAllOpisStanu()
        {
            return dataContext.egzemplarze;
        }

        //metody add...

        public void addWykaz(Wykaz element)
        {
            dataContext.czytelnicy.Add(element);
        }

        public void addKatalog(Katalog pozycja)
        {
            dataContext.katalogi.Add(pozycja.Klucz, pozycja);
        }

        public void addZdarzenie(Zdarzenie zdarzenie)
        {
            dataContext.zdarzenie.Add(zdarzenie);
        }

        public void addOpisStanu(OpisStanu opisStanu)
        {
            dataContext.egzemplarze.Add(opisStanu);
        }

        public void fillData()
        {
            dataFiller.fill(dataContext);
        }                              

    }
}
