using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public static class SerializationCSV
    {
        public static void SerializeA(A a,string filename)
        {
            File.WriteAllText(filename, string.Empty);
            Stream stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
            FormatterCSV<A> fromatterCSV = new FormatterCSV<A>();
            fromatterCSV.Serialize(stream, a);
            stream.Close();
        }

        public static void SerializeB(B b, string filename)
        {
            File.WriteAllText(filename, string.Empty);
            Stream stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
            FormatterCSV<B> fromatterCSV = new FormatterCSV<B>();
            fromatterCSV.Serialize(stream, b);
            stream.Close();
        }

        public static void SerializeC(C c, string filename)
        {
            File.WriteAllText(filename, string.Empty);
            Stream stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
            FormatterCSV<C> fromatterCSV = new FormatterCSV<C>();
            fromatterCSV.Serialize(stream, c);
            stream.Close();
        }
    }
}
