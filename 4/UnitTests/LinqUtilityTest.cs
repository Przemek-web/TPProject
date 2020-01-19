using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class LinqUtilityTest
    {
        [TestMethod()]
        public void GetProductsByNameTest()
        {
            List<Product> query = LinqUtility.GetProductsByName("Chain");
            Assert.AreEqual(query.Count, 5);
        }

        [TestMethod()]
        public void GetProductsByVendorNameTest()
        {
            List<Product> query = LinqUtility.GetProductsByVendorName("Speed Corporation");
            Assert.AreEqual(query.Count, 9);
        }

        [TestMethod()]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> query = LinqUtility.GetProductNamesByVendorName("Speed Corporation");
            Assert.AreEqual(query.Count, 9);
        }

        [TestMethod()]
        public void GetProductVendorByProductName()
        {
            string query = LinqUtility.GetProductVendorByProductName("Bearing Ball");
            Assert.AreEqual(query, "Wood Fitness");
        }

        [TestMethod()]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> products = LinqUtility.GetProductsWithNRecentReviews(10);
            Assert.AreEqual(products.Count, 4);
        }

        [TestMethod()]
        public void GetNRecentlyReviewedProducts()
        {
            List<Product> products = LinqUtility.GetNRecentlyReviewedProducts(10);
            Assert.AreEqual(products.Count, 4);
        }

        [TestMethod()]
        public void GetNProductsFromCategory()
        {
            List<Product> products = LinqUtility.GetNProductsFromCategory("Bikes", 5);
            Assert.AreEqual(products.Count, 5);
        }

        [TestMethod()]
        public void GetTotalStandardCostByCategory()
        {
            ProductCategory bikes = new ProductCategory
            {
                ProductCategoryID = 1
            };
            Assert.AreEqual(29880, LinqUtility.GetTotalStandardCostByCategory(bikes));
        }

        [TestMethod]
        public void TestMethod1()
        {
            DataClassesDataContext dataContext = new DataClassesDataContext();
            List<Product> produkty = dataContext.Products.ToList();
            Assert.AreEqual(produkty.produktyBezKategoriiROZSZERZAJĄCA().Count, produkty.produktyBezKategoriiFROM().Count);
            Assert.AreEqual(LinqExtensions.PodzielNaStrony(produkty, 5, 10)[0].Count, 5);
        }
    }
}
