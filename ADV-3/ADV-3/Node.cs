using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV_3
{
    public class Node
    {
        public int length;
        public string text;
        public Node parent;
        public Node left;
        public Node right;

        public Node(Node parent)
        {
            length = 0;
            text = "";
            this.parent = parent;
        }
        public Node(string text, Node parent)
        { 
            this.text = text;
            length = text.Length;
            this.parent = parent;
        }
    }
}