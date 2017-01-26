using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList
{
    public class LinkedList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// The first node in the linked list or null if empty
        /// </summary>
        private Node<T> head { get; set; }

        /// <summary>
        /// The last node in the linked list or null if empty
        /// </summary>
        private Node<T> tail { get; set; }

        /// <summary>
        /// The size of the list
        /// </summary>
        public uint Count { get; private set; }

        /// <summary>
        /// Constructor for the linked list
        /// </summary>
        public LinkedList()
        {
            this.Count = 0;
        }

        /// <summary>
        /// Adds a value to the start of the linked list
        /// </summary>
        /// <param name="value"></param>
        public void AddFirst(T value)
        {
            this.AddFirst(new Node<T>(value));
        }

        /// <summary>
        /// Adds a node to the start of the linked list
        /// </summary>
        /// <param name="node"></param>
        private void AddFirst(Node<T> node)
        {
            // Save the head so it's not lost
            Node<T> temp = this.head;

            // Point the head to the new node
            this.head = node;

            // Set next to the old head
            this.head.Next = temp;

            // Increment the node count
            this.Count++;

            // If the count is 1, then head and tail should point to the same node
            if (this.Count == 1)
            {
                this.tail = this.head;
            }
        }

        /// <summary>
        /// Adds a value to the end of the linked list
        /// </summary>
        /// <param name="value"></param>
        public void AddLast(T value)
        {
            this.AddLast(new Node<T>(value));
        }

        /// <summary>
        /// Adds a node to the end of the linked list
        /// </summary>
        /// <param name="node"></param>
        private void AddLast(Node<T> node)
        {
            if (this.Count == 0)
            {
                // If there are no nodes, set head to this node
                this.head = node;
            }
            else
            {
                // If this is at least one node, set the tail's next node to this node
                this.tail.Next = node;
            }

            // Point the tail to this node
            this.tail = node;

            // Increment the node count
            this.Count++;
        }

        /// <summary>
        /// Removes the first node from the list
        /// </summary>
        public void RemoveFirst()
        {
            if (this.Count > 0)
            {
                // Points the head to head+1
                this.head = this.head.Next;

                // Decrement the count
                this.Count--;

                if (this.Count == 0)
                {
                    this.tail = null;
                }
            }
        }

        /// <summary>
        /// Remove this last node from the list
        /// </summary>
        public void RemoveLast()
        {
            if (this.Count > 0)
            {
                // If there's at least 1 node
                if (this.Count == 1)
                {
                    // If there's just 1 node then set head and tail to null
                    this.head = null;
                    this.tail = null;
                }
                else
                {
                    // Iterate through the node chain until you find the node pointing to the tail i.e. the second last node
                    Node<T> current = this.head;
                    while (current.Next != this.tail)
                    {
                        current = current.Next;
                    }

                    // Set the next (tail) node to null
                    current.Next = null;

                    // Set the tail to the current node
                    this.tail = current;
                }

                // Decrement the node count
                this.Count--;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
