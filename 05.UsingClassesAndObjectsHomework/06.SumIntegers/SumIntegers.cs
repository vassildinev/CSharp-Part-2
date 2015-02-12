//You are given a sequence of positive integer values written into a string, separated by spaces.
//Write a function that reads these values from given string and calculates their sum.

using System;
using System.Linq;
class SumIntegers
{
    static long SumOfNums(string numbers)
    {
        long sum = numbers.Split(' ').Select(int.Parse).ToArray().Sum();
        return sum;
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter integers on a single line separated by space to calculate their sum:");
        string input = Console.ReadLine();

        //OUTPUT
        Console.WriteLine("\nThe sum of these numbers is:\n{0}\n", SumOfNums(input));
    }
}