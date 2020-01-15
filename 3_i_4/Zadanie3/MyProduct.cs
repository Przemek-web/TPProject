using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MyProduct : Product
    {
        public MyProduct(Product product)
        {
            foreach (PropertyInfo propertyInfo in product.GetType().GetProperties())
            {
                if (propertyInfo.CanWrite) propertyInfo.SetValue(this, propertyInfo.GetValue(product));
            }
        }
    }
}
