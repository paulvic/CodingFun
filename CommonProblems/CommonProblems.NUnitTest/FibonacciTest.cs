using NUnit.Framework;
using System.Linq;

namespace CommonProblems.NUnitTest
{
    [TestFixture]
    public class FibonacciTest
    {
        [Test]
        public void ShouldFib0EqualZero()
        {
            int result;
            result = Fibonacci.GetFibonacciNumber(0, Fibonacci.Method.Iterative);
            Assert.AreEqual(0, result);

            result = Fibonacci.GetFibonacciNumber(0, Fibonacci.Method.Recursive);
            Assert.AreEqual(0, result);

            result = Fibonacci.GetFibonacciNumber(0, Fibonacci.Method.Dynamic);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ShouldFib1EqualOne()
        {
            int result;
            result = Fibonacci.GetFibonacciNumber(1, Fibonacci.Method.Iterative);
            Assert.AreEqual(1, result);

            result = Fibonacci.GetFibonacciNumber(1, Fibonacci.Method.Recursive);
            Assert.AreEqual(1, result);

            result = Fibonacci.GetFibonacciNumber(1, Fibonacci.Method.Dynamic);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ShouldFib2EqualOne()
        {
            int result;
            result = Fibonacci.GetFibonacciNumber(2, Fibonacci.Method.Iterative);
            Assert.AreEqual(1, result);

            result = Fibonacci.GetFibonacciNumber(2, Fibonacci.Method.Recursive);
            Assert.AreEqual(1, result);

            result = Fibonacci.GetFibonacciNumber(2, Fibonacci.Method.Dynamic);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ShouldFib3EqualTwo()
        {
            int result;
            result = Fibonacci.GetFibonacciNumber(3, Fibonacci.Method.Iterative);
            Assert.AreEqual(2, result);

            result = Fibonacci.GetFibonacciNumber(3, Fibonacci.Method.Recursive);
            Assert.AreEqual(2, result);

            result = Fibonacci.GetFibonacciNumber(3, Fibonacci.Method.Dynamic);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void ShouldFib4EqualThree()
        {
            int result;
            result = Fibonacci.GetFibonacciNumber(4, Fibonacci.Method.Iterative);
            Assert.AreEqual(3, result);

            result = Fibonacci.GetFibonacciNumber(4, Fibonacci.Method.Recursive);
            Assert.AreEqual(3, result);

            result = Fibonacci.GetFibonacciNumber(4, Fibonacci.Method.Dynamic);
            Assert.AreEqual(3, result);
        }
        [Test]
        public void ShouldFib5EqualFive()
        {
            int result;
            result = Fibonacci.GetFibonacciNumber(5, Fibonacci.Method.Iterative);
            Assert.AreEqual(5, result);

            result = Fibonacci.GetFibonacciNumber(5, Fibonacci.Method.Recursive);
            Assert.AreEqual(5, result);

            result = Fibonacci.GetFibonacciNumber(5, Fibonacci.Method.Dynamic);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void ShouldFibMinus3EqualZeroMinusOneMinusOneMinusTwo()
        {
            int[] expected = { 0, -1, -1, -2 };
            int[] results = Fibonacci.GetFibonacciSequence(-3).ToArray();
            Assert.AreEqual(expected, results);
        }
    }
}
