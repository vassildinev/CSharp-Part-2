//Write a method that calculates the number of workdays between today and given date, passed as parameter.
//Consider that workdays are all days from Monday to Friday except a fixed list of public holidays 
//specified preliminary as array.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
class WorkDays
{
    static bool IsWorkingDay(DateTime date)
    {
        return date.DayOfWeek != DayOfWeek.Saturday
            && date.DayOfWeek != DayOfWeek.Sunday;
    }

    static IEnumerable<DateTime> AllDates(DateTime fromDate, DateTime toDate)
    {
        return Enumerable.Range(0, toDate.Subtract(fromDate).Days + 1).Select(d => fromDate.AddDays(d));
    }

    static void Main()
    {
        //INPUT
        Console.WriteLine("Input holidays for 2015 on a single line in the format DD/MM/YYYY");
        DateTime[] holidays2015 = Console.ReadLine().Split(' ').
            Select(x => DateTime.ParseExact(x, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToArray();

        //SOLUTION
        Console.WriteLine("\nEnter two dates on separate lines in the same format to calculate work days between them.\nThe interval is [startDate, endDate]:");
        IEnumerable<DateTime> allDates = AllDates(DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
            DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture));
        int countOfWorkDays = allDates.Where(day => IsWorkingDay(day) && !holidays2015.Contains(day)).Count();

        //OUTPUT
        Console.WriteLine("\nNumber of work days between these two dates:\n{0}", countOfWorkDays);
    }
}