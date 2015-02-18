//Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Words
{
    static void AddOrUpdate(Dictionary<string, int> dic, string key, int newValue)
    {
        int val;
        if (dic.TryGetValue(key, out val))
        {
            dic[key] = newValue;
        }
        else
        {
            dic.Add(key, newValue);
        }
    }
    static void Main()
    {
        //INPUT

        //sample input - az obicham da pravq mekici. mnogo obicham mekici az da pravq mekici, mekici, da
        Console.WriteLine("Enter string to process:");
        string input = Console.ReadLine();

        //SOLUTION
        var words = input.Replace(".", "")
                         .Replace(",", "")
                         .Split(' ');

        var UniqueWords = new HashSet<string>(words);

        var wordsAndCount = new Dictionary<string, int>();

        foreach (var word in UniqueWords)
        {
            int count = 0;
            foreach (var otherWord in words)
            {
                if (otherWord==word)
                {
                    count++;
                }
            }
            AddOrUpdate(wordsAndCount, word, count);
        }

        foreach (var word in wordsAndCount)
        {
            Console.WriteLine("{0} - {1} occurrence(s)", word.Key, word.Value);
        }
    }
}