using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV_206
{
    public class ContainerStack<T>
    {
        IContainer<T> container;
        public int Count => container.Count;

        public ContainerStack(IContainer<T> container)
        {
            this.container = container;
        }

        public void Push(T value)
        {
            container.Last = value;
        }

        public T Pop()
        {
            if (container.Count == 0) throw new Exception("The stack is empty");

            T temp = container.Last;

            container.RemoveLast();

            return temp;
        }

        public T? Peek()
        {
            if (container.Count == 0) throw new Exception("The stack is empty");

            return container.Last;
        }
    }
}
