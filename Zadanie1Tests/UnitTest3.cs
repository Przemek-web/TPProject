using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zadanie1.Tests
{
    [TestClass()]
    public class TestWypelniania
    {
        [TestMethod()]
        public void Stale()
        {
            DataContext dataContext = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository repository = new DataRepository(dataContext,wypelnianieStalymi);
            Assert.AreEqual(0, dataContext.czytelnicy.Count);
            Assert.AreEqual(0, dataContext.egzemplarze.Count);
            Assert.AreEqual(0, dataContext.katalogi.Count);
            Assert.AreEqual(0, dataContext.zdarzenia.Count);

            repository.FillData();

            Assert.AreEqual(2, dataContext.czytelnicy.Count);
            Assert.AreEqual(5, dataContext.egzemplarze.Count);
            Assert.AreEqual(3, dataContext.katalogi.Count);
            Assert.AreEqual(5, dataContext.zdarzenia.Count);
        }


        [TestMethod()]
        public void Plik()
        {
            DataContext dataContext = new DataContext();
            WypelnianieZPliku wypelnianieZPliku = new WypelnianieZPliku();
            DataRepository repository = new DataRepository(dataContext, wypelnianieZPliku);
            Assert.AreEqual(0, dataContext.czytelnicy.Count);
            Assert.AreEqual(0, dataContext.egzemplarze.Count);
            Assert.AreEqual(0, dataContext.katalogi.Count);
            Assert.AreEqual(0, dataContext.zdarzenia.Count);

            repository.FillData();

            Assert.AreEqual(3, dataContext.czytelnicy.Count);
            Assert.AreEqual(6, dataContext.egzemplarze.Count);
            Assert.AreEqual(3, dataContext.katalogi.Count);
            Assert.AreEqual(3, dataContext.zdarzenia.Count);
        }
    }
}
