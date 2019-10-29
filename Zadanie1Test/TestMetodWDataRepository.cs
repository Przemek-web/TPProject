using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;
 

namespace Zadanie1Test
{
    [TestClass]
    public class TestMetodWDataRepository
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataContext data = new DataContext();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            Zadanie1.DataRepository dataRepository = new Zadanie1.DataRepository(data, wypelnianieStalymi);
            
            
        }
    }
}
