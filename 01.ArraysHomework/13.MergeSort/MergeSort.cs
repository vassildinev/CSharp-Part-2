//Write a program that sorts an array of integers using the Merge sort algorithm.

using System;
using System.Collections.Generic;
using System.Linq;
class MergeSort
{
    // array numbers[] has the items to sort; array workArray[] is a work array
    public static void BottomUpSort(int[] numbers, int[] workArray, int numberOfElements)
    {
        // Each 1-element run in A is already "sorted".
        // Make successively longer sorted runs of length 2, 4, 8, 16... until whole array is sorted.
        for (int width = 1; width < numberOfElements; width = 2 * width)
        {
            // Original array is full of runs of length width.
            for (int i = 0; i < numberOfElements; i = i + 2 * width)
            {
                // Merge two runs: numbers[i:i + width - 1] and numbers[i + width: i + 2 * width - 1] to workArray[]
                BottomUpMerge(numbers, i, Math.Min(i + width, numberOfElements), Math.Min(i + 2 * width, numberOfElements), workArray);
            }
            // Now work array is full of runs of length 2 * width.
            // Copy work array to original array for next iteration.
            CopyArray(workArray, numbers, numberOfElements);
        }
    }

    public static void BottomUpMerge(int[] numbers, int iLeft, int iRight, int iEnd, int[] workArray)
    {
        int i0 = iLeft;
        int i1 = iRight;

        // While there are elements in the left or right runs
        for (int j = iLeft; j < iEnd; j++)
        {
            // If left run head exists and is <= existing right run head
            if (i0 < iRight && (i1 >= iEnd || numbers[i0] <= numbers[i1]))
            {
                workArray[j] = numbers[i0];
                ++i0;
            }
            else
            {
                workArray[j] = numbers[i1];
                ++i1;
            }
        }
    }

    public static void CopyArray(int[] workArray, int[] numbers, int numberOfElements)
    {
        for (int i = 0; i < numberOfElements; i++)
        {
            numbers[i] = workArray[i];
        }
    }
    static void Main()
    {
        //-7 0 35 -1 8 2 17 - example array
        //-7 -1 0 2 8 17 35 - sorted array

        // INPUT
        Console.WriteLine("Array elements - on a single line, separated by space:");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // SOLUTION
        int[] workArray = new int[numbers.Length];
        BottomUpSort(numbers, workArray, numbers.Length);

        // OUTPUT
        Console.WriteLine(string.Join(" ", numbers));
    }
}
