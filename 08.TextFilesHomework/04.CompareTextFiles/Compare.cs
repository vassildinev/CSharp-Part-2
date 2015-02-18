//Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different.
//Assume the files have equal number of lines.

using System;
using System.Collections.Generic;
using System.IO;
class Compare
{
    static void Main()
    {
        //SOLUTION
        Console.WriteLine("Comparing read.txt and some_text.txt:");
        StreamReader reader = new StreamReader("../../read.txt");
        StreamReader anotherReader = new StreamReader("../../some_text.txt");

        int sameLines = 0;
        int differentLines = 0;

        string line = reader.ReadLine();
        string anotherLine = anotherReader.ReadLine();

        while (line != null)
        {
            if (line==anotherLine)
            {
                sameLines++;
            }
            else
            {
                differentLines++;
            }
            line = reader.ReadLine();
            anotherLine = anotherReader.ReadLine();
        }
        reader.Close();
        anotherReader.Close();

        //OUTPUT
        Console.WriteLine("\nNumber of same lines: {0}", sameLines);
        Console.WriteLine("Number of different lines: {0}\n", differentLines);
    }
}