namespace ADV_202
{
    //imagine staircase
    //only possible to take steps of 1 or 2 stairs
    //find number of combinations of steps to get to nth step
    //no recursion(input can be huge)

    /*
    1: 1
    2: 2
    3: 3
    4: 5
    5: 8
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static int Do(int destination)
        {
            List<int[]> combos = new List<int[]>();

            for (int i = 0; i < Math.Pow(3, destination); i++)
            {
                
            }
        }
    }
}