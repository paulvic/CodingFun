using NUnit.Framework;

namespace CommonProblems.NUnitTest
{
    [TestFixture]
    public class RangeOverlapTest
    {
        [Test]
        public void IsNoOverlapFoundInEmptyRangeArray()
        {
            Range[] input = { };
            Range[] output = RangeOverlap.GetOverlappingRanges(input);
            Assert.AreEqual(0, output.Length);
        }

        [Test]
        public void IsNoOverlapFoundInOneRange()
        {
            Range[] input = { new Range(0, 5) };
            Range[] output = RangeOverlap.GetOverlappingRanges(input);
            Assert.AreEqual(0, output.Length);
        }

        [Test]
        public void IsNoOverlapFoundInTwoNonOverlappingRanges()
        {
            Range[] input = { new Range(0, 2), new Range(3, 7) };
            Range[] output = RangeOverlap.GetOverlappingRanges(input);
            Assert.AreEqual(0, output.Length);
        }

        [Test]
        public void IsOverlapFoundInTwoOverlappingRanges()
        {
            Range[] input = { new Range(0, 5), new Range(3, 7) };
            Range[] output = RangeOverlap.GetOverlappingRanges(input);
            Range[] expected = { new Range(0, 7) };
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void IsOverlapFoundInManyOverlappingRanges()
        {
            Range[] input = { new Range(0, 5), new Range(3, 7), new Range(10, 11), new Range(11, 12), new Range(20, 21), new Range(19, 22) };
            Range[] output = RangeOverlap.GetOverlappingRanges(input);
            Range[] expected = { new Range(0, 7), new Range(10, 12), new Range(19, 22) };
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void AreNoDuplicatesInOverlappingRanges()
        {
            Range[] input = { new Range(0, 5), new Range(3, 7), new Range(0, 7) };
            Range[] output = RangeOverlap.GetOverlappingRanges(input);
            Range[] expected = { new Range(0, 7) };
            Assert.AreEqual(expected, output);
        }
    }
}
