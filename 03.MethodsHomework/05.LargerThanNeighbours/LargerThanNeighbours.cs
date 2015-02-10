//Write a method that checks if the element at given position in given array
//of integers is larger than its two neighbours (when such exist).

using System;
using System.Collections.Generic;
using System.Linq;
class LargerThanNeighbours
{
    static object SmallerNeighbours(int[] array, int position)
    {
        if (position == 0 || position == array.Length - 1)
        {
            return "Only one neighbour.";
        }
        else
        {
            if (array[position] > array[position - 1] && array[position] > array[position + 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Input an array of integers on a single line with elements separated by space.");
        int[] inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.WriteLine("Enter a position in the array:");
        int pos = int.Parse(Console.ReadLine());

        //OUTPUT
        Console.WriteLine("Element at index {0} is larger than its TWO neighbour elements => {1}",
            pos, SmallerNeighbours(inputNumbers, pos));
    }
}