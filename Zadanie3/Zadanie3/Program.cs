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
           

            DataClassesDataContext dataContext = new DataClassesDataContext();
            List<Product> produkty = dataContext.Product.ToList();
            List<ProductVendor> dostawcy = dataContext.ProductVendor.ToList();
            string[] s1 = produkty.LancuchZnakowROZSZERZAJĄCA(dostawcy).Split('\n');
            //for (int i= 0;i < s1.Count();i++)
            //{
            //    Console.WriteLine(s1[i]);
            //}
            List<Product> products = Etap3.GetNProductsFromCategory("Bikes", 5);
            foreach(Product product in products)
            {
                Console.Write(product.Name);
            }

        }
    }
}
