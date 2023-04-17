using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV_1
{
    public class Trie
    {
        Node root = new Node('^');

        public List<string> Complete(string input)
        {
            List<string> results = new List<string>();
            
            
            results.AddRange(find(input, root));

            //find parts here:

            //Starting search from lower levels:
            results.AddRange(checkLevel(root, input, 10));

            //Cutting off beginning charachters:
            string text = input;
            for (int i = 0; i < 2; i++)
            {
                text = depend(text);
                text = depend(text);
                results.AddRange(checkLevel(root, text, 10));
            }

            results = results.Distinct().ToList();
            results = results.OrderBy(o => findDistance(o, input)).ToList();

            return results;
        }

        private List<string> find(string input, Node node)
        {
            List<string> results = new List<string>();

            if (input.Length == 0)
            {
                results.Add(reverse(node));

                results.AddRange(MatchPrefix(node));
                return results;
            }

            for (int i = 0; i < node.Children.Count; i++)
            {
                if (node.Children[i].letter == input[0])
                {
                    results.AddRange(find(depend(input), node.Children[i]));
                }
            }

            return results;
        }

        private string reverse(Node node)
        {
            List<char> word = new List<char>();

            while (node != root)
            {
                word.Insert(0, node.letter);
                node = node.Parent;
            }

            return new string(word.ToArray());
        }

        private List<string> MatchPrefix(Node node)
        {
            List<string> results = new List<string>();

            if (node.Children.Count == 0)
            {
                results.Add(reverse(node));
            }

            for (int i = 0; i < node.Children.Count; i++)
            {
                results.AddRange(MatchPrefix(node.Children[i]));
            }

            return results;
        }

        private string depend(string input) //reverse append
        {
            string result = "";
            for (int i = 1; i < input.Length; i++)
            {
                result += input[i];
            }
            return result;
        }

        public void add(string word)
        {
            Node fish = root;

            for (int i = 0; i < word.Length; i++)
            {
                if (fish.ContainsKey(word[i]))
                {
                    for (int j = 0; j < fish.Children.Count; j++)
                    {
                        if (fish.Children[j].letter == word[i]) fish = fish.Children[j];
                    }
                }
                else
                {
                    fish.Children.Add(new Node(word[i], fish));
                    fish = fish.Children[fish.Children.Count - 1];
                }
            }
        }

        private List<string> checkLevel(Node node, string input, int level)
        {
            List<string> results = new List<string>();

            for (int i = 0; i < node.Children.Count; i++)
            {
                results.AddRange(find(input, node));//.Children[i]));

                if (level > 0)
                {
                    results.AddRange(checkLevel(node.Children[i], input, level - 1));
                }
            }

            return results;
        }


        private int findDistance(string a, string b)
        {
            // Declaring a 2D array on the heap dynamically:
            int len_a = a.Length;
            int len_b = b.Length;
            int[,] d = new int[len_a + 1, len_b + 1];

            // Initialising first column:
            for (int i = 0; i < len_a + 1; i++)
            {
                d[i,0] = i;
            }

            // Initialising first row:
            for (int j = 0; j < len_b + 1; j++)
                d[0,j] = j;

            // Applying the algorithm:
            int insertion, deletion, replacement;

            for (int i = 1; i < len_a + 1; i++)
            {
                for (int j = 1; j < len_b + 1; j++)
                {
                    if (a[i - 1] == b[j - 1])
                    {
                        d[i,j] = d[i - 1,j - 1];
                    }
                    else
                    {
                        // Choosing the best option:
                        insertion = d[i,j - 1];
                        deletion = d[i - 1,j];
                        replacement = d[i - 1,j - 1];

                        d[i,j] = 1 + findMin(insertion, deletion, replacement);
                    }
                }
            }

            return d[len_a, len_b];
        }

        private int findMin(int x, int y, int z)
        {
            if (x <= y && x <= z) return x;
            else if (y <= x && y <= z) return y;
            else return z;
        }
    }
}