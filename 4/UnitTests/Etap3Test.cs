using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;

namespace UnitTests
{
    [TestClass]
    public class Etap3Test
    {
        [TestMethod()]
        public void GetProductsByNameTest()
        {
            List<Product> query = Etap3.GetProductsByName("Chain");
            Assert.AreEqual(query.Count, 5);
        }

        [TestMethod()]
        public void GetProductsByVendorNameTest()
        {
            List<Product> query = Etap3.GetProductsByVendorName("Speed Corporation");
            Assert.AreEqual(query.Count, 9);
        }

        [TestMethod()]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> query = Etap3.GetProductNamesByVendorName("Speed Corporation");
            Assert.AreEqual(query.Count, 9);
        }

        [TestMethod()]
        public void GetProductVendorByProductName()
        {
            string query = Etap3.GetProductVendorByProductName("Bearing Ball");
            Assert.AreEqual(query, "Wood Fitness");
        }

        [TestMethod()]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> products = Etap3.GetProductsWithNRecentReviews(10);
            Assert.AreEqual(products.Count, 4);
        }

        [TestMethod()]
        public void GetNRecentlyReviewedProducts()
        {
            List<Product> products = Etap3.GetNRecentlyReviewedProducts(10);
            Assert.AreEqual(products.Count, 4);
        }

        [TestMethod()]
        public void GetNProductsFromCategory()
        {
            List<Product> products = Etap3.GetNProductsFromCategory("Bikes", 5);
            Assert.AreEqual(products.Count, 5);
        }

        [TestMethod()]
        public void GetTotalStandardCostByCategory()
        {
            ProductCategory bikes = new ProductCategory
            {
                ProductCategoryID = 1
            };
            Assert.AreEqual(29880, Etap3.GetTotalStandardCostByCategory(bikes));
        }
    }
}
