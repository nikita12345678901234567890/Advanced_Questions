using Microsoft.VisualBasic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

        public string justify(int width)
        {
            List<Node> list = GetLeafNodes();

            List<List<Node>> lines = new List<List<Node>>();
            lines.Add(new List<Node>());
            int index = 0;
            while (index < list.Count)
            {
                if (length(lines[lines.Count - 1]) + list[index].text.Length > width)
                {
                    lines.Add(new List<Node>());
                }

                lines[lines.Count - 1].Add(list[index]);
                index++;
            }

            foreach (var line in lines)
            {
                index = 0;
                while (length(line) < width)
                {
                    if (line[index].text.Contains(' ') || line.Count == 1) line[index].text += " ";

                    index++;

                    if (index >= line.Count) index = 0;
                }
            }

            string result = "";
            foreach (var line in lines)
            {
                foreach (var node in line)
                { 
                    result += node.text;
                }
                result += "\n";
            }

            return result;
        }
        private int length(List<Node> line)
        {
            int result = 0;
            foreach (var node in line)
            {
                result += node.text.Length;
            }
            return result;
        }
        public List<Node> GetLeafNodes()
        {
            var leafNodes = new List<Node>();
            TraverseLeafNodes(root, leafNodes);
            return leafNodes;
        }
        private void TraverseLeafNodes(Node node, List<Node> leafNodes)
        {
            if (node == null)
                return;

            if (node.left == null && node.right == null)
                leafNodes.Add(node);

            TraverseLeafNodes(node.left, leafNodes);
            TraverseLeafNodes(node.right, leafNodes);
        }

        public void BuildRope(List<(string, string)> texts)
        {
            root = BuildRopeRecursive(texts, 0, texts.Count - 1);
        }

        private Node BuildRopeRecursive(List<(string, string)> texts, int start, int end)
        {
            if (start > end)
                return null;

            if (start == end)
            {
                var (text, type) = texts[start];
                return new Node(text, type, null);
            }

            int mid = (start + end) / 2;
            var leftNode = BuildRopeRecursive(texts, start, mid);
            var rightNode = BuildRopeRecursive(texts, mid + 1, end);
            var node = new Node("", "", null);

            if (leftNode.type == rightNode.type)
            {
                node.text = leftNode.text + rightNode.text;
                //node.type = leftNode.type;
                node.left = leftNode;
                node.right = rightNode;
                node.length = leftNode.length + rightNode.length;
            }
            else
            {
                node.left = leftNode;
                node.right = rightNode;
                node.length = leftNode.length;

                var separator = new Node("", "separator", null);
                separator.left = new Node(" ", "space", null);
                separator.right = new Node(" ", "space", null);
                separator.length = separator.left.length + separator.right.length;

                node.text = leftNode.text + separator.left.text + rightNode.text;
                //node.type = "concatenation";
                node.length += separator.length;
                node.left = Concatenate(leftNode, separator.left);
                node.right = Concatenate(separator.right, rightNode);
            }

            return node;
        }

        public void Insert(List<(string, string)> text)
        {
            Insert(root.length, text);
        }

        public void Insert(int index, List<(string, string)> text)
        {
            if (index < 0 || index > root.length)
            {
                throw new ArgumentOutOfRangeException("index", "Index is out of range.");
            }

            BuildRope(text);
            var (left, right) = Split(index, root);

            root = Concatenate(Concatenate(left, new Node(null)), right);
        }

        private (Node, Node) Split(int index, Node node)
        {
            if (node == null)
            {
                return (null, null);
            }

            if (index == 0)
            {
                return (null, node);
            }

            if (index >= node.length)
            {
                return (node, null);
            }

            if (index < node.left.length)
            {
                var (left, right) = Split(index, node.left);
                node.left = right;
                UpdateWeight(node);
                return (left, node);
            }
            else if (index > node.left.length)
            {
                var (left, right) = Split(index - node.left.length, node.right);
                node.right = left;
                UpdateWeight(node);
                return (node, right);
            }

            return (node.left, node.right);
        }

        private Node Concatenate(Node left, Node right)
        {
            if (left == null)
            {
                return right;
            }

            if (right == null)
            {
                return left;
            }

            var node = new Node(null);
            node.left = left;
            node.right = right;
            node.length = left.length + right.length;

            return node;
        }

        private void UpdateWeight(Node node)
        {
            node.length = (node.left != null ? node.left.length : 0) + (node.right != null ? node.right.length : 0);
        }
    }
}