using System.Collections.Generic;

namespace Zadanie1
{
    public class Wykaz
    {
        private long pesel;
        private string imie;
        private string nazwisko;

        public Wykaz(long pesel, string imie, string nazwisko)
        {
            this.pesel = pesel;
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        public long Pesel { get => pesel; set => pesel = value; }
        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }

        public override bool Equals(object obj)
        {
            return obj is Wykaz wykaz &&
                   pesel == wykaz.pesel &&
                   imie == wykaz.imie &&
                   nazwisko == wykaz.nazwisko;
        }

        public override int GetHashCode()
        {
            var hashCode = 1317080520;
            hashCode = hashCode * -1521134295 + pesel.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(imie);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nazwisko);
            return hashCode;
        }

        public override string ToString()
        {
            return "WYKAZ " + "Imię: " + Imie + ", " + "Nazwisko: " + Nazwisko + ", " + "PESEL: " + Pesel;
        }
    }
}
