using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AoC2020ClassLibrary
{
    public class FileParser
    {
        private List<string> lines;

        public FileParser(string path)
        {
            lines = new List<string>();

            foreach (var line in ReadLogLines(path))
            {
                lines.Add(line);
            }
        }

        private IEnumerable<string> ReadLogLines(string path)
        {
            using (StreamReader reader = File.OpenText(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        public List<string> Lines
        {
            get
            {
                return lines;
            }
        }

        public List<int> Integers
        {
            get
            {
                List<int> ints = new List<int>();
                foreach (var line in lines)
                {
                    ints.Add(Int32.Parse(line));
                }
                return ints;
            }
        }
    }
}
