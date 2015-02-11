//Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).

using System;
class BinaryShort
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a number of type short in decimal system:");
        short number = short.Parse(Console.ReadLine());

        //OUTPUT
        Console.WriteLine("Number in binary system:\n{0}", Convert.ToString(number, 2));
    }
}
