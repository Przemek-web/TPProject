using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public static class DeserializationCSV
    {
        public static A DeserializeA(string filename)
        {
            String line;
            FormatterCSV<A> formatterCSV = new FormatterCSV<A>();
            StreamReader file = new StreamReader(filename);
            line = file.ReadLine();
            A a = (A)formatterCSV.Deserialize(MakeStream(line));
            file.Close();
            return a; 
        }


        public static B DeserializeB(string filename)
        {
            String line;
            FormatterCSV<B> formatterCSV = new FormatterCSV<B>();
            StreamReader file = new StreamReader(filename);
            line = file.ReadLine();
            B b = (B)formatterCSV.Deserialize(MakeStream(line));
            file.Close();
            return b;
        }


        public static C DeserializeC(string filename)
        {
            String line;
            FormatterCSV<C> formatterCSV = new FormatterCSV<C>();
            StreamReader file = new StreamReader(filename);
            line = file.ReadLine();
            C c = (C)formatterCSV.Deserialize(MakeStream(line));
            file.Close();
            return c;
        }

        public static Stream MakeStream(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
