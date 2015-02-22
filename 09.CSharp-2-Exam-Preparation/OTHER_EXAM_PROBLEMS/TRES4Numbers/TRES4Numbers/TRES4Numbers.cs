using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
class TRES4Numbers
{
    static string[] tres4Digits = {
                                      "LON+", "VK-","*ACAD", "^MIM","ERIK|", "SEY&", "EMY>>", "/TEL","<<DON" 
                                  };
    static void Main()
    {
        //INPUT
        BigInteger input = BigInteger.Parse(Console.ReadLine().Replace(" ", ""));

        //SOLUTION
        if (input==0)
        {
            Console.WriteLine(tres4Digits[0]);
            return;
        }

        var representation = new List<int>();
        while (input != 0)
        {
            var digit = input % 9;
            representation.Add((int)digit);
            input /= 9;
        }
        representation.Reverse();

        StringBuilder result = new StringBuilder();
        foreach (int digit in representation)
        {
            result.Append(tres4Digits[digit]);
        }

        //OUTPUT
        Console.WriteLine(result.ToString());
    }
}