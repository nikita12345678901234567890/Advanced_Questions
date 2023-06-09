﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV_2
{
    public class Node
    {
        public bool bit;

        public List<Node> Children;
        public Node Parent;

        public BitArray bestXOR;

        public Node(bool bit)
        {
            this.bit = bit;
            Children = new List<Node>();

            bestXOR = new BitArray(8);
        }
        public Node(bool bit, Node Parent)
        {
            this.bit = bit;
            Children = new List<Node>();
            this.Parent = Parent;

            bestXOR = new BitArray(8);
        }

        public bool ContainsKey(bool key)
        {
            for (int i = 0; i < Children.Count; i++)
            {
                if (Children[i].bit == key) return true;
            }
            return false;
        }
    }
}
