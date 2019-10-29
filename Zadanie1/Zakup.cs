using System;
using System.Collections.Generic;

namespace Zadanie1
{
    public class Zakup : Zdarzenie
    {
        private string nazwa;
        private string pozycjaKatalogowa;
        private DateTime dataZakupu;

        public Zakup(string nazwa, string pozycjaKatalogowa, DateTime dataZakupu)
        {
            this.Nazwa = nazwa;
            this.PozycjaKatalogowa = pozycjaKatalogowa;
            this.DataZakupu = dataZakupu;
        }

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public string PozycjaKatalogowa { get => pozycjaKatalogowa; set => pozycjaKatalogowa = value; }
        public DateTime DataZakupu { get => dataZakupu; set => dataZakupu = value; }

        public override bool Equals(object obj)
        {
            return obj is Zakup zakup &&
                   nazwa == zakup.nazwa &&
                   pozycjaKatalogowa == zakup.pozycjaKatalogowa &&
                   dataZakupu == zakup.dataZakupu;
        }

        public override int GetHashCode()
        {
            var hashCode = 1262452884;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nazwa);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(pozycjaKatalogowa);
            hashCode = hashCode * -1521134295 + dataZakupu.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Zakup: " + "Nazwa ksiązki: " + Nazwa + ", " + "Pozycja katalogowa: " + PozycjaKatalogowa + ", " + "Data zakupu: " + DataZakupu;
        }
    }
}
