//Modify the solution of the previous problem to replace only whole words (not strings).

using System;
using System.IO;
using System.Text.RegularExpressions;
class ReplaceWholeWord
{
    static void Main()
    {
        Console.WriteLine("Replacing all words in text.txt \"start\" with string \"finish\"...");

        File.WriteAllText("../../text.txt", Regex.Replace(File.ReadAllText("../../text.txt"), @"\bstart\b", "finish"));

        Console.WriteLine("Completed. ");
    }
}