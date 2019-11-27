using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zadanie2
{
    public class C : ISerializable
    {
        private DateTime dateTimeC;
        private float Fc;
        private string Sc;
        private A a;

        [JsonConstructor]
        public C(DateTime dateTime, float fc, string sc, A a)
        {
            dateTimeC = dateTime;
            Fc = fc;
            Sc = sc;
            this.a = a;
        }

        public DateTime DateTimeC { get => dateTimeC; set => dateTimeC = value; }
        public float Fc1 { get => Fc; set => Fc = value; }
        public string Sc1 { get => Sc; set => Sc = value; }
        public A A { get => a; set => a = value; }

        public C(SerializationInfo info, StreamingContext streamingContext)
        {
            this.DateTimeC = DateTime.Parse(info.GetString("dateTimeC")).ToLocalTime();
            this.Fc1 = float.Parse((info.GetString("floatC")));
            this.Sc1 = info.GetString("stringC");

            //this.A = new A(info, streamingContext);
            this.A = new A(DateTime.Parse(info.GetString("dateTimeA")).ToLocalTime(), float.Parse(info.GetString("floatA")), info.GetString("stringA"),
                new B(DateTime.Parse(info.GetString("dateTimeB")).ToLocalTime(), float.Parse(info.GetString("floatB")), info.GetString("stringB"), this));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("dateTimeC", this.DateTimeC);
            info.AddValue("floatC", this.Fc1);
            info.AddValue("stringC", this.Sc1);

            bool flag;
            FormatterCSV<A>.objectIDGenerator.GetId(this, out flag);
            FormatterCSV<A>.objectIDGenerator.GetId(A, out flag);
            if (flag == true) { A.GetObjectData(info, context); }
        }

        public override string ToString()
        {
            return "C " + "dateTime: " + dateTimeC + ", " + "Fc: " + Fc + ", " + "Sc: " + Sc + ", " + "a" + a;
        }
    }
}

