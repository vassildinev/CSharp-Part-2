//Write a program that finds the index of given element in a sorted array of integers by using the Binary search algorithm.

using System;
using System.Collections.Generic;
using System.Linq;
class BinarySearch
{
    //Note: this method binarySearch is not used in the solution
    public static int binarySearch(int[] array, int key, int imin, int imax)
    {
        // continue searching while [imin,imax] is not empty
        while (imax >= imin)
        {
            // roughly calculate the midpoint
            int imid = (imax + imin) / 2;
            if (array[imid] == key)
                // key found at index imid
                return imid;
            // determine which subarray to search
            else if (array[imid] < key)
                // change min index to search upper subarray
                imin = imid + 1;
            else
                // change max index to search lower subarray
                imax = imid - 1;
        }
        // key was not found
        return -1;
    }

    static void Main()
    {
        //9 0 -8 23 10 4 5 8 - example array
        //-8 0 4 5 8 9 10 23 - same array sorted in ascending order

        // INPUT
        Console.WriteLine("Array elements - on a single line, separated by space:");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.WriteLine("Value to search:");
        int key = int.Parse(Console.ReadLine());

        // SOLUTION

        // for the binary search to work we need a sorted array
        // so I am going to use an array with ascending values:
        Array.Sort(numbers);
        Console.WriteLine("\nAscending values array:\n{0}\n", string.Join(" ", numbers));

        int imin = 0;
        int imax = numbers.Length - 1;
        int index = -1;

        // imin and imax are the indices, between which to search for value (we call this value the 'key')
        // continue searching while [imin,imax] is not empty
        while (imax > imin)
        {
            // roughly calculate the midpoint
            int imid = (imax + imin) / 2;
            if (numbers[imid] == key)
            // key found at index imid
            {
                index = imid;
                break;
            }
            // determine which subarray to search
            else if (numbers[imid] < key)
                // change min index to search upper subarray
                imin = imid + 1;
            else
                // change max index to search lower subarray
                imax = imid - 1;
        }
        // key was not found if index remains index = -1

        // OUTPUT
        if(index == -1)
        {
            Console.WriteLine("KEY_NOT_FOUND");
        }
        else
        {
            Console.WriteLine("Key is at index: {0}", index);
        }
    }
}
