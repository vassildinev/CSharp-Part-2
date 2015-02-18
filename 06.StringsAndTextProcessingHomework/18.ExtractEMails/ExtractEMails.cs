//Write a program for extracting all email addresses from given text.
//All sub-strings that match the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class ExtractEMails
{
    static void EmailExtractor(string text)
    {
        const string MatchEmailPattern =
       @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
       + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
         + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
       + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";
        Regex regexpr = new Regex(MatchEmailPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        MatchCollection matches = regexpr.Matches(text);
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value.ToString());
        }
    }
    static void Main()
    {
        //sample input - just@some.tests+++to-prove@that.this()program@works.fine
        //INPUT
        Console.WriteLine("Enter a text to extract e-mails from:");
        string input = Console.ReadLine();

        //OUTPUT
        Console.WriteLine("\nExtracted e-mails:\n");
        EmailExtractor(input);
        Console.WriteLine();
    }
}
