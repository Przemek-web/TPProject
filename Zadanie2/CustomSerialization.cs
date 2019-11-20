using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

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
            //public object Deserialize(Stream serializationStream)
            //{
            //    Object object1 = new object();
            //    ISerializable _data = (ISerializable)object1;
            //    SerializationInfo _info = new SerializationInfo(object1.GetType(), new FormatterConverter());
            //    StreamingContext _context = new StreamingContext(StreamingContextStates.File);
            //    _data.GetObjectData(_info, _context);

            //    using (StreamReader stream = new StreamReader(serializationStream))
            //    {
            //        foreach (SerializationEntry _item in _info)
            //        {
            //            object1 = stream.Read(_item.Name);

            //            stream.Write('-');
            //            stream.Write(' ');
            //            stream.Write(_item.Value);
            //            stream.Write(';');
            //            stream.Write(' ');
            //        }
            //        stream.Write('\n');
            //        stream.Flush();
            //    }
            //    throw
        //}

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

        public void SerializeCSVWykaz(IEnumerable<Wykaz> klienci, String fileName)
        {
            CustomSerialization customSerialization = new CustomSerialization();

            File.Delete(fileName);
            FileStream s = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

            foreach (Wykaz wykaz in klienci)
            {
                customSerialization.Serialize(s, wykaz);
                s = File.Open(fileName, FileMode.Append);
            }
        }

        public void SerializeCSVKatalog(IEnumerable<Katalog> katalogi, String fileName)
        {
            CustomSerialization customSerialization = new CustomSerialization();

            File.Delete(fileName);
            FileStream s = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

            foreach (Katalog katalog in katalogi)
            {
                customSerialization.Serialize(s, katalog);
                s = File.Open(fileName, FileMode.Append);
            }
        }

        public void SerializeCSVOpisStanu(IEnumerable<OpisStanu> egzemplarze, String fileName)
        {
            CustomSerialization customSerialization = new CustomSerialization();

            File.Delete(fileName);
            FileStream s = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

            foreach (OpisStanu opisStanu in egzemplarze)
            {
                customSerialization.Serialize(s, opisStanu);
                s = File.Open(fileName, FileMode.Append);
            }
        }

        public void SerializeCSVZdarzenie(IEnumerable<Zdarzenie> zdarzenia, String fileName)
        {
            CustomSerialization customSerialization = new CustomSerialization();

            File.Delete(fileName);
            FileStream s = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

            foreach (Zdarzenie zdarzenie in zdarzenia)
            {
                customSerialization.Serialize(s, zdarzenie);
                s = File.Open(fileName, FileMode.Append);
            }
        }

        public void SerializeCSV(DataRepository data)
        {
            SerializeCSVWykaz(data.GetAllWykaz(), "Wykaz.csv");
            SerializeCSVKatalog(data.GetAllKatalog(), "Katalog.csv");
            SerializeCSVOpisStanu(data.GetAllOpisStanu(), "OpisStanu.csv");
            SerializeCSVZdarzenie(data.GetAllZdarzenie(), "Zdarzenie.csv");
        }
    }
}
