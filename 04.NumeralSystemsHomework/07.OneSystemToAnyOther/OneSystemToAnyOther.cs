//Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤ 16).

using System;
using System.Numerics;
class OneSystemToAnyOther
{
    static BigInteger Power(BigInteger numBase, BigInteger pow)
    {
        BigInteger result = 1;
        for (int i = 0; i < pow; i++)
        {
            result *= numBase;
        }
        return result;
    }
    static string ToAnySystem(string number, int firstSystem, int secondSystem)
    {
        string[] digits = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
        BigInteger decNumber = 0;
        for (int i = 0; i < number.Length; i++)
        {
            decNumber += Array.IndexOf(digits,number[number.Length - 1 - i].ToString()) * Power(firstSystem, i);
        }
        string reversedResult = "";
        while (decNumber != 0)
        {
            reversedResult += digits[(int)(decNumber % secondSystem)];
            decNumber /= secondSystem;
        }
        char[] resultToArray = reversedResult.ToCharArray();
        Array.Reverse(resultToArray);

        string result = new string(resultToArray);

        return result;
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a base for a numeral system to convert from (>= 2 && <= 16)");
        int baseConvertFrom = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter number in a numeral system with base {0}:", baseConvertFrom);
        string number = Console.ReadLine();

        Console.WriteLine("Enter a base for a numeral system to convert to (>= 2 && <= 16)");
        int baseConvertTo = int.Parse(Console.ReadLine());

        //OUTPUT
        Console.WriteLine("{0} in numeral system with base {1} is\n{2} in numeral system with base {3}",
            number,baseConvertFrom,ToAnySystem(number,baseConvertFrom, baseConvertTo),baseConvertTo);
    }
}