//Write a program that finds the maximal increasing sequence in an array.

using System;
class MaximumIncreasing
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter the sequence of numbers, separated by space:");
        string[] input = Console.ReadLine().Split();

        //SOLUTION

        string bestResult = "";
        string result = "";
        int bestLen = 0;
        int len = 1;
        for (int i = 1; i < input.Length; i++)
        {
            int lastNumber = Convert.ToInt32(input[i - 1]);
            int currentNumber = Convert.ToInt32(input[i]);

            //if the current number is the same, continue counting
            if (currentNumber > lastNumber)
            {
                len++;
                result += lastNumber;
                result += " ";
                if (i == input.Length - 1)
                {
                    if (len > bestLen)
                    {
                        result += currentNumber;
                        bestResult = result;
                    }
                }
            }

            //if not, start a new sequence
            //if there are several equal sequences in length
            //the first sequence found will be printed afterwards
            else
            {
                result += lastNumber;
                if (len > bestLen)
                {
                    bestLen = len;
                    bestResult = result;
                }
                len = 1;
                result = "";
            }

            lastNumber = Convert.ToInt32(currentNumber);
        }

        //OUTPUT
        Console.WriteLine(bestResult);
    }
}
