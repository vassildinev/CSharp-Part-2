//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.

using System;
using System.Collections.Generic;
using System.IO;
class SaveSortedNames
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Reading from input.txt...");
        StreamReader reader = new StreamReader("../../input.txt");

        var strings = new List<string>();

        string line = reader.ReadLine();
        while (line != null)
        {
            strings.Add(line);
            line = reader.ReadLine();
        }
        reader.Close();

        //SOLUTION
        strings.Sort();

        //OUTPUT
        Console.WriteLine("Writing to output.txt...");
        StreamWriter writer = new StreamWriter("../../output.txt");

        foreach (string str in strings)
        {
            writer.WriteLine(str);
        }
        writer.Close();

        Console.WriteLine("Completed.");
    }
}