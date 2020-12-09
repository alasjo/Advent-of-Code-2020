using System;
using System.Collections.Generic;
using System.Text;
using AoC2020Days;
using AoC2020ClassLibrary;
using System.Linq;

namespace AoC2020Days
{
    public class Day9 : Day
    {
        long[] preamble;
        List<long> numbers;

        public Day9(string path, int preambleLength) : base(9)
        {
            FileParser parser = new FileParser(path);

            preamble = parser.Longs.Take(preambleLength).ToArray();
            numbers = parser.Longs.Skip(preambleLength).ToList();
        }

        public override long Part1Long()
        {
            XmasEncryption xmas = new XmasEncryption(preamble);

            foreach (var n in numbers)
            {
                if (xmas.IsValid(n))
                {
                    xmas.Add(n);
                }
                else
                {
                    return n;
                }
            }

            return -1;
        }

        public override long Part2Long()
        {
            long prev = Part1Long();
            
            List<long> numberList = new List<long>(preamble);
            numberList = numberList.Concat(numbers).ToList();

            for (int i = 0; i < numberList.Count; i++)
            {
                int j = i;
                long result = 0;
                List<long> invalidList = new List<long>();

                while (result < prev && j < numberList.Count)
                {
                    result += numberList[j];
                    invalidList.Add(numberList[j]);
                    j++;
                }

                if (result == prev)
                {
                    invalidList.Sort();
                    return invalidList[0] + invalidList[invalidList.Count - 1];
                }
            }

            return -1;
        }
    }
}
