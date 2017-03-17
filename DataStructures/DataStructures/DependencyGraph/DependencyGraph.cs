using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DependencyGraph
{
    public class DependencyGraph<T> where T : IComparable<T>
    {
        public Node<T> CreateNode(T value)
        {
            return new Node<T>(value);
        }

        public void Resolve(Node<T> node, out List<Node<T>> resolved)
        {
            resolved = new List<Node<T>>();
            List<Node<T>> unresolved = new List<Node<T>>();
            Resolve(node, resolved, unresolved);
        }

        public void Resolve(Node<T> node, List<Node<T>> resolved, List<Node<T>> unresolved)
        {
            unresolved.Add(node);
            foreach (var edge in node.Edges)
            {
                if (!resolved.Contains(edge))
                {
                    if (unresolved.Contains(edge))
                    {
                        throw new Exception("Circular reference detected");
                    }
                    Resolve(edge, resolved, unresolved);
                }
            }
            resolved.Add(node);
            unresolved.Remove(node);
        }
    }
}
