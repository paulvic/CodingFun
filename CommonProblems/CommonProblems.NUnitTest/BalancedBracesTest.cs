using NUnit.Framework;

namespace CommonProblems.NUnitTest
{
    [TestFixture]
    public class BalanacedBracesTest
    {
        [Test]
        public void ShouldBeBalanced()
        {
            bool result = BalancedBraces.CheckBraces("{{asd}}");
            Assert.AreEqual(true, result);

            result = BalancedBraces.CheckBraces("sad<>");
            Assert.AreEqual(true, result);

            result = BalancedBraces.CheckBraces("{[]}");
            Assert.AreEqual(true, result);

            result = BalancedBraces.CheckBraces("asd");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void ShouldNotBeBalanced()
        {
            string text = "{{}";
            bool result = BalancedBraces.CheckBraces(text);
            Assert.AreEqual(false, result, text);

            text = "<";
            result = BalancedBraces.CheckBraces(text);
            Assert.AreEqual(false, result, text);

            text = "{]}";
            result = BalancedBraces.CheckBraces(text);
            Assert.AreEqual(false, result, text);
            
            text = "}[]";
            result = BalancedBraces.CheckBraces(text);
            Assert.AreEqual(false, result, text);
        }
    }
}
