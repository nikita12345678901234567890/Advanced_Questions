using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV_21
{
    public class MagicList<T>
    {
        List<T[]> arrays;
        int index;

        public MagicList()
        {
            arrays = new List<T[]>();
            arrays.Add(new T[4]);
            index = 0;
        }

        public void Add(T value)//O(1)
        {
            if (index < Math.Pow(2, 1 + arrays.Count))
            {
                int array = Math.ILogB(index);
                if (array <= 0) array = 1;
                array--;

                arrays[array][arrays[array].Length - ((int)Math.Pow(2, 1 + arrays.Count) - index)] = value;
                index++;
            }
            else
            {
                arrays.Add(new T[index]);
                arrays[arrays.Count - 1][0] = value;
                index++;
            }
        }

        public bool Contains(T value)//O(n)
        {
            bool contains = false;
            for (int i = 0; i < arrays.Count; i++)
            {
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    if (arrays[i][j].Equals(value)) contains = true;
                }
            }
            return contains;
        }

        public T Index(int position)//O(1)
        {
            int array = Math.ILogB(position) - 1;
            return arrays[array][arrays[array].Length - (position - (int)Math.Pow(2, 1 + array))];
        }

        public void Remove()//O(n)
        {
            
        }
    }
}