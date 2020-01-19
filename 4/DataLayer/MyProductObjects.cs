using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MyProductObjects
    {
        private List<MyProduct> myProducts;

        public MyProductObjects()
        {
            DataClassesDataContext dataContext = new DataClassesDataContext();
            this.myProducts = new List<MyProduct>();
            foreach (Product product in dataContext.Products.ToList())
            {
                MyProduct myProduct = new MyProduct(product);
                myProducts.Add(myProduct);
            }
        }
        public List<MyProduct> MyProducts { get => myProducts; set => myProducts = value; }
    }
}
