//Write a method that counts how many times given number appears in given array.
//Write a test program to check if the method is working correctly.

using System;
using System.Collections.Generic;
using System.Linq;
class Appearance
{
    static int ApperanceCount(int[] array, int number)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if(array[i]==number)
            {
                count++;
            }
        }
        return count;
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter numbers for an integer array, on a single line separated by space:");
        int[] inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.WriteLine("Number to search for in the array:");
        int number = int.Parse(Console.ReadLine());

        //OUTPUT
        Console.WriteLine();
        Console.WriteLine("The number {0} appers {1} times.", number, ApperanceCount(inputNumbers,number));
    }
}