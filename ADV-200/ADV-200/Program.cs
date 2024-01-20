using System;
using System.Reflection;
using System.Linq;

namespace ADV_200
{
    //have a struct constrained to only having IComparables.
    //On one of these fields only you have [sortBy]
    //have function that orderBys by this field

    public class OrderBy : Attribute
    {
        public IComparable thing;
    }

    public class Cat
    {
        int yeeeet;
        [OrderBy] double fish;
    }

    public class Fish
    {
        [OrderBy] int yeet;
        int thingy;
    }

    public class thingy<T> where T : struct
    {
        public IEnumerable<T> derp(IEnumerable<T> values)
        {
            T yeet = values.First();
            var fsh = yeet.GetType();

            foreach (var method in fsh.GetMethods())
            {
                if (method.GetCustomAttribute(typeof(OrderBy)) != null)
                {
                    return values.OrderBy(method);
                }
            }
        }
    }

    internal class Program
    {
        public static void Main()
        {
            
        }
    }
}