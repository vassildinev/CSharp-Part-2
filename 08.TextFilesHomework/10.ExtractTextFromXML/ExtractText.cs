//Write a program that extracts from given XML file all the text without the tags.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
class ExtractText
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Reading from input.txt...");
        StreamReader reader = new StreamReader("../../input.txt");
        string input = reader.ReadToEnd();
        reader.Close();
        Console.WriteLine("Completed.");

        //SOLUTION
        string output = Regex.Replace(input, "<.*?>", " ").Trim();
        output = Regex.Replace(output, @"\s+", " ");
        var contents = new List<string>(output.Split(' '));

        //OUTPUT
        Console.WriteLine("\nContents:\n");
        foreach (string str in contents)
        {
            Console.WriteLine(str);
        }
        Console.WriteLine();
    }
}