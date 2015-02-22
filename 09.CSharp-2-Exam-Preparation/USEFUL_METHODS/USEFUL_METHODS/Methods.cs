using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
class Methods
{
    static void Main()
    {
    }

    // calculates all subset sums from a set of signed integers
    static IEnumerable<int> CalculateSubsetSums(int[] numbers)
    {
        int offset = 10000;

        int[] possible = new int[offset + offset];

        int countOfNumbersInArray = numbers.Length;

        int minSum = numbers[0];
        int maxSum = numbers[0];

        for (int i = 0; i < countOfNumbersInArray; i++)
        {
            int newMinSum = minSum;
            int newMaxSum = maxSum;

            int[] newPossible = new int[offset + offset];
            for (int j = maxSum; j >= minSum; j--)
            {
                if (possible[j + offset] == 1)
                {
                    newPossible[j + numbers[i] + offset] = 1;
                }
                if (j + numbers[i] > newMaxSum)
                {
                    newMaxSum = j + numbers[i];
                }
                if (j + numbers[i] < newMinSum)
                {
                    newMinSum = j + numbers[i];
                }
            }
            minSum = newMinSum;
            maxSum = newMaxSum;
            for (int j = maxSum; j >= minSum; j--)
            {
                if (newPossible[j + offset] == 1)
                {
                    possible[j + offset] = 1;
                }
            }
            if (numbers[i] > maxSum)
            {
                maxSum = numbers[i];
            }
            if (numbers[i] < minSum)
            {
                minSum = numbers[i];
            }
            possible[numbers[i] + offset] = 1;
        }

        var listOfPossibleSums = new List<int>();
        for (int i = minSum; i <= maxSum; i++)
        {
            if (possible[i + offset] == 1)
            {
                listOfPossibleSums.Add(i);
            }
        }
        return listOfPossibleSums;
    }

    // splits a string into chunks of at leats a minimum length
    static IEnumerable<string> Split(string str, int chunkLength)
    {
        for (int i = 0; i < str.Length; i += chunkLength)
            yield return str.Substring(i, Math.Min(chunkLength, str.Length - i));
    }

    // encrypt/decrypt a message using a cypher, both of different lengths, with both cases covered
    static string Encrypt(string message, string cypher)
    {
        char[] encryptedMsg = new char[message.Length];

        if (message.Length >= cypher.Length)
        {
            for (int i = 0; i < message.Length; i++)
            {
                encryptedMsg[i] = (char)('A' + (char)((message[i] - 'A') ^ (cypher[i % cypher.Length] - 'A')));
            }
        }
        else
        {
            var cyphers = Split(cypher, message.Length);
            for (int i = 0; i < message.Length; i++)
            {
                int count = 1;
                foreach (var cyph in cyphers)
                {
                    if (cyph.Length - 1 >= i && count == 1)
                    {
                        encryptedMsg[i] = (char)('A' + (char)((message[i] - 'A') ^ (cyph[i % cyph.Length] - 'A')));
                    }
                    else if (cyph.Length - 1 >= i && count != 1)
                    {
                        encryptedMsg[i] = (char)('A' + (char)((encryptedMsg[i] - 'A') ^ (cyph[i % cyph.Length] - 'A')));
                    }
                    count = 0;
                }
            }
        }
        return string.Join(string.Empty, encryptedMsg);
    }

    // AAABCCCCD => 3AB4CD
    static string RemoveAndReplaceRepeatingLetters(string input)
    {
        var regExpression = new Regex(@"(\w)(\1){2,}", RegexOptions.Compiled);
        string output = regExpression.Replace(input, match => match.Length.ToString() + match.Value[0]);
        return output;
    }

    // 3AB4CD => AAABCCCCD
    static string ReplaceWithRepeatingLetters(string input)
    {
        //3A4BCFF => AAABBBBCFF
        StringBuilder output = new StringBuilder();

        StringBuilder count = new StringBuilder();

        int index = 0;
        while (index <= input.Length - count.Length)
        {
            while (index < input.Length && !char.IsDigit(input[index]))
            {
                output.Append(input[index]);
                index++;
            }

            while (index < input.Length && char.IsDigit(input[index]))
            {
                count.Append(input[index]);
                index++;
            }

            if (count.Length != 0)
            {
                for (int i = 0; i < int.Parse(count.ToString()); i++)
                {
                    if (index < input.Length)
                    {
                        output.Append(input[index]);
                    }
                }
            }
            count.Clear();
            index++;
        }
        return output.ToString();
    }

    // adds spaces before lowercase letters in a string
    //can be edited easily to operate with every occurrence
    //of a lowercase letter in the string
    static string AddSpacesBeforeSingleLowerCaseLetters(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;
        StringBuilder newText = new StringBuilder(text.Length * 2);
        newText.Append(text[0]);
        for (int i = 1; i < text.Length; i++)
        {
            if (char.IsLower(text[i]))
                if ((text[i - 1] != ' ' && !char.IsLower(text[i - 1])) ||
                    (char.IsLower(text[i - 1]) &&
                     i < text.Length - 1 && !char.IsLower(text[i + 1])))
                    newText.Append(' ');
            newText.Append(text[i]);
        }
        return newText.ToString();
    }

    // an alternative to Math.Pow();
    static long Power(int baseNumber, int pow)
    {
        long result = 1;
        for (int i = 0; i < pow; i++)
        {
            result *= baseNumber;
        }
        return result;
    }

    //return true
    static bool NextPermutation(char[] array)
    {
        for (int index = array.Length - 2; index >= 0; index--)
        {
            if (array[index] < array[index + 1])
            {
                int swapWithIndex = array.Length - 1;
                while (array[index] >= array[swapWithIndex])
                {
                    swapWithIndex--;
                }

                // Swap i-th and j-th elements
                var tmp = array[index];
                array[index] = array[swapWithIndex];
                array[swapWithIndex] = tmp;

                Array.Reverse(array, index + 1, array.Length - index - 1);
                return true;
            }
        }

        // No more permutations
        return false;
    }

    // ckecks if a string is Grisko Style
    static bool IsGrisko(char[] text)
    {
        for (int i = 1; i < text.Length; i++)
        {
            if (text[i] == text[i - 1])
            {
                return false;
            }
        }
        return true;
    }

    // counts Grisko words from a given set of characters
    private static int CountWords(char[] letters)
    {
        Array.Sort(letters);

        var count = 0;
        do
        {
            if (IsGrisko(letters))
            {
                count++;
            }
        }
        while (NextPermutation(letters));

        return count;
    }

    // replace multiple whitespaces using Regex
    static string ReplaceWhitespaces(string input)
    {
        string output = Regex.Replace(input, @"\s+", " ");
        return output;
    }

    // cyclic movement of an element in a sequence
    public static void Move(List<string> list, int currentIndex, int newIndex)
    {
        var item = list[currentIndex];
        list[currentIndex] = null;
        list.Insert(newIndex, item);
        list.Remove(null);
    }
}