using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
  
    public class B
    {
        private DateTime dateTime;
        private float Fb;
        private string Sb;
        private C c;

        public B(DateTime dateTime, float fb, string sb, C c)
        {
            this.dateTime = dateTime;
            Fb = fb;
            Sb = sb;
            this.c = c;
        }

        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public float Fb1 { get => Fb; set => Fb = value; }
        public string Sb1 { get => Sb; set => Sb = value; }
        public C C { get => c; set => c = value; }

        public override string ToString()
        {
            return "B " + "dateTime: " + dateTime + ", " + "Fb: " + Fb + ", " + "Sb: " + Sb + ", " + "c: " + c;
        }
    }
}

