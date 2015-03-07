using System;
using System.IO;
using System.Threading;
/// <summary>
/// The Menu class encompasses the basic menu functionality for the game.
/// </summary>
static class Menu
{
    // FIELDS

    private static string menuPath = @"..\..\Menu\Menu.txt"; // holds the path to the file in which the format of the menu is kept
    private static string[] menu = new string[menuOptionsCount]; // the menu will be loaded as a string array
    private static int highlightedLine; // the line of the menu which is currently selected
    private const int menuX = 40; // the X axis of the start of the menu
    private const int menuY = 10; // the Y axis of the start of the menu
    private const int menuOptionsCount = 4; // the count of options currently in the menu

    // CONSTRUCTOR

    static Menu()
    {
        highlightedLine = 0;
        Engine.GameIsOn = false;

        using (StreamReader reader = new StreamReader(menuPath))
        {
            for (int i = 0; i < menuOptionsCount; i++)
            {
                menu[i] = reader.ReadLine();
            }
        }
    }

    // METHODS

    /// <summary>
    /// Sets the console background color to black, clears the console and prints the menu.
    /// </summary>
    public static void PrintMenu()
    {
        // set console
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;

        // print the lines of the menu
        for (int i = 0; i < menuOptionsCount; i++)
        {
            Console.SetCursorPosition(menuX, menuY + i * 3); // that lame formatting thou!

            if (highlightedLine == i) // if the line is currently selected by the user
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(menu[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.WriteLine(menu[i]);
            }
        }

    }

    /// <summary>
    /// Executes the line of the menu selected by the user and return TRUE if you can continue a game.
    /// </summary>
    /// <returns></returns>
    private static bool ExecuteSelectedOption()
    {
        switch (highlightedLine)
        {
            case 0:
                return Engine.GameIsOn; // if there is a game started, tell the engine to resume(CONTINUE)

            case 1:
                if (!Engine.GameIsOn) // if no game has been started, start one(NEWGAME)
                {
                    Engine.Run();
                    Engine.GameIsOn = true;
                }
                else // if a game has been started, tell the engine to discard the last game and start a new one
                {
                    Engine.GameIsOn = false;
                }
                break;

            case 2:
                Console.Clear();
                Console.WriteLine(HighScore.PrintPoints_WithPosition()); // print the highscores(WALL OF SHAME)
                Console.ReadKey(true);
                break;

            case 3: Environment.Exit(0); // exit with code 0(EXIT)
                break;

            default: throw new ArgumentException(); // if the highlightedLine equals none of the above, throw an exception

        }

        return false; // if no game is to be continued, tell the engine not to continue
    }

    /// <summary>
    /// Displays the user menu.
    /// </summary>
    public static void Display()
    {
        // set up keys
        ConsoleKeyInfo keyPressed;
        Console.CursorVisible = false;

        while (true)
        {
            PrintMenu();

            keyPressed = Engine.ki;

            if (Console.KeyAvailable)
                keyPressed = Engine.GetKeyInfo();

            switch (keyPressed.Key)
            {
                    // manage selection of the menu line
                case ConsoleKey.UpArrow:
                    highlightedLine--;
                    if (highlightedLine == -1)
                    {
                        highlightedLine = menuOptionsCount - 1;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    highlightedLine++;
                    if (highlightedLine == menuOptionsCount)
                    {
                        highlightedLine = 0;
                    }
                    break;

                    // execute a line
                case ConsoleKey.Enter:
                    if (ExecuteSelectedOption())
                    {
                        return;
                    }
                    break;

                default: // if no valid command, just break
                    break;

            }

            Thread.Sleep(70);
        }

    }

}

