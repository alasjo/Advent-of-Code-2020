using System;
using System.Text.RegularExpressions;
using AoC2020ClassLibrary;
using System.Collections.Generic;

namespace AoC2020Days
{
    public class Day2 : Day
    {
        private Iter<string[]> input;

        private Regex regex = new Regex(@"([0-9]+)-([0-9]+) ([a-z]): ([a-z]+)");

        public Day2(string path) : base(2)
        {
            FileParser parser = new FileParser(path);

            input = new Iter<string[]>();

            foreach (var res in parser.SplitLinesByRegex(regex))
            {
                input.Add(res);
            }
        }

        public override int Part1()
        {
            int count = 0;

            foreach (string[] res in input)
            {
                int min = Int32.Parse(res[1]);
                int max = Int32.Parse(res[2]);

                SortedDictionary<char, int> histogram = Analysis<char>.Histogram(res[4]);

                if (histogram.ContainsKey(res[3][0])
                    && histogram[res[3][0]] >= min
                    && histogram[res[3][0]] <= max)
                {
                    count++;
                }
            }
            return count;
        }

        public override int Part2()
        {
            int count = 0;

            foreach (string[] res in input)
            {
                int[] positions = new int[2] {
                    Int32.Parse(res[1]),
                    Int32.Parse(res[2])
                };

                List<int> indexes = new List<int>();
                foreach (var i in Analysis<string>.AllIndexOf(res[3], res[4]))
                {
                    indexes.Add(i + 1); // No zero-index
                }

                if (indexes.Contains(positions[0]) ^ indexes.Contains(positions[1]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
