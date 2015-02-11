//Write a program to convert binary numbers to their decimal representation.

using System;
class BinToDec
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a number in binary system:");
        string input = Console.ReadLine();

        //OUTPUT
        Console.WriteLine("Number in decimal system:\n{0}", Convert.ToInt32(input, 2));
    }
}