using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public class FormatterCSV : Formatter
    {
        public override ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override StreamingContext Context { get; set; }

        StringBuilder objectString = new StringBuilder();
        private List<string> objectsList = new List<string>();

        public FormatterCSV()
        {
            Context = new StreamingContext(StreamingContextStates.File);
        }

        public override object Deserialize(Stream serializationStream)
        {
            //T returnObject = null;
            //using (StreamReader stream = new StreamReader(serializationStream))
            //{
            //    String line = stream.ReadLine();
            //    T obj = (T)FormatterServices.GetUninitializedObject(typeof(T));
            //    // var members = FormatterServices.GetSerializableMembers(obj.GetType(), Context);
            //    // object[] data = new object[members.Length];
            //    // ISerializable type = (ISerializable)obj;
            //    SerializationInfo _info = new SerializationInfo(obj.GetType(), new FormatterConverter());
            //    string[] fields = line.Split(';');
            //    for (int i = 0; i < fields.Length - 1; ++i)
            //    {
            //        string[] word = fields[i].Split('-');
            //        _info.AddValue(word[0], word[1]);
            //    }

            //    var constructor = obj.GetType().GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(SerializationInfo), typeof(StreamingContext) }, null);
            //    constructor.Invoke(obj, new object[] { _info, Context });
            //    returnObject = obj;

            //    //  returnObject = FormatterServices.PopulateObjectMembers(obj, members, data))

            //}
            //return returnObject;
                throw new NotImplementedException();
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            Stream stream = serializationStream;
            ISerializable serializedObject;

            if (graph is ISerializable)
                serializedObject = (ISerializable)graph;
            else
                throw new SerializationException();

            SerializationInfo info = new SerializationInfo(graph.GetType(), new FormatterConverter());


            objectString.Append(graph.GetType() + "-" + m_idGenerator.GetId(graph, out bool flag) + ";");

            serializedObject.GetObjectData(info, Context);

            foreach (SerializationEntry item in info)
            {
                WriteMember(item.Name, item.Value);
            }

            objectsList.Add(objectString.ToString());

            objectString = new StringBuilder();

            while (m_objectQueue.Count != 0)
            {
                Serialize(null, m_objectQueue.Dequeue());
            }

            StreamWrite(stream);
        }

        private void StreamWrite(Stream serializationStream)
        {
            if (serializationStream != null)
            {
                using (StreamWriter writer = new StreamWriter(serializationStream))
                {
                    foreach (string line in objectsList)
                        writer.Write(line);
                }
            }
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            objectString.Append(name + "-" + val.ToString("dd/MM/yyyy HH:mm") + ";");
        }

        protected override void WriteSingle(float val, string name)
        {
            objectString.Append(name + "-" + val.ToString("0.0", CultureInfo.InvariantCulture) + ";");
        }

        private void WriteString(string val, string name)
        {
            objectString.Append(name + "-" + val + ";");
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {

            if (obj is string)
            {
                WriteString((String)obj, name);
            }
            else if (obj is null)
            {
                objectString.Append(name + "-" + "null" + ";");
            }
            else
            {
                Schedule(obj);
                objectString.AppendLine(name + "-" + m_idGenerator.GetId(obj, out bool firstTime) + ";");
            }

        }

        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt64(long val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }
    }
}