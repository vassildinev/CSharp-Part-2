//Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm.

using System;
using System.Collections.Generic;
using System.Linq;
class PrimeNumbers
{
    static void Main()
    {
        //ATTENTION: PLEASE WAIT FOR THE PROGRAM TO FINISH, IT TAKES ABOUT 80 SECONDS :D
        //BUT IT WORKS!!!

        //SOLUTION
        int[] numbers = Enumerable.Range(1, 10000000).ToArray();
        for (int i = 1; i <= Math.Sqrt(numbers.Length); i++)
        {
            int sieve;
            if (numbers[i] != -1)
            {
                sieve = numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] % sieve == 0)
                    {
                        numbers[j] = -1;
                    }
                }
            }
        }

        //OUTPUT
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] != -1)
            {
                Console.WriteLine(numbers[i] + " ");
            }
        }
    }
}
