using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV_206
{
    public class ContainerQueue<T>
    {
        IContainer<T> container;
        public int Count => container.Count;

        public ContainerQueue(IContainer<T> container)
        {
            this.container = container;
        }

        public void Enqueue(T value)
        {
            container.Last = value;
        }

        public T Dequeue()
        {
            if (container.Count == 0) throw new Exception("The queue is empty");

            T temp = container.First;

            container.RemoveFirst();

            return temp;
        }

        public T? Peek()
        {
            if (container.Count == 0) throw new Exception("The queue is empty");

            return container.First;
        }
    }
}
