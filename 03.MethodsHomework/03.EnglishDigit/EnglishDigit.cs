//Write a method that returns the last digit of given integer as an English word.

using System;
class EnglishDigit
{
    static string DigitAsWord(int number)
    {
        int lastDigit = number % 10;
        switch (lastDigit)
        {
            case 0: return "zero"; break;
            case 1: return "one"; break;
            case 2: return "two"; break;
            case 3: return "three"; break;
            case 4: return "four"; break;
            case 5: return "five"; break;
            case 6: return "six"; break;
            case 7: return "seven"; break;
            case 8: return "eight"; break;
            case 9: return "nine"; break;
            default: return ""; break;
        }
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter integer number:");
        int number = int.Parse(Console.ReadLine());

        //OUTPUT
        Console.WriteLine("Last digit as word:");
        Console.WriteLine(DigitAsWord(number));
    }
}