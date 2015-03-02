using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
class CaspichanNumbers
{
    static List<int> ConvertToOther(BigInteger number, int baseNumber)
    {
        BigInteger  workNumber = number;
        var result = new List<int>();
        while (workNumber != 0)
        {
            result.Add((int)(workNumber % baseNumber));
            workNumber /= baseNumber;
        }

        if (number==0)
        {
            return new List<int>() { 0 };
        }
        return result;
    }
    static void Main()
    {
        //INPUT
        int baseNumber = 256;
        BigInteger input = BigInteger.Parse(Console.ReadLine());

        //SOLUTION
        StringBuilder sb = new StringBuilder();

        var number = ConvertToOther(input, baseNumber);
        for (int i = 0; i < number.Count;i++ )
        {
            int digit = number[i];
            if (digit < 26)
            {
                sb.Append((char)(digit + 'A'));
            }
            else
            {
                int smallDigit = digit % 26;
                int bigDigit = digit / 26;
                sb.Append((char)(smallDigit + 'A'));
                sb.Append((char)(bigDigit + 'a' - 1));
            }
        }

        string result = new string(sb.ToString().Reverse().ToArray());
        Console.WriteLine(result);
    }
}
