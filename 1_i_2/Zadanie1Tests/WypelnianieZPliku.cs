using System;
using System.Collections.Generic;

namespace Zadanie1.Tests
{
    public class WypelnianieZPliku : DataFiller
    {
        public WypelnianieZPliku() { }

        public void Fill(DataContext context)
        {
            List<string[]> data = ReadDataFromFile();
            for (int i = 0; i < 3; i++)
            {
                context.czytelnicy.Add(new Wykaz(Convert.ToInt64(data[i][0]), data[i][1], data[i][2]));

                context.katalogi.Add(Convert.ToInt32(data[i + 3][0]), new Katalog(Convert.ToInt32(data[i + 3][0]), data[i + 3][1]));
            }
            for (int i = 6; i < 12; i++)
            {
                context.egzemplarze.Add(new OpisStanu(context.katalogi[Convert.ToInt32(data[i][0])],
                    Convert.ToBoolean(data[i][1]), data[i][2]));
            }
            for (int i = 12; i < 15; i++)
            {
                context.egzemplarze[Convert.ToInt32(data[i][3])].CzyWypozyczona = true;

                context.zdarzenia.Add(new Wypozyczenie(DateTime.Parse(data[i][0]), DateTime.Parse(data[i][1]),
                    context.czytelnicy[Convert.ToInt32(data[i][2])], context.egzemplarze[Convert.ToInt32(data[i][3])]));         
            }
        }

        public List<string[]> ReadDataFromFile()
        {
            string line;
            List<string[]> data = new List<string[]>();

            System.IO.StreamReader file =
                new System.IO.StreamReader("../../data.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                data.Add(words);
            }

            file.Close();
            return data;
        }
    }
}
