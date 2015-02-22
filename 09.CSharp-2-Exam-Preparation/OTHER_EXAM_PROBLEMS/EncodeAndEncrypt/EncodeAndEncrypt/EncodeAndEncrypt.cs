using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
class EncodeAndEncrypt
{
    static readonly Regex regExpr = new Regex(@"(\w)(\1){2,}", RegexOptions.Compiled);
    static void Main()
    {
        //INPUT
        string message = Console.ReadLine();
        string cypher = Console.ReadLine();

        //SOLUTION
        string encryptedMsg = Encrypt(message, cypher);
        string encodedLong = encryptedMsg + cypher + cypher.Length;
        string encodedMsg = regExpr.Replace(encodedLong, match => match.Length.ToString() + match.Value[0]);

        //OUTPUT
        Console.WriteLine(encodedMsg);
    }
    static string Encode(string message)
    {
        //3A4BCFF => AAABBBBCFF
        StringBuilder decodedMsg = new StringBuilder();

        StringBuilder count = new StringBuilder();

        int index = 0;
        while (index <= message.Length - count.Length)
        {
            while (index < message.Length && !char.IsDigit(message[index]))
            {
                decodedMsg.Append(message[index]);
                index++;
            }

            while (index < message.Length && char.IsDigit(message[index]))
            {
                count.Append(message[index]);
                index++;
            }

            if (count.Length != 0)
            {
                for (int i = 0; i < int.Parse(count.ToString()); i++)
                {
                    if (index < message.Length)
                    {
                        decodedMsg.Append(message[index]);
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
    static IEnumerable<string> Split(string str, int chunkLength)
    {
        for (int i = 0; i < str.Length; i += chunkLength)
            yield return str.Substring(i, Math.Min(chunkLength, str.Length - i));
    }
}