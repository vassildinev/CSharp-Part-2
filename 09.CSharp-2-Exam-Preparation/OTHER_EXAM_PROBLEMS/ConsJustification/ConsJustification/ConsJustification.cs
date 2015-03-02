using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class ConsJustification
{
    static void Main()
    {
        //INPUT
        int numberOfLines = int.Parse(Console.ReadLine());
        int width = int.Parse(Console.ReadLine());

        var words = new List<string>();
        for (int i = 0; i < numberOfLines; i++)
        {
            var lineWords = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in lineWords)
            {
                words.Add(word);
            }
        }

        //SOLUTION
        StringBuilder result = new StringBuilder();
        StringBuilder currentLine = new StringBuilder();
        string line = "";
        int spacesToAdd = 0;
        int gapsCount = 0;

        for (int i = 0; i < words.Count; i++)
        {
            if (currentLine.Length + words[i].Length <= width)
            {
                currentLine.Append(words[i] + " ");
            }
            else
            {
                i--;
                line = currentLine.ToString().Trim();

                spacesToAdd = width - line.Length;
                gapsCount = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count() - 1;
                if (gapsCount == 0)
                {
                    result.AppendLine(line);
                    currentLine.Clear();
                    continue;
                }

                if (spacesToAdd == gapsCount)
                {
                    line = line.Replace(" ", "  ");
                }
                else
                {
                    int indexToAdd = line.IndexOf(" ");
                    while (true)
                    {
                        int spaces = (int)Math.Ceiling((double)spacesToAdd / gapsCount);
                        line = line.Insert(indexToAdd, new string(' ', spaces));

                        spacesToAdd -= spaces;
                        if (spacesToAdd == 0)
                        {
                            break;
                        }
                        indexToAdd = line.IndexOf(" ", indexToAdd + spaces + 1);
                        gapsCount--;
                    }
                }
                result.AppendLine(line);
                currentLine.Clear();
            }
        }
        line = currentLine.ToString().Trim();
        spacesToAdd = width - line.Length;
        gapsCount = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count() - 1;
        if (gapsCount == 0)
        {
            result.Append(line);
            Console.WriteLine(result.ToString());
            return;
        }
        if (spacesToAdd == gapsCount)
        {
            line = line.Replace(" ", "  ");
        }
        else
        {
            int indexToAdd = line.IndexOf(" ");
            while (true)
            {
                int spaces = (int)Math.Ceiling((double)spacesToAdd / gapsCount);
                line = line.Insert(indexToAdd, new string(' ', spaces));

                spacesToAdd -= spaces;
                if (spacesToAdd == 0)
                {
                    break;
                }
                indexToAdd = line.IndexOf(" ", indexToAdd + spaces + 1);
                gapsCount--;
            }
        }
        result.Append(line);

        //OUTPUT
        Console.WriteLine(result.ToString());
    }
}