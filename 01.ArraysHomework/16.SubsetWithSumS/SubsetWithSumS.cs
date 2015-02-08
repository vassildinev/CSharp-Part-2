//We are given an array of integers and a number S.
//Write a program to find if there exists a subset of the elements of the array that has a sum S.

using System;
using System.Collections.Generic;
using System.Linq;
class SubsetWithSumS
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter array of integers on a single line with spaces:");
        int[] numbers = Console.ReadLine().Split(' ').ToArray().Select(int.Parse).ToArray();

        Console.WriteLine("Sum to search:");
        int sumToSearch = int.Parse(Console.ReadLine());

        //SOLUTION
        bool isSum = false;
        for (int sieve = 1; sieve < 1 << numbers.Length; sieve++)
        {
            int currentSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (((sieve >> i) & 1) == 1)
                {
                    currentSum += numbers[i];
                }
            }
            if(currentSum == sumToSearch)
            {
                isSum = true;
            }
        }

        //OUTPUT
        Console.WriteLine("Is sum? - {0}",isSum);
    }
}
