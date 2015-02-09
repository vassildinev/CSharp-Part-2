//Write a program, that reads from the console an array of N integers and an integer K, sorts the array and
//using the method Array.BinSearch() finds the largest number in the array which is ≤ K.

using System;
using System.Collections.Generic;
using System.Linq;
class BinarySearch
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Array of N integers on a single line separated by space (N does not matter):");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.WriteLine("value to perform binary search for:");
        int originalKey = int.Parse(Console.ReadLine());

        //SOLUTION
        Array.Sort(numbers);
        int result = Array.BinarySearch(numbers, originalKey);
        int key = originalKey;

        //OUTPUT
        if (result == -1)
        {
            Console.WriteLine("No value X meets the conditions\nX <= {0} && X exists in the array.", originalKey);
        }
        else if (result >= 0)
        {
            Console.WriteLine("The largest value X <= {0} in the array is:", originalKey);
            Console.WriteLine(numbers[result]);
        }
        else
        {
            while (result < 0)
            {
                key--;
                result = Array.BinarySearch(numbers, key);
            }
            Console.WriteLine("The largest value X <= {0} in the array is:", originalKey);
            Console.WriteLine(numbers[result]);
        }
    }
}