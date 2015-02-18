// dictionary is stored as a sequence of text lines containing words and their explanations.
//Write a program that enters a word and translates it by using the dictionary.

using System;
using System.Collections.Generic;
class WordDictionary
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a word to translate:");
        string input = Console.ReadLine();

        //SOLUTION
        var dict = new Dictionary<string, string>();

        dict[".NET"]= "a platform for applications from Microsoft";
        dict["CLR"] = "managed execution environment for .NET";
        dict["namespace"] = "hierarchical organization of classes";

        //OUTPUT
        foreach (var term in dict)
        {
            if(term.Key == input)
            {
                Console.WriteLine("\n{0}\n", term.Value);
            }
        }
    }
}