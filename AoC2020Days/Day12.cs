using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AoC2020ClassLibrary;

namespace AoC2020Days
{
    public class Day12 : Day
    {
        private int x = 0;
        private int y = 0;
        private int wx = 10;
        private int wy = -1;
        FileParser parser;
        Regex re = new Regex(@"([A-Z])([0-9]+)");

        public Day12(string path) : base(12)
        {
            parser = new FileParser(path);
        }

        public override int Part1()
        {
            x = 0;
            y = 0;
            Tuple<int, int> direction = Direction("E", new Tuple<int, int>(0, 0));
            string[] directions = { "E", "S", "W", "N" };
            int facing = 0;

            string inst;
            int len;

            Console.WriteLine("x: " + x + ", y: " + y);

            foreach (var line in parser.SplitLinesByRegex(re))
            {
                Console.WriteLine(line[1] + line[2]);
                inst = line[1];
                len = int.Parse(line[2]);
                switch (inst)
                {
                    case "N":
                        y -= len;
                        break;
                    case "S":
                        y += len;
                        break;
                    case "E":
                        x += len;
                        break;
                    case "W":
                        x -= len;
                        break;
                    case "F":
                        x += direction.Item1 * len;
                        y += direction.Item2 * len;
                        break;
                    case "L":
                        facing = (facing - (len / 90)) % directions.Length;
                        if (facing < 0)
                        {
                            facing += directions.Length;
                        }
                        direction = Direction(directions[facing], direction);
                        break;
                    case "R":
                        facing = (facing + (len / 90)) % directions.Length;
                        if (facing < 0)
                        {
                            facing += directions.Length;
                        }
                        direction = Direction(directions[facing], direction);
                        break;
                }

                Console.WriteLine("x: " + x + ", y: " + y);
            }


            return Math.Abs(x) + Math.Abs(y);
        }

        private Tuple<int, int> Direction(string v, Tuple<int, int> def)
        {
            switch (v)
            {
                case "N":
                    return new Tuple<int, int>(0, -1);
                case "S":
                    return new Tuple<int, int>(0, 1);
                case "E":
                    return new Tuple<int, int>(1, 0);
                case "W":
                    return new Tuple<int, int>(-1, 0);
            }

            return def;
        }

        public override int Part2()
        {
            x = 0;
            y = 0;
            string inst;
            int len;

            Console.WriteLine("x: " + x + ", y: " + y);
            Console.WriteLine("wx: " + wx + ", wy: " + wy);

            foreach (var line in parser.SplitLinesByRegex(re))
            {
                Console.WriteLine(line[0]);
                inst = line[1];
                len = int.Parse(line[2]);
                switch (inst)
                {
                    case "N":
                    case "S":
                    case "E":
                    case "W":
                        MoveWaypoint(inst, len);
                        break;
                    case "L":
                    case "R":
                        RotateWaypoint(inst, len);
                        break;
                    case "F":
                        for (int i = 0; i < len; i++)
                        {
                            x += wx;
                            y += wy;
                            // wx += dx;
                            // wy += dy;
                        }
                        break;
                    default:
                        // nothing
                        break;
                }

                Console.WriteLine("x: " + x + ", y: " + y);
                Console.WriteLine("wx: " + wx + ", wy: " + wy);
                Console.WriteLine();
            }

            return Math.Abs(x) + Math.Abs(y);
        }

        private void RotateWaypoint(string inst, int len)
        {
            int tx = wx;
            int ty = wy;
            int temp;

            for (int i = 0; i < len; i += 90)
            {
                // Flip
                temp = tx;
                tx = ty;
                ty = temp;
                if (inst.Equals("L"))
                {
                    // Anti-Clockwise
                    ty *= -1;
                }
                else if (inst.Equals("R"))
                {
                    // Clockwise
                    tx *= -1;
                }
            }

            wx = tx;
            wy = ty;
        }

        private void MoveWaypoint(string inst, int len)
        {
            Tuple<int, int> d = Direction(inst, new Tuple<int, int>(0, 0));
            wx += len * d.Item1;
            wy += len * d.Item2;
        }
    }
}
