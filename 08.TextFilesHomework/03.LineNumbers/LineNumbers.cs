//Write a program that reads a text file and inserts line numbers in front of each of its lines.
//The result should be written to another text file.

using System;
using System.IO;
class LineNumbers
{
    static void Main()
    {
        Console.WriteLine("Adding line numbers to read.txt and writing the result to with_lines.txt...");
        StreamReader reader = new StreamReader("../../read.txt");
        StreamWriter writer = new StreamWriter("../../with_lines.txt");
        int lineNumber = 0;
        string line = reader.ReadLine();
        while (line != null)
        {
            lineNumber++;
            writer.WriteLine("{0}. {1}", lineNumber, line);
            line = reader.ReadLine();
        }
        reader.Close();
        writer.Close();
        Console.WriteLine("Done.");
    }
}