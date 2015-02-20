using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class Brackets
{
    static StringBuilder result = new StringBuilder();
    static string tab;
    static int count = 0;
    static string tabulation;
    static int maxCount = 0;
    static void Main()
    {
        //INPUT
        int numberOfLinesOfCode = int.Parse(Console.ReadLine());

        tab = Console.ReadLine();

        //SOLUTION

        //process each line
        for (int i = 0; i < numberOfLinesOfCode; i++)
        {
            string line = Console.ReadLine();
            ProcessLine(ref line);
        }

        //remove all empty lines in the result
        while (result.ToString().Contains("\n\n"))
        {
            result.Replace("\n\n", "\n");
        }

        //remove all lines containing only tabulations
        for (int i = maxCount; i >= 1; i--)
        {
            tabulation = string.Concat(Enumerable.Repeat(tab, i));
            while (result.ToString().Contains("\n" + tabulation + "\n"))
            {
                result.Replace("\n" + tabulation + "\n", "\n");
            }
        }

        //OUTPUT

        //trim just in case
        Console.WriteLine(result.ToString().Trim());
    }

    private static void ProcessLine(ref string line)
    {
        //replace all multiple whitespaces with a single one
        line = Regex.Replace(line, @"\s+", " ");

        //trim the line of code on both sides
        line = line.Trim();

        for (int i = 0; i < line.Length; i++)
        {
            char currentChar = line[i];
            char nextChar = '@';
            char previousChar = '@';


            //handle constraints for next character
            if (i < line.Length - 1)
            {
                nextChar = line[i + 1];
            }

            //handle constraints for previous character
            if (i > 0)
            {
                previousChar = line[i - 1];
            }

            if (currentChar != '{' && currentChar != '}')
            {
                //if the current character is a whitespace and before or after it there is a bracket, do not add it to the result
                if ((currentChar == ' ' && (nextChar == '{' || nextChar == '}')) || ((previousChar == '{' || previousChar == '}') && currentChar == ' '))
                {

                }

                //else add the current character to the result
                else
                {
                    //add tabulation only before the first symbol of the current line
                    if (i == 0)
                    {
                        tabulation = string.Concat(Enumerable.Repeat(tab, count));
                        result.Append(tabulation);
                    }
                    result.Append(currentChar);
                }
            }

            //if the current character is a bracket, go on a new line, write current tabulation,
            //write the bracket, go on a new line, write the new tabulation
            else if (currentChar == '{' || currentChar == '}')
            {
                if (currentChar == '{')
                {
                    result.Append("\n");
                    tabulation = string.Concat(Enumerable.Repeat(tab, count));
                    result.Append(tabulation);
                    count++;
                    if (maxCount < count)
                    {
                        maxCount = count;
                    }
                }
                else if (currentChar == '}')
                {
                    count--;
                    result.Append("\n");
                    tabulation = string.Concat(Enumerable.Repeat(tab, count));
                    result.Append(tabulation);
                }
                result.Append(currentChar + "\n");
                tabulation = string.Concat(Enumerable.Repeat(tab, count));
                result.Append(tabulation);

            }
        }

        //prepare the next line
        result.Append("\n");
    }
}