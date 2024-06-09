using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        //abstract class cat
        //if I inherit from cat, must have a constructor that takes in int age

        public abstract class Cat
        {
            public Cat()
            {
                if(GetType().GetConstructors().Where(x => x.GetParameters().Where(y => y.ParameterType == typeof(int) && y.Name == "age").Count() != 0).Count() == 0) throw new Exception("yo");
                
            }
        }

        public class Garfield : Cat
        {
            //public Garfield(int age)
            //{

            //}
        }

        static void Main(string[] args)
        {
            var yeet = new Garfield();
        }
    }
}
