using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Crossword
{
    static string[] words;
    static HashSet<string> allWords = new HashSet<string>();
    static string[] crossword;
    static void Main()
    {
        //INPUT
        int crosswordSize = int.Parse(Console.ReadLine());
        words = new string[2 * crosswordSize];
        crossword = new string[crosswordSize];

        for (int i = 0; i < 2 * crosswordSize; i++)
        {
            words[i] = Console.ReadLine();
            allWords.Add(words[i]);
        }

        Array.Sort(words);

        //SOLITION AND OUTPUT
        int recursionBeginning = 0;

        Solver(recursionBeginning);

        Console.WriteLine("NO SOLUTION!");

    }
    static void Solver(int lineIndex)
    {
        // recursion bottom
        if (lineIndex >= crossword.Length)
        {
            if (IsCrossword())
            {
                PrintCrossword();
                Environment.Exit(0);
            }
            return;
        }

        // recursive call
        for (int i = 0; i < words.Length; i++)
        {
            crossword[lineIndex] = words[i];
            Solver(lineIndex + 1);
            //crossword[lineIndex] = null;
        }
    }

    static void PrintCrossword()
    {
        for (int row = 0; row < crossword.Length; row++)
        {
            Console.WriteLine(crossword[row]);
        }
    }

    static bool IsCrossword()
    {
        StringBuilder sb = new StringBuilder();
        for (int row = 0; row < crossword.Length; row++)
        {
            for (int col = 0; col < crossword.Length; col++)
            {
                sb.Append(crossword[col][row]);
            }
            if (!allWords.Contains(sb.ToString()))
            {
                return false;
            }
            sb.Clear();
        }
        return true;
    }
}
