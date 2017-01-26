using NUnit.Framework;
using DataStructures.BinaryTree;
using System.Linq;

namespace DataStructures.NUnitTest.BinaryTreeTest
{
    [TestFixture]
    class BinaryTreeTest
    {
        [Test]
        public void IsEmptyAtInitialization()
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            string[] expected = new string[] { };
            Assert.AreEqual(expected, tree.ToArray());
        }

        [Test]
        public void CanAddValue()
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            tree.Add("test");
            string[] expected = new string[] { "test" };
            Assert.AreEqual(expected, tree.ToArray());
        }

        [Test]
        public void IsAddedNodePositionCorrect()
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            tree.Add("d");
            tree.Add("b");
            tree.Add("c");
            tree.Add("f");
            tree.Add("a");
            // Tree structure should be:
            //        d
            //   b        f
            //  a  c
            //
            Node<string> root = tree.FindNode("d");
            Assert.AreEqual("d", root.Value);
            Assert.AreEqual("b", root.Left.Value);
            Assert.AreEqual("a", root.Left.Left.Value);
            Assert.AreEqual("c", root.Left.Right.Value);
            Assert.AreEqual("f", root.Right.Value);
        }

        [Test]
        public void CanEnumerateInOrder()
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            tree.Add("d");
            tree.Add("b");
            tree.Add("c");
            tree.Add("f");
            tree.Add("a");
            string[] expected = new string[] { "a", "b", "c", "d", "f" };
            Assert.AreEqual(expected, tree.ToArray());
        }


        [Test]
        public void CanRemoveNode()
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            tree.Add("d");
            tree.Add("b");
            tree.Add("c");
            tree.Add("f");
            tree.Add("a");
            tree.Remove("b");
            string[] expected = new string[] { "a", "c", "d", "f" };
            Assert.AreEqual(expected, tree.ToArray());
        }

        [Test]
        public void CanFindNode()
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            tree.Add("b");
            tree.Add("a");
            tree.Add("c");
            Node<string> node = tree.FindNode("c");
            Assert.AreEqual("c", node.Value);
        }

        [Test]
        public void CanAddDuplicateValues()
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            tree.Add("test");
            tree.Add("test");
            string[] expected = new string[] { "test", "test" };
            Assert.AreEqual(expected, tree.ToArray());
        }
    }
}
