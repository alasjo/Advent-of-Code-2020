using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020ClassLibrary
{
    public class XmasEncryption
    {
        private long[] prev;

        public XmasEncryption(long[] preamble)
        {
            prev = new long[preamble.Length];
            for (int i = 0; i < preamble.Length; i++)
            {
                prev[i] = preamble[i];
            }
        }

        public bool IsValid(long n)
        {
            for (int i = 0; i < prev.Length; i++)
            {
                for (int j = i; j < prev.Length; j++)
                {
                    if (prev[i] + prev[j] == n)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void Add(long n)
        {
            long[] temp = new long[prev.Length];

            for (int i = 1; i < prev.Length; i++)
            {
                temp[i - 1] = prev[i];
            }

            temp[prev.Length - 1] = n;

            prev = temp;
        }
    }
}
