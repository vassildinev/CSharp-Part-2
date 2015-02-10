//Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
//Use variable number of arguments.

using System;
using System.Numerics;
using System.Linq;
class Calculations
{
    static void Min(params int[] numbers)
    {
        int min = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
                min = numbers[i];
        }
        Console.WriteLine("Min = {0}",min);
    }

    static void Max(params int[] numbers)
    {
        int max = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
                max = numbers[i];
        }
        Console.WriteLine("Max = {0}", max);
    }

    static void Average(params int[] numbers)
    {
        decimal avg = 0;
        for (int n = 0; n < numbers.Length; n++)
        {
            avg += numbers[n];
        }
        avg /= numbers.Length;
        Console.WriteLine("Avg = {0}", avg);
    }

    static void Sum(params int[] numbers)
    {
        long sum = 0;
        foreach (var num in numbers)
        {
            sum += num;
        }
        Console.WriteLine("Sum = {0}", sum);
    }

    static void Product(params int[] numbers)
    {
        BigInteger prod = 1;
        foreach (var num in numbers)
        {
            prod *= (BigInteger)num;
        }
        Console.WriteLine("Product = {0}", prod);
    }

    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a sequence of numbers on a single line separated by space:");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        //OUTPUT
        Console.WriteLine();

        Min(numbers);
        Max(numbers);
        Average(numbers);
        Sum(numbers);
        Product(numbers);

        //you can try 
        //Min(1, 2, 502, -3); 
        //it works for variable number of arguments
    }
}