//Write a program that reads a number and prints it as a decimal number, 
//hexadecimal number, percentage and in scientific notation.
//Format the output aligned right in 15 symbols.

using System;
class FormatNumber
{
    static void Main()
    {
        //INPUT
        Console.BufferWidth = Console.WindowWidth;
        Console.WriteLine("Enter a number:");
        decimal number = decimal.Parse(Console.ReadLine());

        //OUTPUT
        Console.WriteLine("{0,65}", number);
        Console.WriteLine("{0,65:X}", BitConverter.DoubleToInt64Bits((double)number));
        Console.WriteLine("{0,65:P}", number);
        Console.WriteLine("{0,65:e2}", number);
    }
}