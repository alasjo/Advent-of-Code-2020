using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020ClassLibrary
{
    public class Mathematics
    {
        public static long BinomialCoefficient(long n, long k)
        {
            long r = 1;
            long d;
            if (k > n) return 0;
            for (d = 1; d <= k; d++)
            {
                r *= n--;
                r /= d;
            }
            return r;
        }
    }
}
