//Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found.

using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter string to process:");
        string input = Console.ReadLine();

        //SOLUTION

        //finds all unique letters
        var uniqueLetters = new HashSet<char>();
        foreach (char c in input)
        {
            uniqueLetters.Add(c);
        }

        //every unique letter and its occurrences will be stored in a dictionary
        var letters = new Dictionary<char, int>();
        foreach (var letter in uniqueLetters)
        {
            letters[letter] = 0;
        }

        //finds all occurrences of unique letters
        foreach (var letter in uniqueLetters)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == letter)
                {
                    count++;
                }
            }
            letters[letter] = count;
        }

        //OUTPUT
        foreach (var pair in letters)
        {
            Console.WriteLine("{0} - {1} ocuurrence(s)", pair.Key, pair.Value);
        }
    }
}