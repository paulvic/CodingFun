using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonProblems.NUnit.Tests
{
    [TestFixture]
    public class HuffmanCodingTest
    {
        private const string TestString2 = "this is an example of a huffman tree";
        private const string TestString1 = "This is an interesting test string about a quick brown fox";
//T
//h
//iiiii
//ssss

//aaa
//nnnnn
//tttttt
//ee
//rrr
//gg
//bb
//ooo
//uu
//q
//c
//k
//w
//f
//x

        
        [Test]
        public void CanInstantiateClass()
        {
            HuffmanTree huffman = new HuffmanTree(TestString1);
        }

        [Test]
        public void IsUniqueCharacterCountCorrect()
        {
            HuffmanTree huffman = new HuffmanTree(TestString1);
            Dictionary<char, int> characters = huffman.Characters;
            Assert.AreEqual(20, characters.Count);
        }

        [Test]
        public void IsCharacterFrequencyCorrect()
        {
            HuffmanTree huffman = new HuffmanTree(TestString1);
            Dictionary<char, int> characters = huffman.Characters;
            Assert.AreEqual(1, characters['T']);
            Assert.AreEqual(6, characters['i']);
            Assert.AreEqual(1, characters['f']);
            Assert.AreEqual(1, characters['x']);
        }

        [Test]
        public void IsUniqueCharacterCountCorrectTestString2()
        {
            HuffmanTree huffman = new HuffmanTree(TestString2);
            Dictionary<char, int> characters = huffman.Characters;
            Assert.AreEqual(16, characters.Count);
        }

        [Test]
        public void IsCharacterFrequencyCorrectTestString2()
        {
            HuffmanTree huffman = new HuffmanTree(TestString2);
            Dictionary<char, int> characters = huffman.Characters;
            Assert.AreEqual(2, characters['t']);
            Assert.AreEqual(4, characters['e']);
            Assert.AreEqual(7, characters[' ']);
            Assert.AreEqual(1, characters['x']);
        }
        
        [Test]
        public void AreCharactersSortedByFrequencyThenCharacter()
        {
            HuffmanTree huffman = new HuffmanTree(TestString2);
            SortedSet<HuffmanNode> nodes = huffman.Nodes;
            Assert.AreEqual('l', nodes.Min.Character);
            Assert.AreEqual(' ', nodes.Max.Character);
        }
    }
}
