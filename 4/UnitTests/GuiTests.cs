using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;
using Service;
using System.Windows;
using DataLayer;

namespace UnitTests
{
    [TestClass]
    public class GuiTests
    {
        [TestMethod]
        public void ProductDetailsTest()
        {
            ProductDetails productDetails = new ProductDetails(new ProductService());
            Assert.IsNotNull(productDetails.DisplayMessage);
            Assert.IsNotNull(productDetails.AddItemToDataBase);
            Assert.IsNotNull(productDetails.Colors);
            Assert.IsNotNull(productDetails.Sizes);
            Assert.IsNotNull(productDetails.SizesUnits);
            Assert.IsNotNull(productDetails.WeightUnits);
            Assert.IsNotNull(productDetails.Flags);
            Assert.IsNotNull(productDetails.ProductLines);
            Assert.IsNotNull(productDetails.Classes);
            Assert.IsNotNull(productDetails.Styles);
            Assert.IsNotNull(productDetails.ProductSubCategories);
            Assert.IsNotNull(productDetails.ModelIds);
        }


        [TestMethod]
        public void ProductListTest()
        {
            ProductList productList = new ProductList(new ProductService());
            Assert.IsNotNull(productList.ProductService);
            Assert.IsNotNull(productList.Products);
            Assert.IsNotNull(productList.ActionText);
            Assert.IsNotNull(productList.DisplayAddWindow);
            Assert.IsNotNull(productList.RemoveEntity);
            Assert.IsNotNull(productList.DisplayDetails);
        }

        [TestMethod]
        public void Delete()
        {
            ProductList productList = new ProductList(new TestService());
            Assert.AreEqual(10, productList.products.Count);
            productList.products.RemoveAt(3);
            Assert.AreEqual(9, productList.products.Count);
        }

        [TestMethod]
        public void Add()
        {
            ProductList productList = new ProductList(new TestService());
            Assert.AreEqual(10, productList.products.Count);
            productList.products.Add(new Product());
            Assert.AreEqual(11, productList.products.Count);
        }
    }
}
