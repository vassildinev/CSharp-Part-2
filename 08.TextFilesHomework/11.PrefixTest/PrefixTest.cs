//Write a program that deletes from a text file all words that start with the prefix "test".
//Words contain only the symbols 0…9, a…z, A…Z, _.

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
class PrefixTest
{
    static void Main()
    {
        //SOLUTION
        Console.WriteLine("Processing text.txt...");
        string filePath = "../../text.txt";
        File.WriteAllText(filePath,
            Regex.Replace(File.ReadAllText(filePath), @"(?<!\w)test?\w+", string.Empty));
        var lines = File.ReadAllLines(filePath).Where(x => !string.IsNullOrWhiteSpace(x)).Select(x=>x.Trim());
        File.WriteAllLines(filePath, lines);
        Console.WriteLine("Complete.");
    }
}