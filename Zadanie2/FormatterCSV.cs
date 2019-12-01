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
            string resultId = null;
            Dictionary<string, object> objects = new Dictionary<string, object>();
            List<Tuple<string, string, string>> references = new List<Tuple<string, string, string>>();
            Dictionary<string, SerializationInfo> info = new Dictionary<string, SerializationInfo>();

            using (StreamReader reader = new StreamReader(serializationStream))
            {
                string id = null;
                bool flag = true;
                string line;

                while ((line = reader.ReadLine()) != null && line.Length > 1)
                {
                    string[] fields = line.Split(';');

                    // Pierwsze pole - obiekt
                    string[] objectField = fields[0].Split('-');

                    Type objType = Type.GetType(objectField[0]);
                    if (objType is null)
                        throw new SerializationException();

                    id = objectField[1];
                    objects.Add(id, FormatterServices.GetUninitializedObject(objType));
                    info.Add(id, new SerializationInfo(objType, new FormatterConverter()));

                    if (flag)
                    {
                        flag = false;
                        resultId = id;
                    }

                    // Drugie pole - data
                    string[] dateField = fields[1].Split('-');

                    info[id].AddValue(dateField[0], DateTime.ParseExact(dateField[1], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture));

                    // Trzecie pole - float
                    string[] floatField = fields[2].Split('-');

                    info[id].AddValue(floatField[0], float.Parse(floatField[1], CultureInfo.InvariantCulture));

                    // Czwarte pole - string
                    string[] stringField = fields[3].Split('-');

                    info[id].AddValue(stringField[0], stringField[1]);

                    // Piate pole - referencja
                    string[] referenceField = fields[4].Split('-');

                    references.Add(Tuple.Create(id, referenceField[0], referenceField[1]));
                }
            }

            foreach (Tuple<string, string, string> reference in references)
            {
                info[reference.Item1].AddValue(reference.Item2, objects[reference.Item3]);
            }

            foreach (KeyValuePair<string, object> keyValue in objects)
            {
                Type[] constructorTypes = { typeof(SerializationInfo), typeof(StreamingContext) };
                object[] constuctorParameters = { info[keyValue.Key], Context };

                keyValue.Value.GetType().GetConstructor(constructorTypes).Invoke(keyValue.Value, constuctorParameters);
            }

            return objects[resultId];
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
            objectString.Append(name + "-" + val.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture) + ";");
        }

        protected override void WriteSingle(float val, string name)
        {
            objectString.Append(name + "-" + val.ToString(CultureInfo.InvariantCulture) + ";");
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