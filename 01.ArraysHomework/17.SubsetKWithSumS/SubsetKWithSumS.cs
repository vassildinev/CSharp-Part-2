//Write a program that reads three integer numbers N, K and S and an array of N elements from the console.
//Find in the array a subset of K elements that have sum S or indicate about its absence.

using System;
using System.Collections.Generic;
using System.Linq;
class SubsetKWithSumS
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter array of integers on a single line with spaces:");
        int[] numbers = Console.ReadLine().Split(' ').ToArray().Select(int.Parse).ToArray();

        Console.WriteLine("Subset of how many elements:");
        int subsetNoOfElements = int.Parse(Console.ReadLine());

        Console.WriteLine("Sum to search:");
        int sumToSearch = int.Parse(Console.ReadLine());

        //SOLUTION
        bool isSum = false;
        string bestSubset = "";
        for (int sieve = 1; sieve < 1 << numbers.Length; sieve++)
        {
            int currentSum = 0;
            int currentNumberOfSubsetNumbers = 0;
            string subset = "";
            for (int i = 0; i < numbers.Length; i++)
            {
                if (((sieve >> i) & 1) == 1)
                {
                    currentNumberOfSubsetNumbers++;
                }
            }
            if (currentNumberOfSubsetNumbers == subsetNoOfElements)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (((sieve >> i) & 1) == 1)
                    {
                        currentSum += numbers[i];
                        subset += numbers[i].ToString();
                        subset += " ";
                    }
                }
                if (currentSum == sumToSearch)
                {
                    isSum = true;
                    bestSubset = subset;
                }
            }
        }

        //OUTPUT
        Console.WriteLine();
        Console.WriteLine("Is sum? - {0}", isSum);
        if (isSum)
        {
            Console.WriteLine("Subset -> {0}", bestSubset);
        }
        else
        {
            Console.WriteLine("SUBSET_NOT_FOUND");
        }
    }
}
