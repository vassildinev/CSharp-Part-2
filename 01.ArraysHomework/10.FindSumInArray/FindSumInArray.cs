//Write a program that finds in given array of integers a sequence of given sum S (if present).

using System;
using System.Collections.Generic;
using System.Linq;
class FindSumInArray
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Array elements - on a single line, separated by space:");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.WriteLine("Sum to search for:");
        int sumToSearch = int.Parse(Console.ReadLine());

        //SOLUTION
        List<int> currentSumList = new List<int>();
        int[] sumSArray = { };
        int currentSum = 0;
        int i = 0;
        int j = 1;
        bool isSum = false;

        //the first to be found will be considered
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
            if (currentSum == sumToSearch)
            {
                isSum = true;
                sumToSearch = currentSum;
                sumSArray = new int[j];
                currentSumList.CopyTo(sumSArray);
            }
            currentSum = 0;
            currentSumList.Clear();
            i++;
            if (i > numbers.Length - j)
            {
                j++;
                i = 0;
            }
            if (j > numbers.Length - 1)
            {
                break;
            }
        }

        //OUTPUT
        if (isSum)
        {
            Console.WriteLine(string.Join(" ", sumSArray));
        }
        else
        {
            Console.WriteLine(isSum);
        }
    }
}
