using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class Etap5
    {
        public static List<MyProduct> GetMyProductsByName(string namePart)
        {
            MyProductObjects myProductObjects = new MyProductObjects();
            return myProductObjects.MyProducts.Where(product => product.Name.Contains(namePart)).ToList();
        }

        public static List<MyProduct> GetNMyProductsFromCategory(string categoryName, int n)
        {
            MyProductObjects myProductObjects = new MyProductObjects();
            return (from myproduct in myProductObjects.MyProducts
                    where myproduct.ProductSubcategory != null && myproduct.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                    select myproduct).Take(n).ToList();

        }


        public static List<MyProduct> GetMyProductsWithNRecentReviews(int howManyReviews)
        {
            MyProductObjects myProductObjects = new MyProductObjects();
            return myProductObjects.MyProducts.Where(product => product.ProductReviews.Count.Equals(howManyReviews)).ToList();
           

            
        }
    }
}
