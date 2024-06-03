using BenchmarkDotNet.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSelect
{

    public class Class1
    {
        int[] numbers;
        Random random;
        int I;

        public Class1()
        {
            numbers = MakeArray(10);
            random = new Random();
            numbers = Mix(random, numbers, 15);
            I = random.Next(numbers.Length);
        }
        public int[] MakeArray(int size)
        {
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = i * 10;
            }
            return result;
        }

        public int[] Mix(Random random, int[] numbers, int swaps)
        {
            int[] result = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = numbers[i];
            }

            for (int i = 0; i < swaps; i++)
            {
                int yeet = random.Next(numbers.Length);
                int derp = random.Next(numbers.Length);
                (numbers[yeet], numbers[derp]) = (numbers[derp], numbers[yeet]);
            }
            return numbers;
        }

        [IterationSetup]
        public void Setup()
        {
            numbers = MakeArray(10);
            random = new Random();
            numbers = Mix(random, numbers, 15);
            I = random.Next(numbers.Length);
        }

        [Benchmark]
        public int ZoomZoom()
        {
            return QuickSelect(numbers, I);
        }
        public int QuickSelect(int[] numbers, int chosen1, int start = 0, int end = -1)
        {
            end = end == -1 ? numbers.Length - 1 : end;

            int pivot = numbers[start];

            int left = start;
            int right = end;
            while (left < right)
            {
                while (numbers[left] < pivot) left++;

                while (numbers[right] > pivot) right--;

                if (left < right) (numbers[left], numbers[right]) = (numbers[right], numbers[left]);
            }

            if (chosen1 == left) return numbers[left];
            if (chosen1 == right) return numbers[right];

            if (chosen1 < left) return QuickSelect(numbers, chosen1, start, left);
            else return QuickSelect(numbers, chosen1, left + 1, end);
        }

        [Benchmark]
        public int QuickSort()
        {
            return QuickSortLomuto(numbers)[I];
        }

        public static int[] QuickSortLomuto(int[] collection)
        {
            //Starting the quick sort range from the beginning to end of the array
            QuickSort(collection, 0, collection.Length - 1);

            return collection;

            //Using an internal function to allow the user to just pass in the array in the main function
            //A return is not needed for this function because arrays are pass by reference
            void QuickSort(int[] items, int left, int right)
            {
                //Keep making recursive calls until the right overlaps with the left
                if (left < right)
                {
                    //Call the partition which will return the pivot
                    //Since the pivot tells us where the split is in the array
                    //We call quicksort for the left and right side
                    int pivot = LomutoPartition(items, left, right);

                    //Left
                    QuickSort(items, left, pivot - 1);

                    //Right
                    QuickSort(items, pivot + 1, right);
                }
            }
        }
        private static int LomutoPartition(int[] items, int left, int right)
        {
            //Sorting index values for both wall and pivot
            //Easier this way to swap
            int pivot = right;
            int wall = left - 1;

            //Loop from the left to right index
            for (int i = left; i < right; i++)
            {
                //Check if the current value is less than the pivot value
                if (items[i].CompareTo(items[pivot]) < 0)
                {
                    //Move the wall up by one 
                    //Swap the current value with the wall value
                    wall++;
                    Swap(ref items[i], ref items[wall]);
                }
            }

            //Swap the pivot with pivot
            Swap(ref items[pivot], ref items[wall + 1]);

            //Since the pivot value is at the wall, we will return wall + 1
            return wall + 1;
        }
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

    }
}
