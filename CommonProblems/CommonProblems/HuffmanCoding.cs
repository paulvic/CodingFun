using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems
{
    public class HuffmanNode : IComparable<HuffmanNode>
    {
        public HuffmanNode Parent { get; set; }
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }
        public char Character { get; set; }
        public int Frequency { get; set; }

        public int CompareTo(HuffmanNode other)
        {
            int returnVal = -1;

            if (Frequency == other.Frequency)
            {
                if (Character == other.Character)
                {
                    return 0;
                }
                else if (Character < other.Character)
                {
                    return -1;
                }
                else
                {
                    returnVal = 1;
                }
            }
            else if (Frequency < other.Frequency)
            {
                returnVal = -1;
            }
            else
            {
                returnVal = 1;
            }

            return returnVal;
        }
    }

    public class HuffmanTree
    {
        private Dictionary<char, int> characters;
        private SortedSet<HuffmanNode> nodes;

        public HuffmanTree(string input)
        {
            characters = new Dictionary<char, int>();

            foreach (var character in input)
            {
                if (!characters.ContainsKey(character))
                {
                    characters.Add(character, 0);
                }

                characters[character]++;
            }

            nodes = new SortedSet<HuffmanNode>();
            foreach (KeyValuePair<char, int> character in characters)
            {
                nodes.Add(new HuffmanNode() { Character = character.Key, Frequency = character.Value });
            }

            while (nodes.Count > 1)
            {
                var node1 = nodes.Min;
                nodes.Remove(node1);
                var node2 = nodes.Min;
                nodes.Remove(node2);
                var parent = new HuffmanNode() { Left = node1, Right = node2, Frequency = node1.Frequency + node2.Frequency };
                node1.Parent = parent;
                node2.Parent = parent;
                nodes.Add(parent);
            }
        }

        public Dictionary<char, int> Characters
        {
            get { return characters; }
            private set { characters = value; }
        }


        public SortedSet<HuffmanNode> Nodes
        {
            get { return nodes; }
            private set { nodes = value; }
        }

    }
}
