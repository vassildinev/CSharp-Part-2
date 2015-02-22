using System;
using System.Collections.Generic;
using System.Numerics;
 
class HelpDoge
{
    static void Main(string[] args)
    {
        //INPUT
        string[] sizesOfField = Console.ReadLine().Split(' ');
        int height = int.Parse(sizesOfField[0]);
        int width = int.Parse(sizesOfField[1]);

        string[] boneCoords = Console.ReadLine().Split(' ');
        int boneX = int.Parse(boneCoords[0]);
        int boneY = int.Parse(boneCoords[1]);

        int k = int.Parse(Console.ReadLine());
        HashSet<string> enemies = new HashSet<string>();
        for (int i = 0; i < k; i++)
        {
            enemies.Add(Console.ReadLine());
        }

        //SOLUTION
        BigInteger[,] possiblePaths = new BigInteger[height, width];
        possiblePaths[0, 0] = 1;

        for (int i = 0; i <= boneX; i++)
        {
            for (int j = 0; j <= boneY; j++)
            {
                if (enemies.Contains(i + " " + j)) continue;
                if (i != 0) possiblePaths[i, j] += possiblePaths[i - 1, j];
                if (j != 0) possiblePaths[i, j] += possiblePaths[i, j - 1];
            }
        }

        //OUTPUT

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Console.Write(possiblePaths[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine(possiblePaths[boneX, boneY]);
    }
}