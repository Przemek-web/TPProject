using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zadanie2
{
    [Serializable]
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
        {
            dateTime = (DateTime)info.GetValue(nameof(dateTime), typeof(DateTime));
            number = info.GetSingle(nameof(number));
            name = info.GetValue(nameof(name), typeof(string)) as string;
            cRef = info.GetValue(nameof(cRef), typeof(classC)) as classC;
        }

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

