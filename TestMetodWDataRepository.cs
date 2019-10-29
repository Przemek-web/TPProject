using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace Zadanie1Test
{
    [TestClass]
    public class TestMetodWDataRepository
    {
        [TestMethod]
        public void TestMethodAddKatalog()
        {
            DataContext data = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(data, wypelnianieStalymi);

            Katalog k1 = new Katalog(1, "Lord Of The Rings");
            Katalog k2 = new Katalog(2, "The Witcher");
            Katalog k3 = new Katalog(3, "Harry Potter and the Goblet of Fire");

            dataRepository.AddKatalog(k1);
            Assert.AreEqual(1, data.katalogi.Count);
            Assert.AreSame(k1, data.katalogi[1]);

            dataRepository.AddKatalog(k2);
            dataRepository.AddKatalog(k3);
            Assert.AreEqual(3, data.katalogi.Count);
        }

        [TestMethod]
        public void TestMethodAddWykaz()
        {
            DataContext data = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(data, wypelnianieStalymi);

            Wykaz w1 = new Wykaz(123, "Franek", "Duk");
            Wykaz w2 = new Wykaz(451, "Gieniek", "Ziemba");
            Wykaz w3 = new Wykaz(656, "Daniel", "Skulski");

            dataRepository.AddWykaz(w1);
            Assert.AreEqual(1, data.czytelnicy.Count);
            Assert.AreSame(w1, data.czytelnicy[0]);

            dataRepository.AddWykaz(w2);
            dataRepository.AddWykaz(w3);
            Assert.AreEqual(3, data.czytelnicy.Count);
        }

        [TestMethod]
        public void TestMethodAddOpisStanu()
        {
            DataContext data = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(data, wypelnianieStalymi);

            Katalog k1 = new Katalog(1, "Lord Of The Rings");
            Katalog k2 = new Katalog(2, "The Witcher");

            OpisStanu o1 = new OpisStanu(k1, false, "LOTR1");
            OpisStanu o2 = new OpisStanu(k1, true, "LOTR2");
            OpisStanu o3 = new OpisStanu(k2, false, "TW1");

            dataRepository.AddOpisStanu(o1);
            Assert.AreEqual(1, data.egzemplarze.Count);
            Assert.AreSame(o1, data.egzemplarze[0]);

            dataRepository.AddOpisStanu(o2);
            dataRepository.AddOpisStanu(o3);
            Assert.AreEqual(3, data.egzemplarze.Count);
        }

        [TestMethod]
        public void TestMethodAddZdarzenie()
        {
            DataContext data = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(data, wypelnianieStalymi);

            Wykaz w1 = new Wykaz(123, "Franek", "Duk");
            Wykaz w2 = new Wykaz(451, "Gieniek", "Ziemba");

            Katalog k1 = new Katalog(1, "Lord Of The Rings");
            Katalog k2 = new Katalog(2, "The Witcher");

            OpisStanu o1 = new OpisStanu(k1, false, "LOTR1");
            OpisStanu o2 = new OpisStanu(k1, true, "LOTR2");
            OpisStanu o3 = new OpisStanu(k2, false, "TW1");

            Zdarzenie z1 = new Wypozyczenie(System.DateTime.Now, System.DateTime.Now.AddDays(30),
                w1, o2);
            Zdarzenie z2 = new Wypozyczenie(System.DateTime.Now, System.DateTime.Now.AddDays(30),
                w2, o1);
            Zdarzenie z3 = new Oddanie(System.DateTime.Now.AddDays(15), w1, o2);
            Zdarzenie z4 = new Wypozyczenie(System.DateTime.Now, System.DateTime.Now.AddDays(30),
                w1, o3);

            dataRepository.AddZdarzenie(z1);
            dataRepository.AddZdarzenie(z2);
            Assert.AreEqual(2, data.zdarzenia.Count);
            Assert.AreSame(z1, data.zdarzenia[0]);

            dataRepository.AddZdarzenie(z3);
            dataRepository.AddZdarzenie(z4);
            Assert.AreEqual(4, data.zdarzenia.Count);
        }

        [TestMethod]
        public void TestMethodUpdate()
        {
            DataContext data = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(data, wypelnianieStalymi);

            Katalog k1 = new Katalog(1, "Lord Of The Rings");

            OpisStanu o1 = new OpisStanu(k1, false, "LOTR1");

            Assert.AreEqual(false, o1.CzyWypozyczona);
            dataRepository.UpdateOpisStanu(o1);
            Assert.AreNotEqual(false, o1.CzyWypozyczona);
        }

        [TestMethod]
        public void TestMethodGetKatalog()
        {
            DataContext data = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(data, wypelnianieStalymi);

            Katalog k1 = new Katalog(1, "Lord Of The Rings");

            dataRepository.AddKatalog(k1);
            Assert.AreEqual(k1, dataRepository.GetKatalog("Lord Of The Rings"));
            Assert.AreEqual(k1, dataRepository.GetKatalog(1));
        }

        [TestMethod]
        public void TestMethodGetWykaz()
        {
            DataContext data = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(data, wypelnianieStalymi);

            Wykaz w1 = new Wykaz(123, "Franek", "Duk");

            dataRepository.AddWykaz(w1);
            Assert.AreEqual(w1, dataRepository.GetWykaz(123));
        }

        [TestMethod]
        public void TestMethodGetOpisStanu()
        {
            DataContext data = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(data, wypelnianieStalymi);

            Katalog k1 = new Katalog(1, "Lord Of The Rings");

            OpisStanu o1 = new OpisStanu(k1, false, "LOTR1");

            dataRepository.AddOpisStanu(o1);
            Assert.AreEqual(o1, dataRepository.GetOpisStanu("LOTR1"));
        }

        [TestMethod]
        public void TestMethodGetAvailableBook()
        {
            DataContext data = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(data, wypelnianieStalymi);

            Katalog k1 = new Katalog(1, "Lord Of The Rings");

            OpisStanu o1 = new OpisStanu(k1, true, "LOTR1");
            OpisStanu o2 = new OpisStanu(k1, false, "LOTR2");

            dataRepository.AddKatalog(k1);
            dataRepository.AddOpisStanu(o1);
            dataRepository.AddOpisStanu(o2);

            Assert.AreNotEqual(o1, dataRepository.GetAvailableBook("Lord Of The Rings"));
            Assert.AreEqual(o2, dataRepository.GetAvailableBook("Lord Of The Rings"));
        }
    }
}

