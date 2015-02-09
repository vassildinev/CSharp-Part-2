//You are given an array of strings. Write a method that sorts
//the array by the length of its elements (the number of characters composing them).

using System;
using System.Collections.Generic;
using System.Linq;
class Sort
{
    static void Main()
    {
        //brakes car consequence of a small - example input
        //INPUT
        Console.WriteLine("Input array of strings on a single line separated by space:");
        string[] inputStrings = Console.ReadLine().Split(' ');

        //SOLUTION

        //copy string array elements' lengths to an integer string
        int[] inputStringsLengths = new int[inputStrings.Length];
        for (int i = 0; i < inputStrings.Length; i++)
        {
            inputStringsLengths[i] = inputStrings[i].Length;
        }

        //sort the integer string
        Array.Sort(inputStringsLengths);

        //copy the original string array elements to a new string array
        //at a position corresponding to the position of its length
        //in the integer array
        string[] sortedInputStrings = new string[inputStrings.Length];
        for (int i = 0; i < inputStrings.Length; i++)
        {
            for (int j = 0; j < inputStrings.Length; j++)
            {
                if (inputStringsLengths[i] == inputStrings[j].Length)
                {
                    if (inputStringsLengths[i] == inputStrings[j].Length)
                    {
                        sortedInputStrings[i] = inputStrings[j];
                        inputStrings[j] = "";
                        break;
                    }
                }
            }
        }

        //OUTPUT
        Console.WriteLine("\nSorted string array:\n");
        Console.WriteLine(string.Join(" ", sortedInputStrings));
        Console.WriteLine();
    }
}