using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class Etap4Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataClassesDataContext dataContext = new DataClassesDataContext();
            List<Product> produkty = dataContext.Products.ToList();
            Assert.AreEqual(produkty.produktyBezKategoriiROZSZERZAJĄCA().Count, produkty.produktyBezKategoriiFROM().Count);
            Assert.AreEqual(Etap4.PodzielNaStrony(produkty, 5, 10)[0].Count, 5);
        }
    }
}
