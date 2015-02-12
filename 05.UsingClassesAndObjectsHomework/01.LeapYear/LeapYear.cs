//Write a program that reads a year from the console and checks whether it is a leap one.
//Use System.DateTime.

using System;
class LeapYear
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter an year:");

        //OUTPUT
        Console.WriteLine("Is leap year? -> {0}", DateTime.IsLeapYear(int.Parse(Console.ReadLine())));
    }
}
