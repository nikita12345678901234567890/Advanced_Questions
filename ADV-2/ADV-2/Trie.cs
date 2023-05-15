using Microsoft.Win32.SafeHandles;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ADV_2
{
    public class Trie
    {
        public Node root { get; private set; }

        public Trie()
        {
            root = new Node(false);
        }

        public void add(int number)
        {
            Node fish = root;

            BitArray input = new BitArray(new byte[]{ Convert.ToByte(number) });

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if ((fish.Children.Count > 0 && fish.Children[0].bit == input[i]) || (fish.Children.Count > 1 && fish.Children[1].bit == input[i]))
                {
                    for (int j = 0; j < fish.Children.Count; j++)
                    {
                        if (fish.Children[j].bit == input[i]) fish = fish.Children[j];
                    }
                }
                else
                {
                    fish.Children.Add(new Node(input[i], fish));
                    fish = fish.Children[fish.Children.Count - 1];
                }
            }
        }

        public void BreadthFirstTraversal()
        {
            Queue<Node> queue = new Queue<Node>();
            HashSet<Node> visited = new HashSet<Node>();

            queue.Enqueue(root);
            visited.Add(root);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                visited.Add(current);

                if (current.Children.Count == 0)
                {
                    current.bestXOR = new BitArray(new bool[] { false, false, false, false, false, false, false, current.bit });
                }
                else if (current.Children.Count == 1)
                {
                    current.bestXOR = new BitArray(current.Children[0].bestXOR);
                }
                else
                { 
                    current.bestXOR = current.Children[0].bestXOR.Xor(current.Children[1].bestXOR);
                }

                foreach (Node child in current.Children)
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                    }
                }
            }
        }

        public (BitArray one, BitArray zero) thing()
        {
            Node one = root;
            Node zero = root;

            while (one.Children.Count != 0 && zero.Children.Count != 0)
            {
                if (one.Children.Count == 1)
                {
                    if (zero.Children.Count == 1)
                    {
                        one = one.Children[0];
                        zero = zero.Children[0];
                        continue;
                    }
                    else
                    {
                        if (one.Children[0].bit != zero.Children[0].bit)
                        {
                            one = one.Children[0];
                            zero = zero.Children[0];
                            continue;
                        }
                        else
                        {
                            one = one.Children[0];
                            zero = zero.Children[1];
                            continue;
                        }
                    }
                }
                else
                {
                    if (zero.Children.Count == 1)
                    {
                        if (one.Children[0].bit != zero.Children[0].bit)
                        {
                            one = one.Children[0];
                            zero = zero.Children[0];
                            continue;
                        }
                        else
                        {
                            one = one.Children[1];
                            zero = zero.Children[0];
                            continue;
                        }
                    }
                    else
                    {
                        if (one.Children[0].bit) one = one.Children[0];
                        else one = one.Children[1];

                        if (zero.Children[0].bit) zero = zero.Children[1];
                        else zero = zero.Children[0];
                    }
                }
            }

            return (reverse(one), reverse(zero));
        }

        private BitArray reverse(Node node)
        {
            BitArray result = new BitArray(8, false);

            int level = 0;

            while (node != root)
            {
                result.Set(level, node.bit);
                node = node.Parent;
                level++;
            }

            return result;
        }

        public int FindMaximumXor(int[] nums)
        {
            TrieNode root = new TrieNode();

            // Insert all the numbers into the trie
            foreach (int num in nums)
            {
                TrieNode node = root;
                for (int i = 31; i >= 0; i--)
                {
                    int bit = (num >> i) & 1;
                    if (node.Children[bit] == null)
                    {
                        node.Children[bit] = new TrieNode();
                    }
                    node = node.Children[bit];
                }
            }

            int max_xor = 0;

            // Find the maximum XOR value
            foreach (int num in nums)
            {
                int xor = 0;
                TrieNode node = root;
                for (int i = 31; i >= 0; i--)
                {
                    int bit = (num >> i) & 1;
                    if (node.Children[bit ^ 1] != null)
                    {
                        xor += (1 << i);
                        node = node.Children[bit ^ 1];
                    }
                    else
                    {
                        node = node.Children[bit];
                    }
                }
                max_xor = Math.Max(max_xor, xor);
            }

            return max_xor;
        }
    }
    public class TrieNode
    {
        public TrieNode[] Children = new TrieNode[2];
    }
}