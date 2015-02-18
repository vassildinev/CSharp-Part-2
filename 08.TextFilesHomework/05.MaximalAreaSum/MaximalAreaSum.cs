//Write a program that reads a text file containing a square matrix of numbers.
//Find an area of size 2 x 2 in the matrix, with a maximal sum of its elements.
//The first line in the input file contains the size of matrix N.
//Each of the next N lines contain N numbers separated by space.
//The output should be a single number in a separate text file.

using System;
using System.IO;
using System.Linq;
class MaximalAreaSum
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Reading from input.txt...");
        StreamReader reader = new StreamReader("../../input.txt");

        int sizeOfMatrix = int.Parse(reader.ReadLine());

        int height = sizeOfMatrix;
        int width = sizeOfMatrix;
        int[][] matrix = new int[height][];

        for (int row = 0; row < height; row++)
        {
            matrix[row] = reader.ReadLine().Trim().Split(' ').Select(x=>int.Parse(x)).ToArray();
        }

        reader.Close();

        //SOLUTION
        int platformSize = 2;
        int bestSum = int.MinValue;
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
                }
            }
        }
        reader.Close();

        //OUTPUT
        Console.WriteLine("Writing result to output.txt...");

        StreamWriter writer = new StreamWriter("../../output.txt");
        writer.WriteLine(bestSum);
        writer.Close();

        Console.WriteLine("Completed.");
    }
}