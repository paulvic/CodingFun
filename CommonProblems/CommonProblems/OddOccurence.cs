using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonProblems
{
    public class OddOccurence<T>
    {
        public T GetOddOccurence(T[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array must not be empty");
            }
            else if (array.Length == 2)
            {
                throw new ArgumentException("Array cannot contain just two elements");
            }
 
            HashSet<T> numberTracker = new HashSet<T>();
            for (int i = 0; i < array.Length; i++)
            {
                if (numberTracker.Contains(array[i]))
                {
                    numberTracker.Remove(array[i]);
                }
                else
                {
                    numberTracker.Add(array[i]);
                }
            }

            if (numberTracker.Count > 1)
            {
                throw new ArgumentException("Array more than one element that occurs an odd number of times");
            }

            return numberTracker.First();
        }

        public int GetIntOddOccurence(int[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array must not be empty");
            }
            else if (array.Length == 2)
            {
                throw new ArgumentException("Array cannot contain just two elements");
            }

            int bitValue = 0;
            for (int i = 0; i < array.Length; i++)
            {
                // Performing XOR on a value against itself always yields zero
                // If we encounter the same number twice, the second XOR effectively removes it
                bitValue = bitValue ^ array[i];
            }

            return bitValue;
        }
    }
}
