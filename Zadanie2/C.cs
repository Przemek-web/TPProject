using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public class C
    {
        private DateTime dateTime;
        private float Fc;
        private string Sc;
        private A a;

        public C(DateTime dateTime, float fc, string sc, A a)
        {
            this.dateTime = dateTime;
            Fc = fc;
            Sc = sc;
            this.a = a;
        }

        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public float Fc1 { get => Fc; set => Fc = value; }
        public string Sc1 { get => Sc; set => Sc = value; }
        public A A { get => a; set => a = value; }

         public override string ToString()
        {
            return "C " + "dateTime: " + dateTime + ", " + "Fc: " + Fc + ", " + "Sc: " + Sc + ", " + "a" + a;
        }
    }
}

