using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Text;


class Engine
{
    // FIELDS

    public static Level level;
    public static ConsoleKeyInfo ki = new ConsoleKeyInfo();
    public static bool GameIsOn;
    private static int scoreCount = 0;

    // Prepares playfield width and height
    public static void SetConsole(int height, int width)
    {
        Console.Title = "Super Shapkario";
        Console.WindowHeight = height;
        Console.WindowWidth = width;
        Console.CursorVisible = false;
        Console.BufferHeight = height;
        Console.BufferWidth = width;
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.OutputEncoding = Encoding.Unicode;

    }

    public static void GameOver()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Clear();

        Engine.GameIsOn = false;
        Level.levelCounter = 1;

        Random rnd = new Random();
        for (int i = 0; i < 60; i++)
        {
            Console.SetCursorPosition(rnd.Next(2, 100), rnd.Next(2, 28));
            Console.WriteLine("GAME OVER");
            Thread.Sleep(100);
        }

        Thread.Sleep(3000);
        Console.Clear();

        HighScore.Add(scoreCount, null);

    }

    public static ConsoleKeyInfo GetKeyInfo()
    {
        ConsoleKeyInfo keyPressed;

        if (Console.KeyAvailable)
        {
            // reading the keys
            keyPressed = Console.ReadKey(true);

            // flushing the key input stream
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            return keyPressed;

        }
        else
        {
            return ki;
        }

    }

    public static Size GetSize(string size)
    {
        switch (size)
        {
            case "BIG": return Size.BIG;
            case "BOSS": return Size.BOSS;
            case "SMALL": return Size.SMALL;
            default: throw new ArgumentException();
                
        }
    }

    public static List<Enemy> GenerateEnemies()
    {
        List<Enemy> enemyList = new List<Enemy>();
        string enemiesPath = string.Format(@"..\..\Enemies\enemies.txt");


        using (StreamReader reader = new StreamReader(enemiesPath))
        {
            string line = reader.ReadLine();

            while (!string.IsNullOrEmpty(line))
            {


                string[] EnemyArray = line.Split(',');

                enemyList.Add(new Enemy(EnemyArray[0] == "true",
                                        int.Parse(EnemyArray[1]),
                                        int.Parse(EnemyArray[2]),
                                        GetSize(EnemyArray[3]),
                                        int.Parse(EnemyArray[4]),
                                        int.Parse(EnemyArray[5])));

                line = reader.ReadLine();
            }
        }
        return enemyList;
    }

    // Game logic

    public static void Run()
    {
        level = new Level();
        
        SetConsole(30, 120);

        //Load level
        level.Print();

        Mario NinjaMario = new Mario(5, 5);
        NinjaMario.Print();

        var enemies = GenerateEnemies();

        int counter = 0;

        Jukebox jk = new Jukebox(@"..\..\Music\Super_Mario_Bros_Official_Theme_Song.wav");
        jk.Play();

        // Game Flow
        while (true)
        {

            ConsoleKeyInfo keyPressed = GetKeyInfo();

            // clear the enemies
            if (counter % 2 == 0)
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].levelPosition == Level.levelCounter)
                    {
                        enemies[i].Clear();
                    }
                        
                }

            // clear mario
            NinjaMario.Clear();

            // handle jumping
            if (NinjaMario.isJumping)
            {
                // if left or right arrow has been pressed after jumping, modify the arc of the jump accordingly

                if ((NinjaMario.lastJumpKey == ConsoleKey.LeftArrow && keyPressed.Key == ConsoleKey.RightArrow) ||
                    (NinjaMario.lastJumpKey == ConsoleKey.RightArrow && keyPressed.Key == ConsoleKey.LeftArrow) ||
                    NinjaMario.lastJumpKey == ki.Key)
                {
                    NinjaMario.Jump(level, keyPressed.Key);
                }
                else
                {
                    NinjaMario.Jump(level, NinjaMario.lastJumpKey);
                }



            }
            else if (!NinjaMario.Collision("down", level) && !NinjaMario.isJumping)
            {
                // fall down
                NinjaMario.MoveDown(level);
            }

            // take action according to pressed key
            switch (keyPressed.Key)
            {
                case ConsoleKey.LeftArrow: // move left
                    NinjaMario.MoveLeft(level);
                    break;

                case ConsoleKey.RightArrow: // move right
                    NinjaMario.MoveRight(level);
                    break;

                case ConsoleKey.UpArrow: // start jumping
                    NinjaMario.isJumping = true;
                    break;

                case ConsoleKey.Escape:

                    Engine.GameIsOn = true;
                    Menu.Display();
                    SetConsole(30, 120);
                    Console.Clear();
                    level.Print();

                    break; // exit
                default: break;
            }

            // DUPKI MAINA
            if (NinjaMario.MarioInTheHole())
            {
                GameOver();
                break;
            }

            // move enemies
            if (counter++ % 2 == 0)
                for (int i = 0; i < enemies.Count; i++) // for each enemy in the list
                {
                    if (enemies[i].levelPosition == Level.levelCounter) // if the enemy is to be displayed in that level 
                    {
                        enemies[i].BounceHorizontal(level);



                        if (NinjaMario.isDead(enemies[i], level))
                        {
                            // Game over code here
                            GameOver();
                            Engine.GameIsOn = false;
                            return;
                        }

                        if (enemies[i].isEnemyDead(NinjaMario)) // mario has jumped on top of it
                        {
                            scoreCount++;
                            enemies[i].Clear(); // clear from console
                            enemies.RemoveAt(i); // remove from the list
                        }
                    }

                    

                    

                }

            NinjaMario.Print();
            Thread.Sleep(50);
        }
       
    }
}