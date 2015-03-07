using System;
using System.Text;
/// <summary>
/// Enemy class creates an enemy entity that
/// will move vertically or horizontaly.
/// </summary>

public enum Size { SMALL = 0, BIG = 1, BOSS = 2 };

class Enemy
{
    //FIELDS
    //private int scorePoints; // points added to player total score when enemy dies
    //private int healthPoints;// number of points to be alive
    public int levelPosition;
    private bool isDead; // if true, enemy dispapear
    private int posX, posY; //cursor positon in console for printing the enemy
    private Size enemyTypeSize;// will determine which enemy to print
    private int enemyHeight; // enemy printed lines
    private int enemyWidth; // enemy characters length per line
    private int distance; // number of steps for movement
    private int steps; //distance  moved by enemy
    private bool right; //direction right or left
    private bool up;   //direction up or down


    //PROPERTIES
    //public int ScorePoints { get { return scorePoints; } set { scorePoints = value; } }
    //public int HealthPoints { get { return healthPoints; } set { healthPoints = value; } }
    public bool IsDead { get { return isDead; } set { isDead = value; } }
    public int PosX { get { return posX; } set { posX = value; } }
    public int PosY { get { return posY; } set { posY = value; } }
    public Size EnemyTypeSize { get { return enemyTypeSize; } set { enemyTypeSize = value; } }
    public int EnemyWidth { get { return enemyHeight; } set { enemyHeight = value; } }
    public int EnemyHeight { get { return enemyWidth; } set { enemyWidth = value; } }
    public int Distance { get { return distance; } set { distance = value; } }
    public int Steps { get { return steps; } set { steps = value; } }
    public bool Right { get { return right; } set { right = value; } }
    public bool Up { get { return up; } set { up = value; } }




    //CONSTRUCTORS

    /// <summary>
    /// Creates an enemy at the given position and sets it's
    /// distance of movement
    /// </summary>
    /// <param name="score"> the points addedt to the players total score when enemy is dead</param>
    /// <param name="health"> number of hits to be killed</param>
    /// <param name="dead"> returs true if health is less or equal to 0</param>
    /// <param name="posX"> position on x to print the enemy</param>
    /// <param name="posY"> position on y to priont the enemy</param>
    /// <param name="typeSize"> size of the enemy</param>
    /// <param name="distance"> total number of steps enemy will move</param>
    //public Enemy(int score, int health, bool dead, int posX, int posY, Size typeSize, int distance)
    //{
    //    ScorePoints = score;
    //    HealthPoints = health;
    //    IsDead = dead;
    //    PosX = posX;
    //    PosY = posY;
    //    EnemyTypeSize = typeSize;
    //    Distance = distance;

    //    // set height and width for collision checks
    //    if (EnemyTypeSize == Size.SMALL)
    //    {
    //        EnemyHeight = 1;
    //        EnemyWidth = 6;
    //    }
    //    else if (EnemyTypeSize == Size.BIG)
    //    {
    //        EnemyHeight = 3;
    //        EnemyWidth = 6;
    //    }
    //    else if (EnemyTypeSize == Size.BOSS)
    //    {
    //        EnemyHeight = 5;
    //        EnemyWidth = 8;
    //    }
    //    //initialize directions for bounce movement
    //    Steps = 0;
    //    Right = false;
    //    Up = false;
    //}

    public Enemy(bool dead, int posX, int posY, Size typeSize, int distance, int levelPos)
    {

        IsDead = dead;
        PosX = posX;
        PosY = posY;
        EnemyTypeSize = typeSize;
        Distance = distance;
        levelPosition = levelPos;

        // set height and width for collision checks
        if (EnemyTypeSize == Size.SMALL)
        {
            EnemyHeight = 1;
            EnemyWidth = 6;
        }
        else if (EnemyTypeSize == Size.BIG)
        {
            EnemyHeight = 3;
            EnemyWidth = 6;
        }
        else if (EnemyTypeSize == Size.BOSS)
        {
            EnemyHeight = 5;
            EnemyWidth = 8;
        }
        //initialize directions for bounce movement
        Steps = 0;
        Right = false;
        Up = false;
    }

    //METHODS

    /// <summary>
    /// Prints a different enemy style, depending on the Enemy Size
    /// at the given console position.
    /// </summary>
    public void Print()
    {
        
        switch (EnemyTypeSize)
        {
            case Size.BIG: //print a big enemy
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.CursorTop = PosY;
                Console.CursorLeft = PosX;
                Console.WriteLine(" ___ ");
                Console.CursorLeft = PosX;
                Console.WriteLine("/o o\\");
                Console.CursorLeft = PosX;
                Console.WriteLine("V---V ");
                break;
            case Size.BOSS: // print a boss
                Console.ForegroundColor = ConsoleColor.Black;
                Console.CursorTop = PosY;
                Console.CursorLeft = PosX;
                Console.WriteLine(" ?___? ");
                Console.CursorLeft = PosX;
                Console.WriteLine("/o   o\\");
                Console.CursorLeft = PosX;
                Console.WriteLine("|  X  |");
                Console.CursorLeft = PosX;
                Console.WriteLine("|     |");
                Console.CursorLeft = PosX;
                Console.Write("\\/---\\/");
                break;
            default://print a small enemy
                Console.OutputEncoding = Encoding.Unicode;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.CursorTop = PosY;
                Console.CursorLeft = PosX;
                Console.WriteLine("|o`_´o|");
                break;
        }
    }


    public void Clear()
    {
        switch (EnemyTypeSize)
        {
            case Size.BIG: //clear a big enemy
                
                Console.CursorTop = PosY;
                Console.CursorLeft = PosX;
                Console.WriteLine("     ");
                Console.CursorLeft = PosX;
                Console.WriteLine("     ");
                Console.CursorLeft = PosX;
                Console.WriteLine("     ");
                break;
            case Size.BOSS: // clear a boss
                
                Console.CursorTop = PosY;
                Console.CursorLeft = PosX;
                Console.WriteLine("       ");
                Console.CursorLeft = PosX;
                Console.WriteLine("       ");
                Console.CursorLeft = PosX;
                Console.WriteLine("       ");
                Console.CursorLeft = PosX;
                Console.WriteLine("       ");
                Console.CursorLeft = PosX;
                Console.Write("       ");
                break;
            default://clear a small enemy
                
                Console.CursorTop = PosY;
                Console.CursorLeft = PosX;
                Console.WriteLine("       ");
                break;
        }
    }

    /// <summary>
    /// Moves enemy horizontally in a total of steps equals to distance
    /// </summary>
    public void BounceHorizontal(Level level)
    {
        if (Steps <= Distance && Right == false && !Collision(level))
        {
            Console.CursorLeft = PosX--;
            Steps++;
            if (Steps == Distance || Collision(level) || posX == 0)
            {
                Right = true;
            }
        }

        else if (Steps >= 0 && Right == true)
        {
            Console.CursorLeft = PosX++;
            Steps--;
            if (Steps == 0 || posX == Console.BufferWidth - 7)
            {
                Right = false;
            }
        }

        Print();
    }
    public bool Collision(Level level)
    {
        if (posX > 0)
        {
            return level[posY + 1, posX - 1] == '█';
        }
        return true;
    }

    public bool isEnemyDead(Mario m)
    {
        // checks if legs are hitting the enemy and are above the enemy
        // and not to its side
        if (m.marioCenter.row + 3 >= posY - 1 - EnemyHeight / 2 && m.marioCenter.row + 3 <= posY +1 + EnemyHeight
         && (m.marioBody[12].col - 1 >= posX && m.marioBody[13].col - 3 <= posX))
        {
            return true;
        }
        return false;
    }
    ///// <summary>
    ///// Diagonal move going down from left to right and back
    ///// </summary>
    //public void DiagonalLeftRightDown()
    //{
    //    if (Steps <= Distance && Up == false)
    //    {
    //        Console.CursorLeft = PosY++;
    //        Console.CursorLeft = PosX++;
    //        Steps++;
    //        if (Steps == Distance)
    //        {
    //            Up = true;
    //        }
    //    }

    //    if (Steps >= 0 && Up == true)
    //    {
    //        Console.CursorLeft = PosY--;
    //        Console.CursorLeft = PosX--;
    //        Steps--;
    //        if (Steps == 0)
    //        {
    //            Up = false;
    //        }
    //    }

    //    Print();
    //}
    ///// <summary>
    ///// Digaonal move going down from right to left and  back
    ///// </summary>
    //public void DiagonalRightLefttDown()
    //{
    //    if (Steps <= Distance && Up == false)
    //    {
    //        Console.CursorLeft = PosY++;
    //        Console.CursorLeft = PosX--;
    //        Steps++;
    //        if (Steps == Distance)
    //        {
    //            Up = true;
    //        }
    //    }

    //    if (Steps >= 0 && Up == true)
    //    {
    //        Console.CursorLeft = PosY--;
    //        Console.CursorLeft = PosX++;
    //        Steps--;
    //        if (Steps == 0)
    //        {
    //            Up = false;
    //        }
    //    }

    //    Print();
    //}

    ///// <summary>
    ///// Moves in clockwise direction
    ///// </summary>
    //public void MoveClockWise()
    //{
    //    if (Steps <= Distance && Up == false && Right == false)
    //    {
    //        Console.CursorLeft = PosY++;
    //        Steps++;
    //        if (Steps == Distance)
    //        {
    //            Up = true;
    //        }
    //    }

    //    if (Steps >= 0 && Right == false && Up == true)
    //    {
    //        Console.CursorLeft = PosX--;
    //        Steps--;
    //        if (Steps == 0)
    //        {
    //            Right = true;
    //        }
    //    }

    //    if (Steps <= Distance && Up == true && Right == true)
    //    {
    //        Console.CursorLeft = PosY--;
    //        Steps++;
    //        if (Steps == Distance)
    //        {
    //            Up = false;
    //        }
    //    }

    //    if (Steps >= 0 && Right == true && Up == false)
    //    {
    //        Console.CursorLeft = PosX++;
    //        Steps--;
    //        if (Steps == 0)
    //        {
    //            Right = false;
    //        }
    //    }

    //    Print();
    //}

    ///// <summary>
    ///// Moves in  counter clockwise direction
    ///// </summary>
    //public void MoveCounterClockWise()
    //{
    //    if (Steps <= Distance && Right == false && Up == false)
    //    {
    //        Console.CursorLeft = PosX++;
    //        Steps++;
    //        if (Steps == Distance)
    //        {
    //            Right = true;
    //        }
    //    }
    //    if (Steps >= 0 && Up == false && Right == true)
    //    {
    //        Console.CursorLeft = PosY--;
    //        Steps--;
    //        if (Steps == 0)
    //        {
    //            Up = true;
    //        }
    //    }

    //    if (Steps <= Distance && Right == true && Up == true)
    //    {
    //        Console.CursorLeft = PosX--;
    //        Steps++;
    //        if (Steps == Distance)
    //        {
    //            Right = false;
    //        }
    //    }


    //    if (Steps >= 0 && Up == true && Right == false)
    //    {
    //        Console.CursorLeft = PosY++;
    //        Steps--;
    //        if (Steps == 0)
    //        {
    //            Up = false;
    //        }
    //    }

    //    Print();
    //}
}