using System;
using System.Collections.Generic;
using System.Text;
using AoC2020Days;
using AoC2020ClassLibrary;

namespace AoC2020Days
{
    public class Day10 : Day
    {
        private List<int> adapters;
        private Dictionary<int, long> dynamic;

        public Day10(string path) : base(10)
        {
            FileParser parser = new FileParser(path);
            adapters = new List<int>();
            adapters.Add(0);
            adapters.AddRange(parser.Integers);
            adapters.Sort();
            adapters.Add(adapters[adapters.Count - 1] + 3);
            dynamic = new Dictionary<int, long>();
        }

        public override int Part1()
        {
            int jolt = 0;
            int ones = 0;
            int threes = 1;
            foreach (var n in adapters)
            {
                if (n - jolt == 1)
                {
                    ones++;
                }
                else if (n - jolt == 3)
                {
                    threes++;
                }

                jolt = n;
            }

            return ones * threes;
        }

        public override long Part2Long()
        {
            return NumberOfPaths(0);
        }

        private long NumberOfPaths(int v)
        {
            if (v == adapters.Count - 1)
            {
                return 1;
            }

            if (dynamic.ContainsKey(v))
            {
                return dynamic[v];
            }

            long result = 0;

            for (int i = v + 1; i < adapters.Count; i++)
            {
                if (adapters[i] - adapters[v] <= 3)
                {
                    result += NumberOfPaths(i);
                }
            }

            dynamic[v] = result;

            return result;
        }
    }
}
