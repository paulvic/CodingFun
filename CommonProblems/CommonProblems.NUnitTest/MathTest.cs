using NUnit.Framework;

namespace CommonProblems.NUnitTest
{
    [TestFixture]
    public class MathTest
    {
        [Test]
        public void Should3Pow0EqualOne()
        {
            double result = Math.Power(3,0);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Should3Pow1EqualThree()
        {
            double result = Math.Power(3, 1);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Should3Pow2EqualNine()
        {
            double result = Math.Power(3, 2);
            Assert.AreEqual(9, result);
        }

        [Test]
        public void Should3Pow7Equal2187()
        {
            double result = Math.Power(3, 7);
            Assert.AreEqual(2187, result);
        }

        [Test]
        public void Should3PowMinus2EqualZeroPointOne()
        {
            double result = Math.Power(3, -2);
            Assert.AreEqual(1/9d, result);
        }

        [Test]
        public void Should0FacEqualOne()
        {
            int result = Math.Factorial(0);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Should1FacEqualOne()
        {
            int result = Math.Factorial(1);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Should2FacEqualTwo()
        {
            int result = Math.Factorial(2);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Should3FacEqualSix()
        {
            int result = Math.Factorial(3);
            Assert.AreEqual(6, result);
        }
    }
}
