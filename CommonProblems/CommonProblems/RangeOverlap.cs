using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonProblems
{
    public class RangeOverlap
    {
        public static Range[] GetMergedOverlappingRanges(Range[] ranges)
        {
            if (ranges.Length == 0)
            {
                throw new ArgumentException("ranges array must not be empty");
            }
            else if (ranges.Length == 1)
            {
                return new Range[] { };
            }
            
            Array.Sort(ranges);

            Stack<Range> stack = new Stack<Range>();
            stack.Push(ranges[0]);

            var isCurrentAnOverlap = false;
            for (int i = 1; i < ranges.Length; i++)
            {
                var current = stack.Peek();

                if (current.End < ranges[i].Start)
                {
                    if (!isCurrentAnOverlap)
                    {
                        stack.Pop();
                        isCurrentAnOverlap = false;
                    }
                    stack.Push(ranges[i]);
                }
                else if (current.End < ranges[i].End)
                {
                    current.End = ranges[i].End;
                    isCurrentAnOverlap = true;
                }
            }

            if (!isCurrentAnOverlap)
            {
                stack.Pop();
            }

            return stack.Reverse().ToArray();
        }
    }

    public class Range : IEquatable<Range>, IComparable<Range>
    {
        public int Start { get; set; }
        public int End { get; set; }

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

        public int CompareTo(Range other)
        {
            if (this.Start < other.Start)
            {
                return -1;
            }
            else if (this.Start > other.Start)
            {
                return 1;
            }
            return 0;
        }
    }
}

