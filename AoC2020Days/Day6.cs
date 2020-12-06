using AoC2020ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020Days
{
    public class Day6 : Day
    {
        public List<SortedDictionary<char, int>> customsGroups;
        public List<int> groupSizes;

        public Day6(string path) : base(6)
        {
            customsGroups = new List<SortedDictionary<char, int>>();
            groupSizes = new List<int>();

            FileParser parser = new FileParser(path);

            StringBuilder builder = new StringBuilder();
            groupSizes.Add(0);
            int head = 0;

            foreach (var line in parser.Lines)
            {
                if (line.Length == 0)
                {
                    if (builder.Length > 0)
                    {
                        customsGroups.Add(Analysis<char>.Histogram(builder.ToString()));
                        groupSizes.Add(0);
                        head++;
                    }
                    builder = new StringBuilder();
                }
                else
                {
                    builder.Append(line);
                    groupSizes[head]++;
                }
            }

            if (builder.Length > 0)
            {
                customsGroups.Add(Analysis<char>.Histogram(builder.ToString()));
            }
        }

        public override int Part1()
        {
            int sum = 0;

            foreach(var group in customsGroups)
            {
                sum += group.Count;
            }

            return sum;
        }

        public override int Part2()
        {
            int count = 0;

            for (int i = 0; i < customsGroups.Count; i++)
            {
                foreach (var question in customsGroups[i])
                {
                    //Console.WriteLine("Group {0}: Q:{1} N:{2} Gsize:{3}", i, question.Key, question.Value, groupSizes[i]);
                    if (question.Value == groupSizes[i])
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
