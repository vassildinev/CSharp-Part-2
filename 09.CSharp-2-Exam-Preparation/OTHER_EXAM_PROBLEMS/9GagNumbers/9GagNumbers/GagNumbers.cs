using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
class GagNumbers
{
    static string[] digits = { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };
    static void Main()
    {
        //INPUT
        string number = Console.ReadLine();

        //SOLUTION
        string baseNineNumber = ConvertTextToDigitsNumberSystems(number, digits);
        BigInteger result = Convert(baseNineNumber);

        //OUTPUT
        Console.WriteLine(result);
    }

    private static string ConvertTextToDigitsNumberSystems(string number, string[] digits)
    {
        string baseNineNumber = string.Empty;

        for (int i = 0; i < number.Length; i++)
        {
            for (int j = 0; j < digits.Length; j++)
            {
                string digit = digits[j];
                int digitLength = digit.Length;
                if (i + digitLength - 1 < number.Length)
                {
                    string substr = number.Substring(i, digitLength);
                    if (substr == digit)
                    {
                        baseNineNumber += j;
                        i += digitLength - 1;
                        break;
                    }
                }
            }
        }
        return baseNineNumber;
    }

    private static BigInteger Convert(string baseNineNumber)
    {
        BigInteger number = BigInteger.Parse(baseNineNumber);
        if (number == 0)
        {
            return 0;
        }
        BigInteger output = 0;
        int power = 0;
        while (number!=0)
        {
            int digit = (int)(number % 10);
            output += digit * Power(9, power);
            number /= 10;
            power++;
        }
        return output;
    }

    private static BigInteger Power(int p, int power)
    {
        BigInteger result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= p;
        }
        return result;
    }
}
