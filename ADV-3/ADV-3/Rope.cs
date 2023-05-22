using Microsoft.VisualBasic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Net.Mime.MediaTypeNames;

namespace ADV_3
{
    public class Rope
    {
        Node root = new Node(null);

        public Rope()
        {
            
        }

        public string getString()
        { 
            Stack<Node> stack = new Stack<Node>();
            List<string> list = new List<string>();

            Node current = root;

            while (current.left != null)
            {
                stack.Push(current);
                current = current.left;
            }
            list.Add(current.text);

            while (stack.Count > 0)
            {
                var parent = stack.Pop();
                var right = parent.right;
                if (right != null)
                {
                    stack.Push(right);
                    var left = right.left;
                    while (left != null)
                    {
                        stack.Push(left);
                        left = left.left;
                    }
                    list.Add(left.text);
                }
            }

            string result = "";
            foreach (var item in list)
            {
                result += item;
            }
            return result;
        }

        public Node BuildRope(string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            if (text.Length == 1)
                return new Node(text, null);

            int mid = text.Length / 2;
            var leftText = text.Substring(0, mid);
            var rightText = text.Substring(mid);

            var node = new Node(null);
            node.left = BuildRope(leftText);
            node.right = BuildRope(rightText);
            node.length = (node.left != null ? node.left.length : 0) + (node.right != null ? node.right.length : 0);

            return node;
        }

        public void Rebalance()
        {
            var text = getString();
            root = BuildRope(text);
        }
    }
}