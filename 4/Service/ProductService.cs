using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        public event MyHandler CollectionChanged;
        public void Create(Product product)
        {
            Task.Run(() =>
            {
                LinqUtility.AddProduct(product);
                CollectionChanged?.Invoke();
            });
        }

        public void Delete(int productId)
        {
            Task.Run(() =>
            {
                Product product = LinqUtility.GetProduct(productId);
                product.DiscontinuedDate = DateTime.Today;
                LinqUtility.UpdateProduct(product);
                CollectionChanged?.Invoke();
            });
        }

        public List<Product> GetAllProducts()
        {
            return LinqUtility.GetAllProducts().Where(product => !product.DiscontinuedDate.HasValue).ToList();
        }

        public int GetModelIDByName(string name)
        {
            return LinqUtility.SelectModelId(name);
        }

        public string GetModelNameByID(int id)
        {
            return LinqUtility.SelectModelName(id);
        }

        public List<string> GetProductClasses()
        {
            return LinqUtility.SelectDistinctClasses();
        }

        public List<string> GetProductColors()
        {
            return LinqUtility.SelectDistinctColors();
        }

        public List<string> GetProductLines()
        {
            return LinqUtility.SelectDistinctProductLines();
        }

        public List<string> GetProductModels()
        {
            return LinqUtility.SelectDistinctModels();
        }

        public List<string> GetProductSizes()
        {
            return LinqUtility.SelectDistinctSizes();
        }

        public List<string> GetProductStyles()
        {
            return LinqUtility.SelectDistinctStyles();
        }

        public List<string> GetProductSubcategories()
        {
            return LinqUtility.SelectDistinctSubcategories();
        }

        public List<string> GetSizeUnits()
        {
            return LinqUtility.SelectDistinctSizesUnits();
        }

        public int GetSubcategoryIDByName(string name)
        {
            return LinqUtility.SelectSubcategoryId(name);
        }

        public string GetSubcategoryNameByID(int id)
        {
            return LinqUtility.SelectSubcategoryName(id);
        }

        public List<string> GetWeightUnits()
        {
            return LinqUtility.SelectDistinctWeightUnits();
        }

        public void Insert(Product product)
        {
            Task.Run(() =>
            {
                if (LinqUtility.GetProduct(product.ProductID) != null)
                    LinqUtility.UpdateProduct(product);
                else
                    LinqUtility.AddProduct(product);

                CollectionChanged?.Invoke();
            });
        }

        public void Update(Product product)
        {
            Task.Run(() =>
            {
                LinqUtility.UpdateProduct(product);
                CollectionChanged?.Invoke();
            });
        }
    }
}
