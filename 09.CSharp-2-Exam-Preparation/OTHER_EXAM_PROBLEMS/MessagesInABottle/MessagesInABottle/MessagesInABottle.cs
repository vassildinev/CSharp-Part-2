using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class MessagesInABottle
{
    static List<KeyValuePair<char, string>> cypherKeyValuePairs = new List<KeyValuePair<char, string>>();
    static SortedSet<string> allOriginalMessages = new SortedSet<string>();
    static StringBuilder currentOriginalMessage = new StringBuilder();
    static string message;
    static void Main()
    {
        //INPUT
        message = Console.ReadLine();
        string cypher = Console.ReadLine();

        //SOLUTION
        ExtractCypherToListOfKeyValuePairs(cypher);
        FindPossibleDecypheredMessages(0, new StringBuilder());

        //OUTPUT
        Console.WriteLine(allOriginalMessages.Count);
        foreach (var originalMessage in allOriginalMessages)
        {
            Console.WriteLine(originalMessage);
        }
    }

    private static void FindPossibleDecypheredMessages(int pointer, StringBuilder sb)
    {
        if (pointer == message.Length)
        {
            allOriginalMessages.Add(currentOriginalMessage.ToString());
            return;
        }
        foreach (var cypher in cypherKeyValuePairs)
        {
            if (message.Substring(pointer).StartsWith(cypher.Value))
            {
                currentOriginalMessage.Append(cypher.Key);
                FindPossibleDecypheredMessages(pointer + cypher.Value.Length, sb);
                currentOriginalMessage.Length--;
            }
        }
    }

    private static void ExtractCypherToListOfKeyValuePairs(string cypher)
    {
        char key = char.MinValue;
        StringBuilder value = new StringBuilder();
        for (int i = 0; i < cypher.Length; i++)
        {
            if (cypher[i] >= 'A' && cypher[i] <= 'Z')
            {
                if (key != char.MinValue)
                {
                    cypherKeyValuePairs.Add(new KeyValuePair<char, string>(key, value.ToString()));
                    value.Clear();
                }
                key = cypher[i];
            }
            else
            {
                value.Append(cypher[i]);
            }
        }

        // for last key value pair
        if (key != char.MinValue)
        {
            cypherKeyValuePairs.Add(new KeyValuePair<char, string>(key, value.ToString()));
            value.Clear();
        }
    }
}