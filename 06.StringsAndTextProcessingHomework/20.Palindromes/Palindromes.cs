//Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe.

using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
class Palindromes
{
    static void PalindromeExtractor(string input)
    {
        int minimum = 3;
        for (int i = 0; i < input.Length - minimum + 1; i++)
        {
            for (int j = i+minimum; j <= input.Length; j++)
            {
                string forstr = input.Substring(i, j - i);
                string revstr = new string(forstr.Reverse().ToArray());
                if (forstr == revstr && forstr.Length >= minimum)
                {
                    Console.WriteLine(forstr);
                }
            }
        }
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        //OUTPUT
        Console.WriteLine("\nAll palindromes in the text:\n");
        PalindromeExtractor(text);
    }
}