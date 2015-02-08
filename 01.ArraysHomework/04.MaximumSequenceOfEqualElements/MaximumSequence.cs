//Write a program that finds the maximal sequence of equal elements in an array.

using System;
using System.Linq;
class MaximumSequence
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter the sequence of numbers on a single line, separated by space:");
        int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        //SOLUTION
        int? lastNumber = null;
        int? repeatingNumber = null;
        int bestLen = 0;
        int len = 0;
        for (int i = 0; i < input.Length; i++)
        {
            int currentNumber = input[i];

            //if the current number is the same, continue counting
            if (currentNumber == lastNumber)
            {
                len++;
            }

            //if not, start a new sequence
            //if there are several equal sequences in length
            //the first sequence found will be printed afterwards
            else
            {
                if (len > bestLen)
                {
                    bestLen = len;
                    repeatingNumber = lastNumber;
                }
                len = 1;
            }
            lastNumber = currentNumber;
        }

        //We do it one more time, because if the longest sequence includes the last
        //element of the array, when the for-loop reaches an index out of range,
        //it breaks the loop and never saves the longest sequence.
        if (len > bestLen)
        {
            bestLen = len;
            repeatingNumber = lastNumber;
        }

        //OUTPUT
        for (int i = 0; i < bestLen; i++)
        {
            Console.Write(repeatingNumber + " ");
        }
        Console.WriteLine();
    }
}
