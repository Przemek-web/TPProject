using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public class FormatterCSV<T> : IFormatter where T : class
    {
        public static ObjectIDGenerator objectIDGenerator = new ObjectIDGenerator();
        public ISurrogateSelector SurrogateSelector { get; set; }
        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }

        public object Deserialize(Stream serializationStream)
        {
            T returnObject = null;
            using (StreamReader stream = new StreamReader(serializationStream))
            {
                String line = stream.ReadLine();
                T obj = (T)FormatterServices.GetUninitializedObject(typeof(T));
                // var members = FormatterServices.GetSerializableMembers(obj.GetType(), Context);
                // object[] data = new object[members.Length];
                // ISerializable type = (ISerializable)obj;
                SerializationInfo _info = new SerializationInfo(obj.GetType(), new FormatterConverter());
                string[] fields = line.Split(';');
                for (int i = 0; i < fields.Length - 1; ++i)
                {
                    string[] word = fields[i].Split('-');
                    _info.AddValue(word[0], word[1]);
                }

                var constructor = obj.GetType().GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(SerializationInfo), typeof(StreamingContext) }, null);
                constructor.Invoke(obj, new object[] { _info, Context });
                returnObject = obj;

                //  returnObject = FormatterServices.PopulateObjectMembers(obj, members, data))

            }
            return returnObject;
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            ISerializable _data = (ISerializable)graph;
            SerializationInfo _info = new SerializationInfo(graph.GetType(), new FormatterConverter());
            StreamingContext _context = new StreamingContext(StreamingContextStates.File);
            _data.GetObjectData(_info, _context);

            using (StreamWriter stream = new StreamWriter(serializationStream))
            {
                foreach (SerializationEntry _item in _info)
                {
                    stream.Write(_item.Name);
                    stream.Write('-');
                    stream.Write(_item.Value);
                    stream.Write(';');
                }
                stream.Write('\n');
                stream.Flush();
            }
        }
    }
}
