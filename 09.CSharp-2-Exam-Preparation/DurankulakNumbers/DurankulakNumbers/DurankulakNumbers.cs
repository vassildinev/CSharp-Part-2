using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
class DurankulakNumbers
{
    static string AddSpaces(string text, bool preserveAcronyms = false)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;
        StringBuilder newText = new StringBuilder(text.Length * 2);
        newText.Append(text[0]);
        for (int i = 1; i < text.Length; i++)
        {
            if (char.IsLower(text[i]))
                if ((text[i - 1] != ' ' && !char.IsLower(text[i - 1])) ||
                    (preserveAcronyms && char.IsLower(text[i - 1]) &&
                     i < text.Length - 1 && !char.IsLower(text[i + 1])))
                    newText.Append(' ');
            newText.Append(text[i]);
        }
        return newText.ToString();
    }
    static BigInteger Power(int baseNumber, int pow)
    {
        BigInteger result = 1;
        for (int i = 0; i < pow; i++)
        {
            result *= baseNumber;
        }
        return result;
    }
    static IEnumerable<string> ChunksUpTo(string str, int maxChunkSize)
    {
        for (int i = 0; i < str.Length; i += maxChunkSize)
            yield return str.Substring(i, Math.Min(maxChunkSize, str.Length - i));
    }
    static void Main()
    {
        //INPUT
        string input = Console.ReadLine();

        //SOLUTION

        #region Separate Digits as Strings
        int[] digitsValues;
        if (input.ToUpper() == input)
        {
            digitsValues = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                digitsValues[i] = input[i] - 'A';
            }

            goto CalculateResult;
        }

        input = AddSpaces(input, true);

        var digitsAsNestedLists = input
            .Split()
            .Select(x => ChunksUpTo(x, 2))
            .SelectMany(x => x)
            .ToList()
            .Select(x => x.Split().ToList())
            .ToList();

        for (int i = 0; i < digitsAsNestedLists.Count; i++)
        {
            if (digitsAsNestedLists[i][0] == digitsAsNestedLists[i][0].ToUpper())
            {
                digitsAsNestedLists[i] = digitsAsNestedLists[i]
                    .Select(x => ChunksUpTo(x, 1))
                    .SelectMany(x => x)
                    .ToList();
            }
        }

        var digitsAsStrings = digitsAsNestedLists.SelectMany(x => x).ToList();

        #endregion

        #region Digits as Numbers
        digitsValues = new int[digitsAsStrings.Count];

        for (int i = 0; i < digitsAsStrings.Count; i++)
        {
            if (digitsAsStrings[i].Length == 1)
            {
                digitsValues[i] = digitsAsStrings[i][0] - 'A';
            }
            else
            {
                digitsValues[i] = 26 * (digitsAsStrings[i][0] - 'a' + 1) + (digitsAsStrings[i][1] - 'A');
            }
        }
        #endregion

    CalculateResult:
        BigInteger result = 0;
        for (int i = 0; i < digitsValues.Length; i++)
        {
            result += digitsValues[i] * Power(168, digitsValues.Length - 1 - i);
        }

        //OUTPUT
        Console.WriteLine(result);
    }
}