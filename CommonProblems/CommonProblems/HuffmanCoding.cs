using System.Collections.Generic;
using System.Linq;

namespace CommonProblems
{
    public class HuffmanNode
    {
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }
        public char Character { get; set; }
        public int Count { get; set; }
    }

    public class HuffmanTree
    {
        public Dictionary<char, int> GetCharacterCounts(string input)
        {
            var characterCounts = new Dictionary<char, int>();
            foreach (var character in input)
            {
                if (!characterCounts.ContainsKey(character))
                {
                    characterCounts.Add(character, 0);
                }

                characterCounts[character]++;
            }

            return characterCounts;
        }

        public HuffmanNode BuildTree(Dictionary<char, int> characterCounts)
        {
            var nodes = new PriorityQueue<HuffmanNode>();
            foreach (var character in characterCounts)
            {
                nodes.Enqueue(new HuffmanNode() { Character = character.Key, Count = character.Value }, character.Value);
            }

            while (nodes.Count > 1)
            {
                var node1 = nodes.Dequeue();
                var node2 = nodes.Dequeue();
                var parent = new HuffmanNode() { Left = node1, Right = node2, Count = node1.Count + node2.Count };
                nodes.Enqueue(parent, parent.Count);
            }

            return nodes.Dequeue();
        }

        public Dictionary<char, string> CreateEncodings(HuffmanNode root)
        {
            var encodings = new Dictionary<char, string>();
            Encode(root, "", encodings);
            return encodings;
        }

        private void Encode(HuffmanNode node, string path, Dictionary<char, string> encodings)
        {
            if (node.Left != null)
            {
                Encode(node.Left, path + "0", encodings);
                Encode(node.Right, path + "1", encodings);
            }
            else
            {
                encodings.Add(node.Character, path);
            }
        }
    }

    public class PriorityQueue<T>
    {
        private SortedDictionary<int, Queue<T>> _dictionary;

        public PriorityQueue()
        {
            _dictionary = new SortedDictionary<int, Queue<T>>();
        }

        public int Count { get; private set; }

        public void Enqueue(T item, int priority)
        {
            if (!_dictionary.ContainsKey(priority))
            {
                _dictionary.Add(priority, new Queue<T>());
            }
            _dictionary[priority].Enqueue(item);
            Count++;
        }

        public T Dequeue()
        {
            var item = _dictionary.First().Value.Dequeue();
            if (_dictionary.First().Value.Count == 0)
            {
                _dictionary.Remove(_dictionary.First().Key);
            }
            Count--;
            return item;
        }

        public T Peek()
        {
            return _dictionary.First().Value.Peek();
        }
    }
}
