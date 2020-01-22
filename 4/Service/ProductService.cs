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
                Methods.AddProduct(product);
                CollectionChanged?.Invoke();
            });
        }

        public void Delete(int productId)
        {
            Task.Run(() =>
            {
                Product product = Methods.GetProduct(productId);
                product.DiscontinuedDate = DateTime.Today;
                Methods.UpdateProduct(product);
                CollectionChanged?.Invoke();
            });
        }

        public List<Product> GetAllProducts()
        {
            return Methods.GetAllProducts().Where(product => !product.DiscontinuedDate.HasValue).ToList();
        }

        public int GetModelIDByName(string name)
        {
            return Methods.SelectModelId(name);
        }

        public string GetModelNameByID(int id)
        {
            return Methods.SelectModelName(id);
        }

        public List<string> GetProductClasses()
        {
            return Methods.SelectDistinctClasses();
        }

        public List<string> GetProductColors()
        {
            return Methods.SelectDistinctColors();
        }

        public List<string> GetProductLines()
        {
            return Methods.SelectDistinctProductLines();
        }

        public List<string> GetProductModels()
        {
            return Methods.SelectDistinctModels();
        }

        public List<string> GetProductSizes()
        {
            return Methods.SelectDistinctSizes();
        }

        public List<string> GetProductStyles()
        {
            return Methods.SelectDistinctStyles();
        }

        public List<string> GetProductSubcategories()
        {
            return Methods.SelectDistinctSubcategories();
        }

        public List<string> GetSizeUnits()
        {
            return Methods.SelectDistinctSizesUnits();
        }

        public int GetSubcategoryIDByName(string name)
        {
            return Methods.SelectSubcategoryId(name);
        }

        public string GetSubcategoryNameByID(int id)
        {
            return Methods.SelectSubcategoryName(id);
        }

        public List<string> GetWeightUnits()
        {
            return Methods.SelectDistinctWeightUnits();
        }

        public void Insert(Product product)
        {
            Task.Run(() =>
            {
                if (Methods.GetProduct(product.ProductID) != null)
                    Methods.UpdateProduct(product);
                else
                    Methods.AddProduct(product);

                CollectionChanged?.Invoke();
            });
        }

        public void Update(Product product)
        {
            Task.Run(() =>
            {
                Methods.UpdateProduct(product);
                CollectionChanged?.Invoke();
            });
        }
    }
}