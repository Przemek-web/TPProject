using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;

namespace Zadanie3Test
{
    [TestClass]
    public class Etap3Test
    {
        
        
        [TestMethod()]
        public void GetProductsByNameTest()
        {
            DataClassesDataContext db = new DataClassesDataContext();
            List<Product> query = Etap3.GetProductsByName("Decal");

            List<Product> check = new List<Product>();
            Product C = (from p in db.Product where p.ProductID == 325 select p).First();
            check.Add(C);
            C = (from p in db.Product where p.ProductID == 326 select p).First();
            check.Add(C);

            for (int i = 0; i < query.Count(); i++)
            {
                if (query[i].ProductID != check[i].ProductID) Assert.Fail();
                if (query[i].Name != check[i].Name) Assert.Fail();
            }
            if (query.Count() != check.Count()) Assert.Fail();
        }
    }
}
