using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020ClassLibrary
{
    public class BoardingPass
    {
        private string pass;
        private uint seat;

        public BoardingPass(string Pass)
        {
            pass = Pass;
            if (pass.Length == 10)
            {
                foreach (char c in pass)
                {
                    if (c == 'B' || c == 'R')
                    {
                        seat += 0b_1;
                    }

                    seat = seat << 1;
                }
                seat = seat >> 1;
            }
        }

        public int SeatID
        {
            get
            {
                return (int)seat;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} ({1})", pass, SeatID);
        }
    }
}
