namespace ADV_205
{
    internal class Program
    {
        //give array of pipe heights, find volume of water it can hold
        static void Main(string[] args)
        {
            Console.WriteLine(WaterVolume2(new int[] { 3, 2, 0, 1, 1, 1, 4, 3, 1, 2, 1}));//{ 3, 3, 4, 4, 2, 2, 3, 3, 1, 1, 5, 5, 0, 0, 5, 5, 1, 1, 3, 3}));
        }

        static int WaterVolume(int[] heights)
        {
            int volume = 0;
            Stack<(int height, int index)> stack = new Stack<(int height, int index)>();

            stack.Push((heights[0], 0));

            for (int i = 1; i < heights.Length; i++)
            {
                if (heights[i] < stack.Peek().height)
                {
                    stack.Push((heights[i], i));
                }
                else if (heights[i] == stack.Peek().height)
                {

                }
                else
                {
                    int LeftTallest = 0;
                    var array = stack.ToArray();

                    for (int j = array.Length; j > 0; j--)
                    {

                    }

                    while (stack.Peek().height < heights[i])
                    {
                        //volume += 
                    }

                    volume += (heights[i] - stack.Peek().height) * (i - (stack.Peek().index + 1));
                }
            }

            return volume;
        }


        static int WaterVolume2(int[] heights)
        {
            int min = int.MaxValue;
            int max = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                if (heights[i] < min) min = heights[i];

                if (heights[i] > max) max = heights[i];
            }

            int volume = 0;

            for (int i = min; i < max + 1; i++)
            {
                int right = 0;
                bool holds = false;
                for (int j = heights.Length - 1; j > 0; j--)
                {
                    if (heights[j] >= i)
                    {
                        right = j;
                        break;
                    }
                }

                for (int j = 0; j < right; j++)
                {
                    if (holds)
                    {
                        if (heights[j] < i)
                        {
                            volume++;
                        }
                    }

                    if (heights[j] >= i) holds = true;
                }
            }

            return volume;
        }
    }
}