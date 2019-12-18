using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;

namespace Zadanie3Test
{
    [TestClass]
    public class Etap4Test
    {
        [TestMethod]
        public void TestMethod1()
        {

            DataClassesDataContext dataContext = new DataClassesDataContext();
            List<Product> produkty = dataContext.Product.ToList();
           
            Assert.AreEqual(produkty.produktyBezKategoriiROZSZERZAJĄCA().Count, produkty.produktyBezKategoriiFROM().Count);

            Assert.AreEqual(Etap4.PodzielNaStrony(produkty, 5, 10)[0].Count, 5);
            
        }
    }
}
