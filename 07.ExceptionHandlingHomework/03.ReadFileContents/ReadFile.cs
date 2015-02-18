//Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console.
//Find in MSDN how to use System.IO.File.ReadAllText(…).
//Be sure to catch all possible exceptions and print user-friendly error messages.

using System;
using System.IO;
class ReadFile
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a full file path to read from:");
        string path = Console.ReadLine();

        //OUTPUT
        try
        {
            Console.WriteLine("\nContents:\n\n{0}\n", File.ReadAllText(path));
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("\nFILE_NOT_FOUND\n");
        }
    }
}