using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonProblems
{
    public class NumberPool
    {
        private const long MinValue = 1;
        private long highestCheckedOut;
        private SortedSet<long> checkedIn;

        public NumberPool()
        {
            highestCheckedOut = 0;
            checkedIn = new SortedSet<long>();
        }

        public long CheckOut()
        {
            long lowestAvailable = 0;

            if (checkedIn.Count != 0)
            {
                lowestAvailable = checkedIn.First();
                checkedIn.Remove(lowestAvailable);
            }
            else
            {
                lowestAvailable = ++highestCheckedOut;
            }

            return lowestAvailable;
        }

        public void CheckIn(long n)
        {
            if (n < MinValue)
            {
                throw new ArgumentException($"{n} must be greater than {MinValue}");
            }

            if (n == highestCheckedOut)
            {
                highestCheckedOut--;
            }
            else
            {
                if (n > highestCheckedOut || checkedIn.Contains(n))
                {
                    throw new InvalidOperationException($"{n} is not available");
                }
                else
                {
                    checkedIn.Add(n);
                }
            }
        }
    }
}
