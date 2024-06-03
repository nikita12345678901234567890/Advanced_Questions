using BenchmarkDotNet.Running;

namespace QuickSelect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Class1>();
        }
    }
}
