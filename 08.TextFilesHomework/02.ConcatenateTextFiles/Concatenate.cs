//Write a program that concatenates two text files into another text file.

using System;
using System.IO;
class Concatenate
{
    static void Main()
    {
        Console.WriteLine("Concatenating...");
        StreamReader reader = new StreamReader("../../read.txt");
        StreamWriter writer = new StreamWriter("../../concat.txt");
        string line = reader.ReadLine();
        while (line != null)
        {
            writer.WriteLine(line);
            line = reader.ReadLine();
        }

        reader = new StreamReader("../../othertext.txt");
        line = reader.ReadLine();
        while (line != null)
        {
            writer.WriteLine(line);
            line = reader.ReadLine();
        }

        Console.WriteLine("Concatenating finished.\nSee result in concat.txt = read.txt + othertext.txt");

        reader.Close();
        writer.Close();
    }
}