using System.Reflection;

namespace ADV_201
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yeet = 2;

            Type type = yeet.GetType();
            var instance = Activator.CreateInstance(type);


            object thing = new Cat();

            Type type1 = thing.GetType();

            //type1.
        }
    }

    public class Cat
    {
        int age = 2;

        public Cat(int age = 0)
        {
            this.age = age;
        }

        public void Meow()
        {
            Console.WriteLine(Meow);
        }
    }
}