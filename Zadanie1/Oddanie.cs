using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Zadanie1
{
    public class Oddanie : Zdarzenie,ISerializable
    {
        private DateTime dataOddania;
        private Wykaz wykaz;
        private OpisStanu opisStanu;

        [JsonConstructor]
        public Oddanie(DateTime dataOddania, Wykaz wykaz, OpisStanu opisStanu)
        {
            this.DataOddania = dataOddania;
            this.Wykaz = wykaz;
            this.OpisStanu = opisStanu;
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

        public DateTime GetStartDate()
        {
            return DataOddania;
        }

        public Wykaz GetWykaz()
        {
            return Wykaz;
        }

        public override string ToString()
        {
            return "ODDANIE:  " + "Data oddania: " + DataOddania + ", " + Wykaz + ", " + OpisStanu;
        }

        public Oddanie(SerializationInfo info, StreamingContext streamingContext)
        {
            this.dataOddania = DateTime.Parse(info.GetString("dataOddania"));

            this.wykaz = new Wykaz(long.Parse(info.GetString("peselCzytelnika")), info.GetString("imieCzytelnika"), info.GetString("nazwiskoCzytelnika"));

            this.opisStanu = new OpisStanu(new Katalog(int.Parse(info.GetString("kluczKsiazki")), info.GetString("nazwaKsiazki")),
                Boolean.Parse(info.GetString("czyWypozyczona")), info.GetString("pozycjaKatalogowa"));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("dataOddania", this.dataOddania);

            info.AddValue("peselCzytelnika", this.wykaz.Pesel);
            info.AddValue("imieCzytelnika", this.wykaz.Imie);
            info.AddValue("nazwiskoCzytelnika", this.wykaz.Nazwisko);

            info.AddValue("kluczKsiazki", this.opisStanu.Katalog.Klucz);
            info.AddValue("nazwaKsiazki", this.opisStanu.Katalog.NazwaKsiazki);
            info.AddValue("czyWypozyczona", this.opisStanu.CzyWypozyczona);
            info.AddValue("pozycjaKatalogowa", this.opisStanu.PozycjaKatalogowa);
        }
    }
}
