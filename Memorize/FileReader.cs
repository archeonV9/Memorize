using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorize
{ 
    public class FileReader
    {

        public static List<string> slowkaANG;

        public static List<string> slowkaPL;


        public FileReader()
        {
            slowkaANG = new List<string>();
            slowkaPL = new List<string>();
        }

        public void Czytaj(string nazwaPliku)
        {
            using (var reader = new StreamReader(nazwaPliku))
            {
                try
                {
                    while (reader.Peek() != 0)
                    {
                        RozdzielLinie(reader.ReadLine());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void RozdzielLinie(string readLine)
        {
            string[] tmp_line = readLine.Split('-');
            slowkaANG.Add(tmp_line[0]);
            slowkaPL.Add(tmp_line[1]);
        }

        public void SaveDataToFile(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                try
                {
                    for (int i = 0; i < slowkaANG.Count; i++)
                    {
                        var line = new StringBuilder();
                        line.Append(slowkaANG[i]);
                        line.Append('-');
                        line.Append(slowkaPL[i]);
                        writer.WriteLine(line);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
