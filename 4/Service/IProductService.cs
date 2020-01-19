using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace Service
{
    public interface IProductService
    {
        event MyHandler CollectionChanged;
        void Create(Product product);
        void Insert(Product product);
        void Update(Product product);
        void Delete(int productId);

        List<Product> GetAllProducts();
        List<string> GetWeightUnits();
        List<string> GetProductLines();
        List<string> GetProductClasses();
        List<string> GetProductStyles();
        List<string> GetProductColors();
        List<string> GetProductSubcategories();
        List<string> GetProductModels();
        List<string> GetProductSizes();

        List<string> GetSizeUnits();
        int GetModelIDByName(string name);
        string GetSubcategoryNameByID(int id);
        int GetSubcategoryIDByName(string name);

        string GetModelNameByID(int id);
    }
    public delegate void MyHandler();
}
