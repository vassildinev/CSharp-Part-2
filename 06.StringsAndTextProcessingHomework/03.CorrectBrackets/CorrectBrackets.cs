//Write a program to check if in a given expression the brackets are put correctly.

using System;
using System.Collections.Generic;
class CorrectBrackets
{
    static List<char> brackets = new List<char> { '(', ')' };
    static List<string> SeparateBrackets(string input)
    {
        if (input.Length == 0)
        {
            Console.WriteLine("\nINCORRECT_INPUT\n");
            Environment.Exit(0);
        }
        var result = new List<string>();
        for (int i = 0; i < input.Length; i++)
        {
            if (brackets.Contains(input[i]))
            {
                result.Add(input[i].ToString());
            }
        }
        return result;
    }
    static void EvaluateBrackets(List<string> brackets)
    {
        Stack<string> stack = new Stack<string>();
        Queue<string> queue = new Queue<string>();
        for (int i = 0; i < brackets.Count; i++)
        {
            var currentBracket = brackets[i];
            if (currentBracket == "(")
            {
                stack.Push(currentBracket);
            }
            else if (currentBracket == ")")
            {
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    Console.WriteLine("\nINCORRECT_BRACKETS\n");
                    Environment.Exit(0);
                }
                while (stack.Count != 0 && stack.Peek() != "(")
                {
                    string currentOperator = stack.Pop();
                    queue.Enqueue(currentOperator);
                }
                stack.Pop();
            }
        }
        while (stack.Count != 0)
        {
            if (brackets.Contains(stack.Peek()))
            {
                Console.WriteLine("\nINCORRECT_BRACKETS\n");
                Environment.Exit(0);
            }
            queue.Enqueue(stack.Pop());
        }
        Console.WriteLine("\nCORRECT_BRACKETS\n");
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a string to investigate:");
        string input = Console.ReadLine();

        //SOLUTION AND OUTPUT
        EvaluateBrackets(SeparateBrackets(input));
    }
}