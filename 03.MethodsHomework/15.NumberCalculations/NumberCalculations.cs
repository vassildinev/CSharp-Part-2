//Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.)
//Use generic method (read in Internet about generic methods in C#).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
class NumberCalculations
{
    static void Min(params decimal[] numbers)
    {
        decimal min = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
                min = numbers[i];
        }
        Console.WriteLine("Min = {0}", min);
    }

    static void Max(params decimal[] numbers)
    {
        decimal max = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
                max = numbers[i];
        }
        Console.WriteLine("Max = {0}", max);
    }

    static void Average(params decimal[] numbers)
    {
        decimal avg = 0;
        for (int n = 0; n < numbers.Length; n++)
        {
            avg += numbers[n];
        }
        avg /= numbers.Length;
        Console.WriteLine("Avg = {0}", avg);
    }

    static void Sum(params decimal[] numbers)
    {
        decimal sum = 0;
        foreach (var num in numbers)
        {
            sum += num;
        }
        Console.WriteLine("Sum = {0}", sum);
    }

    static void Product(params decimal[] numbers)
    {
        decimal prod = 1;
        foreach (var num in numbers)
        {
            prod *= num;
        }
        Console.WriteLine("Product = {0}", prod);
    }

    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a sequence of numbers on a single line separated by space:");
        decimal[] numbers = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

        //OUTPUT
        Console.WriteLine();

        Min(numbers);
        Max(numbers);
        Average(numbers);
        Sum(numbers);
        Product(numbers);

        //you can try 
        //Min(1M, 2M, 502M, -3.14M); 
        //all methods work for variable number of arguments
    }
}