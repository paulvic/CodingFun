using System;

namespace DataStructures.LinkedList
{
    /// <summary>
    /// A node in a singly linked list
    /// </summary>
    public class Node<T> : IComparable<T>
       where T : IComparable<T>
    {
        public T Value { get; set; }

        /// <summary>
        /// The next node in the list, null if last node (tail)
        /// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// Constructs a new node with the specified value
        /// </summary>
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
