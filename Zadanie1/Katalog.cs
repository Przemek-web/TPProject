using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Zadanie1
{
    public class Katalog : ISerializable
    {
        private string nazwaKsiazki;
        private int klucz;

        [JsonConstructor]
        public Katalog(int klucz, string nazwaKsiazki)
        {
            this.klucz = klucz;
            this.nazwaKsiazki = nazwaKsiazki;
        }

        public string NazwaKsiazki { get => nazwaKsiazki; set => nazwaKsiazki = value; }
        public int Klucz { get => klucz; set => klucz = value; }

        public override bool Equals(object obj)
        {
            return obj is Katalog katalog &&
                   nazwaKsiazki == katalog.nazwaKsiazki &&
                   klucz == katalog.klucz;
        }

        public override int GetHashCode()
        {
            var hashCode = 1833528696;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nazwaKsiazki);
            hashCode = hashCode * -1521134295 + klucz.GetHashCode();
            return hashCode;
        }
      
        public override string ToString()
        {
            return "KATALOG " + "Klucz: " + Klucz + ", " + "Nazwa książki: " + NazwaKsiazki;
        }

        public Katalog(SerializationInfo info, StreamingContext streamingContext)
        {
            this.nazwaKsiazki = info.GetString("nazwaKsiazki");
            this.klucz = Int32.Parse((info.GetString("klucz")));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("nazwaKsiazki", this.nazwaKsiazki);
            info.AddValue("kluczKsiazki", this.klucz);
        }
    }
}
