using System;
using System.Text;
class Tags
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter text to process:");
        string input = Console.ReadLine();

        //SOLUTION
        string openingTag = "<upcase>";
        string closingTag = "</upcase>";
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            if (i < input.Length - closingTag.Length + 1)
            {
                string subString = input.Substring(i, openingTag.Length);
                if (subString != openingTag && subString != closingTag)
                {
                    sb.Append(input[i]);
                }
                else if (subString == openingTag)
                {
                    i += openingTag.Length;
                    for (int j = i; j < input.Length - closingTag.Length + 1; j++)
                    {
                        string newSubString = input.Substring(j, closingTag.Length);
                        if (newSubString == closingTag)
                        {
                            sb.Append(input.Substring(i, j - i).ToUpper());
                            i = j + closingTag.Length - 1;
                            break;
                        }
                    }
                }
            }
            else
            {
                sb.Append(input[i]);
            }
        }

        //OUTPUT
        Console.WriteLine("\nProcessed string:\n{0}\n",sb);
    }
}