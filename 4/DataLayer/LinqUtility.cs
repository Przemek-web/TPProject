using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LinqUtility
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

        public static void AddProduct(Product product)
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                product.ModifiedDate = DateTime.Today;
                product.rowguid = Guid.NewGuid();
                dataContext.Products.InsertOnSubmit(product);
                dataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
        }

        public static Product GetProduct(int productId)
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                try
                {
                    return dataContext.GetTable<Product>().Single(id => id.ProductID == productId);
                }
                catch
                {
                    return null;
                }
            }
        }

        public static int DeleteProduct(int productId)
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                var v = dataContext.GetTable<Product>().Single(id => id.ProductID == productId);
                dataContext.Products.DeleteOnSubmit(v);
                dataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
                if (v != null)
                {
                    return 0;
                }
            }
            return 1;
        }

        public static void UpdateProduct(Product product)
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                Product previousProduct = dataContext.GetTable<Product>().Single(id => id.ProductID == product.ProductID);
                previousProduct.Name = product.Name;
                previousProduct.ProductNumber = product.ProductNumber;
                previousProduct.MakeFlag = product.MakeFlag;
                previousProduct.FinishedGoodsFlag = product.FinishedGoodsFlag;
                previousProduct.Color = product.Color;
                previousProduct.SafetyStockLevel = product.SafetyStockLevel;
                previousProduct.ReorderPoint = product.ReorderPoint;
                previousProduct.StandardCost = product.StandardCost;
                previousProduct.ListPrice = product.ListPrice;
                previousProduct.Size = product.Size;
                previousProduct.SizeUnitMeasureCode = product.SizeUnitMeasureCode;
                previousProduct.WeightUnitMeasureCode = product.WeightUnitMeasureCode;
                previousProduct.Weight = product.Weight;
                previousProduct.DaysToManufacture = product.DaysToManufacture;
                previousProduct.ProductLine = product.ProductLine;
                previousProduct.Class = product.Class;
                previousProduct.Style = product.Style;
                previousProduct.ProductSubcategoryID = product.ProductSubcategoryID;
                previousProduct.ProductModelID = product.ProductModelID;
                previousProduct.SellStartDate = product.SellStartDate;
                previousProduct.SellEndDate = product.SellEndDate;
                previousProduct.DiscontinuedDate = product.DiscontinuedDate;
                previousProduct.ModifiedDate = DateTime.Today;
                dataContext.SubmitChanges();
            }
        }

        public static List<Product> GetAllProducts()
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                IQueryable<Product> products = (from product in dataContext.Products
                                                select product);
                return products.ToList();
            }
        }

        public static List<string> SelectDistinctSizesUnits()
        {
            List<string> results = new List<string>();
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                List<Product> products = dataContext.Products.GroupBy(x => x.SizeUnitMeasureCode).Select(y => y.First()).ToList();
                foreach (Product p in products)
                {
                    results.Add(p.SizeUnitMeasureCode);
                }
                return results;
            }
        }

        public static List<string> SelectDistinctWeightUnits()
        {
            List<string> results = new List<string>();
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                List<Product> products = dataContext.Products.GroupBy(x => x.WeightUnitMeasureCode).Select(y => y.First()).ToList();
                foreach (Product p in products)
                {
                    results.Add(p.WeightUnitMeasureCode);
                }
                return results;
            }
        }

        public static List<string> SelectDistinctProductLines()
        {
            List<string> results = new List<string>();
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                List<Product> products = dataContext.Products.GroupBy(x => x.ProductLine).Select(y => y.First()).ToList();
                foreach (Product p in products)
                {
                    results.Add(p.ProductLine);
                }
                return results;
            }
        }




        public static List<string> SelectDistinctClasses()
        {
            List<string> results = new List<string>();
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                List<Product> products = dataContext.Products.GroupBy(x => x.Class).Select(y => y.First()).ToList();
                foreach (Product p in products)
                {
                    results.Add(p.Class);
                }
                return results;
            }
        }

        public static List<string> SelectDistinctColors()
        {
            List<string> results = new List<string>();
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                List<Product> products = dataContext.Products.GroupBy(x => x.Color).Select(y => y.First()).ToList();
                foreach (Product p in products)
                {
                    results.Add(p.Color);
                }
                return results;
            }
        }

        public static List<string> SelectDistinctSizes()
        {
            List<string> results = new List<string>();
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                List<Product> products = dataContext.Products.GroupBy(x => x.Size).Select(y => y.First()).ToList();
                foreach (Product p in products)
                {
                    results.Add(p.Size);
                }
                return results;
            }
        }

        public static List<string> SelectDistinctStyles()
        {
            List<string> results = new List<string>();
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                List<Product> products = dataContext.Products.GroupBy(x => x.Style).Select(y => y.First()).ToList();
                foreach (Product p in products)
                {
                    results.Add(p.Style);
                }
                return results;
            }
        }



        public static int SelectSubcategoryId(string subcategoryName)
        {
            if (subcategoryName == null)
                return 0;
            int query = 0;
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                query = (from product in dataContext.Products
                         where product.ProductSubcategory.Name == subcategoryName
                         select product.ProductSubcategory.ProductSubcategoryID).First();
                return query;
            }
        }


        public static int SelectModelId(string modelName)
        {
            if (modelName == null)
                return 0;
            int query = 0;
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                query = (from product in dataContext.Products
                         where product.ProductModel.Name == modelName
                         select product.ProductModel.ProductModelID).First();
                return query;
            }
        }




        public static string SelectSubcategoryName(int? subcategoryName)
        {
            if (subcategoryName == 0)
                return "";
            string query = "";
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                query = (from product in dataContext.Products
                         where product.ProductSubcategoryID == subcategoryName
                         select product.ProductSubcategory.Name).First();
                return query;
            }
        }


        public static string SelectModelName(int? modelName)
        {
            if (modelName == 0)
                return "";
            string query = "";
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                query = (from product in dataContext.Products
                         where product.ProductModelID == modelName
                         select product.ProductModel.Name).First();
                return query;
            }
        }

        public static List<string> SelectDistinctSubcategories()
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                List<string> query = (from product in dataContext.Products
                                      where product.ProductSubcategory != null
                                      select product.ProductSubcategory.Name).Distinct().ToList();
                return query;
            }
        }




        public static List<string> SelectDistinctModels()
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                List<string> query = (from product in dataContext.Products
                                      where product.ProductModel != null
                                      select product.ProductModel.Name).Distinct().ToList();
                return query;
            }
        }
    }
}



