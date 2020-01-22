using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Service;

namespace UnitTests
{
    class TestService : IProductService
    {
        public event MyHandler CollectionChanged;
        private List<Product> products;

        public TestService()
        {
            products = new List<Product>();

            for (int i = 0; i < 10; i++)
            {
                Product product = new Product();
                product.Name = "Test" + i.ToString();
                products.Add(product);
            }
        }

        public void Create(Product product)
        {
            products.Add(product);
        }

        public void Delete(int productId)
        {
            foreach (Product product in products)
            {
                if (product.ProductID.Equals(productId)) products.Remove(product);
            };
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public int GetModelIDByName(string name)
        {
            throw new NotImplementedException();
        }

        public string GetModelNameByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetProductClasses()
        {
            throw new NotImplementedException();
        }

        public List<string> GetProductColors()
        {
            throw new NotImplementedException();
        }

        public List<string> GetProductLines()
        {
            throw new NotImplementedException();
        }

        public List<string> GetProductModels()
        {
            throw new NotImplementedException();
        }

        public List<string> GetProductSizes()
        {
            throw new NotImplementedException();
        }

        public List<string> GetProductStyles()
        {
            throw new NotImplementedException();
        }

        public List<string> GetProductSubcategories()
        {
            throw new NotImplementedException();
        }

        public List<string> GetSizeUnits()
        {
            throw new NotImplementedException();
        }

        public int GetSubcategoryIDByName(string name)
        {
            throw new NotImplementedException();
        }

        public string GetSubcategoryNameByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetWeightUnits()
        {
            throw new NotImplementedException();
        }

        public void Insert(Product product)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
