using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Katalog
    {
        private string nazwaKsiazki;
        private int klucz;

        public Katalog(int klucz, string nazwa)
        {
            this.Nazwa = nazwa;
            this.Klucz = klucz;

        }

        public string Nazwa { get => nazwaKsiazki; set => nazwaKsiazki = value; }
        public int Klucz { get => klucz; set => klucz = value; }

        public override bool Equals(object obj)
        {
            return obj is Katalog katalog &&
                   nazwaKsiazki == katalog.nazwaKsiazki &&
                   klucz == katalog.klucz;
        }

        public override int GetHashCode()
        {
            var hashCode = 1833528696;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nazwaKsiazki);
            hashCode = hashCode * -1521134295 + klucz.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return klucz + " " + nazwaKsiazki;
        }




    }
}
