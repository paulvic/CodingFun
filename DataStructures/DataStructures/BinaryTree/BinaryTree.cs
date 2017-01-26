using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private Node<T> root;
        private int count;

        public void Add(T value)
        {
            if (this.root == null)
            {
                // No root element, make this the root
                this.root = new Node<T>(value);
            }
            else
            {
                this.AddTo(this.root, value);
            }

            this.count++;
        }

        // Recursive method for finding the parent to link the new node to add a new node to
        private void AddTo(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                // Value is less than node value
                if (node.Left == null)
                {
                    // No left child, add new node here
                    node.Left = new Node<T>(value);
                }
                else
                {
                    // There's already a left child, try one level down
                    this.AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value);
                }
                else
                {
                    this.AddTo(node.Right, value);
                }
            }
        }

        public bool Remove(T value)
        {
            // Rules are:

            // If the node to be removed is a leaf node (no children) then simply remove the parent's link to this node
            Node<T> nodeParent;
            Node<T> node = this.FindWithParent(value, out nodeParent);

            if (node == null)
            {
                // Couldn't find the node to be removed
                return false;
            }

            // If the node has no right child, then promote the left child
            if (node.Right == null)
            {
                if (nodeParent == null)
                {
                    // We're removing the root node
                    this.root = node.Left;
                }
                else
                {
                    int result = nodeParent.CompareTo(node.Value);
                    if (result > 0)
                    {
                        nodeParent.Left = node.Left;
                    }
                    else if (result < 0)
                    {
                        nodeParent.Right = node.Left;
                    }
                }
            }
            else if (node.Right.Left == null)
            {
                // the node to be deleted's left node will become the promote node's left node
                node.Right.Left = node.Left;

                // Promote the right child
                if (nodeParent == null)
                {
                    this.root = node.Right;
                }
                else
                {
                    int result = nodeParent.CompareTo(node.Value);
                    if (result > 0)
                    {
                        nodeParent.Left = node.Right;
                    }
                    else if (result < 0)
                    {
                        nodeParent.Right = node.Right;
                    }

                }
            }
            else
            {
                // Get the left most child from the node's right subtree
                Node<T> leftMostNode = node.Right.Left;
                Node<T> leftMostParent = node.Right;

                while (leftMostNode != null)
                {
                    leftMostNode = leftMostNode.Left;
                    leftMostParent = leftMostParent.Left;
                }

                leftMostParent.Left = leftMostNode.Right;

                leftMostNode.Left = node.Left;
                leftMostNode.Right = node.Right;

                if (nodeParent == null)
                {
                    root = leftMostNode;
                }
                else
                {
                    int result = nodeParent.CompareTo(node.Value);
                    if (result > 0)
                    {
                        nodeParent.Left = leftMostNode;
                    }
                    else if (result < 0)
                    {
                        nodeParent.Right = leftMostNode;
                    }
                }
            }
            return true;
        }

        public Node<T> FindNode(T value)
        {
            Node<T> parent;
            return FindWithParent(value, out parent);
        }

        private Node<T> FindWithParent(T value, out Node<T> parent)
        {
            Node<T> current = root;
            parent = null;

            while (current != null)
            {
                int result = value.CompareTo(current.Value);
                if (result < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result > 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    // we have a match
                    break;
                }
            }

            return current;
        }

        public List<T> InOrderTraversal()
        {
            List<T> nodes = new List<T>();
            InOrderTraversal(root, nodes);
            return nodes;
        }

        private List<T> InOrderTraversal(Node<T> node, List<T> nodes)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, nodes);
                nodes.Add(node.Value);
                InOrderTraversal(node.Right, nodes);
            }

            return nodes;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var node in this.InOrderTraversal())
            {
                yield return node;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
