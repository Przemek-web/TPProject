using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClassesDataContext db = new DataClassesDataContext();
            List<Product> query = Etap3.GetProductsByName("Chain");
            Console.WriteLine(query.Count);

            List<Product> zob = Etap3.GetProductsByVendorName("Speed Corporation");
            Console.WriteLine(zob.Count);

            List<string> trzy = Etap3.GetProductNamesByVendorName("Speed Corporation");
            Console.WriteLine(trzy.Count);


            Console.WriteLine(Etap3.GetProductVendorByProductName("Bearing Ball"));
            List<Product> products = Etap3.GetProductsWithNRecentReviews(10);
            Console.WriteLine(products.Count);


            List<Product> prod = Etap3.GetNRecentlyReviewedProducts(10);
            Console.WriteLine(prod.Count);

            ProductCategory Clothing = new ProductCategory
            {
                ProductCategoryID = 1
            };

            int test = Etap3.GetTotalStandardCostByCategory(Clothing);
            Console.WriteLine(test);
        }
    }
}
