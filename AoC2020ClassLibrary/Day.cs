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

        public virtual int Part1() { return 0; }
        public virtual int Part2() { return 0; }
        public virtual long Part1Long() { return 0; }
        public virtual long Part2Long() { return 0; }
    }
}
