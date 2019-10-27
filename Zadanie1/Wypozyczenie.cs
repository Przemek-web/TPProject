using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Wypozyczenie : Zdarzenie
    {
        private DateTime dataWypozyczenia;
        private DateTime dataOddania;
        private Wykaz wykaz;
        private OpisStanu opisStanu;

        public Wypozyczenie(DateTime dataWypozyczenia, DateTime dataOddania, Wykaz wykaz, OpisStanu opisStanu)
        {
            this.dataWypozyczenia = dataWypozyczenia;
            this.dataOddania = dataOddania;
            this.wykaz = wykaz;
            this.opisStanu = opisStanu;

            this.opisStanu.CzyWypozyczona = true;
        }

        public override bool Equals(object obj)
        {
            return obj is Wypozyczenie wypozyczenie &&
                   dataWypozyczenia == wypozyczenie.dataWypozyczenia &&
                   dataOddania == wypozyczenie.dataOddania &&
                   EqualityComparer<Wykaz>.Default.Equals(wykaz, wypozyczenie.wykaz) &&
                   EqualityComparer<OpisStanu>.Default.Equals(opisStanu, wypozyczenie.opisStanu);
        }

        public override int GetHashCode()
        {
            var hashCode = 622673726;
            hashCode = hashCode * -1521134295 + dataWypozyczenia.GetHashCode();
            hashCode = hashCode * -1521134295 + dataOddania.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Wykaz>.Default.GetHashCode(wykaz);
            hashCode = hashCode * -1521134295 + EqualityComparer<OpisStanu>.Default.GetHashCode(opisStanu);
            return hashCode;
        }
    }
}
