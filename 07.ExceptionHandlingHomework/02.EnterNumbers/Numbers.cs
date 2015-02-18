//Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end].
//If an invalid number or non-number text is entered, the method should throw an exception.
//Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;
using System.Collections.Generic;
using System.Linq;
class Numbers
{
    static int RealNumber(int start, int end)
    {
        int number;
        if (int.TryParse(Console.ReadLine(), out number) && (number >= start && number <= end))
        {
            return number;
        }
        else
        {
            throw new ArgumentException("INVALID_ENTRY");
        }
    }
    static void Main()
    {
        const int start = 1;
        const int end = 100;
        const int numberOfEntries = 10;
        List<int> entries = new List<int>();

        //INPUT
        Console.WriteLine("Enter {0} valid integers in INCREASING ORDER\nin the range [{1}, {2}] on separate lines:", numberOfEntries, start, end);
        for (int i = 0; i < numberOfEntries; i++)
        {
            int entry = RealNumber(start, end);
            if (entries.Count == 0)
            {
                entries.Add(RealNumber(start, end));
            }
            else if (entry > entries.Max() && entries.Count > 0)
            {
                entries.Add(RealNumber(start, end));
            }
            else
            {
                throw new ArgumentException("INVALID_ENTRY");
            }
        }

        //OUTPUT
        Console.WriteLine("\nYou entered these integers in the range [{0}, {1}]:", start, end);
        foreach (int number in entries)
        {
            Console.WriteLine(number);
        }
    }
}
