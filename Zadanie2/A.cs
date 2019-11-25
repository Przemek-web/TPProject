using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public class A
    {
        private DateTime dateTime;
        private float Fa;
        private string Sa;
        public B b;

        public A(DateTime dateTime, float fa, string sa, B b)
        {
            this.dateTime = dateTime;
            Fa = fa;
            Sa = sa;
            this.b = b;
        }

        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public float Fa1 { get => Fa; set => Fa = value; }
        public string Sa1 { get => Sa; set => Sa = value; }
        public B B { get => b; set => b = value; }

        public override string ToString()
        {
            return "A " + "dateTime: " + dateTime + ", " + "Fa: " + Fa + ", " + "Sa: " + Sa + ", " + "b: " + b;
        }
    }
}
