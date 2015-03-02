using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
class TwoIsBetterThanOne
{
    static bool ContainsOnlyThree(long number)
    {
        string input = number.ToString();
        if (Regex.Matches(input, "3").Count != input.Length)
        {
            return false;
        }
        return true;
    }

    static bool ContainsOnlyFive(long number)
    {
        string input = number.ToString();
        if (Regex.Matches(input, "5").Count != input.Length)
        {
            return false;
        }
        return true;
    }

    static bool ContainsFiveAndThree(long number)
    {
        string input = number.ToString();
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != '5')
            {
                if (input[i] != '3')
                {
                    return false;
                }
            }
        }
        return true;
    }

    static bool IsPalindrome(long number)
    {
        string input = number.ToString();
        string reversed = new string(input.Reverse().ToArray());
        if (input != reversed)
        {
            return false;
        }
        return true;
    }
    static void Main()
    {
        //INPUT

        // task 1
        long[] palindromeNums = Console.ReadLine()
            .Split()
            .Select(long.Parse)
            .ToArray();

        long a = palindromeNums[0];
        long b = palindromeNums[1];

        // task 2
        var sequence = Console
            .ReadLine()
            .Split(',')
            .Select(int.Parse)
            .ToList();

        int percentile = int.Parse(Console.ReadLine());


        //SOLUTION

        // task 1
        int count = 0;
        for (long i = a; i <= b; i++)
        {
            if (IsPalindrome(i))
            {
                if (ContainsFiveAndThree(i) || ContainsOnlyFive(i) && ContainsOnlyThree(i))
                    count++;
            }
        }

        // task 2
        sequence.Sort();
        long result = sequence[0];
        for (int i = 0; i < sequence.Count; i++)
        {
            decimal fraction = (decimal)(i + 1) / sequence.Count;
            if (fraction >= (decimal)percentile / 100)
            {
                result = sequence[i];
                break;
            }
        }

        //OUTPUT
        // task 1
        Console.WriteLine(count);

        // task 2
        Console.WriteLine(result);
    }
}
