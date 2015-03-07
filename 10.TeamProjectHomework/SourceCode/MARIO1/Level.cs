using System;
using System.IO;
using System.Threading;
class Level
{
    public const int levelHeight = 29;
    public static int levelCounter = 1;
    string levelPath = string.Format(@"..\..\Levels\level_{0}.txt", levelCounter);
    string[] level = new string[levelHeight];
    public Level()
    {
        try
        {
            using (StreamReader reader = new StreamReader(levelPath))
            {
                for (int i = 0; i < levelHeight; i++)
                {
                    level[i] = reader.ReadLine();
                }
            }
        }
        catch
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("File missing, unreadable or corrupt");
            Environment.Exit(1);
        }
        
    }
    public char this[int row, int col]
    {
        get
        {
                
                return level[row][col];

        }
    }

    public int this[int row]
    {
        get
        {
            return level[row].Length;
        }
    }

    public int Height
    {
        get 
        {
            return level.Length;
        }
    }

    public void Print()
    {
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        foreach (string row in level)
        {
            Console.WriteLine(row);
        }
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}
