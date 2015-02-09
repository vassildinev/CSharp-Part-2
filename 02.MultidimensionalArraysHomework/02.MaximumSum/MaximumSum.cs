//Write a program that reads a rectangular matrix of size N x M
//and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;
using System.Collections.Generic;
using System.Linq;
class MaximumSum
{
    static void Main()
    {
        //example matrices:
        //| 1 9 9 9 2 3 4 | 1 7 2 0 9 9 8 |
        //| 0 9 9 8 1 0 8 | 0 0 1 8 9 9 9 |
        //| 0 9 9 9 3 8 5 | 0 3 9 9 9 8 9 |
        //| 4 0 1 0 1 0 1 | 4 0 1 0 1 0 1 |
        //| 2 3 4 5 6 7 8 | 2 3 4 5 6 7 8 |

        //INPUT
        Console.WriteLine("Matrix number of rows:");
        int height = int.Parse(Console.ReadLine());
        Console.WriteLine();

        int[][] matrix = new int[height][];

        Console.WriteLine("Fill the matrix row by row, each on a single line with space between elements:");
        for (int row = 0; row < height; row++)
        {
            matrix[row] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        //SOLUTION
        int platformSize = 3;
        int bestSum = int.MinValue;
        int[,] bestPlatform = new int[platformSize, platformSize];
        for (int row = 0; row < height - platformSize + 1; row++)
        {
            for (int col = 0; col < matrix[row].Length - platformSize + 1; col++)
            {
                int currentSum = 0;

                //find each platform's total sum of elements
                for (int platformRow = 0; platformRow < platformSize; platformRow++)
                {
                    for (int platformCol = 0; platformCol < platformSize; platformCol++)
                    {
                        currentSum += matrix[row + platformRow][col + platformCol];
                    }
                }

                //finds and saves the best platform
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                    bestPlatform = new int[platformSize, platformSize];
                    for (int bestPlatformRow = 0; bestPlatformRow < platformSize; bestPlatformRow++)
                    {
                        for (int bestPlatformCol = 0; bestPlatformCol < platformSize; bestPlatformCol++)
                        {
                            bestPlatform[bestPlatformRow, bestPlatformCol] = matrix[row + bestPlatformRow][col + bestPlatformCol];
                        }
                    }
                }
            }
        }

        //OUTPUT
        Console.WriteLine();
        Console.WriteLine("Best platform {0}x{0}:", platformSize);
        for (int row = 0; row < platformSize; row++)
        {
            for (int col = 0; col < platformSize; col++)
            {
                Console.Write(bestPlatform[row, col].ToString().PadRight(3, ' '));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("Sum of elements in best platform {0}x{0}:", platformSize);
        Console.WriteLine(bestSum);
        Console.WriteLine();
    }
}