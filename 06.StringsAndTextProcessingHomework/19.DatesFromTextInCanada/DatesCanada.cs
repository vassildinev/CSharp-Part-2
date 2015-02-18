using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;
class DatesCanada
{
    static void DatesExtractor(string input)
    {
        try
        {
            const string MatchDatePattern = @"[0123]?\d[/.][0123]?\d[/.]\d{4}";
            Regex rg = new Regex(MatchDatePattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = rg.Matches(input);
            foreach (Match match in matches)
            {
                Console.WriteLine(DateTime.ParseExact(match.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture)
                    .ToString("yyyy-MM-dd"));
            }
        }
        catch
        {
            Console.WriteLine("Incorrect input.");
            System.Environment.Exit(0);
        }
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter text to process:");
        string input = Console.ReadLine();

        //OUTPUT
        Console.WriteLine("\nDates found in the text and converted to standard datetime in Canada:\n");
        DatesExtractor(input);
    }
}