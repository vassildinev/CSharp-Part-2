using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
class PHPVariables
{
    static void Main()
    {
        //INPUT
        string input = ReadInput();

        //SOLUTION
        var result = ExtractVars(input);
        var count = result.Count;

        //OUTPUT
        Console.WriteLine(count);
        foreach (var variable in result)
        {
            Console.WriteLine(variable);
        }
    }

    static string ReadInput()
    {
        StringBuilder phpCode = new StringBuilder();

        string line = Console.ReadLine().Trim();
        while (line != "?>")
        {
            phpCode.AppendLine(line);
            line = Console.ReadLine().Trim();
        }

        string phpCodeToString = phpCode.ToString();
        return phpCodeToString;
    }

    static HashSet<string> ExtractVars(string inputLine)
    {
        HashSet<string> vars = new HashSet<string>();

        bool oneLineComment = false;
        bool multiLineComment = false;
        bool inSingleQuoteString = false;
        bool inDoubleQuoteString = false;
        bool inVariable = false;

        StringBuilder currentVar = new StringBuilder();

        for (int i = 0; i < inputLine.Length; i++)
        {
            char currentChar = inputLine[i];

            //1-line comment
            if (oneLineComment)
            {
                if (currentChar == '\n')
                {
                    oneLineComment = false;
                    continue;
                }
                else
                {
                    continue;
                }
            }

            //multi-line comment
            if (multiLineComment)
            {
                if (currentChar == '*'
                    && i + 1 < inputLine.Length
                    && inputLine[i + 1] == '/')
                {
                    multiLineComment = false;
                    i++;
                    continue;
                }
                else
                {
                    continue;
                }
            }

            //in var
            if (inVariable)
            {
                if (isValidVariableSymbol(currentChar))
                {
                    currentVar.Append(currentChar);
                    continue;
                }
                else
                {
                    if (currentVar.Length > 0)
                    {
                        vars.Add(currentVar.ToString());
                    }
                    currentVar.Clear();
                    inVariable = false;
                }
            }

            // in single-quote
            if (inSingleQuoteString)
            {
                if (currentChar == '\'')
                {
                    inSingleQuoteString = false;
                    continue;
                }
            }

            // in double-quote
            if (inDoubleQuoteString)
            {
                if (currentChar == '"')
                {
                    inDoubleQuoteString = false;
                    continue;
                }
            }

            // not in a string
            if (!inSingleQuoteString && !inDoubleQuoteString)
            {
                if (currentChar == '#')
                {
                    oneLineComment = true;
                    continue;
                }

                //start one-line comment
                if (currentChar == '/'
                    && i + 1 < inputLine.Length
                    && inputLine[i + 1] == '/')
                {
                    oneLineComment = true;
                    i++;
                    continue;
                }

                //start multiline comment
                if (currentChar == '/'
                    && i + 1 < inputLine.Length
                    && inputLine[i + 1] == '*')
                {
                    multiLineComment = true;
                    i++;
                    continue;
                }
            }
            else
            {
                // in string => escaping next char => skip next char
                if (currentChar == '\\')
                {
                    i++;
                    continue;
                }
            }

            //start a single-quote
            if (currentChar == '\'')
            {
                inSingleQuoteString = true;
                continue;
            }
            //start a double-quote
            if (currentChar == '"')
            {
                inDoubleQuoteString = true;
                continue;
            }

            //if we reached down here => may be in a variable
            if (currentChar == '$')
            {
                inVariable = true;
                continue;
            }
        }
        return vars;
    }

    static bool isValidVariableSymbol(char symbol)
    {
        if (char.IsLetterOrDigit(symbol) || symbol == '_')
        {
            return true;
        }
        return false;
    }
}
