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

            for (int i = 0; i < input.Length; i++)
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
    }
}