using System;
using System.Collections.Generic;

namespace CommonProblems
{
    // https://en.wikipedia.org/wiki/Fibonacci_number

    public class Fibonacci
    {
        public static int GetFibonacciNumber(int n, Method method)
        {
            switch (method)
            {
                case Method.Recursive:
                    return GetFibonacciNumberRecursive(n);
                case Method.Dynamic:
                    return GetFibonacciNumberDynamic(n);
                default:
                    return GetFibonacciNumberIterative(n);
            }
        }

        // Time complexity: O(n)
        // Space: O(1)
        public static int GetFibonacciNumberIterative(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("n must be 0 or greater");
            }

            if (n == 0 || n == 1)
            {
                return n;
            }

            int a = 0;
            int b = 1;
            int c = 0;

            for (int index = 2; index <= n; index++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return c;
        }

        // Time complexity: Exponential
        // Space: O(n)
        // http://stackoverflow.com/questions/16388982/algorithm-function-for-fibonacci-series
        public static int GetFibonacciNumberRecursive(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("n must be 0 or greater");
            }

            if (n <= 1)
            {
                return n;
            }
            return GetFibonacciNumberRecursive(n - 1) + GetFibonacciNumberRecursive(n - 2);
        }

        // Time complexity: O(n)
        // Space: O(n)
        // Uses memoization to save the sub problem result so it doesn't have to be solved again
        public static int GetFibonacciNumberDynamic(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("n must be 0 or greater");
            }

            if (n <= 1)
            {
                return n;
            }

            int[] f = new int[n + 1];                       
            f[0] = 0;
            f[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                f[i] = f[i - 1] + f[i - 2];
            }

            return f[n];
        }

        // Returns the sequence of numbers up to the specified index.
        // Also supports negative indices.
        public static IEnumerable<int> GetFibonacciSequence(int n)
        {
            int absN = (n > 0) ? n : -n;

            // Sequence always starts with 0
            yield return 0;

            if (absN > 0)
            {
                yield return (n > 0) ? 1 : -1;
            }

            int a = 0;
            int b = 1;
            int c = 0;

            for (int index = 2; index <= absN; index++)
            {
                c = a + b;
                yield return (n > 0) ? c : -c;
                a = b;
                b = c;
            }
        }

        public enum Method { Iterative, Recursive, Dynamic };
    }
}
