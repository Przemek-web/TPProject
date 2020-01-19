using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class LinqExtensions
    {
        public static List<Product> produktyBezKategoriiFROM(this List<Product> lista)
        {
            List<Product> wynik = (from produkt in lista
                                   where produkt.ProductSubcategoryID == null
                                   select produkt).ToList();
            return wynik;
        }

        public static List<Product> produktyBezKategoriiROZSZERZAJĄCA(this List<Product> lista)
        {
            List<Product> wynik;
            wynik = lista.Where(produkt => produkt.ProductSubcategoryID == null).ToList();
            return wynik;
        }

        public static String LancuchZnakowROZSZERZAJĄCA(this List<Product> produkty, List<ProductVendor> dostawcy)
        {

            String s = "";
            var zapytanie = produkty.Join(dostawcy, produkt => produkt.ProductID, dostawca => dostawca.ProductID,
            (produkt, dostawca) => produkt.Name + " - " + dostawca.Vendor.Name + "\n").ToList();

            foreach (var z in zapytanie)
            {
                s = s + z.ToString();
            }
            return s;
        }

        public static List<List<Product>> PodzielNaStrony(this List<Product> produkty, int liczbaProduktow, int liczbaStron)
        {
            List<List<Product>> strony = new List<List<Product>>();
            List<Product> strona = new List<Product>();
            for (int i = 0; i < liczbaStron; i++)
            {
                strona = produkty.Skip(liczbaProduktow * i).Take(liczbaProduktow).ToList();
                strony.Add(strona);
            }
            return strony;
        }
    }
}
