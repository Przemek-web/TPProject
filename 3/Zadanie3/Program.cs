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
            List<Product> produkty = dataContext.Products.ToList();
            List<ProductVendor> dostawcy = dataContext.ProductVendors.ToList();
            string[] s1 = produkty.LancuchZnakowROZSZERZAJĄCA(dostawcy).Split('\n');
            //for (int i= 0;i < s1.Count();i++)
            //{
            //    Console.WriteLine(s1[i]);
            //}
            //  List<Product> products = Etap3.GetNProductsFromCategory("Bikes", 5);
            //   foreach (Product product in products)
            //   {
            //       Console.Write(product.Name);
            //   }
            
           foreach(List<Product> products in Etap4.PodzielNaStrony(produkty,5,10)){
                Console.WriteLine(products.Count);
            }
     
            
        }
    }
}
