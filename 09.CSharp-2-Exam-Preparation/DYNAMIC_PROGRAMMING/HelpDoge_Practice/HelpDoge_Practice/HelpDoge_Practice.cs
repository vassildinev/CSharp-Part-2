using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
    class HelpDoge_Practice
    {
        static void Main()
        {
            //INPUT

            // read Doge path dimensions and create the paths matrix
            int[] matrixDimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int matrixHeight = matrixDimensions[0];
            int matrixWidth = matrixDimensions[1];

            BigInteger[,] dogePathsMatrix = new BigInteger[matrixHeight, matrixWidth];

            // read food coordinates
            int[] foodCoordinates = Console.ReadLine()
                .Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int foodHeight = foodCoordinates[0];
            int foodWidth = foodCoordinates[1];

            // mark enemies positions on Doge paths matrix
            int enemiesCount = int.Parse(Console.ReadLine());
            var enemiesCoords = new HashSet<string>();
            for (int i = 0; i < enemiesCount; i++)
            {
                enemiesCoords.Add(string.Join(" ",Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries)));
            }

            //SOLUTION
            dogePathsMatrix[0, 0] = 1;
            for (int row = 0; row < matrixHeight; row++)
            {
                for (int col = 0; col < matrixWidth; col++)
                {
                    if (enemiesCoords.Contains((row.ToString() + " " + col.ToString())))
                    {
                        continue;
                    }
                    if (row != 0) dogePathsMatrix[row, col] += dogePathsMatrix[row - 1, col];
                    if (col != 0) dogePathsMatrix[row, col] += dogePathsMatrix[row, col - 1];
                }
            }

            //OUTPUT
            Console.WriteLine(dogePathsMatrix[foodHeight, foodWidth]);
        }
    }