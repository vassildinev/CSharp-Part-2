//Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
class ExtractText
{
    static Regex htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);
    static string HtmlStripTags(string source)
    {
        return htmlRegex.Replace(source, " ");
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Input html text: ");
        StringBuilder sb = new StringBuilder();
        string input = Console.ReadLine();
        while (input != "</html>")
        {
            sb.Append(input);
            input = Console.ReadLine();
        }
        sb.Replace("  ", " ");

        //SOLUTION
        input = sb.ToString();

        //extract title
        int startPosHead = input.IndexOf("<title>") + "<title>".Length;
        int endPosHead = input.IndexOf("</title>");
        string title = input.Substring(startPosHead, endPosHead - startPosHead);
        title = HtmlStripTags(title);
        title = title.Trim();
        title = title.Replace("  ", " ");

        //extract body
        int startPosBody = input.IndexOf("<body>") + "<body>".Length;
        int endPosBody = input.IndexOf("</body>");
        string body = input.Substring(startPosBody, endPosBody - startPosBody);
        body = HtmlStripTags(body);
        body = body.Trim();
        body = body.Replace("  ", " ");

        //OUTPUT
        Console.WriteLine("\nTitle: {0}\n", title);
        Console.WriteLine("Body: {0}\n", body);
    }
}
