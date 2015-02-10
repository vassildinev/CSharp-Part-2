//Write a method that reverses the digits of given decimal number.

using System;
class Reverse
{
    static int ReverseNumber(int number)
    {
        string num = number.ToString();
        string reversedNum = "";
        for (int i = 0; i < num.Length; i++)
        {
            reversedNum += num[num.Length - 1 - i];
        }
        int reversedNumber = int.Parse(reversedNum);
        return reversedNumber;
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Number to reverse:");
        int number = int.Parse(Console.ReadLine());

        //OUTPUT
        Console.WriteLine("\nReversed:");
        Console.WriteLine(ReverseNumber(number));
    }
}