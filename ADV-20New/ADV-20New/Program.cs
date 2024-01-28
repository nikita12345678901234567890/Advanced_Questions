namespace ADV_20New
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = { "bac", "abc", "gif", "bac", "gif" };

            

            Console.WriteLine(Two(input));
        }

        static string One(string[] input)
        {
            HashSet<string> seen = new HashSet<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (seen.Contains(input[i]))
                {
                    seen.Remove(input[i]);
                }
                else
                {
                    seen.Add(input[i]);
                }
            }

            return seen.ToList()[0];
        }

        static string Two(string[] input)
        {
            int maxSize = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Length > maxSize) maxSize = input[i].Length;
            }

            int[,] counts = new int[26, maxSize];
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    counts[input[i][j] - 'a', j]++;
                }
            }

            string result = "";
            for (int i = 0; i < maxSize; i++)
            {
                char letter = 'A';
                int min = int.MaxValue;
                for (int j = 0; j < 26; j++)
                {
                    if (counts[j, i] % 2 == 1 && counts[j, i] < min)
                    {
                        min = counts[j, i];
                        letter = (char)(j + 'a');
                    }
                }
                if (letter == 'A') break;
                result += letter;
            }

            return result;
        }
    }
}