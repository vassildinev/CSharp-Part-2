using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FTML
{
    static StringBuilder sb = new StringBuilder();
    static void Main()
    {
        //INPUT
        int numberOfLines = int.Parse(Console.ReadLine());
        string input = string.Empty;

        for (int i = 0; i < numberOfLines; i++)
        {
            sb.AppendLine(Console.ReadLine());
        }

        input = sb.ToString();
        sb.Clear();

        //SOLUTION
        int closingTagOpenIndex = input.IndexOf("</");
        int closingTagCloseIndex = input.IndexOf(">", closingTagOpenIndex);

        int openingTagCloseIndex = input.LastIndexOf(">", closingTagOpenIndex);
        int openingTagOpenIndex = input.LastIndexOf("<", openingTagCloseIndex);

        while (true)
        {
            string content = input.Substring(openingTagCloseIndex + 1, closingTagOpenIndex - openingTagCloseIndex - 1);
            string tag = input.Substring(openingTagOpenIndex + 1, openingTagCloseIndex - openingTagOpenIndex - 1);

            switch (tag)
            {
                case "upper":
                    content = content.ToUpper();
                    break;
                case "lower":
                    content = content.ToLower();
                    break;
                case "toggle":
                    content = Toggle(content);
                    break;
                case "del":
                    content = "";
                    break;
                case "rev":
                    content = Reverse(content);
                    break;
            }

            string finishedTag = input.Substring(openingTagOpenIndex, closingTagCloseIndex - openingTagOpenIndex + 1);
            input = input.Replace(finishedTag, content);

            closingTagOpenIndex = input.IndexOf("</");

            if (closingTagOpenIndex == -1)
            {
                break;
            }

            closingTagCloseIndex = input.IndexOf(">", closingTagOpenIndex);

            openingTagCloseIndex = input.LastIndexOf(">", closingTagOpenIndex);
            openingTagOpenIndex = input.LastIndexOf("<", openingTagCloseIndex);
        }

        //OUTPUT
        input = input
            .Replace("\r", "")
            .Trim();

        Console.WriteLine(input);
    }

    static string Reverse(string input)
    {
        string output = string.Empty;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            sb.Append(input[i]);
        }

        output = sb.ToString();
        sb.Clear();

        return output;
    }

    static string Toggle(string input)
    {
        string output = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];
            if (char.IsUpper(currentChar))
            {
                sb.Append(Char.ToLower(currentChar));
            }
            else
            {
                sb.Append(Char.ToUpper(currentChar));
            }
        }

        output = sb.ToString();
        sb.Clear();

        return output;
    }
}