using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV_1
{
    public class Node
    {
        public char letter { get; private set; }

        public List<Node> Children;
        public Node Parent;

        public Node(char letter)
        {
            this.letter = letter;
            Children = new List<Node>();
        }
        public Node(char letter, Node Parent)
        {
            this.letter = letter;
            Children = new List<Node>();
            this.Parent = Parent;
        }

        public bool ContainsKey(char glyph)
        {
            for (int i = 0; i < Children.Count; i++)
            {
                if (Children[i].letter == glyph) return true;
            }
            return false;
        }
    }
}