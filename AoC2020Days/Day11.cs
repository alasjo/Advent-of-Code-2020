using System;
using System.Collections.Generic;
using System.Text;
using AoC2020ClassLibrary;

namespace AoC2020Days
{
    public class Day11 : Day
    {
        private WaitingArea area;
        FileParser parser;

        public Day11(string path) : base(11)
        {
            parser = new FileParser(path);
        }

        private void Init()
        {
            int h = parser.Lines.Count;
            int w = parser.Lines[0].Length;
            area = new WaitingArea(w, h);
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (parser.Lines[i][j].Equals('L'))
                    {
                        area.SetState(j, i, SeatState.Empty);
                    }
                }
            }
        }

        public override int Part1()
        {
            Init();
            int prev;
            do
            {
                prev = area.CountOccupied();
                area.Run();
                // Console.WriteLine(area.ToString());
            } while (area.CountOccupied() != prev);
            return prev;
        }

        public override int Part2()
        {
            Init();
            int prev;
            do
            {
                prev = area.CountOccupied();
                area.RunPart2();
                // Console.WriteLine(area.ToString());
            } while (area.CountOccupied() != prev);
            return prev;
        }
    }
}
