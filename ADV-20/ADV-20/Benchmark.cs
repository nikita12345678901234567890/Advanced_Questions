using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ADV_20
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        public byte[] input;
        public int N = 1000;
        Random random;

        public Benchmark()
        {
            random = new Random();
            input = new byte[N];
            random.NextBytes(input);
        }

        [Benchmark]
        public byte[] Linear()
        {
            byte[] copy = new byte[N];

            for (int i = 0; i < N; i++)
            {
                copy[i] = input[i];
            }

            return copy;
        }

        [Benchmark]
        public unsafe byte[] Mine()
        {
            byte[] array = input;

            byte[] copy = new byte[N];

            fixed (byte* start = &array[0], copyPointer = &copy[0])
            {
                long buffer;
                byte* current = start;
                byte* destination = copyPointer;

                long* temp;

                for (int i = 0; i < N / 8; i++)
                {
                    buffer = *(long*)current;

                    *(long*)destination = buffer;

                    current += 8;
                    destination += 8;
                }

                byte fish;
                for (int i = 0; i < N % 8; i++)
                {
                    fish = *current;
                    *destination = fish;

                    current++;
                    destination++;
                }
            }

            return copy;
        }

        [Benchmark]
        public byte[] ACopy()
        {
            byte[] copy = new byte[input.Length];

            Array.Copy(input, copy, input.Length);

            return copy;
        }
    }
}