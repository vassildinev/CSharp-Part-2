using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class EnigmaCat
{
    static StringBuilder sb = new StringBuilder();
    static void Main()
    {
        //INPUT
        string[] catNumbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        //SOLUTION
        var results = new List<string>();

        foreach (string number in catNumbers)
        {
            ulong decimalNum = ConvertToDecimal(number);
            string result = ConvertTo26Base(decimalNum);
            results.Add(result);
        }

        //OUTPUT
        Console.WriteLine(string.Join(" ", results));
    }

    private static string ConvertTo26Base(ulong decimalNum)
    {
        ulong temp = decimalNum;
        if (temp == 0)
        {
            return "a";
        }
        while (temp != 0)
        {
            sb.Append((char)(temp % 26 + 'a'));
            temp /= 26;
        }
        string result = string.Join("", sb.ToString().Reverse()).Trim();
        sb.Clear();
        return result;
    }

    private static ulong ConvertToDecimal(string number)
    {
        ulong baseNum = 17;
        ulong result = 0;
        for (int i = number.Length - 1; i >= 0; i--)
        {
            ulong digit = (ulong)((ulong)(number[i] - 'a') % baseNum);
            result += (digit * Power(baseNum, number.Length - 1 - i));
        }
        return result;
    }

    static ulong Power(ulong number, int power)
    {
        ulong result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= number;
        }
        return result;
    }
}