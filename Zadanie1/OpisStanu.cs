using System.Collections.Generic;

namespace Zadanie1
{
    class OpisStanu
    {
        private Katalog katalog;
        private bool czyWypozyczona;
        private string pozycjaKatalogowa;

        public OpisStanu(Katalog katalog, bool czyWypozyczona, string pozycjaKatalogowa)
        {
            this.katalog = katalog;
            this.czyWypozyczona = czyWypozyczona;
            this.pozycjaKatalogowa = pozycjaKatalogowa;
        }

        public bool CzyWypozyczona { get => czyWypozyczona; set => czyWypozyczona = value; }
        public string PozycjaKatalogowa { get => pozycjaKatalogowa; set => pozycjaKatalogowa = value; }
        internal Katalog Katalog { get => katalog; set => katalog = value; }

        public override bool Equals(object obj)
        {
            return obj is OpisStanu stanu &&
                   EqualityComparer<Katalog>.Default.Equals(katalog, stanu.katalog) &&
                   czyWypozyczona == stanu.czyWypozyczona &&
                   pozycjaKatalogowa == stanu.pozycjaKatalogowa;
        }

        public override int GetHashCode()
        {
            var hashCode = 1745975141;
            hashCode = hashCode * -1521134295 + EqualityComparer<Katalog>.Default.GetHashCode(katalog);
            hashCode = hashCode * -1521134295 + czyWypozyczona.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(pozycjaKatalogowa);
            return hashCode;
        }

        public override string ToString()
        {
            return Katalog + " " + PozycjaKatalogowa + " " + CzyWypozyczona;
        }
    }
}
