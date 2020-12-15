using System;
using System.Collections.Generic;
using System.Text;
using AoC2020ClassLibrary;
using System.Linq;

namespace AoC2020Days
{
    public class Day13 : Day
    {
        private long time;
        private List<long> buses;
        FileParser parser;

        public Day13(string path) : base(13)
        {
            parser = new FileParser(path);
            time = long.Parse(parser.Lines[0]);
        }

        public override long Part1Long()
        {
            SortedDictionary<long, long> dict = new SortedDictionary<long, long>();

            buses = new List<long>();
            foreach (var id in parser.Lines[1].Split(','))
            {
                try
                {
                    buses.Add(long.Parse(id));
                }
                catch
                {
                    // nah
                }
            }

            foreach (var bus in buses)
            {
                long t = Mathematics.FindNextNumerator(time, bus) - time;
                dict[t] = bus;
            }

            long k = dict.Keys.First();
            return k * dict[k];
        }

        public override long Part2Long()
        {
            long i = 0;
            Dictionary<long, long> bus = new Dictionary<long, long>();
            foreach (var id in parser.Lines[1].Split(','))
            {
                if (id.Equals("x") == false)
                {
                    try
                    {
                        bus.Add(i, long.Parse(id));
                    }
                    catch
                    {
                        // nope
                    }
                }

                i++;
            }

            long result = Mathematics.ChineseRemainderTheorem(bus.Values.ToArray(), bus.Keys.ToArray());

            return result;
        }
    }
}
