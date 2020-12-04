using System.Collections.Generic;
using AoC2020ClassLibrary;

namespace AoC2020Days
{
    public class Day1: Day
    {
        private int[] input;

        public Day1(string path): base(1)
        {
            FileParser parser = new FileParser(path);
            input = parser.Integers.ToArray();
        }

        public override int Part1()
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i; j < input.Length; j++)
                {
                    if (input[i] + input[j] == 2020)
                    {
                        return input[i] * input[j];
                    }
                }
            }

            return 0;
        }

        public override int Part2()
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i; j < input.Length; j++)
                {
                    for (int k = j; k < input.Length; k++)
                    {
                        if (input[i] + input[j] + input[k] == 2020)
                        {
                            return input[i] * input[j] * input[k];
                        }

                    }
                }
            }

            return 0;
        }
    }
}
