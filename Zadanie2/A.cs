using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zadanie2
{
    public class A : ISerializable
    {
        private DateTime dateTimeA;
        private float Fa;
        private string Sa;
        private B b;

        [JsonConstructor]
        public A(DateTime dateTime, float fa, string sa, B b)
        {
            this.dateTimeA = dateTime;
            Fa = fa;
            Sa = sa;
            this.b = b;
        }

        public DateTime DateTimeA { get => dateTimeA; set => dateTimeA = value; }
        public float Fa1 { get => Fa; set => Fa = value; }
        public string Sa1 { get => Sa; set => Sa = value; }
        public B B { get => b; set => b = value; }


        public A(SerializationInfo info, StreamingContext streamingContext)
        {
            this.DateTimeA = DateTime.Parse(info.GetString("dateTimeA")).ToLocalTime();
            this.Fa1 = float.Parse((info.GetString("floatA")));
            this.Sa1 = info.GetString("stringA");
            //this.B = ?????
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("dateTimeA", this.DateTimeA);
            info.AddValue("floatA", this.Fa1);
            info.AddValue("stringA", this.Sa1);
            B.GetObjectData(info, context);
        }

        public override string ToString()
        {
            return "A " + "dateTime: " + dateTimeA + ", " + "Fa: " + Fa + ", " + "Sa: " + Sa + ", " + "b: " + b;
        }
    }
}
