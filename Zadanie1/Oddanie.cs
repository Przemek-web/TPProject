using System;
using System.Collections.Generic;

namespace Zadanie1
{
    public class Oddanie : Zdarzenie
    {
        private DateTime dataOddania;
        private Wykaz wykaz;
        private OpisStanu opisStanu;

        public Oddanie(DateTime dataOddania, Wykaz wykaz, OpisStanu opisStanu)
        {
            this.DataOddania = dataOddania;
            this.Wykaz = wykaz;
            this.OpisStanu = opisStanu;

            this.OpisStanu.CzyWypozyczona = false;
        }

        public DateTime DataOddania { get => dataOddania; set => dataOddania = value; }
        public Wykaz Wykaz { get => wykaz; set => wykaz = value; }
        public OpisStanu OpisStanu { get => opisStanu; set => opisStanu = value; }

        public override bool Equals(object obj)
        {
            return obj is Oddanie oddanie &&
                   DataOddania == oddanie.DataOddania &&
                   EqualityComparer<Wykaz>.Default.Equals(Wykaz, oddanie.Wykaz) &&
                   EqualityComparer<OpisStanu>.Default.Equals(OpisStanu, oddanie.OpisStanu);
        }

        public override int GetHashCode()
        {
            var hashCode = -1511708615;
            hashCode = hashCode * -1521134295 + DataOddania.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Wykaz>.Default.GetHashCode(Wykaz);
            hashCode = hashCode * -1521134295 + EqualityComparer<OpisStanu>.Default.GetHashCode(OpisStanu);
            return hashCode;
        }

        public override string ToString()
        {
            return "ODDANIE:  " + "Data oddania: " + DataOddania + ", " + Wykaz + ", " + OpisStanu;
        }
    }
}
