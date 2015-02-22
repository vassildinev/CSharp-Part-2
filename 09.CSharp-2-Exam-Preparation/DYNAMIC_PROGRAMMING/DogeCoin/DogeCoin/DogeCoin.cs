using System;
using System.Linq;

class DogeCoin
{
    static void Main()
    {
        //INPUT
        int[] sizesOfField = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int height = sizesOfField[0];
        int width = sizesOfField[1];

        int[,] dogeField = new int[height, width];

        int numberOfCoins = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCoins; i++)
        {
            int[] coinCoords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int coinX = coinCoords[0];
            int coinY = coinCoords[1];
            dogeField[coinX, coinY] += 1;
        }

        //SOLUTION

        // solve for cells on row = 0
        for (int col = 1; col < width; col++)
        {
            dogeField[0, col] += dogeField[0, col - 1];
        }

        // solve for cells on col = 0
        for (int row = 1; row < height; row++)
        {
            dogeField[row, 0] += dogeField[row - 1, 0];
        }

        // solve for every other cell
        for (int row = 1; row < height; row++)
        {
            for (int col = 1; col < width; col++)
            {
                if (dogeField[row, col - 1] > dogeField[row - 1, col])
                {
                    dogeField[row, col] += dogeField[row, col - 1];
                }
                else
                {
                    dogeField[row, col] += dogeField[row - 1, col];
                }
            }
        }
        
        //OUTPUT
        int endPointX = height - 1;
        int endPointY = width - 1;
        Console.WriteLine(dogeField[endPointX, endPointY]);
    }
}