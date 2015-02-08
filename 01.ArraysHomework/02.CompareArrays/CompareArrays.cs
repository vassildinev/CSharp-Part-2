//Write a program that reads two integer arrays from the console and compares them element by element.

using System;
using System.Linq;
class CompareArrays
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter the elements of the first integer array on a single line,\nseparated by space:");
        int[] firstArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.WriteLine("Enter the elements of the second integer array on a single line,\nseparated by space:");
        int[] secondArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        //SOLUTION
        bool areEqual = false;
        if (firstArray.Length == secondArray.Length)
        {
            areEqual = true;
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    areEqual = false;
                }
            }
        }

        //OUTPUT
        Console.WriteLine("Equal? - {0}", areEqual);
    }
}
