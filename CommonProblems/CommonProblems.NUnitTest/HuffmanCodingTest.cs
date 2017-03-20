using NUnit.Framework;
using System.Collections.Generic;

namespace CommonProblems.NUnit.Tests
{
    [TestFixture]
    public class HuffmanCodingTest
    {
        private const string TestString = "this is an example of a huffman tree";

        [Test]
        public void AreCharacterCountsCorrect()
        {
            HuffmanTree huffman = new HuffmanTree();
            Dictionary<char, int> characterCounts = huffman.GetCharacterCounts(TestString);
            Assert.AreEqual(2, characterCounts['t']);
            Assert.AreEqual(4, characterCounts['e']);
            Assert.AreEqual(7, characterCounts[' ']);
            Assert.AreEqual(1, characterCounts['x']);
        }

        [Test]
        public void AreEncodingsCorrect()
        {
            HuffmanTree huffman = new HuffmanTree();
            Dictionary<char, int> characterCounts = huffman.GetCharacterCounts(TestString);
            HuffmanNode root = huffman.BuildTree(characterCounts);
            var encodings = huffman.CreateEncodings(root);
            Assert.AreEqual(16, encodings.Count);
            Assert.AreEqual("000", encodings['a']);
            Assert.AreEqual("001", encodings['e']);
            Assert.AreEqual("111", encodings[' ']);
            Assert.AreEqual("10101", encodings['p']);
        }
    }
}
