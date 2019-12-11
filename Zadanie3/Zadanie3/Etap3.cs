using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class Etap3
    {

        public static List<Product> GetProductsByName(string namePart)
        {
            DataClassesDataContext datacontext = new DataClassesDataContext();
            List<Product> query =
                (from product in datacontext.Product
                 where product.Name.Contains(namePart)
                 select product).ToList();

            return query;
        }



        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            DataClassesDataContext dataContext = new DataClassesDataContext();
            List<Product> query = (from product in dataContext.ProductVendor
                                   where product.Vendor.Name.Equals(vendorName)
                                   select product.Product).ToList();

            return query;
       }


        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            DataClassesDataContext dataContext = new DataClassesDataContext();
            List<string> query = (from product in dataContext.ProductVendor
                                  where product.Vendor.Name.Equals(vendorName)
                                  select product.Vendor.Name).ToList();
            return query;
        }


        public static string GetProductVendorByProductName(string productName)
        {
            DataClassesDataContext dataContext = new DataClassesDataContext();
            string query = (from product in dataContext.ProductVendor
                            where product.Product.Name.Equals(productName)
                            select product.Vendor.Name).First();
            return query;
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {

            DataClassesDataContext dataContext = new DataClassesDataContext();
            List<Product> query = (from reviews in dataContext.ProductReview
                                   join tab in dataContext.Product on reviews.ProductID equals tab.ProductID
                                   select tab).Take(howManyReviews).ToList<Product>();

            return query;
        }
        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            
            DataClassesDataContext dataContext = new DataClassesDataContext();
            List<Product> query =      (from product in dataContext.Product
                                        join tab in dataContext.ProductReview on product.ProductID equals tab.ProductID
                                        orderby tab.ReviewDate
                                        select product).Take(howManyProducts).ToList<Product>();

            return query;
        }

    }
}
