//Write a program to convert decimal numbers to their binary representation.

using System;
class DecToBin
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a number in decimal system:");
        long number = long.Parse(Console.ReadLine());

        //OUTPUT
        Console.WriteLine("In binary system:\n{0}", Convert.ToString(number, 2));
    }
}
