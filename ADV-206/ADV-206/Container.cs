using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV_206
{
    public interface IContainer<T>
    {
        public T First { get; set; }
        public T Last { get; set; }
        public int Count { get; }

        public void RemoveFirst();
        public void RemoveLast();
    }
}
