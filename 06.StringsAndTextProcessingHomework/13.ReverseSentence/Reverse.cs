//Write a program that reverses the words in given sentence.

using System;
using System.Linq;
using System.Text;
class Reverse
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a string to reverse:");
        string text = Console.ReadLine();
        char mark = text[text.Length - 1];
        string[][] input = text.Remove(text.Length - 1, 1).Split(',').
            Select(x => x.TrimStart()).Select(x => x.Split(' ')).ToArray();

        //SOLUTION
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = input[i].Reverse().ToArray();
        }

        //OUTPUT
        Console.WriteLine();
        for (int i = 0; i < input.Length; i++)
        {
            Console.Write(string.Join(" ", input[input.Length -1 - i]));
            if (i != input.Length - 1)
                Console.Write(", ");
        }
        Console.WriteLine(mark);
    }
}