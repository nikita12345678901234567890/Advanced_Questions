using System.Collections.Immutable;
using System.Linq;

namespace ADV_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] envelopes = { new int[] { 1, 15 }, new int[] { 7, 18 }, new int[] { 7, 6 }, new int[] { 7, 100 }, new int[] { 2, 200 }, new int[] { 17, 30 }, new int[] { 17, 45 }, new int[] { 3, 5 }, new int[] { 7, 8 }, new int[] { 3, 6 }, new int[] { 3, 10 }, new int[] { 7, 20 }, new int[] { 17, 3 }, new int[] { 17, 45 } };
            
            Console.WriteLine(MaxEnvelopes(envelopes));
        }

        public static int MaxEnvelopes(int[][] envelopes)
        {
            envelopes = envelopes.OrderBy(y => y[0]).ThenBy(y => y[1]).ToArray();

            int[] fish = new int[envelopes.Length];
            Array.Fill(fish, int.MaxValue);

            int max = 0;
            int lastx = 0;
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


                if (left == max && lastx < envelope[0])
                {
                    fish[left] = envelope[1];
                    max++;
                    lastx = envelope[0];
                }
                else if (left < max && lastx < envelope[0] && lastx >= envelope[0]-5 && fish[left] > envelope[1])
                {
                    fish[left] = envelope[1];
                    lastx = envelope[0];
                }
            }
            return max;
        }
    }
}