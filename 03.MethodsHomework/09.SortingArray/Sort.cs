//Write a method that return the maximal element in a portion of array of integers starting at given index.
//Using it write another method that sorts an array in ascending / descending order.

using System;
using System.Linq;
class Sort
{
    static int MaxElement(int[] array, int startPosition)
    {
        int maxElement = array[startPosition];
        for (int i = startPosition; i < array.Length; i++)
        {
            if (array[i] > maxElement)
            {
                maxElement = array[i];
            }
        }
        return maxElement;
    }

    static void SortArray(int[] array)
    {
        int startPosition = 0;
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(MaxElement(array, startPosition) + " ");
            for (int j = 0; j < array.Length; j++)
            {
                if(MaxElement(array, startPosition)==array[j])
                {
                    array[j] = int.MinValue;
                    break;
                }
            }
        }
        Console.WriteLine();
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Input an array of integers on a single line with elements separated by space.");
        int[] inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        //OUTPUT
        Console.WriteLine("\nSorted array:");
        SortArray(inputNumbers);
    }
}