namespace DataStructures.LinkedList
{
    /// <summary>
    /// A node in a linked list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        /// <summary>
        /// The node value
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The next node in the list, null if last node (tail)
        /// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// Constructs a new node with the specified value
        /// </summary>
        /// <param name="value"></param>
        public Node(T value)
        {
            this.Value = value;
        }
    }
}
