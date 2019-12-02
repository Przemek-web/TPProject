using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;


namespace Zadanie1
{
    public class Zakup : Zdarzenie,ISerializable
    {
        private OpisStanu opisStanu;
        private DateTime dataZakupu;

        [JsonConstructor]
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

        public Zakup(SerializationInfo info, StreamingContext streamingContext)
        {
            this.opisStanu = new OpisStanu(new Katalog(int.Parse(info.GetString("kluczKsiazki")), info.GetString("nazwaKsiazki")),
                Boolean.Parse(info.GetString("czyWypozyczona")), info.GetString("pozycjaKatalogowa")); 

            this.dataZakupu = DateTime.Parse(info.GetString("dataZakupu"));
      
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("kluczKsiazki", this.opisStanu.Katalog.Klucz);
            info.AddValue("nazwaKsiazki", this.opisStanu.Katalog.NazwaKsiazki);
            info.AddValue("czyWypozyczona", this.opisStanu.CzyWypozyczona);
            info.AddValue("pozycjaKatalogowa", this.opisStanu.PozycjaKatalogowa);

            info.AddValue("dataZakupu", this.dataZakupu);
        }
    }
}
