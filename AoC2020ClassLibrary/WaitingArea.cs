using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020ClassLibrary
{
    public class WaitingArea
    {
        Seat[,] seats;
        readonly int height;
        readonly int width;
        Dictionary<Tuple<int, int>, List<Tuple<int, int>>> dict;

        public WaitingArea(int w, int h)
        {
            height = h;
            width = w;
            seats = InitSeats();
            dict = new Dictionary<Tuple<int, int>, List<Tuple<int, int>>>();
        }

        private Seat[,] InitSeats()
        {
            Seat[,] _seats = new Seat[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    _seats[i, j] = new Seat(SeatState.Floor);
                }
            }
            return _seats;
        }

        public void SetState(int x, int y, SeatState state)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                seats[y, x].State = state;
            }
        }

        public SeatState GetState(int x, int y)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                return seats[y, x].State;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int CountOccupied()
        {
            int count = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (seats[i, j].State == SeatState.Occupied)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static int CountOccupied(List<Seat> seatList)
        {
            int count = 0;
            foreach (var s in seatList)
            {
                if (s.State == SeatState.Occupied)
                {
                    count++;
                }
            }
            return count;
        }

        private List<Seat> Adjacent(int x, int y)
        {
            List<Seat> adj = new List<Seat>();

            for (int i = y - 1; i <= y + 1; i++)
            {
                // row -1, 0, +1
                for (int j = x - 1; j <= x + 1; j++)
                {
                    // col -1, 0, +1
                    if (i == y && j == x)
                    {
                        // do nothing
                    }
                    else
                    {
                        // not current pos
                        if (i >= 0 && i < height && j >= 0 && j < width)
                        {
                            // not out of bounds
                            adj.Add(seats[i, j]);
                        }
                    }
                }
            }

            return adj;
        }

        private List<Seat> Visible(int x, int y)
        {
            List<Seat> vis = new List<Seat>();

            Tuple<int, int> t = new Tuple<int, int>(x, y);

            if (dict.ContainsKey(t))
            {
                foreach (var list in dict[t])
                {
                    vis.Add(seats[list.Item2, list.Item1]);
                }
                return vis;
            }

            List<Tuple<int, int>> tList = new List<Tuple<int, int>>();

            // Add vertical
            for (int iy = y + 1; iy < height; iy++)
            {
                if (seats[iy, x].State != SeatState.Floor)
                {
                    tList.Add(new Tuple<int, int>(x, iy));
                    vis.Add(seats[iy, x]);
                    break;
                }
            }
            for (int iy = y - 1; iy >= 0; iy--)
            {
                if (seats[iy, x].State != SeatState.Floor)
                {
                    tList.Add(new Tuple<int, int>(x, iy));
                    vis.Add(seats[iy, x]);
                    break;
                }
            }

            // Add horizontal
            for (int ix = x + 1; ix < width; ix++)
            {
                if (seats[y, ix].State != SeatState.Floor)
                {
                    tList.Add(new Tuple<int, int>(ix, y));
                    vis.Add(seats[y, ix]);
                    break;
                }
            }
            for (int ix = x - 1; ix >= 0; ix--)
            {
                if (seats[y, ix].State != SeatState.Floor)
                {
                    tList.Add(new Tuple<int, int>(ix, y));
                    vis.Add(seats[y, ix]);
                    break;
                }
            }

            // Add diagonal
            int vy = -1;
            int vx = -1;
            int i = y + vy;
            int j = x + vx;
            while (i >= 0 && i < height && j >= 0 && j < width)
            {
                if (seats[i, j].State != SeatState.Floor)
                {
                    tList.Add(new Tuple<int, int>(j, i));
                    vis.Add(seats[i, j]);
                    break;
                }
                i += vy;
                j += vx;
            }

            // Add diagonal
            vy = -1;
            vx = 1;
            i = y + vy;
            j = x + vx;
            while (i >= 0 && i < height && j >= 0 && j < width)
            {
                if (seats[i, j].State != SeatState.Floor)
                {
                    tList.Add(new Tuple<int, int>(j, i));
                    vis.Add(seats[i, j]);
                    break;
                }
                i += vy;
                j += vx;
            }

            // Add diagonal
            vy = 1;
            vx = 1;
            i = y + vy;
            j = x + vx;
            while (i >= 0 && i < height && j >= 0 && j < width)
            {
                if (seats[i, j].State != SeatState.Floor)
                {
                    tList.Add(new Tuple<int, int>(j, i));
                    vis.Add(seats[i, j]);
                    break;
                }
                i += vy;
                j += vx;
            }

            // Add diagonal
            vy = 1;
            vx = -1;
            i = y + vy;
            j = x + vx;
            while (i >= 0 && i < height && j >= 0 && j < width)
            {
                if (seats[i, j].State != SeatState.Floor)
                {
                    tList.Add(new Tuple<int, int>(j, i));
                    vis.Add(seats[i, j]);
                    break;
                }
                i += vy;
                j += vx;
            }

            dict[t] = tList;

            return vis;
        }

        public void Run()
        {
            Seat[,] _seats = InitSeats();

            // If a seat is empty (L) and there are no occupied seats adjacent to it, the seat becomes occupied.
            // If a seat is occupied (#) and four or more seats adjacent to it are also occupied, the seat becomes empty.
            // Otherwise, the seat's state does not change.
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int occ = CountOccupied(Adjacent(j, i));
                    if (seats[i, j].State == SeatState.Empty && occ == 0){
                        _seats[i, j].State = SeatState.Occupied;
                    }
                    else if (seats[i, j].State == SeatState.Occupied && occ >= 4)
                    {
                        _seats[i, j].State = SeatState.Empty;
                    }
                    else
                    {
                        _seats[i, j].State = seats[i, j].State;
                    }
                }
            }

            seats = _seats;
        }

        public void RunPart2()
        {
            Seat[,] _seats = InitSeats();

            // If a seat is empty (L) and there are no occupied seats visible to it, the seat becomes occupied.
            // If a seat is occupied (#) and five or more seats visible to it are also occupied, the seat becomes empty.
            // Otherwise, the seat's state does not change.
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int occ = CountOccupied(Visible(j, i));
                    if (seats[i, j].State == SeatState.Empty && occ == 0)
                    {
                        _seats[i, j].State = SeatState.Occupied;
                    }
                    else if (seats[i, j].State == SeatState.Occupied && occ >= 5)
                    {
                        _seats[i, j].State = SeatState.Empty;
                    }
                    else
                    {
                        _seats[i, j].State = seats[i, j].State;
                    }
                }
            }

            seats = _seats;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    builder.Append(seats[i, j].ToString());
                }
                builder.Append(System.Environment.NewLine);
            }
            return builder.ToString();
        }
    }

    public class Seat
    {
        private SeatState state;

        public Seat(SeatState inState)
        {
            state = inState;
        }

        public SeatState State
        {
            get => state;
            set
            {
                state = value;
            }
        }

        public override string ToString()
        {
            switch (state)
            {
                case SeatState.Empty:
                    return "L";
                case SeatState.Occupied:
                    return "#";
                default:
                    return ".";
            }
        }
    }

    public enum SeatState
    {
        Floor,
        Empty,
        Occupied
    }
}
