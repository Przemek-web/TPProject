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
            using (DataClassesDataContext datacontext = new DataClassesDataContext())
            {
                List<Product> query =
                    (from product in datacontext.Products
                     where product.Name.Contains(namePart)
                     select product).ToList();

                return query;
            }
        }



        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                List<Product> query = (from product in dataContext.ProductVendors
                                       where product.Vendor.Name.Equals(vendorName)
                                       select product.Product).ToList();

                return query;
            }
        }


        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                List<string> query = (from product in dataContext.ProductVendors
                                      where product.Vendor.Name.Equals(vendorName)
                                      select product.Vendor.Name).ToList();
                return query;
            }
        }


        public static string GetProductVendorByProductName(string productName)
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                string query = (from product in dataContext.ProductVendors
                                where product.Product.Name.Equals(productName)
                                select product.Vendor.Name).First();
                return query;
            }
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {

            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                List<Product> query = (from reviews in dataContext.ProductReviews
                                       join tab in dataContext.Products on reviews.ProductID equals tab.ProductID
                                       select tab).Take(howManyReviews).ToList<Product>();

                return query;
            }
        }
        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {

            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                List<Product> query = (from product in dataContext.Products
                                       join tab in dataContext.ProductReviews on product.ProductID equals tab.ProductID
                                       orderby tab.ReviewDate
                                       select product).Take(howManyProducts).ToList<Product>();

                return query;
            }
        }


        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                List<Product> query = (from product in dataContext.Products
                                       join tab in dataContext.ProductCategories on product.ProductSubcategoryID equals tab.ProductCategoryID
                                       where tab.Name == categoryName
                                       // SPRAWDZIC TO CO NIZEJ
                                       orderby tab.Name
                                       select product).Take(n).ToList();
                return query;
            }
        }

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                decimal query = (from product in dataContext.Products
                                 where (product.ProductSubcategoryID == category.ProductCategoryID)
                                 select product.StandardCost).ToList().Sum();

                return (int)query;
            }
        }
    }
}
