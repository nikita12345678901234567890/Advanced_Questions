using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ADV_20
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Benchmark]
        public byte[] Linear(byte[] input)
        {
            byte[] copy = new byte[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                copy[i] = input[i];
            }

            return copy;
        }

        [Benchmark]
        public byte[] Mine(byte[] input)
        {
            byte[] copy = new byte[input.Length];

            for (int i = 0; i < input.Length - 1; i += 2)
            {
                copy[i] = input[i];
                copy[i + 1] = input[i + 1];
            }

            return copy;
        }

        [Benchmark]
        public byte[] ACopy(byte[] input)
        {
            byte[] copy = new byte[input.Length];

            Array.Copy(input, copy, input.Length);

            return copy;
        }
    }
}