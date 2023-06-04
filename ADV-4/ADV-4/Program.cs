using System.Collections.Immutable;
using System.Linq;

namespace ADV_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] envelopes = new int[4][];
            for (int i = 0; i < envelopes.GetLength(0); i++)
            {
                envelopes[i] = new int[2];
            }
            
            envelopes[0][0] = 5;
            envelopes[0][1] = 4;

            envelopes[1][0] = 6;
            envelopes[1][1] = 4;

            envelopes[2][0] = 6;
            envelopes[2][1] = 7;

            envelopes[3][0] = 2;
            envelopes[3][1] = 3;

            Console.WriteLine(doStuff(envelopes));
        }

        public static int doStuff(int[][] envelopes)
        {
            envelopes = envelopes.OrderBy(y => y[0]).ThenBy(y => y[1]).ToArray();

            int[] fish = new int[envelopes.Length];
            Array.Fill(fish, int.MaxValue);

            int max = 0;
            foreach (int[] envelope in envelopes)
            {
                //binary search
                int left = 0, right = max;
                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (fish[mid] < envelope[1])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }

                fish[left] = envelope[1];

                if (left == max)
                {
                    max++;
                }
            }
            return max;
        }
    }
}