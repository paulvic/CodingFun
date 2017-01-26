using NUnit.Framework;
using DataStructures.LinkedList;
using System.Linq;

namespace DataStructures.NUnitTest.LinkedListTest
{
    [TestFixture]
    class LinkedListTest
    {
        [Test]
        public void IsEmptyAtInitialization()
        {
            LinkedList<int> list = new LinkedList<int>();
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void CanAddToFirst()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(1);
            Assert.AreEqual(1, list.Count);
            list.AddFirst(2);
            Assert.AreEqual(2, list.Count);
            int[] expected = new int[] { 2, 1 };
            int[] actual = list.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanAddToLast()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(1);
            Assert.AreEqual(1, list.Count);
            list.AddLast(2);
            Assert.AreEqual(2, list.Count);
            int[] expected = new int[] { 1, 2 };
            int[] actual = list.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanRemoveFromFirst()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(1);
            Assert.AreEqual(1, list.Count);
            list.AddFirst(2);
            Assert.AreEqual(2, list.Count);
            list.RemoveFirst();
            Assert.AreEqual(1, list.Count);
            int[] expected = new int[] { 1 };
            int[] actual = list.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanRemoveFromLast()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(1);
            Assert.AreEqual(1, list.Count);
            list.AddLast(2);
            Assert.AreEqual(2, list.Count);
            list.RemoveLast();
            int[] expected = new int[] { 1 };
            Assert.AreEqual(1, list.Count);
            int[] actual = list.ToArray();
            Assert.AreEqual(expected, actual);
        }
    }
}
