//Write a program that reads a list of words from the file words.txt and finds how many times each of the words is contained in another file test.txt.
//The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order.
//Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
class CountWords
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
        Console.WriteLine("Reading from words.txt and test.txt...");
        var words = new List<string>(File.ReadAllText("../../words.txt").Split(','));
        var text = File.ReadAllText("../../test.txt");

        //SOLUTION
        var wordsAndCount = new Dictionary<string, int>();
        foreach (string word in words)
        {
            var count = Regex.Matches(text, word).Count;
            AddOrUpdate(wordsAndCount, word, count);
        }
        var sortedWordsAndCount = (from entry in wordsAndCount orderby entry.Value descending select entry).ToDictionary(x=> x.Key, x=> x.Value);

        Console.WriteLine("Writing to result.txt...");
        File.WriteAllLines("../../result.txt", 
            sortedWordsAndCount.Select(x => x.Key + " - " + x.Value + " occurrence(s)").ToArray());
        Console.WriteLine("Completed.");
    }
}