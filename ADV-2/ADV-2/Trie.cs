﻿using System;
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
        Node root = new Node(false);

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

        private List<string> find(int input, Node node)
        {
            BitArray results = new BitArray(sizeof(int), false);
            BitArray number = new BitArray(input);

            if (number.Length == 0)
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

        private string depend(int input) //reverse append
        {
            string result = "";
            for (int i = 1; i < input.Length; i++)
            {
                result += input[i];
            }
            return result;
        }

        public void add(int number)
        {
            Node fish = root;

            BitArray input = new BitArray(new byte[]{ Convert.ToByte(number) });

            for (int i = 0; i < input.Length; i++)
            {
                if (fish.ContainsKey(input[i]))
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

        public (int one, int two) FindBest()
        {
            var start = GetNodesInRow(1);

            SortedList list = new SortedList();

            //list.Add(MaxXORvalue, (number1, number2));


        }

        public List<Node> GetNodesInRow(int row)
        {
            var nodesInRow = new List<Node>();

            if (root == null || row < 0)
            {
                return nodesInRow;
            }

            var queue = new Queue<Node>();
            queue.Enqueue(root);

            int currentRow = 0;

            while (queue.Count > 0 && currentRow <= row)
            {
                int currentLevelSize = queue.Count;

                for (int i = 0; i < currentLevelSize; i++)
                {
                    var node = queue.Dequeue();

                    if (currentRow == row)
                    {
                        nodesInRow.Add(node);
                    }

                    foreach (var child in node.Children)
                    {
                        queue.Enqueue(child);
                    }
                }

                currentRow++;
            }

            return nodesInRow;
        }
    }
}