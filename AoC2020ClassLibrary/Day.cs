using System;

namespace AoC2020ClassLibrary
{
    public class Day
    {
        private readonly int number;

        public Day(int nr)
        {
            number = nr;
        }

        public override String ToString()
        {
            return String.Format("Day {0}", number);
        }
    }
}
