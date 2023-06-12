using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Linq;

namespace ADV_20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //copy array in sub linear time.
            var summary = BenchmarkRunner.Run<Benchmark>();

            Benchmark fish = new Benchmark();

            Console.WriteLine("Did it do it correctly? " + fish.input.SequenceEqual(fish.Mine()));
        }
    }
}