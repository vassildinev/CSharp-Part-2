using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
class BasicLanguage
{
    static StringBuilder sb = new StringBuilder();
    static List<string> commands = new List<string>();
    static void Main()
    {
        ReadInput();
        ConvertInputToCommands();
        RunCommands();
        Console.Write(sb.ToString());
    }

    private static void RunCommands()
    {
        for (int i = 0; i < commands.Count; i++)
        {
            int loops = 1;
            string[] subcommands = commands[i].Split(new char[] { ')' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var command in subcommands)
            {
                string currentCommand = command.TrimStart();

                if (currentCommand.StartsWith("EXIT"))
                {
                    return;
                }
                else if (currentCommand.StartsWith("PRINT"))
                {
                    int parmsStart = currentCommand.IndexOf("(") + 1;
                    string content = currentCommand.Substring(parmsStart);
                    for (int j = 0; j < loops; j++)
                    {
                        sb.Append(content);
                    }
                }
                else if (currentCommand.StartsWith("FOR"))
                {
                    int parmsStart = currentCommand.IndexOf("(") + 1;
                    string allParams = currentCommand.Substring(parmsStart);
                    if (allParams.Contains(","))
                    {
                        string[] loopParams = allParams.Split(',');
                        int a = int.Parse(loopParams[0]);
                        int b = int.Parse(loopParams[1]);
                        loops = loops * (b - a + 1);
                    }
                    else
                    {
                        int value = int.Parse(allParams);
                        loops = loops * value;
                    }
                }
            }
        }
    }

    private static void ConvertInputToCommands()
    {
        string input = sb.ToString();
        sb.Clear();
        foreach (var symbol in input)
        {
            sb.Append(symbol);
            if (symbol == ';')
            {
                commands.Add(sb.ToString());
                sb.Clear();
            }
        }
    }

    private static void ReadInput()
    {
        sb.Clear();
        while (true)
        {
            string line = Console.ReadLine();
            sb.AppendLine(line);
            if (line.Contains("EXIT;"))
            {
                break;
            }
        }
    }
}