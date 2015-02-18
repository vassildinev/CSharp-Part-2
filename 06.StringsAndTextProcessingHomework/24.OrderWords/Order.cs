//Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

using System;
using System.Collections.Generic;
class Order
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter words on a single line separated by spaces:");
        List<string> input = new List<string>(Console.ReadLine().Split(' '));

        //SOLUTION
        input.Sort();

        //OUTPUT
        Console.WriteLine("\nSorted list of words:");
        foreach (var word in input)
        {
            Console.WriteLine(word);
        }
        Console.WriteLine();
    }
}