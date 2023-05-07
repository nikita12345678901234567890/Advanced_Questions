using System.Collections;

namespace ADV_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = getNumbers(10);//0000);
            Console.WriteLine(benchmark(numbers));
            Console.WriteLine(MaxXOR(numbers));
            Console.WriteLine(MaxierXOR(numbers));
        }

        public static int benchmark(int[] numbers)
        {
            int result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                { 
                    if ((numbers[i] ^ numbers[j]) > result) result = numbers[i] ^ numbers[j];
                }
            }

            return result;
        }

        public static int MaxierXOR(int[] numbers)
        {
            Trie trie = new Trie();

            for (int i = 0; i < numbers.Length; i++)
            {
                trie.add(numbers[i]);
            }

            var result = trie.FindBest();

            return result.one ^ result.two;
        }

        public static int MaxXOR(int[] numbers)
        {
            Array.Sort(numbers);

            int biggest = numbers[numbers.Length - 1];

            int result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if ((numbers[i] ^ biggest) > result) result = numbers[i] ^ biggest;
            }

            return result;
        }

        public static int[] getNumbers(int number)
        {
            Random random = new Random();
            int[] numbers = new int[number];

            for (int i = 0; i < number; i++)
            {
                numbers[i] = random.Next(0, 100);
            }

            return numbers;
        }
    }
}