//Write a method GetMax() with two parameters that returns the larger of two integers.
//Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().

using System;
class GetLargest
{
    static int GetLargestNum(int a, int b)
    {
        //if a = b => it makes no difference which number we are to print
        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter 3 integers to compare, each on a new line.");
        int result = GetLargestNum(GetLargestNum(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())),
            int.Parse(Console.ReadLine()));

        //OUTPUT
        Console.WriteLine("Largest number is:");
        Console.WriteLine(result);
    }
}