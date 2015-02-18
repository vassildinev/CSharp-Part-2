//Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20,
//the rest of the characters should be filled with *.
//Print the result string into the console.

using System;
class StringLength
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a string of 20 charaters max:");
        string input = Console.ReadLine();

        //OUTPUT
        if (input.Length > 20)
        {
            Console.WriteLine("\nINCORRECT_INPUT\n");
            return;
        }
        else
        {
            Console.WriteLine("Result:\n{0}\n", input.PadRight(20,'*'));
        }
    }
}