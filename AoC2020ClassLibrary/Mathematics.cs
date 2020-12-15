using System;
using System.Collections.Generic;
using System.Linq;

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

        public static long FindNextNumerator(long start, long divisor)
        {
            if (start <= divisor)
            {
                return divisor;
            }

            long num = start;

            for (long i = start; i < start + divisor; i++)
            {
                if (i % divisor == 0)
                {
                    return i;
                }
            }

            return num;
        }

        public static long GreatestCommonDivisor(long a, long b)
        {
            while (b != 0)
            {
                long t = b;
                b = a % b;
                a = t;
            }

            return a;
        }

        public static long LeastCommonMultiple(long a, long b)
        {
            return (a / GreatestCommonDivisor(a, b)) * b;
        }

        /// <summary>
        /// Taken in part from https://rosettacode.org/wiki/Chinese_remainder_theorem#C.23
        /// </summary>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static long ChineseRemainderTheorem(long[] n, long[] a)
        {
            long prod = 1;
            foreach (var ns in n)
            {
                prod *= ns;
            }
            
            long p;
            long sm = 0;
            for (long i = 0; i < n.Length; i++)
            {
                p = prod / n[i];
                sm += a[i] * ModularMultiplicativeInverse(p, n[i]) * p;
            }

            Console.WriteLine(prod + " " + sm);

            return prod - (sm % prod);
        }

        /// <summary>
        /// Taken from https://rosettacode.org/wiki/Chinese_remainder_theorem#C.23
        /// </summary>
        /// <param name="a"></param>
        /// <param name="mod"></param>
        /// <returns></returns>
        private static long ModularMultiplicativeInverse(long a, long mod)
        {
            long b = a % mod;
            for (long x = 1; x < mod; x++)
            {
                if ((b * x) % mod == 1)
                {
                    return x;
                }
            }
            return 1;
        }
    }
}
