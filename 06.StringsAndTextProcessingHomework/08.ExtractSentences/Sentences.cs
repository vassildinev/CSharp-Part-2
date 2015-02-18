//Write a program that extracts from a given text all sentences containing given word.

using System;
using System.Text.RegularExpressions;
class Sentences
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter text to process:");
        string[] sentences = Console.ReadLine().Replace(". ", ".").Split('.');

        Console.WriteLine("\nEnter keyword:");
        string keyWord = Console.ReadLine();

        //SOLUTION
        string[][] wordsInSentences = new string[sentences.Length][];
        for (int i = 0; i < sentences.Length; i++)
        {
            wordsInSentences[i] = Regex.Split(sentences[i], @"\W|_");
        }

        //OUTPUT
        Console.WriteLine("\nSentences containing keyword:\n");
        for (int row = 0; row < wordsInSentences.Length; row++)
        {
            for (int col = 0; col < wordsInSentences[row].Length; col++)
            {
                if(wordsInSentences[row][col]==keyWord)
                {
                    Console.WriteLine("{0}.", sentences[row]);
                    break;
                }
            }
        }
        Console.WriteLine();
    }
}
