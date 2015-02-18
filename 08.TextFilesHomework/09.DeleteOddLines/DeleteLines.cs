//Write a program that deletes from given text file all odd lines.
//The result should be in the same file.

using System;
using System.IO;
class DeleteLines
{
    static void Main()
    {
        Console.WriteLine("Processing ../../read.txt:\n");

        StreamReader reader = new StreamReader("../../read.txt");
        StreamWriter writer = new StreamWriter("../../output.txt");

        int lineNumber = 0;
        string line = reader.ReadLine();
        while (line != null)
        {
            lineNumber++;
            if (lineNumber % 2 == 0)
            {
                writer.WriteLine(line);
            }
            line = reader.ReadLine();
        }

        reader.Close();
        writer.Close();

        File.Delete("../../read.txt");
        File.Move("../../output.txt", "../../read.txt");

        Console.WriteLine("Completed.");
    }
}