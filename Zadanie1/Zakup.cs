using System;
using System.Collections.Generic;

namespace Zadanie1
{
    public class Zakup : Zdarzenie
    {
        private OpisStanu opisStanu;
        private DateTime dataZakupu;

        public Zakup(OpisStanu opisStanu, DateTime dataZakupu)
        {
            this.opisStanu = opisStanu;
            this.dataZakupu = dataZakupu;
        }

        public DateTime DataZakupu { get => dataZakupu; set => dataZakupu = value; }
        public OpisStanu OpisStanu { get => opisStanu; set => opisStanu = value; }

        public override bool Equals(object obj)
        {
            var zakup = obj as Zakup;
            return zakup != null &&
                   EqualityComparer<OpisStanu>.Default.Equals(opisStanu, zakup.opisStanu) &&
                   dataZakupu == zakup.dataZakupu;
        }

      

        public override int GetHashCode()
        {
            var hashCode = -1349915112;
            hashCode = hashCode * -1521134295 + EqualityComparer<OpisStanu>.Default.GetHashCode(opisStanu);
            hashCode = hashCode * -1521134295 + dataZakupu.GetHashCode();
            hashCode = hashCode * -1521134295 + DataZakupu.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<OpisStanu>.Default.GetHashCode(OpisStanu);
            return hashCode;
        }

        public DateTime GetStartDate()
        {
            return DataZakupu;
        }

        public Wykaz GetWykaz()
        {
            return null;
        }

        public override string ToString()
        {
            return "ZAKUP: " + "Data zakupu: " + dataZakupu + ", " + opisStanu;
        }
    }
}
