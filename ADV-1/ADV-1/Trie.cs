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
            Node fish = root;
            for (int i = 0; i < Input.Length; i++)
            {
                if (fish.ContainsKey(Input[i]))
                {
                    fish = fish.Children[Input[i]];
                }
                else
                {
                    break;
                }
            }


        }
    }
}