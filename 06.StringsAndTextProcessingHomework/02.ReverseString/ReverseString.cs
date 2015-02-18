//Write a program that reads a string, reverses it and prints the result at the console.

using System;
class ReverseString
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();

        //SOLUTION
        string reversedString = "";
        for (int i = 0; i < input.Length; i++)
        {
            reversedString += input[input.Length - 1 - i];
        }

        //OUTPUT
        Console.WriteLine("\nReversed string:\n{0}\n", reversedString);
    }
}