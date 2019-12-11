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
            DataClassesDataContext db = new DataClassesDataContext();
            List<Product> query =
                (from p in db.Product
                 where SqlMethods.Like(p.Name, "%" + namePart + "%")
                 select p).ToList();

            return query;
        }
    }
}
