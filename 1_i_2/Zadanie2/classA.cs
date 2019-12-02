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
    public class classA : ISerializable
    {
        public DateTime dateTime { get; set; }
        public float number { get; set; }
        public string name { get; set; }
        public classB bRef { get; set; }


        [JsonConstructor]
        public classA(DateTime dateTime, float fa, string sa, classB b)
        {
            this.dateTime = dateTime;
            number = fa;
            name = sa;
            bRef = b;
        }

        public classA(SerializationInfo info, StreamingContext streamingContext)
        {
            dateTime = (DateTime)info.GetValue(nameof(dateTime), typeof(DateTime));
            number = info.GetSingle(nameof(number));
            name = info.GetValue(nameof(name), typeof(string)) as string;
            bRef = info.GetValue(nameof(bRef), typeof(classB)) as classB;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(dateTime), this.dateTime,typeof(DateTime));
            info.AddValue(nameof(number), this.number, typeof(float));
            info.AddValue(nameof(name), this.name, typeof(string));
            info.AddValue(nameof(bRef), this.bRef, typeof(classB));
        }

        public override string ToString()
        {
            return "A " + "dateTime: " + dateTime + ", " + "number: " + number + ", " + "name: " + name + ", " + "bRef: " + bRef;
        }
    }
}
