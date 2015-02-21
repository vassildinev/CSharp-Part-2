using System;
using System.Linq;
using System.Text;
class MovingLetters
{
    static void Main()
    {
        //INPUT
        string[] words = Console.ReadLine().Split();

        //SOLUTION
        int longestWordLength = words[0].Length;
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > longestWordLength)
            {
                longestWordLength = words[i].Length;
            }
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < longestWordLength; i++)
        {
            foreach (string word in words)
            {
                if (word.Length - 1 - i >= 0)
                {
                    sb.Append(word[word.Length - 1 - i]);
                }
            }
        }

        var chars = sb.ToString().ToList();

        for (int i = 0; i < chars.Count; i++)
        {
            char currentChar = chars[i];
            int newIndex = (i + char.ToLower(currentChar) - 'a' + 1) % chars.Count;
            chars.Remove(currentChar);
            if (newIndex==chars.Count - 1)
            {
                chars.Add(currentChar);
            }
            chars.Insert(newIndex, currentChar);
        }

        sb.Clear();
        sb.Append(string.Join("", chars));

        //OUTPUT
        Console.WriteLine(sb.ToString());
    }
}