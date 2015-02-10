//Write a program that can solve these tasks:
//  1.Reverses the digits of a number
//  2.Calculates the average of a sequence of integers
//  3.Solves a linear equation a * x + b = 0
//Create appropriate methods.
//Provide a simple text-based menu for the user to choose which task to solve.
//Validate the input data:
//  1.The decimal number should be non-negative
//  2.The sequence should not be empty
//  3.a should not be equal to 0

using System;
using System.Linq;
class SolveTasks
{
    static void ReverseDigits(long number)
    {
        if (number < 0)
        {
            Console.WriteLine("NOT_VALID!");
        }
        else
        {
            while (number % 10 == 0)
            {
                number /= 10;
            }
            Console.Write("Reversed number = ");
            while (number != 0)
            {
                Console.Write(number % 10);
                number /= 10;
            }
            Console.WriteLine();
        }
    }

    static void Average(long[] numbers)
    {
            long avg = 0;
            for (int n = 0; n < numbers.Length; n++)
            {
                avg += numbers[n];
            }
            avg /= numbers.Length;
            Console.WriteLine("AVG = {0}",avg);
    }

    static void LinearEquation(int[] parameters)
    {
        if(parameters[0]==0)
        {
            Console.WriteLine("NOT_VALID!");
        }
        else
        {
            decimal x = -parameters[1] / parameters[0];
            Console.WriteLine("x = {0}", x);
        }
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Please make a choice:\n");
        Console.WriteLine("1.Reverse the digits of a number.");
        Console.WriteLine("2.Calculate the average of a sequence of integers.");
        Console.WriteLine("3.Solve a linear equation a * x + b = 0.\n");

        int choice = int.Parse(Console.ReadLine());

        //OUTPUT
        switch (choice)
        {
            case 1:
                Console.WriteLine("\nEnter a number:");
                ReverseDigits(long.Parse(Console.ReadLine()));
                break;

            case 2:
                Console.WriteLine("\nEnter a sequence of numbers on a single line separated by space:");
                try
                {
                    Average(Console.ReadLine().Split(' ').Select(long.Parse).ToArray());
                }
                catch
                {
                    Console.WriteLine("NOT_VALID!");
                }
                break;

            case 3:
                Console.WriteLine("\nEnter coefficients a and b on a single line separated by space,\nwhere a*x+b=0:");
                LinearEquation(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
                break;

            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }
}