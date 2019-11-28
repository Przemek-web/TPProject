﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zadanie2
{
  
    public class B : ISerializable
    {
        private DateTime dateTimeB;
        private float Fb;
        private string Sb;
        private C c;

        [JsonConstructor]
        public B(DateTime dateTime, float fb, string sb, C c)
        {
            dateTimeB = dateTime;
            Fb = fb;
            Sb = sb;
            this.c = c;
        }

        public DateTime DateTimeB { get => dateTimeB; set => dateTimeB = value; }
        public float Fb1 { get => Fb; set => Fb = value; }
        public string Sb1 { get => Sb; set => Sb = value; }
        public C C { get => c; set => c = value; }


        public B(SerializationInfo info, StreamingContext streamingContext)
        {
            this.DateTimeB = DateTime.Parse(info.GetString("dateTimeB")).ToLocalTime();
            this.Fb1 = float.Parse((info.GetString("floatB")));
            this.Sb1 = info.GetString("stringB");

            //this.C = new C(info, streamingContext);

            this.C = new C(DateTime.Parse(info.GetString("dateTimeC")).ToLocalTime(), float.Parse(info.GetString("floatC")), info.GetString("stringC"),
                 new A(DateTime.Parse(info.GetString("dateTimeA")).ToLocalTime(), float.Parse(info.GetString("floatA")), info.GetString("stringA"), this));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("dateTimeB", this.DateTimeB);
            info.AddValue("floatB", this.Fb1);
            info.AddValue("stringB", this.Sb1);

            bool flag;
            FormatterCSV<A>.objectIDGenerator.GetId(this, out flag);
            FormatterCSV<A>.objectIDGenerator.GetId(C, out flag);
            if (flag != false) { C.GetObjectData(info, context); }       
        }

        public override string ToString()
        {
            return "B " + "dateTimeB: " + dateTimeB + ", " + "Fb: " + Fb + ", " + "Sb: " + Sb + ", " + "c: " + c;
        }
    }
}
