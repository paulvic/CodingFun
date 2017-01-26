using System;

namespace DataStructures.BinaryTree
{    
    /// <summary>
    /// A node in a binary tree
    /// </summary>
    public class Node<T> : IComparable<T>
       where T : IComparable<T>
    {
        public T Value { get; set; }

        /// <summary>
        /// The left child node
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// The right child node
        /// </summary>
        public Node<T> Right { get; set; }

        public Node(T value)
        {
            this.Value = value;
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
