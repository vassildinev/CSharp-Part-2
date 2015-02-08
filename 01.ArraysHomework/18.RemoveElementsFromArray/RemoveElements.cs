//Write a program that reads an array of integers and removes from it a minimal number of elements in such a way that the remaining array is sorted in increasing order.
//Print the remaining sorted array.

using System;
using System.Collections.Generic;
using System.Linq;
class RemoveElements
{
    public static bool compareArrays(int[] arrayA, int[] arrayB)
    {
        bool areTheSame = false;
        if (arrayA.Length == arrayB.Length)
        {
            areTheSame = true;
            for (int i = 0; i < arrayB.Length; i++)
            {
                if (arrayA[i] != arrayB[i])
                {
                    areTheSame = false;
                }
            }
        }
        return areTheSame;
    }
    static void Main()
    {
        //Basically our task is to find the longest serie of numbers in increasing order.

        Console.BufferHeight = 3000;
        //INPUT
        Console.WriteLine("Enter array of integers on a single line with spaces:");
        int[] numbers = Console.ReadLine().Split(' ').ToArray().Select(int.Parse).ToArray();

        //SOLUTION
        int bestLen = 0;
        int[] bestListOfNumbers = new int[0];

        //Checks all ORDERED combinations of numbers in the array.
        for (int sieve = 1; sieve < 1 << numbers.Length; sieve++)
        {
            int len = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (((sieve >> i) & 1) == 1)
                {
                    len++;
                }
            }

            //creates the current combination
            int[] currentSeriesOfNumbers = new int[len];
            int j = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (((sieve >> i) & 1) == 1)
                {
                    currentSeriesOfNumbers[j] = numbers[i];
                    j++;
                }
            }

            //copies the current combination, sorts it and checks for matches
            int[] helper = new int[currentSeriesOfNumbers.Length];
            Array.Copy(currentSeriesOfNumbers, helper, currentSeriesOfNumbers.Length);
            Array.Sort(currentSeriesOfNumbers);

            //if a match is found we have found a serie of a given length
            if (compareArrays(helper, currentSeriesOfNumbers))
            {
                //if this serie's length is larger than the best found
                //we have found a new best
                //if there are more than one best found, the first to be found
                //is going to be considered
                //for the last to be considered - set len >= bestLen
                if (len > bestLen)
                {
                    bestLen = len;
                    bestListOfNumbers = new int[bestLen];
                    Array.Copy(currentSeriesOfNumbers, bestListOfNumbers, currentSeriesOfNumbers.Length);
                }
            }
        }

        //OUTPUT

        //prints the best found serie
        Console.WriteLine(string.Join(" ", bestListOfNumbers));
    }
}
