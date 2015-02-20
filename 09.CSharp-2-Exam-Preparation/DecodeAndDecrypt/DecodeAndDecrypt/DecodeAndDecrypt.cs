using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class DecodeAndDecrypt
{
    static void Main()
    {
        string input = Console.ReadLine();
        var digits = new List<int>();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            if (!char.IsDigit(input[i]))
            {
                break;
            }
            digits.Add(input[i] - '0');
        }

        digits.Reverse();

        int lengthOfCypher = 0;
        foreach (var digit in digits)
        {
            lengthOfCypher *= 10;
            lengthOfCypher += digit;
        }

        string encodedMsg = input.Substring(0, input.Length - digits.Count);

        string decodedMsg = Decode(encodedMsg);

        string cypher = decodedMsg.Substring(decodedMsg.Length - lengthOfCypher, lengthOfCypher);

        string encryptedMsg = decodedMsg.Substring(0, decodedMsg.Length - lengthOfCypher);

        string decryptedMsg = Encrypt(encryptedMsg, cypher);

        Console.WriteLine(decryptedMsg);
    }

    static string Decode(string encodedMsg)
    {
        //3A4BCFF => AAABBBBCFF
        StringBuilder decodedMsg = new StringBuilder();

        StringBuilder count = new StringBuilder();

        int index = 0;
        while (index <= encodedMsg.Length - count.Length)
        {
            while (index < encodedMsg.Length && !char.IsDigit(encodedMsg[index]))
            {
                decodedMsg.Append(encodedMsg[index]);
                index++;
            }

            while (index < encodedMsg.Length && char.IsDigit(encodedMsg[index]))
            {
                count.Append(encodedMsg[index]);
                index++;
            }

            if (count.Length != 0)
            {
                for (int i = 0; i < int.Parse(count.ToString()); i++)
                {
                    if (index < encodedMsg.Length)
                    {
                        decodedMsg.Append(encodedMsg[index]);
                    }
                }
            }
            count.Clear();
            index++;
        }
        return decodedMsg.ToString();
    }

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
                    else if (cyph.Length - 1 >= i && count!=1)
                    {
                        encryptedMsg[i] = (char)('A' + (char)((encryptedMsg[i] - 'A') ^ (cyph[i % cyph.Length] - 'A')));
                    }
                    count = 0;
                }
            }
        }

        return string.Join(string.Empty, encryptedMsg);
    }
    static IEnumerable<string> Split(string str, int chunkLength)
    {
        for (int i = 0; i < str.Length; i += chunkLength)
            yield return str.Substring(i, Math.Min(chunkLength, str.Length - i));
    }
}