using System;
using System.Collections.Generic;
using AoC2020ClassLibrary;

namespace AoC2020Days
{
    public class Day5 : Day
    {
        private List<BoardingPass> boardingPasses;

        public Day5(string path) : base(5)
        {
            FileParser parser = new FileParser(path);
            boardingPasses = new List<BoardingPass>();

            foreach (var line in parser.Lines)
            {
                boardingPasses.Add(new BoardingPass(line));
            }
        }

        public override int Part1()
        {
            int id = 0;

            foreach (var pass in boardingPasses)
            {
                Console.WriteLine(pass.ToString());
                if (pass.SeatID > id)
                {
                    id = pass.SeatID;
                }
            }

            return id;
        }

        public override int Part2()
        {
            int highest = Part1() + 1;
            bool previous = false;

            BoardingPass[] ps = new BoardingPass[highest];

            List<int> candidates = new List<int>();

            foreach (var pass in boardingPasses)
            {
                ps[pass.SeatID] = pass;
            }

            for (int i = 1; i < ps.Length - 1; i++)
            {
                if (ps[i] == null && previous)
                {
                    Console.WriteLine(i + " candidate");
                    candidates.Add(i);
                    previous = false;
                }
                else if (ps[i] != null)
                {
                    previous = true;
                }
            }

            return candidates[0];
        }
    }
}
