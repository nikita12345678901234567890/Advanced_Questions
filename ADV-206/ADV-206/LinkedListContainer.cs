using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV_206
{
    public class LinkedListContainer<T> : IContainer<T>
    {
        public T First { get => list.First.Value; set => list.AddFirst(value); }
        public T Last { get => list.Last.Value; set => list.AddLast(value); }
        public int Count { get => list.Count; }

        private LinkedList<T> list = new(); 

        public LinkedListContainer() { }
        public LinkedListContainer(LinkedList<T> list)
        {
            this.list = list;
        }

        public void RemoveFirst()
        {
            list.RemoveFirst();
        }

        public void RemoveLast()
        {
            list.RemoveLast();
        }
    }
}
