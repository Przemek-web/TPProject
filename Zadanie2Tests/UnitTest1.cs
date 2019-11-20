using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;
using Zadanie1.Tests;
using Zadanie2;

namespace Zadanie2Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void JSON()
        {
            DataContext data1 = new DataContext();
            WypelnianieStalymi stale1 = new WypelnianieStalymi();
            DataRepository repository1 = new DataRepository(data1, stale1);
            repository1.FillData();
            DataService service1 = new DataService(repository1);

            DataContext data2 = new DataContext();
            PusteWypelnienie pusteWypelnienie = new PusteWypelnienie();
            DataRepository repository2 = new DataRepository(data2, pusteWypelnienie);
            repository2.FillData();
            DataService service2 = new DataService(repository2);
            
            
            SerializationJSON serialization = new SerializationJSON();
           

            
            serialization.SerializeJSON(repository1);
            

           



            Assert.AreEqual(0, data2.czytelnicy.Count);
            Assert.AreEqual(0, data2.katalogi.Count);
            Assert.AreEqual(0, data2.egzemplarze.Count);
            Assert.AreEqual(0, data2.zdarzenia.Count);


            DeserializationJSON deserialization = new DeserializationJSON();
            deserialization.DeserializeJSON(data2);



            Assert.AreEqual(2, data2.czytelnicy.Count);
            Assert.AreEqual(3, data2.katalogi.Count);
            Assert.AreEqual(5, data2.egzemplarze.Count);
            Assert.AreEqual(5, data2.zdarzenia.Count);

        }
    }
}
