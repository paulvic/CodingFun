using NUnit.Framework;
using System;

namespace CommonProblems.NUnit.Tests
{
    [TestFixture]
    class OddOccurenceTest
    {
        #region Generic Implementation
        [Test]
        public void ArrayContainingNoElementsThrowsException()
        {
            OddOccurence<char> odd = new OddOccurence<char>();
            ArgumentException ex = Assert.Throws<ArgumentException>(
                delegate { odd.GetOddOccurence(new char[]{}); });
        }

        [Test]
        public void ArrayContainingOneElementReturnsThatElement()
        {
            OddOccurence<char> odd = new OddOccurence<char>();
            Assert.AreEqual('a', odd.GetOddOccurence(new char[]{ 'a' }));
        }

        [Test]
        public void ArrayContainingTwoElementsThrowsException()
        {
            OddOccurence<char> odd = new OddOccurence<char>();
            ArgumentException ex = Assert.Throws<ArgumentException>(
                delegate { odd.GetOddOccurence(new char[] { 'a', 'b' }); });
        }

        [Test]
        public void ArrayContainingOneOddElementOccurenceReturnsThatElement()
        {
            OddOccurence<char> odd = new OddOccurence<char>();
            Assert.AreEqual('c', odd.GetOddOccurence(new char[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c' }));
        }

        [Test]
        public void ArrayContainingTwoOddElementOccurencesThrowsException()
        {
            OddOccurence<char> odd = new OddOccurence<char>();
            ArgumentException ex = Assert.Throws<ArgumentException>(
                delegate { odd.GetOddOccurence(new char[] { 'a', 'a', 'a', 'b', 'b', 'c', 'c', 'c' }); });
        }
        
        [Test]
        public void ArrayContainingNoIntsThrowsException()
        {
            OddOccurence<int> odd = new OddOccurence<int>();
            ArgumentException ex = Assert.Throws<ArgumentException>(
                delegate { odd.GetOddOccurence(new int[] { }); });
        }

        [Test]
        public void ArrayContainingOneIntReturnsThatElement()
        {
            OddOccurence<int> odd = new OddOccurence<int>();
            Assert.AreEqual(1, odd.GetOddOccurence(new int[] { 1 }));
        }

        [Test]
        public void ArrayContainingTwoIntsThrowsException()
        {
            OddOccurence<int> odd = new OddOccurence<int>();
            ArgumentException ex = Assert.Throws<ArgumentException>(
                delegate { odd.GetOddOccurence(new int[] { 1, 2 }); });
        }

        [Test]
        public void ArrayContainingOneOddIntOccurenceReturnsThatElement()
        {
            OddOccurence<int> odd = new OddOccurence<int>();
            Assert.AreEqual(3, odd.GetOddOccurence(new int[] { 1, 1, 2, 2, 3, 3, 3 }));
        }

        [Test]
        public void ArrayContainingTwoOddIntsThrowsException()
        {
            OddOccurence<int> odd = new OddOccurence<int>();
            ArgumentException ex = Assert.Throws<ArgumentException>(
                delegate { odd.GetOddOccurence(new int[] { 1, 1, 1, 2, 2, 2, 3, 3 }); });
        }
        #endregion

        #region int implementation
        [Test]
        public void IntArrayContainingNoIntsThrowsException()
        {
            OddOccurence<int> odd = new OddOccurence<int>();
            ArgumentException ex = Assert.Throws<ArgumentException>(
                delegate { odd.GetIntOddOccurence(new int[] { }); });
        }

        [Test]
        public void IntArrayContainingOneIntReturnsThatElement()
        {
            OddOccurence<int> odd = new OddOccurence<int>();
            Assert.AreEqual(1, odd.GetIntOddOccurence(new int[] { 1 }));
        }

        [Test]
        public void IntArrayContainingTwoIntsThrowsException()
        {
            OddOccurence<int> odd = new OddOccurence<int>();
            ArgumentException ex = Assert.Throws<ArgumentException>(
                delegate { odd.GetIntOddOccurence(new int[] { 1, 2 }); });
        }

        [Test]
        public void IntArrayContainingOneOddIntOccurenceReturnsThatElement()
        {
            OddOccurence<int> odd = new OddOccurence<int>();
            Assert.AreEqual(3, odd.GetIntOddOccurence(new int[] { 1, 1, 2, 2, 3, 3, 3 }));
        }

        [Test]
        public void IntArrayContainingOneOddIntOccurenceNotSortedReturnsThatElement()
        {
            OddOccurence<int> odd = new OddOccurence<int>();
            Assert.AreEqual(7, odd.GetIntOddOccurence(new int[] { 7, 8, 9, 8, 9 }));
        }

        [Test]
        public void IntArrayContainingTwoOddIntOccurencesReturnsWrongValue()
        {
            OddOccurence<int> odd = new OddOccurence<int>();
            Assert.AreEqual(3, odd.GetIntOddOccurence(new int[] { 1, 1, 1, 2, 2, 2, 3, 3 }));
        }
        #endregion
    }
}
