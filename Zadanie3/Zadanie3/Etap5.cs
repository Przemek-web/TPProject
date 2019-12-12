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

        public static List<MyProduct> GetMyProductWithNRecentReviews(int howManyReviews)
        {
            MyProductObjects myProductObjects = new MyProductObjects();
            return myProductObjects.MyProducts.Where(product => product.ProductReview.Count == howManyReviews).ToList();
        }

        public static List<MyProduct> GetNRecentlyReviewedMyProducts(string categoryName, int n)
        {
            MyProductObjects myProductObjects = new MyProductObjects();
            return myProductObjects.MyProducts.Where(product => product.ProductSubcategory.Name == categoryName).OrderBy(p => p.Name).Take(n).ToList();
        }
    }
}
