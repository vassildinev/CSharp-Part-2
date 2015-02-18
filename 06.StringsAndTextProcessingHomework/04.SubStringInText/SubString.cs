//Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).

using System;
class SubString
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter text:");
        string input = Console.ReadLine();

        Console.WriteLine("\nEnter string to search in the text:");
        string subString = Console.ReadLine();

        //SOLUTION
        int count = 0;
        for (int i = 0; i < input.Length - subString.Length + 1; i++)
        {
            string currentSubString = input.Substring(i, subString.Length);
            if (currentSubString==subString)
            {
                count++;
            }
        }

        //OUTPUT
        Console.WriteLine("\nNumber of times string was found in text:\n{0}", count);
    }
}