using System;
using System.Linq;
class DogeCoin_Practice
{
    static void Main()
    {
        //INPUT
        // read Doge matrix
        int[] dogeMatrixDims = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int dogeMatrixHeight = dogeMatrixDims[0] + 1;
        int dogeMatrixWidth = dogeMatrixDims[1] + 1;

        int[,] dogeMatrix = new int[dogeMatrixHeight, dogeMatrixWidth];

        // fill Doge Coins
        int coinsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < coinsCount; i++)
        {
            int[] coinCoord = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

            int coinH = coinCoord[0] + 1;
            int coinW = coinCoord[1] + 1;

            dogeMatrix[coinH, coinW]++;
        }

        //SOLUTION
        for (int row = 1; row < dogeMatrixHeight; row++)
        {
            for (int col = 1; col < dogeMatrixWidth; col++)
            {
                if (dogeMatrix[row - 1, col] >= dogeMatrix[row, col - 1])
                {
                    dogeMatrix[row, col] += dogeMatrix[row - 1, col];
                }
                else
                {
                    dogeMatrix[row, col] += dogeMatrix[row, col - 1];
                }
            }
        }

        //OUPTUT
        Console.WriteLine(dogeMatrix[dogeMatrixHeight - 1, dogeMatrixWidth - 1]);
    }
}