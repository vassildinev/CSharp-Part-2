//Write a method that adds two positive integer numbers represented as arrays of digits 
//(each array element arr[i] contains a digit; the last digit is kept in arr[0]).
//Each of the numbers that will be added could have up to 10 000 digits.

using System;
using System.Collections.Generic;
class NumberArray
{
    static int AddNumbers(int a, int b)
    {
        List<int> digitsA = new List<int>();
        List<int> digitsB = new List<int>();
        while (a != 0)
        {
            digitsA.Add(a % 10);
            a /= 10;
        }
        while (b != 0)
        {
            digitsB.Add(b % 10);
            b /= 10;
        }

        //ensure both lists have the same number of digits
        while (digitsA.Count != digitsB.Count)
        {
            if (digitsA.Count > digitsB.Count)
            {
                for (int i = 0; i < digitsA.Count - digitsB.Count; i++)
                {
                    digitsB.Add(0);
                }
            }
            else
            {
                for (int i = 0; i < digitsB.Count - digitsA.Count; i++)
                {
                    digitsA.Add(0);
                }
            }
        }
        //copy lists to arrays - that is our task - to work with arrays
        int[] digitsOfNumberA = new int[digitsA.Count];
        int[] digitsOfNumberB = new int[digitsB.Count];

        digitsA.CopyTo(digitsOfNumberA);
        digitsB.CopyTo(digitsOfNumberB);

        int excess = 0;
        int[] sum = new int[digitsA.Count + 1];

        for (int i = 0; i < digitsA.Count; i++)
        {
            sum[digitsA.Count - i] = (digitsOfNumberA[i] + digitsOfNumberB[i] + excess) % 10;
            excess = (digitsOfNumberA[i] + digitsOfNumberB[i] + excess) / 10;
        }

        if (excess > 0)
        {
            sum[0] = excess;
        }

        int result = int.Parse(string.Join("",sum));

        return result;
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter two numbers to add, on separate lines:");
        int fnumber = int.Parse(Console.ReadLine());
        int snumber = int.Parse(Console.ReadLine());

        //OUTPUT
        Console.WriteLine();
        Console.WriteLine("Sum:");
        Console.WriteLine(AddNumbers(fnumber, snumber));
    }
}