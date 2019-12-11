using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public static class Etap4
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
            (produkt,dostawca) => produkt.Name + " - " + dostawca.Vendor.Name + "\n").ToList();

            foreach(var z in zapytanie)
            {
                s = s + z.ToString(); 
            }
            return s;
        }




    }
}
