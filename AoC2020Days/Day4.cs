using AoC2020ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020Days
{
    public class Day4 : Day
    {
        private Iter<Passport> passports;

        public Day4(string path) : base(4)
        {
            passports = new Iter<Passport>();
            FileParser parser = new FileParser(path);

            StringBuilder builder = new StringBuilder();
            foreach (var line in parser.Lines)
            {
                if (line.Length == 0)
                {
                    if (builder.Length > 1)
                    {
                        passports.Add(Passport.FromString(builder.ToString()));
                    }
                    builder = new StringBuilder();
                }
                builder.Append(line.Trim() + " ");
            }

            if (builder.Length > 1)
            {
                passports.Add(Passport.FromString(builder.ToString()));
            }
        }

        public override int Part1()
        {
            int count = 0;

            foreach (var passport in passports)
            {
                Console.WriteLine(passport.ToString() + " " + (passport.RequiredFieldsPresent ? "fields ok" : "fields not ok"));
                if (passport.RequiredFieldsPresent)
                {
                    count++;
                }
            }

            return count;
        }

        public override int Part2()
        {
            int count = 0;

            foreach (var passport in passports)
            {
                Console.WriteLine(passport.ToString() + " " + (passport.IsValid ? "valid" : "not valid"));
                if (passport.IsValid)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
