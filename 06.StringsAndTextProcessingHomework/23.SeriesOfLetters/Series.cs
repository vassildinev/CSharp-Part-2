//Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.

using System;
using System.Collections.Generic;
using System.Text;
class Series
{
    static string RemoveRepetedChars(string input)
    {
        if (input.Length == 0) return input;

        StringBuilder sb = new StringBuilder();
        char[] chars = input.ToCharArray();
        char lastChar = '\0';
        for (int i = 1; i < input.Length; i++)
        {
            if (chars[i] != lastChar)
            {
                sb.Append(chars[i]);
            }
            lastChar = chars[i];
        }
        return sb.ToString();
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter string to process:");
        string input = Console.ReadLine();

        //SOLUTION
        string result = RemoveRepetedChars(input);

        //OUTPUT
        Console.WriteLine("\nResult after removing all repeating chars:\n{0}\n", result);
    }
}