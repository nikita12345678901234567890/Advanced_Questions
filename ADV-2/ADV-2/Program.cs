using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ADV_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = getNumbers(15);
            Console.WriteLine(benchmark(numbers));
            //Console.WriteLine(MaxXOR(numbers));
            //Console.WriteLine(MaxierXOR(numbers));
            //Console.WriteLine(hacky(numbers));
            thing(numbers);

            Trie trie = new Trie();
            Console.WriteLine(trie.FindMaximumXor(numbers));
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

        public static int MaxierXOR(int[] numbers)
        {
            Trie trie = new Trie();

            for (int i = 0; i < numbers.Length; i++)
            {
                trie.add(numbers[i]);
            }

            trie.BreadthFirstTraversal();

            int[] array = new int[1];
            trie.root.bestXOR.CopyTo(array, 0);

            return array[0];
        }

        public static int hacky(int[] numbers)
        { 
            HashSet<int> hash = new HashSet<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                hash.Add(numbers[i]);
            }

            return benchmark(hash.ToArray());
        }

        public static void thing(int[] numbers)
        {
            Trie trie = new Trie();

            for (int i = 0; i < numbers.Length; i++)
            {
                trie.add(numbers[i]);
            }

            var result = trie.thing();

            Console.WriteLine(ToBitString(result.one));
            Console.WriteLine(ToBitString(result.zero));
            Console.WriteLine(getInt(result.one.Xor(result.zero)));
            //Console.WriteLine(getInt(result.one) ^ getInt(result.zero));
        }

        public static int getInt(BitArray bitArray)
        {

            if (bitArray.Length > 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");

            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];

        }

        public static string ToBitString(BitArray bits)
        {
            var sb = new StringBuilder();

            for (int i = bits.Count - 1; i >= 0; i--)
            {
                char c = bits[i] ? '1' : '0';
                sb.Append(c);
            }

            return sb.ToString();
        }

        public static int[] getNumbers(int number)
        {
            Random random = new Random(537);
            int[] numbers = new int[number];

            for (int i = 0; i < number; i++)
            {
                numbers[i] = random.Next(0, 100);
            }

            return numbers;
        }
    }
}