using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zadanie2
{
  
    public class classB : ISerializable
    {
        public DateTime dateTime { get; set; }
        public float number { get; set; }
        public string name { get; set; }
        public classC cRef { get; set; }

        [JsonConstructor]
        public classB(DateTime dateTime, float fb, string sb, classC c)
        {
            this.dateTime = dateTime;
            number = fb;
            name = sb;
            this.cRef = c;
        }



        public classB(SerializationInfo info, StreamingContext streamingContext)
        {}

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(dateTime), this.dateTime, typeof(DateTime));
            info.AddValue(nameof(number), this.number, typeof(float));
            info.AddValue(nameof(name), this.name, typeof(string));
            info.AddValue(nameof(cRef), this.cRef, typeof(classC));
        }

        public override string ToString()
        {
            return "B " + "dateTimeB: " + dateTime + ", " + "number: " + number + ", " + "name: " + name + ", " + "cRef: " + cRef;
        }
    }
}

