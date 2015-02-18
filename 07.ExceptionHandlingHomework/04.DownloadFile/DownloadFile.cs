//Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the current directory.
//Find in Google how to download files in C#.
//Be sure to catch all exceptions and to free any used resources in the finally block.

using System;
using System.Net;
class DownloadFile
{
    static void Main()
    {
        try
        {
            //SOLUTION
            string fileURL = "http://telerikacademy.com/Content/Images/news-img01.png";
            string fileName = "../../telerik_logo.jpg";

            WebClient webClient = new WebClient();

            //file will stored in .../bin/Debug
            webClient.DownloadFile(fileURL, fileName);
        }
        catch (WebException)
        {
            Console.WriteLine("The address is invalid.");
            return;
        }
        Console.WriteLine("File downloaded to project directory.");
    }
}