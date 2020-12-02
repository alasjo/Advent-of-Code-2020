using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AoC2020ClassLibrary
{
    public class Analysis<T>
    {
        public static SortedDictionary<T, int> Histogram(IEnumerable<T> list)
        {
            SortedDictionary<T, int> histogram = new SortedDictionary<T, int>();

            foreach (var val in list)
            {
                if (histogram.ContainsKey(val))
                {
                    histogram[val] += 1;
                }
                else
                {
                    histogram.Add(val, 1);
                }
            }

            return histogram;
        }

        public static IEnumerable<int> AllIndexOf(string find, string subject)
        {
            for (int index = 0; ; index += find.Length)
            {
                index = subject.IndexOf(find, index);
                if (index == -1)
                    break;
                yield return index;
            }
        }
    }
}
