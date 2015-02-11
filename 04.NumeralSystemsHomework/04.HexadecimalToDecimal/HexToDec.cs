//Write a program to convert hexadecimal numbers to their decimal representation.

using System;
class HexToDec
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter number in hexadecimal system:");
        string hexValue = Console.ReadLine();

        //OUTPUT
        Console.WriteLine("Number in decimal system is:\n{0}", long.Parse(hexValue, System.Globalization.NumberStyles.HexNumber));
    }
}