using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020ClassLibrary
{
    public class Map
    {
        private int x;
        private int y;

        private readonly int width;
        private readonly int height;

        private Point[,] map;

        public Map(int sizeX, int sizeY)
        {
            width = sizeX;
            height = sizeY;
            map = new Point[sizeY,sizeX];
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    map[i, j] = new Point('.');
                }
            }
        }

        public char CurrentState
        {
            get
            {
                return map[y, x].State;
            }
        }

        public Tuple<int, int> CurrentPosition
        {
            get
            {
                return new Tuple<int, int>(x, y);
            }
        }

        public void SetPosition(int X, int Y)
        {
            x = X % width;
            y = Y % height;
        }

        public void Go(int X, int Y)
        {
            x += X;
            x %= width;
            if (x < 0)
            {
                x += width;
            }

            y += Y;
            y %= height;
            if (y < 0)
            {
                y += height;
            }
        }

        public void SetState(int X, int Y, char c)
        {
            map[Y % height, X % width].State = c;
        }

        public Tuple<int, int> Size
        {
            get
            {
                return new Tuple<int, int>(width, height);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (CurrentPosition.Item1 == j && CurrentPosition.Item2 == i)
                    {
                        builder.Append('0');
                    }
                    else
                    {
                        builder.Append(map[i, j].State);
                    }
                }
                builder.AppendLine();
            }

            return builder.ToString();
        }

        private class Point
        {
            private char state;

            public Point(char s)
            {
                state = s;
            }

            public char State
            {
                get
                {
                    return state;
                }
                set
                {
                    state = value;
                }
            }
        }
    }
}
