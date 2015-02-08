//Write a program that finds the most frequent number in an array.

using System;
using System.Collections.Generic;
using System.Linq;
class FrequentNumber
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Array elements - on a single line, separated by space:");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        //SOLUTION
        int currentCount = 1;
        int bestCount = 0;
        int bestCountElement = int.MinValue;
        int k = 0;

        //for each element with index k in the array counts how many times it is found
        //if there are more than 1 best counts,
        //the first to appear in the array will be considered
        while (k < numbers.Length)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (k != i)
                {
                    if (numbers[k] == numbers[i])
                    {
                        currentCount++;
                    }
                }
            }
            if (currentCount > bestCount)
            {
                bestCount = currentCount;
                bestCountElement = numbers[k];
            }
            currentCount = 1;
            k++;
        }

        //OUTPUT
        Console.WriteLine("{0}: {1} times", bestCountElement, bestCount);
    }
}