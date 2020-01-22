using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using DataLayer;

namespace UnitTests
{
    [TestClass]
    public class LinqTests
    {
        [TestMethod()]
        public void GetProductsByNameTest()
        {
            List<Product> query = Methods.GetProductsByName("Chain");
            Assert.AreEqual(query.Count, 5);
        }

        [TestMethod()]
        public void GetProductsByVendorNameTest()
        {
            List<Product> query = Methods.GetProductsByVendorName("Speed Corporation");
            Assert.AreEqual(query.Count, 9);
        }

        [TestMethod()]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> query = Methods.GetProductNamesByVendorName("Speed Corporation");
            Assert.AreEqual(query.Count, 9);
        }

        [TestMethod()]
        public void GetProductVendorByProductName()
        {
            string query = Methods.GetProductVendorByProductName("Bearing Ball");
            Assert.AreEqual(query, "Wood Fitness");
        }

        [TestMethod()]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> products = Methods.GetProductsWithNRecentReviews(10);
            Assert.AreEqual(products.Count, 4);
        }

        [TestMethod()]
        public void GetNRecentlyReviewedProducts()
        {
            List<Product> products = Methods.GetNRecentlyReviewedProducts(10);
            Assert.AreEqual(products.Count, 4);
        }

        [TestMethod()]
        public void GetNProductsFromCategory()
        {
            List<Product> products = Methods.GetNProductsFromCategory("Bikes", 5);
            Assert.AreEqual(products.Count, 5);
        }

        [TestMethod()]
        public void GetTotalStandardCostByCategory()
        {
            ProductCategory bikes = new ProductCategory
            {
                ProductCategoryID = 1
            };
            Assert.AreEqual(29880, Methods.GetTotalStandardCostByCategory(bikes));
        }

        [TestMethod]
        public void TestMethod1()
        {
            DataClassesDataContext dataContext = new DataClassesDataContext();
            List<Product> produkty = dataContext.Products.ToList();
            Assert.AreEqual(produkty.produktyBezKategoriiROZSZERZAJĄCA().Count, produkty.produktyBezKategoriiFROM().Count);
            Assert.AreEqual(Extensions.PodzielNaStrony(produkty, 5, 10)[0].Count, 5);
        }
    }
}