using Microsoft.VisualBasic;

using System.Reflection;

namespace ADV_201
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly testAssembly = Assembly.LoadFile(@"\\GMRDC1\Folder Redirection\Nikita.Ulianov\Documents\Github\Advanced_Questions\ADV-201\ADV-201\bin\Debug\net6.0\ADV-201.dll");

            Type catType = testAssembly.GetType("ADV_201.Cat");

            object catInstance = Activator.CreateInstance(catType);

            PropertyInfo numberPropertyInfo = catType.GetProperty("age");

            int age = (int)numberPropertyInfo.GetValue(catInstance, null);

            catType.GetMethod("Meow").Invoke(catInstance, null);
            ;
        }
    }

    public class Cat
    {
        public int age { get; set; }

        public Cat()
        { 
            age = 3;
        }
        public Cat(int age = 0)
        {
            this.age = age;
        }

        public void Meow()
        {
            Console.WriteLine("Meow");
        }
    }
}