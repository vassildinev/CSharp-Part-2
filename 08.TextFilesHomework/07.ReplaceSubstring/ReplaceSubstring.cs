//Write a program that replaces all occurrences of the sub-string start with the sub-string finish in a text file.
//Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;
using System.Text.RegularExpressions;
class ReplaceSubstring
{
    static void Main()
    {
        Console.WriteLine("Replacing all substrings in text.txt \"start\" with string \"finish\"...");

        File.WriteAllText("../../text.txt", Regex.Replace(File.ReadAllText("../../text.txt"), "start", "finish"));

        Console.WriteLine("Completed. ");
    }
}