//Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
//and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

using System;
using System.Globalization;
using System.Threading;
class DateInBulgarian
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a date in the format DD.MM.YYYY HH:MM:SS");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        //SOLUTION
        date = date.AddHours(6);
        date = date.AddMinutes(30);

        var culture = new System.Globalization.CultureInfo("bg-BG");
        Thread.CurrentThread.CurrentCulture = culture;
        var day = culture.DateTimeFormat.GetDayName(date.DayOfWeek);

        //OUTPUT
        Console.WriteLine("\nDate in Bulgarian:\n{0} {1}, {2}\n", date.ToLongDateString(), date.ToLongTimeString(), day);
    }
}