using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DependencyGraph
{
    /// <summary>
    /// A node in a singly linked list
    /// </summary>
    public class Node<T> : IComparable<T>
       where T : IComparable<T>
    {
        public T Value { get; set; }

        /// <summary>
        /// A collection of the edges (dependencies)
        /// </summary>
        public List<Node<T>> Edges { get; set; }

        /// <summary>
        /// Constructs a new node with the specified value
        /// </summary>
        public Node(T value)
        {
            this.Value = value;
            this.Edges = new List<Node<T>>();
        }

        /// <summary>
        /// Constructs a new node with the specified value
        /// </summary>
        public void AddEdge(Node<T> node)
        {
            this.Edges.Add(node);
        }

        /// <summary>
        /// Returns 1 if the value is greater than specified value, -1 if it's lower, 0 if they're the same
        /// </summary>
        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }
    }
}
