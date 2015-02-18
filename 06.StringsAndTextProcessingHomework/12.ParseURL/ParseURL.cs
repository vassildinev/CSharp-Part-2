//Write a program that parses an URL address given in the format: [protocol]://[server]/[resource] 
//and extracts from it the [protocol], [server] and [resource] elements.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class ParseURL
{
    static List<string> reverseStringFormat(string template, string str)
    {
        string pattern = "^" + Regex.Replace(template, @"\{[0-9]+\}", "(.*?)") + "$";

        Regex r = new Regex(pattern);
        Match m = r.Match(str);

        List<string> members = new List<string>();

        for (int i = 1; i < m.Groups.Count; i++)
        {
            members.Add(m.Groups[i].Value);
        }

        return members;
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter an URL:");
        string input = Console.ReadLine();

        //SOLUTION
        string template = "{0}://{1}/{2}";
        var result = reverseStringFormat(template, input);

        //OUTPUT
        Console.WriteLine("\n[protocol] = {0}", result[0]);
        Console.WriteLine("[server] = {0}", result[1]);
        Console.WriteLine("[resource] = {0}\n", result[2]);
    }
}