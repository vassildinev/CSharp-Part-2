//Write a method that returns the index of the first element in array that is larger than its neighbours,
//or -1, if there’s no such element.
//Use the method from the previous exercise.

using System;
using System.Collections.Generic;
using System.Linq;
class FirstLarger
{
    static int SmallerNeighbours(int[] array)
    {
        for (int position = 0; position < array.Length; position++)
        {
            if (position != 0 && position != array.Length - 1)
            {
                if (array[position] > array[position - 1] && array[position] > array[position + 1])
                {
                    return position;
                }
            }
        }
        return -1;
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Input an array of integers on a single line with elements separated by space.");
        int[] inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        //OUTPUT
        if (SmallerNeighbours(inputNumbers) == -1)
        {
            Console.WriteLine("-1 => no such element exists in the array");
        }
        else
        {
            Console.WriteLine("Element at index {0} is the first larger than its TWO neighbour elements.", SmallerNeighbours(inputNumbers));
        }
    }
}
