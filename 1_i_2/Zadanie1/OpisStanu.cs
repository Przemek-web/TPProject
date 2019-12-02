using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Zadanie1
{
    public class OpisStanu : ISerializable
    {
        private Katalog katalog;
        private bool czyWypozyczona;
        private string pozycjaKatalogowa;

        [JsonConstructor]
        public OpisStanu(Katalog katalog, bool czyWypozyczona, string pozycjaKatalogowa)
        {
            this.Katalog = katalog;
            this.czyWypozyczona = czyWypozyczona;
            this.pozycjaKatalogowa = pozycjaKatalogowa;
        }

        public bool CzyWypozyczona { get => czyWypozyczona; set => czyWypozyczona = value; }
        public string PozycjaKatalogowa { get => pozycjaKatalogowa; set => pozycjaKatalogowa = value; }
        public Katalog Katalog { get => katalog; set => katalog = value; }

        public override bool Equals(object obj)
        {
            return obj is OpisStanu stanu &&
                   EqualityComparer<Katalog>.Default.Equals(Katalog, stanu.Katalog) &&
                   czyWypozyczona == stanu.czyWypozyczona &&
                   pozycjaKatalogowa == stanu.pozycjaKatalogowa;
        }

        public override int GetHashCode()
        {
            var hashCode = 1745975141;
            hashCode = hashCode * -1521134295 + EqualityComparer<Katalog>.Default.GetHashCode(Katalog);
            hashCode = hashCode * -1521134295 + czyWypozyczona.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(pozycjaKatalogowa);
            return hashCode;
        }
   
        public override string ToString()
        {
            return "EGZEMPLARZ: " + Katalog + ", " + "Pozycja Katalogowa: " + PozycjaKatalogowa + ", " + "Czy wypożyczona: " + CzyWypozyczona;
        }

        public OpisStanu(SerializationInfo info, StreamingContext streamingContext)
        {
            this.katalog = new Katalog(Int32.Parse(info.GetString("kluczKsiazki")), info.GetString("nazwaKsiazki"));

            this.czyWypozyczona = Boolean.Parse(info.GetString("czyWypozyczona"));
            this.pozycjaKatalogowa = info.GetString("pozycjaKatalogowa");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("nazwaKsiazki", this.katalog.NazwaKsiazki);
            info.AddValue("kluczKsiazki", this.katalog.Klucz);

            info.AddValue("czyWypozyczona", this.czyWypozyczona);
            info.AddValue("pozycjaKatalogowa", this.pozycjaKatalogowa);
        }
    }
}
