//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.

using System;
using System.Globalization;
class DateDifference
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter two dates in the format DD.MM.YYYY on separate lines:");
        DateTime fDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
        DateTime sDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

        //OUTPUT
        Console.WriteLine("\nThe number of days between these two dates is:\n{0}\n", (sDate-fDate).Days);
    }
}