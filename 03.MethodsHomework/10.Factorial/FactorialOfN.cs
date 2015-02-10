//Write a program to calculate n! for each n in the range [1..100].
//Hint: Implement first a method that multiplies a number represented as array of digits by given integer number.

//32 * 14 = 448
//   28
// +
//  42
//  448

using System;
using System.Numerics;
using System.Collections.Generic;
class FactorialOfN
{
    static BigInteger Multiplication(BigInteger number, BigInteger multiplier)
    {
        List<int> digitsNumber = new List<int>();
        while (number != 0)
        {
            digitsNumber.Add((int)(number % 10));
            number /= 10;
        }
        int[] digitsOfNumber = new int[digitsNumber.Count];

        digitsNumber.CopyTo(digitsOfNumber);

        List<BigInteger> result = new List<BigInteger>();
        BigInteger excess = 0;

        for (int i = 0; i < digitsNumber.Count; i++)
        {
            result.Add((int)((digitsOfNumber[i] * multiplier + excess) % 10));
            excess = (digitsOfNumber[i] * multiplier + excess) / 10;
        }


        if (excess > 0)
        {
            result.Add(excess);
        }

        result.Reverse(0, result.Count);

        BigInteger output = BigInteger.Parse(string.Join("", result));

        return output;
    }

    static BigInteger Factorial(BigInteger factorialBase)
    {
        BigInteger result = 1;
        for (int i = 1; i <= factorialBase; i++)
        {
            result = Multiplication(result, i);
        }
        return result;
    }
    static void Main()
    {
        //OUTPUT
        Console.WriteLine("Enter integer n:");
        Console.WriteLine("n! = {0}",Factorial(BigInteger.Parse(Console.ReadLine())));
    }
}