using NUnit.Framework;
using System;

namespace CommonProblems.NUnit.Tests
{
    [TestFixture]
    class NumberPoolTest
    {
        [Test]
        public void CanCheckOutOnce()
        {
            NumberPool pool = new NumberPool();
            Assert.AreEqual(1, pool.CheckOut());
        }

        [Test]
        public void CanCheckOutTwice()
        {
            NumberPool pool = new NumberPool();
            Assert.AreEqual(1, pool.CheckOut());
            Assert.AreEqual(2, pool.CheckOut());
        }

        [Test]
        public void CanCheckinOneNumber()
        {
            NumberPool pool = new NumberPool();
            Assert.AreEqual(1, pool.CheckOut());
            Assert.AreEqual(2, pool.CheckOut());
            pool.CheckIn(2);
            Assert.AreEqual(2, pool.CheckOut());
        }

        [Test]
        public void DoesCheckOutReturnLowestCheckedInNumber()
        {
            NumberPool pool = new NumberPool();
            Assert.AreEqual(1, pool.CheckOut());
            Assert.AreEqual(2, pool.CheckOut());
            Assert.AreEqual(3, pool.CheckOut());
            pool.CheckIn(2);
            Assert.AreEqual(2, pool.CheckOut());
            Assert.AreEqual(4, pool.CheckOut());
        }

        [Test]
        public void DoesCheckoutReturnLowestOfManyCheckedInNumbers()
        {
            NumberPool pool = new NumberPool();
            Assert.AreEqual(1, pool.CheckOut());
            Assert.AreEqual(2, pool.CheckOut());
            Assert.AreEqual(3, pool.CheckOut());
            Assert.AreEqual(4, pool.CheckOut());
            Assert.AreEqual(5, pool.CheckOut());
            pool.CheckIn(4);
            pool.CheckIn(2);
            Assert.AreEqual(2, pool.CheckOut());
            Assert.AreEqual(4, pool.CheckOut());
            Assert.AreEqual(6, pool.CheckOut());
        }

        [Test]
        public void CannotCheckInZero()
        {
            NumberPool pool = new NumberPool();
            ArgumentException ex = Assert.Throws<ArgumentException>(
                    delegate { pool.CheckIn(0); });
        }

        [Test]
        public void CannotCheckInNumberHigherThanTheHighestCheckedOutNumber()
        {
            NumberPool pool = new NumberPool();
            Assert.AreEqual(1, pool.CheckOut());
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                    delegate { pool.CheckIn(2); });
        }

        [Test]
        public void CannotCheckInAlreadyCheckedInNumber()
        {
            NumberPool pool = new NumberPool();
            Assert.AreEqual(1, pool.CheckOut());
            Assert.AreEqual(2, pool.CheckOut());
            Assert.AreEqual(3, pool.CheckOut());
            pool.CheckIn(2);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                    delegate { pool.CheckIn(2); });
        }
    }
}
