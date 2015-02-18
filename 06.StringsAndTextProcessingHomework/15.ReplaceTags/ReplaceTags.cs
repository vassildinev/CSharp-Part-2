//Write a program that replaces in a HTML document 
//given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].

using System;
using System.Text;
class ReplaceTags
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter text to process:");
        string input = Console.ReadLine();

        //SOLUTION
        string openingTag = "<a href=";
        string closingTag = "</a>";

        string openingURL = "[URL=";
        string closingURL = "[/URL]";

        input = input.Replace(openingTag, openingURL);
        input = input.Replace(closingTag, closingURL);

        //OUTPUT
        Console.WriteLine("\nProcessed string:\n{0}\n", input);
    }
}
