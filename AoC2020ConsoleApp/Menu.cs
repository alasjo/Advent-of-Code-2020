using AoC2020ClassLibrary;
using AoC2020Days;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AoC2020ConsoleApp
{
    public class Menu
    {
        private List<Day> days;
        private int selected;

        public Menu(int nrDays)
        {
            days = new List<Day>();
            for (int i = 1; i <= nrDays; i++)
            {
                days.Add(new Day(i));
            }

            selected = 0;
        }

        public void Skip(int steps)
        {
            selected += steps;
            selected %= days.Count;
            if (selected < 0 )
            {
                selected += days.Count;
            }
        }

        private String Header()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Advent of Code 2020");
            builder.AppendLine("Esc to exit");
            return builder.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(Header());
            builder.AppendLine("");
            String checkSelected;
            for (int i = 0; i < days.Count; i++)
            {
                checkSelected = selected == i ? "X" : " ";
                builder.AppendLine(String.Format("[{0}] {1}", checkSelected, days[i].ToString()));
            }

            return builder.ToString();
        }

        private string GetPath(string fileName)
        {
            return Path.Combine(AppContext.BaseDirectory, "Input", fileName);
        }

        internal void Handle()
        {
            Day d = new Day(0);

            switch (selected + 1)
            {
                case 1:
                    d = new Day1(GetPath("Day1-Part1.txt"));
                    Console.WriteLine(String.Format("Result Part 1: {0}", d.Part1()));
                    Console.WriteLine(String.Format("Result Part 2: {0}", d.Part2()));
                    break;
                case 2:
                    d = new Day2(GetPath("Day2-Part1.txt"));
                    Console.WriteLine(String.Format("Result Part 1: {0}", d.Part1()));
                    Console.WriteLine(String.Format("Result Part 2: {0}", d.Part2()));
                    break;
                case 3:
                    d = new Day3(GetPath("Day3-Part1.txt"));
                    Console.WriteLine(String.Format("Result Part 1: {0}", d.Part1Long()));
                    Console.WriteLine(String.Format("Result Part 2: {0}", d.Part2Long()));
                    break;
                case 4:
                    d = new Day4(GetPath("Day4-Part1.txt"));
                    Console.WriteLine(String.Format("Result Part 1: {0}", d.Part1()));
                    Console.WriteLine(String.Format("Result Part 2: {0}", d.Part2()));
                    break;
                case 5:
                    d = new Day5(GetPath("Day5-Part1.txt"));
                    Console.WriteLine(String.Format("Result Part 1: {0}", d.Part1()));
                    Console.WriteLine(String.Format("Result Part 2: {0}", d.Part2()));
                    break;
                case 6:
                    d = new Day6(GetPath("Day6-Part1.txt"));
                    Console.WriteLine(String.Format("Result Part 1: {0}", d.Part1()));
                    Console.WriteLine(String.Format("Result Part 2: {0}", d.Part2()));
                    break;
                case 7:
                    d = new Day7(GetPath("Day7-Part1.txt"));
                    Console.WriteLine(String.Format("Result Part 1: {0}", d.Part1()));
                    Console.WriteLine(String.Format("Result Part 2: {0}", d.Part2()));
                    break;
                case 8:
                    d = new Day8(GetPath("Day8-Part1.txt"));
                    Console.WriteLine(String.Format("Result Part 1: {0}", d.Part1()));
                    Console.WriteLine(String.Format("Result Part 2: {0}", d.Part2()));
                    break;
                case 9:
                    d = new Day9(GetPath("Day9-Part1.txt"), 25);
                    Console.WriteLine(String.Format("Result Part 1: {0}", d.Part1Long()));
                    Console.WriteLine(String.Format("Result Part 2: {0}", d.Part2Long()));
                    break;
                case 10:
                    d = new Day10(GetPath("Day10-Part1.txt"));
                    Console.WriteLine(String.Format("Result Part 1: {0}", d.Part1()));
                    Console.WriteLine(String.Format("Result Part 2: {0}", d.Part2Long()));
                    break;
                case 11:
                    d = new Day11(GetPath("Day11-Part1.txt"));
                    Console.WriteLine(String.Format("Result Part 1: {0}", d.Part1()));
                    Console.WriteLine(String.Format("Result Part 2: {0}", d.Part2()));
                    break;
                case 12:
                    d = new Day12(GetPath("Day12-Part1.txt"));
                    Console.WriteLine(String.Format("Result Part 1: {0}", d.Part1()));
                    Console.WriteLine(String.Format("Result Part 2: {0}", d.Part2()));
                    break;
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
