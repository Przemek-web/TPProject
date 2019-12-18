using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;

namespace Zadanie3Test
{
    [TestClass]
    public class Etap5Test
    {
        [TestMethod]
        public void TestMethods()
        {
            List<MyProduct> query = Etap5.GetMyProductsByName("Chain");
            Assert.AreEqual(query.Count, 5);

            List<MyProduct> query2 = Etap5.GetNMyProductsFromCategory("Bikes", 5);
            Assert.AreEqual(query2.Count, 5);

            List<MyProduct> query3 = Etap5.GetMyProductsWithNRecentReviews(1);
            Assert.AreEqual(query3.Count, 2);

            
        }

       


    }
}
