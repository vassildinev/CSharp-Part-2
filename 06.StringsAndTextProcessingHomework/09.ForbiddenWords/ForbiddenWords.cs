//We are given a string containing a list of forbidden words and a text containing some of these words.
//Write a program that replaces the forbidden words with asterisks.

using System;
class ForbiddenWords
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        Console.WriteLine("\nEnter words on a single line separated by space to replace in the text:");
        string[] wordsToReplace = Console.ReadLine().Split(' ');

        //SOLUTION
        foreach (string word in wordsToReplace)
        {
            if(text.Contains(word))
            {
                text = text.Replace(word, new string('*', word.Length));
            }
        }

        //OUTPUT
        Console.WriteLine("\nText after processing:\n{0}\n", text);
    }
}