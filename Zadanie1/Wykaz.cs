using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Wykaz
    {
        private long PESEL;
        private string imie;
        private string nazwisko;

        public Wykaz(long pESEL, string imie, string nazwisko)
        {
            PESEL = pESEL;
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        public long PESEL1 { get => PESEL; set => PESEL = value; }
        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }

        public override bool Equals(object obj)
        {
            return obj is Wykaz wykaz &&
                   PESEL == wykaz.PESEL &&
                   imie == wykaz.imie &&
                   nazwisko == wykaz.nazwisko;
        }

        public override int GetHashCode()
        {
            var hashCode = 1317080520;
            hashCode = hashCode * -1521134295 + PESEL.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(imie);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nazwisko);
            return hashCode;
        }

        public override string ToString()
        {
            return imie + " " + nazwisko + " " + PESEL;
        }



    }
}
