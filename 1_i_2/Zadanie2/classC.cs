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
    public class classC : ISerializable
    {
        public DateTime dateTime { get; set; }
        public float number { get; set; }
        public string name { get; set; }
        public classA aRef { get; set; }

        [JsonConstructor]
        public classC(DateTime dateTime, float fc, string sc, classA a)
        {
            this.dateTime = dateTime;
            number = fc;
            name = sc;
            aRef = a;
        }

        public classC(SerializationInfo info, StreamingContext streamingContext)
        {
            dateTime = (DateTime)info.GetValue(nameof(dateTime), typeof(DateTime));
            number = info.GetSingle(nameof(number));
            name = info.GetValue(nameof(name), typeof(string)) as string;
            aRef = info.GetValue(nameof(aRef), typeof(classA)) as classA;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(dateTime), this.dateTime, typeof(DateTime));
            info.AddValue(nameof(number), this.number, typeof(float));
            info.AddValue(nameof(name), this.name, typeof(string));
            info.AddValue(nameof(aRef), this.aRef, typeof(classA));
        }

        public override string ToString()
        {
            return "C " + "dateTime: " + dateTime + ", " + "number: " + number + ", " + "name: " + name + ", " + "aRef" + aRef;
        }
    }
}

