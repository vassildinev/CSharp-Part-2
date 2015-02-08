//Write a program that finds the sequence of maximal sum in given array.

using System;
using System.Collections.Generic;
using System.Linq;
class MaximumSum
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Array elements - on a single line, separated by space:");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        //SOLUTION
        List<int> currentSumList = new List<int>();
        int[] bestSumArray = { };
        int bestSum = int.MinValue;
        int currentSum = 0;
        int i = 0;
        int j = 1;
        while (true)
        {
            for (int k = 0; k < j; k++)
            {
                if (i + k < numbers.Length)
                {
                    currentSum += numbers[i + k];
                    currentSumList.Add(numbers[i + k]);
                }
            }
            if (currentSum > bestSum)
            {
                bestSum = currentSum;
                bestSumArray = new int[j];
                currentSumList.CopyTo(bestSumArray);
            }
            currentSum = 0;
            currentSumList.Clear();
            i++;
            if (i > numbers.Length - j)
            {
                j++;
                i = 0;
            }
            if(j > numbers.Length -1)
            {
                break;
            }
        }

        //OUTPUT
        Console.WriteLine(string.Join(" ", bestSumArray));
    }
}
