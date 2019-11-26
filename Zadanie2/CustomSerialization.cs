using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class CustomSerialization : IFormatter
    {
        public ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Deserialize(Stream serializationStream)
        {
            throw new NotImplementedException();
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
                    stream.Write(' ');
                    stream.Write('-');
                    stream.Write(' ');
                    stream.Write(_item.Value);
                    stream.Write(';');
                    stream.Write(' ');
                }
                stream.Write('\n');
                stream.Flush();
            }
        }
    }
}
