using AoC2020ClassLibrary;
using System;
using System.Collections.Generic;
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
    }
}
