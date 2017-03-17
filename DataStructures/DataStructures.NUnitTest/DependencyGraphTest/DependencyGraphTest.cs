using NUnit.Framework;
using DataStructures.DependencyGraph;
using System.Linq;
using System.Collections.Generic;
using System;

namespace DataStructures.NUnitTest.DependencyGraphTest
{
    [TestFixture]
    class DependencyGraphTest
    {
        [Test]
        public void AreDependenciesResolved()
        {
            var graph = new DependencyGraph<string>();
            Node<string> a = graph.CreateNode("a");
            Node<string> b = graph.CreateNode("b");
            Node<string> c = graph.CreateNode("c");
            Node<string> d = graph.CreateNode("d");
            Node<string> e = graph.CreateNode("e");

            a.AddEdge(b);
            a.AddEdge(d);
            b.AddEdge(c);
            b.AddEdge(e);
            c.AddEdge(d);
            c.AddEdge(e);

            string[] expected = new string[] { "d", "e", "c", "b", "a" };
            List<Node<string>> resolvedNodes;
            graph.Resolve(a, out resolvedNodes);
            
            Assert.AreEqual(expected, resolvedNodes.Select(x=> x.Value).ToArray());
        }

        [Test]
        public void IsCircularDependencyDetected()
        {
            var graph = new DependencyGraph<string>();
            Node<string> a = graph.CreateNode("a");
            Node<string> b = graph.CreateNode("b");
            Node<string> c = graph.CreateNode("c");
            Node<string> d = graph.CreateNode("d");
            Node<string> e = graph.CreateNode("e");

            a.AddEdge(b);
            a.AddEdge(d);
            b.AddEdge(c);
            b.AddEdge(e);
            c.AddEdge(d);
            c.AddEdge(e);
            d.AddEdge(b);
            
            List<Node<string>> resolvedNodes;

            Exception ex = Assert.Throws<Exception>(
                delegate { graph.Resolve(a, out resolvedNodes); });
        }
    }
}
