using System;
using AoC2020ClassLibrary;

namespace AoC2020Days
{
    public class Day1: Day
    {
        private Iter<int> input;

        public Day1(string path): base(1)
        {
            FileParser parser = new FileParser(path);
            input = new Iter<int>(parser.Integers);
        }

        public Iter<int> Input
        {
            get
            {
                return input;
            }
        }

        public int Part1()
        {
            foreach (var i in input)
            {
                foreach (var j in input)
                {
                    if (i + j == 2020)
                    {
                        return i * j;
                    }
                }
            }

            return 0;
        }

        public int Part2()
        {
            foreach (var i in input)
            {
                foreach (var j in input)
                {
                    foreach (var k in input)
                    {
                        if (i + j + k == 2020)
                        {
                            return i * j * k;
                        }

                    }
                }
            }

            return 0;
        }
    }
}
