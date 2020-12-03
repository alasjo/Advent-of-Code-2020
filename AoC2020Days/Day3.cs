using System;
using System.Text.RegularExpressions;
using AoC2020ClassLibrary;
using System.Collections.Generic;

namespace AoC2020Days
{
    public class Day3 : Day
    {
        private Map map;

        public Day3(string path) : base(2)
        {
            FileParser parser = new FileParser(path);
            map = new Map(Analysis<string>.Longest(parser.Lines), parser.Lines.Count);
            for (int i = 0; i < parser.Lines.Count; i++)
            {
                for (int j = 0; j < parser.Lines[i].Length; j++)
                {
                    if (parser.Lines[i][j] == '#')
                    {
                        map.SetState(j, i, '#');
                    }
                }
            }
        }

        private long Run(int goX, int goY)
        {
            long count = 0;

            map.SetPosition(0, 0);

            int x = 0;

            for (int y = 0; y < map.Size.Item2; y += goY)
            {
                map.SetPosition(x, y);
                if (map.CurrentState == '#')
                {
                    count++;
                }
                x += goX;
            }

            Console.WriteLine(String.Format("Slope {0},{1}: {2}", goX, goY, count));
            return count;
        }

        public override long Part1Long()
        {
            return Run(3, 1);
        }

        public override long Part2Long()
        {
            return Run(1, 1) * Run(3, 1) * Run(5, 1) * Run(7, 1) * Run(1, 2);
        }
    }
}
