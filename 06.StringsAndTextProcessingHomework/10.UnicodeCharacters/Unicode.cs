//Write a program that converts a string to a sequence of C# Unicode character literals.
//Use format strings.

using System;
class UnicodeChars
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter string to process:");
        string input = Console.ReadLine();

        //OUTPUT
        Console.WriteLine("\nString in unicode symbols:");
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        foreach (int c in input)
        {
            Console.Write("\\u{0:X4}", c);
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}