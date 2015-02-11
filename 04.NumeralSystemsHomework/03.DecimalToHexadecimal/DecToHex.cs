//Write a program to convert decimal numbers to their hexadecimal representation.

using System;
class DecToHex
{
    static void Main()
    {
        //OUTPUT
        Console.WriteLine("Enter a number in decimal system:");
        Console.WriteLine("Number in hexadecimal system:\n{0:X}", long.Parse(Console.ReadLine()));
    }
}