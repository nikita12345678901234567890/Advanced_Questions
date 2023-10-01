using System;

namespace ADV_22
{
    internal class Program
    {
        /*
        Rules:
        input is an array of 4 numbers between 1 and 12, and a "target value"
        use arithmetic operations (add, subtract, multiply, divide) on the input values in any order to get the target value
        all 4 values must be used
        each value must be used exactly once
        math operations can repeat
        division is only valid if the result is a whole number
        Examples:
        [7, 7, 7, 3], 24:  7 + 7 + 7 + 3
        [3,, 6, 12, 6], 36: 3 * 12 + 6 - 6

        It's possible to have multiple solution; finding a single solution is ok.
        Can turn this into a game, where the user is asked to type in the solution, and your program verifies it (but first your program ensures there is one)
        */
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int target = 10;
            Do(numbers, target);


        }

        public static void Do(int[] numbers, int target)
        {
            int[] operators = new int[numbers.Length - 1];
            for (int number = 0; number < numbers.Length; number++)
            {
                for (int index = number, i = 0; i < numbers.Length; index++, i++)
                {
                    //try operations:
                    for (int j = 0; j < Math.Pow(4, operators.Length); j++)
                    {
                        int temp = j;
                        for (int k = 0; k < operators.Length; k++)
                        {
                            operators[k] = temp % 4 + 1;
                            temp /= 4;
                        }

                        //Check the maph
                        int result = numbers[0];
                        for (int l = 0; l < operators.Length; l++)
                        {
                            switch (operators[l])
                            {
                                case 1:
                                    result += numbers[l + 1];
                                    break;

                                case 2:
                                    result -= numbers[l + 1];
                                    break;

                                case 3:
                                    result *= numbers[l + 1];
                                    break;

                                case 4:
                                    result /= numbers[l + 1];
                                    break;
                            }
                        }
                        if (result == target)
                        {
                            Console.Write(numbers[0]);
                            for (int l = 0; l < operators.Length; l++)
                            {
                                switch (operators[l])
                                {
                                    case 1:
                                        Console.Write(" + " + numbers[l + 1]);
                                        break;

                                    case 2:
                                        Console.Write(" - " + numbers[l + 1]);
                                        break;

                                    case 3:
                                        Console.Write(" * " + numbers[l + 1]);
                                        break;

                                    case 4:
                                        Console.Write(" / " + numbers[l + 1]);
                                        break;
                                }
                            }
                            Console.WriteLine(" = " + result);

                            //return;
                        }
                    }


                    //Rotate the number through the array:
                    numbers = Move(numbers, index >= numbers.Length ? index - (numbers.Length) : index, index + 1 >= numbers.Length ? index - (numbers.Length - 1) : index + 1);
                }
            }
        }

        public static int[] Move(int[] numbers, int currentIndex, int targetIndex) //Moves a number from one spot in an array to another
        {
            int number = numbers[currentIndex];

            for (int i = currentIndex; i < targetIndex; i++)
            {
                numbers[i] = numbers[i + 1];
            }
            if (currentIndex > targetIndex)
            {
                for (int i = currentIndex; i > targetIndex; i--)
                {
                    numbers[i] = numbers[i - 1];
                }
            }

            numbers[targetIndex] = number;

            return numbers;
        }
    }
}