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
            var Input = input.ToCharArray();
            List<string> results = new List<string>();
            
            
            results.AddRange(find(input, root));

            //find parts here

            return results;
        }

        private List<string> find(string input, Node node)
        {
            List<string> results = new List<string>();

            for (int i = 0; i < node.Children.Count; i++)
            {
                if (node.Children[i].letter == input[0])
                {
                    results.AddRange(find(depend(input), node.Children[i]));
                }
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
                        if (fish.Children[i].letter == word[i]) fish = fish.Children[i];
                    }
                }
                else
                {
                    fish.Children.Add(new Node(word[i]));
                    fish = fish.Children[fish.Children.Count - 1];
                }
            }
        }
    }
}