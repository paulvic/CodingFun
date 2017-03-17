using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonProblems
{
    public class RangeOverlap
    {
        public static Range[] GetOverlappingRanges(Range[] ranges)
        {
            HashSet<Range> results = new HashSet<Range>(new RangeEqualityComparer());

            for (int i = 0; i < ranges.Length; i++)
            {
                for (int j = i+1; j < ranges.Length; j++)
                {
                    int s1 = ranges[i].Start;
                    int e1 = ranges[i].End;
                    int s2 = ranges[j].Start;
                    int e2 = ranges[j].End;

                    if ((s1 <= e2 && s1 >= s2) ||
                        (e1 >= s2 && e1 <= e2))
                    {
                        // found overlap
                        int start = (s1 < s2) ? s1 : s2;
                        int end = (e1 > e2) ? e1 : e2;
                        Range fullRange = new Range(start, end);

                        // As this is a hashset the range won't be added if it's already there
                        results.Add(fullRange);
                    }
                }
            }

            return results.ToArray();
        }
    }

    public class Range : IEquatable<Range>
    {
        public int Start { get; private set; }
        public int End { get; private set; }

        public Range(int start, int end)
        {
            if (start >= end)
            {
                throw new ArgumentOutOfRangeException($"The start value '{start}' must be less than the end value '{end}'");
            }

            this.Start = start;
            this.End = end;
        }

        public bool Equals(Range other)
        {
            return ((this.Start == other.Start) && (this.End == other.End));

        }
    }

    class RangeEqualityComparer : IEqualityComparer<Range>
    {
        public bool Equals(Range range1, Range range2)
        {
            return range1.Equals(range2);
        }

        public int GetHashCode(Range range)
        {
            int hCode = range.Start ^ range.End;
            return hCode.GetHashCode();
        }
    }
}
