using System;
using System.Collections.Generic;

namespace Zadanie1
{
    public class Wypozyczenie : Zdarzenie
    {
        private DateTime dataWypozyczenia;
        private DateTime dataOddania;
        private Wykaz wykaz;
        private OpisStanu opisStanu;

        public Wypozyczenie(DateTime dataWypozyczenia, DateTime dataOddania, Wykaz wykaz, OpisStanu opisStanu)
        {
            this.DataWypozyczenia = dataWypozyczenia;
            this.DataOddania = dataOddania;
            this.Wykaz = wykaz;
            this.OpisStanu = opisStanu;
        }


        public DateTime DataWypozyczenia { get => dataWypozyczenia; set => dataWypozyczenia = value; }
        public DateTime DataOddania { get => dataOddania; set => dataOddania = value; }
        public Wykaz Wykaz { get => wykaz; set => wykaz = value; }
        public OpisStanu OpisStanu { get => opisStanu; set => opisStanu = value; }

        public override bool Equals(object obj)
        {
            return obj is Wypozyczenie wypozyczenie &&
                   DataWypozyczenia == wypozyczenie.DataWypozyczenia &&
                   DataOddania == wypozyczenie.DataOddania &&
                   EqualityComparer<Wykaz>.Default.Equals(Wykaz, wypozyczenie.Wykaz) &&
                   EqualityComparer<OpisStanu>.Default.Equals(OpisStanu, wypozyczenie.OpisStanu);
        }

       

        public override int GetHashCode()
        {
            var hashCode = 622673726;
            hashCode = hashCode * -1521134295 + DataWypozyczenia.GetHashCode();
            hashCode = hashCode * -1521134295 + DataOddania.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Wykaz>.Default.GetHashCode(Wykaz);
            hashCode = hashCode * -1521134295 + EqualityComparer<OpisStanu>.Default.GetHashCode(OpisStanu);
            return hashCode;
        }

        public DateTime GetStartDate()
        {
            return DataWypozyczenia;
        }

        public Wykaz GetWykaz()
        {
            return Wykaz;
        }

        public override string ToString()
        {
            return "WYPOŻYCZENIE:  " + " Data wypożyczenia: " + DataWypozyczenia + ", " + "Data oddania: " + DataOddania + ", " 
                +  Wykaz + ", " + OpisStanu;
        }
    }
}
