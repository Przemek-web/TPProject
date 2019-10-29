using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace Zadanie1.Tests
{
    [TestClass()]
    public class TestMetodWDataService
    {
        [TestMethod()]
        public void TestMethodDodajKatalog()
        {
            DataContext data = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(data, wypelnianieStalymi);
            DataService dataService = new DataService(dataRepository);

            Katalog k1 = new Katalog(1, "Lord Of The Rings");
            Katalog k2 = new Katalog(2, "The Witcher");
            Katalog k3 = new Katalog(3, "Harry Potter and the Goblet of Fire");

            Assert.IsTrue(dataService.DodajKatalog(1, "Lord Of The Rings"));
            Assert.AreEqual(1, data.katalogi.Count);
            Assert.IsTrue(k1.Equals(data.katalogi[1]));

            Assert.IsFalse(dataService.DodajKatalog(1, "Lord Of The Rings"));
            Assert.AreEqual(1, data.katalogi.Count);
        }

        [TestMethod()]
        public void TestMethodDodajWykaz()
        {
            DataContext data = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(data, wypelnianieStalymi);
            DataService dataService = new DataService(dataRepository);

            Wykaz w1 = new Wykaz(123, "Franek", "Duk");

            Assert.IsTrue(dataService.DodajWykaz(123, "Franek", "Duk"));
            Assert.AreEqual(1, data.czytelnicy.Count);
            Assert.IsTrue(w1.Equals(data.czytelnicy[0]));

            Assert.IsFalse(dataService.DodajWykaz(123, "Franco", "Dook"));
            Assert.AreEqual(1, data.czytelnicy.Count);
        }

        [TestMethod()]
        public void TestMethodKupKsiazke()
        {
            DataContext data = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(data, wypelnianieStalymi);
            DataService dataService = new DataService(dataRepository);

            dataService.DodajKatalog(1, "Lord Of The Rings");

            Assert.IsFalse(dataService.KupKsiazke("Lord Of The Ringz", "LOTR1"));
            Assert.AreEqual(0, data.egzemplarze.Count);

            Assert.IsTrue(dataService.KupKsiazke("Lord Of The Rings", "LOTR1"));
            Assert.AreEqual(1, data.egzemplarze.Count);
            Assert.AreEqual(1, data.zdarzenia.Count);

            Assert.IsFalse(dataService.KupKsiazke("Lord Of The Rings", "LOTR1"));
            Assert.AreEqual(1, data.egzemplarze.Count);
            Assert.AreEqual(1, data.zdarzenia.Count);

            Assert.IsTrue(dataService.KupKsiazke("Lord Of The Rings", "LOTR2"));
            Assert.AreEqual(2, data.egzemplarze.Count);
            Assert.AreEqual(2, data.zdarzenia.Count);
        }

        [TestMethod()]
        public void TestMethodWypozyczKsiazke()
        {
            DataContext data = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(data, wypelnianieStalymi);
            DataService dataService = new DataService(dataRepository);

            dataService.DodajKatalog(1, "Lord Of The Rings");

            dataService.DodajWykaz(123, "Franek", "Duk");
            dataService.DodajWykaz(1481, "Henryk", "Kania");

            dataService.KupKsiazke("Lord Of The Rings", "LOTR1");

            Assert.IsFalse(dataService.WypozyczKsiazke(12, "Lord Of The"));
            Assert.AreEqual(1, data.zdarzenia.Count);

            Assert.IsFalse(dataService.WypozyczKsiazke(12, "Lord Of The Rings"));
            Assert.AreEqual(1, data.zdarzenia.Count);

            Assert.IsFalse(dataService.WypozyczKsiazke(123, "Lord Of The"));
            Assert.AreEqual(1, data.zdarzenia.Count);

            Assert.IsTrue(dataService.WypozyczKsiazke(123, "Lord Of The Rings"));
            Assert.AreEqual(2, data.zdarzenia.Count);

            Assert.IsFalse(dataService.WypozyczKsiazke(1481, "Lord Of The Rings"));
            Assert.AreEqual(2, data.zdarzenia.Count);

            dataService.KupKsiazke("Lord Of The Rings", "LOTR2");
            Assert.IsTrue(dataService.WypozyczKsiazke(1481, "Lord Of The Rings"));
            Assert.AreEqual(4, data.zdarzenia.Count);
        }

        [TestMethod()]
        public void TestMethodZwrocKsiazke()
        {
            DataContext data = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(data, wypelnianieStalymi);
            DataService dataService = new DataService(dataRepository);

            dataService.DodajKatalog(1, "Lord Of The Rings");

            dataService.DodajWykaz(123, "Franek", "Duk");
            dataService.DodajWykaz(1481, "Henryk", "Kania");

            dataService.KupKsiazke("Lord Of The Rings", "LOTR1");

            dataService.WypozyczKsiazke(123, "Lord Of The Rings");

            Assert.IsFalse(dataService.WypozyczKsiazke(1481, "Lord Of The Rings"));
            Assert.AreEqual(2, data.zdarzenia.Count);

            Assert.IsFalse(dataService.ZwrocKsiazke(12, "LOTR"));
            Assert.AreEqual(2, data.zdarzenia.Count);

            Assert.IsFalse(dataService.ZwrocKsiazke(12, "LOTR1"));
            Assert.AreEqual(2, data.zdarzenia.Count);

            Assert.IsFalse(dataService.ZwrocKsiazke(123, "LOTR"));
            Assert.AreEqual(2, data.zdarzenia.Count);

            Assert.IsTrue(dataService.ZwrocKsiazke(123, "LOTR1"));
            Assert.AreEqual(3, data.zdarzenia.Count);

            Assert.IsTrue(dataService.WypozyczKsiazke(1481, "Lord Of The Rings"));
            Assert.AreEqual(4, data.zdarzenia.Count);
        }
    }
}