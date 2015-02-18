//Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the current directory.
//Find in Google how to download files in C#.
//Be sure to catch all exceptions and to free any used resources in the finally block.

using System;
using System.Net;
class DownloadFile
{
    static void Main()
    {
        WebClient webClient = new WebClient();

        try
        {
            //SOLUTION
            string fileURL = "http://telerikacademy.com/Content/Images/news-img01.png";
            string fileName = "../../telerik_logo.jpg";

            //file will stored in .../bin/Debug
            webClient.DownloadFile(fileURL, fileName);
        }
        catch (WebException)
        {
            Console.WriteLine("The address is invalid.");
            return;
        }
        finally
        {
            webClient.Dispose();
        }
        Console.WriteLine("File downloaded to project directory.");
    }
}