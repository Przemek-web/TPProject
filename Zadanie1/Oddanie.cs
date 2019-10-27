using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Oddanie : Zdarzenie
    {
        private DateTime dataOddania;
        private Wykaz wykaz;
        private OpisStanu opisStanu;

        public Oddanie(DateTime dataOddania, Wykaz wykaz, OpisStanu opisStanu)
        {
            this.dataOddania = dataOddania;
            this.wykaz = wykaz;
            this.opisStanu = opisStanu;

            this.opisStanu.CzyWypozyczona = false;
        }

        public override bool Equals(object obj)
        {
            return obj is Oddanie oddanie &&
                   dataOddania == oddanie.dataOddania &&
                   EqualityComparer<Wykaz>.Default.Equals(wykaz, oddanie.wykaz) &&
                   EqualityComparer<OpisStanu>.Default.Equals(opisStanu, oddanie.opisStanu);
        }

        public override int GetHashCode()
        {
            var hashCode = -1511708615;
            hashCode = hashCode * -1521134295 + dataOddania.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Wykaz>.Default.GetHashCode(wykaz);
            hashCode = hashCode * -1521134295 + EqualityComparer<OpisStanu>.Default.GetHashCode(opisStanu);
            return hashCode;
        }
    }
}
