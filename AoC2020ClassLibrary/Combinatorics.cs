using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2020ClassLibrary
{
    public class Combinatorics
    {
        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetCombinations(list, length - 1)
                .SelectMany(t => list, (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public static IEnumerable<int[]> GetCombinations(int m, int n)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value < n)
                {
                    result[index++] = ++value;
                    stack.Push(value);

                    if (index == m)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }
    }
}
