using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AoC2020ClassLibrary;

namespace AoC2020Days
{
    public class Day7 : Day
    {
        private SortedDictionary<string, Tree<string>> dict;

        public Day7(string path) : base(7)
        {
            dict = new SortedDictionary<string, Tree<string>>();
            Regex re = new Regex(@"([a-z ]+) bags contain (.*)\.");
            Regex rf = new Regex(@"([0-9]+) ([a-z ]+) bag");
            FileParser parser = new FileParser(path);

            foreach (var line in parser.Lines)
            {
                Match match = re.Match(line);
                Tree<string> tempTree = new Tree<string>(match.Groups[1].Value);
                MatchCollection matches = rf.Matches(match.Groups[2].Value);
                foreach (Match m in matches)
                {
                    int c = int.Parse(m.Groups[1].Value);
                    tempTree.AddChild(m.Groups[2].Value, c);
                }

                dict[tempTree.Data] = tempTree;
            }
        }

        private bool Found(string C)
        {
            bool found = false;
            foreach (var child in dict[C].Children)
            {
                if (child.Data.Equals("shiny gold"))
                {
                    found = true;
                } else
                {
                    found |= Found(child.Data);
                }
            }
            return found;
        }

        private int Size(string C)
        {
            int res = 0;
            foreach (var child in dict[C].Children)
            {
                res += child.Count;
                res += child.Count * Size(child.Data);
            }
            return res;
        }

        public override int Part1()
        {
            int bagCount = 0;

            foreach (var item in dict)
            {
                if (Found(item.Key))
                {
                    bagCount++;
                }
            }

            return bagCount;
        }

        public override int Part2()
        {
            return Size("shiny gold");
        }
    }
}
