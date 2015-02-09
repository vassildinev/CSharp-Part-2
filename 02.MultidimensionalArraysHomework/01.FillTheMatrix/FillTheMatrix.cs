//Write a program that fills and prints a matrix of size (n, n) as shown below:
//| 1	5	9	13| 1	8	9	16| 7	11	14	16| 1   12	11	10
//| 2	6	10	14| 2	7	10	15| 4	8	12	15| 2   13	16	9
//| 3	7	11	15| 3	6	11	14| 2	5	9	13| 3   14	15	8
//| 4	8	12	16| 4	5	12	13| 1	3	6	10| 4   5	6	7 

using System;
using System.Collections.Generic;
using System.Linq;
class FillTheMatrix
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Size of matrix:");
        int size = int.Parse(Console.ReadLine());

        //SOLUTION
        int height = size;
        int width = size;
        int[,] matrix = new int[height, width];
        int currentCol = 0;
        int currentRow = 0;
        string direction = "";
        Console.WriteLine();

        #region Side Fill

        //Side Fill
        int counter = 1;
        for (int col = 0; col < width; col++)
        {
            for (int row = 0; row < height; row++)
            {
                matrix[row, col] = counter;
                counter++;
            }
        }

        //Side Fill - OUTPUT
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Console.Write(matrix[row, col].ToString().PadRight(3, ' '));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        #endregion

        #region Snake Fill
        //Snake Fill
        //reset the matrix
        matrix = new int[height, width];
        counter = 1;
        direction = "down";
        while (true)
        {
            if (direction == "down")
            {
                matrix[currentRow, currentCol] = counter;
                counter++;
                if (counter > size * size)
                {
                    break;
                }
                currentRow++;
                if (currentRow == height)
                {
                    currentRow--;
                    currentCol++;
                    direction = "up";
                }
            }
            else if (direction == "up")
            {
                matrix[currentRow, currentCol] = counter;
                counter++;
                if (counter > size * size)
                {
                    break;
                }
                currentRow--;
                if (currentRow == -1)
                {
                    currentRow++;
                    currentCol++;
                    direction = "down";
                }
            }
        }

        //Snake Fill - OUTPUT
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Console.Write(matrix[row, col].ToString().PadRight(3, ' '));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        #endregion

        #region Zig-Zag
        //Zig-Zag
        //reset the matrix
        matrix = new int[height, width];
        counter = 1;
        currentRow = height - 1;
        currentCol = 0;
        direction = "diagonalDown";
        while (true)
        {
            if (direction == "diagonalUp")
            {
                for (int row = currentRow; row >= 0; row--)
                {
                    if (matrix[row, 0] == 0)
                    {
                        currentRow = row;
                        currentCol = 0;
                        break;
                    }
                }
                direction = "diagonalDown";
            }
            else if (direction == "diagonalUpNew")
            {
                for (int col = 0; col <= width - 1; col++)
                {
                    if (matrix[0, col] == 0)
                    {
                        currentRow = 0;
                        currentCol = col;
                        break;
                    }
                }
                direction = "diagonalDown";
            }
            else if (direction == "diagonalDown")
            {
                matrix[currentRow, currentCol] = counter;
                counter++;
                if (counter > size * size)
                {
                    break;
                }
                currentRow++;
                currentCol++;
                if (currentRow == height || currentCol == width)
                {
                    if (currentCol == width)
                    {
                        direction = "diagonalUpNew";
                    }
                    else
                    {
                        direction = "diagonalUp";
                    }
                    currentRow--;
                    currentCol--;
                }
            }
        }

        //Zig-Zag - OUTPUT
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Console.Write(matrix[row, col].ToString().PadRight(3, ' '));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        #endregion

        #region Spiral
        //Spiral
        //reset the matrix
        matrix = new int[height, width];
        currentRow = 0;
        currentCol = 0;
        direction = "down";

        for (int i = 1; i <= size * size; i++)
        {
            if (direction == "right" && (currentCol >= width || matrix[currentRow, currentCol] != 0))
            {
                currentCol--;
                i--;
                direction = "down";
            }
            else if (direction == "down" && (currentRow >= height || matrix[currentRow, currentCol] != 0))
            {
                currentRow--;
                i--;
                direction = "left";
            }
            else if (direction == "left" && (currentCol < 0 || matrix[currentRow, currentCol] != 0))
            {
                currentCol++;
                i--;
                direction = "up";
            }
            else if (direction == "up" && (currentRow < 0 || matrix[currentRow, currentCol] != 0))
            {
                currentRow++;
                i--;
                direction = "right";
            }

            matrix[currentRow, currentCol] = i;

            if (direction == "right")
            {
                currentCol++;
            }
            else if (direction == "down")
            {
                currentRow++;
            }
            else if (direction == "left")
            {
                currentCol--;
            }
            else if (direction == "up")
            {
                currentRow--;
            }
        }

        //Spiral - OUTPUT
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Console.Write(matrix[row, col].ToString().PadRight(3, ' '));
            }
            Console.WriteLine();
        }
        #endregion
    }
}