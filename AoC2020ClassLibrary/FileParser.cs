﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

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
                    ints.Add(int.Parse(line));
                }
                return ints;
            }
        }

        public List<long> Longs
        {
            get
            {
                List<long> longs = new List<long>();
                foreach (var line in lines)
                {
                    longs.Add(long.Parse(line));
                }
                return longs;
            }
        }

        public IEnumerable<string[]> SplitLinesByRegex(Regex re)
        {
            foreach (var line in lines)
            {
                MatchCollection matches = re.Matches(line);

                foreach (Match match in matches)
                {
                    GroupCollection groups = match.Groups;

                    string[] result = new string[groups.Count];

                    for (int i = 0; i < groups.Count; i++)
                    {
                        result[i] = groups[i].Value;
                    }

                    yield return result;
                }
            }
        }
    }
}
