using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ADV_20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //copy array in sub linear time.
            var summary = BenchmarkRunner.Run<Benchmark>();
        }
    }
}