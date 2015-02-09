//We are given a matrix of strings of size N x M. Sequences in the matrix we define
//as sets of several neighbour elements located on the same line, column or diagonal.
//Write a program that finds the longest sequence of equal strings in the matrix.

using System;
using System.Collections.Generic;
using System.Linq;
class Sequence
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Matrix number of rows:");
        int height = int.Parse(Console.ReadLine());
        Console.WriteLine();

        string[][] matrix = new string[height][];

        Console.WriteLine("Fill the matrix row by row, each on a single line with space between elements:");
        for (int row = 0; row < height; row++)
        {
            matrix[row] = Console.ReadLine().Split(' ');
        }

        //SOLUTION
        int bestLen = int.MinValue;
        string bestSequence = "";

        #region Row Search
        //row search
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                int currentCol = col;
                int len = 1;
                string currentSequence = "";
                while (true)
                {
                    if (currentCol + 1 < matrix[row].Length)
                    {


                        if (matrix[row][currentCol + 1] == matrix[row][currentCol])
                        {
                            currentCol++;
                            len++;
                            currentSequence += matrix[row][currentCol];
                            currentSequence += " ";
                        }
                        else
                        {
                            if (len > bestLen)
                            {
                                bestLen = len;
                                currentSequence += matrix[row][currentCol];
                                bestSequence = currentSequence;
                            }
                            break;
                        }
                    }
                    else
                    {
                        if (len > bestLen)
                        {
                            bestLen = len;
                            currentSequence += matrix[row][currentCol];
                            bestSequence = currentSequence;
                        }
                        break;
                    }
                }
            }
        }
        #endregion

        #region Column Search
        for (int col = 0; col < matrix[0].Length; col++)
        {
            for (int row = 0; row < height; row++)
            {
                int currentRow = row;
                int len = 1;
                string currentSequence = "";
                while (true)
                {
                    if (currentRow + 1 < height)
                    {
                        if (matrix[currentRow + 1][col] == matrix[currentRow][col])
                        {
                            currentRow++;
                            len++;
                            currentSequence += matrix[currentRow][col];
                            currentSequence += " ";
                        }
                        else
                        {
                            if (len > bestLen)
                            {
                                bestLen = len;
                                currentSequence += matrix[currentRow][col];
                                bestSequence = currentSequence;
                            }
                            break;
                        }
                    }
                    else
                    {
                        if (len > bestLen)
                        {
                            bestLen = len;
                            currentSequence += matrix[currentRow][col];
                            bestSequence = currentSequence;
                        }
                        break;
                    }
                }
            }
        }
        #endregion

        #region Diagonal Search Left Tilt

        #region Diagonal Search At Top-Most Row
        //all diagonals starting at row 0
        for (int col = 0; col < matrix[0].Length - 1; col++)
        {
            int currentRow = 0;
            int currentCol = col;
            int len = 1;
            string currentSequence = "";
            while (true)
            {
                if (currentCol + 1 < matrix[0].Length && currentRow + 1 < height)
                {
                    if (matrix[currentRow + 1][currentCol + 1] == matrix[currentRow][currentCol])
                    {
                        currentCol++;
                        currentRow++;
                        len++;
                        currentSequence += matrix[currentRow][currentCol];
                        currentSequence += " ";
                    }
                    else
                    {
                        if (len > bestLen)
                        {
                            bestLen = len;
                            currentSequence += matrix[currentRow][currentCol];
                            bestSequence = currentSequence;
                        }
                        break;
                    }
                }
                else
                {
                    if (len > bestLen)
                    {
                        bestLen = len;
                        currentSequence += matrix[currentRow][currentCol];
                        bestSequence = currentSequence;
                    }
                    break;
                }
            }
        }
        #endregion

        #region Diagonal Search At Column 0
        //all diagonals starting at col 0
        for (int row = 0; row < height - 1; row++)
        {
            int currentRow = row;
            int currentCol = 0;
            int len = 1;
            string currentSequence = "";
            while (true)
            {
                if (currentCol + 1 < matrix[0].Length && currentRow + 1 < height)
                {
                    if (matrix[currentRow + 1][currentCol + 1] == matrix[currentRow][currentCol])
                    {
                        currentCol++;
                        currentRow++;
                        len++;
                        currentSequence += matrix[currentRow][currentCol];
                        currentSequence += " ";
                    }
                    else
                    {
                        if (len > bestLen)
                        {
                            bestLen = len;
                            currentSequence += matrix[currentRow][currentCol];
                            bestSequence = currentSequence;
                        }
                        break;
                    }
                }
                else
                {
                    if (len > bestLen)
                    {
                        bestLen = len;
                        currentSequence += matrix[currentRow][currentCol];
                        bestSequence = currentSequence;
                    }
                    break;
                }
            }
        }
        #endregion

        #endregion

        #region Diagonal Search Right Tilt

        #region Diagonal Search At Top-Most Row
        //all diagonals starting at row 0
        for (int col = matrix[0].Length - 1; col > 0; col--)
        {
            int currentRow = 0;
            int currentCol = col;
            int len = 1;
            string currentSequence = "";
            while (true)
            {
                if (currentCol - 1 >= 0 && currentRow + 1 < height)
                {
                    if (matrix[currentRow + 1][currentCol - 1] == matrix[currentRow][currentCol])
                    {
                        currentCol--;
                        currentRow++;
                        len++;
                        currentSequence += matrix[currentRow][currentCol];
                        currentSequence += " ";
                    }
                    else
                    {
                        if (len > bestLen)
                        {
                            bestLen = len;
                            currentSequence += matrix[currentRow][currentCol];
                            bestSequence = currentSequence;
                        }
                        break;
                    }
                }
                else
                {
                    if (len > bestLen)
                    {
                        bestLen = len;
                        currentSequence += matrix[currentRow][currentCol];
                        bestSequence = currentSequence;
                    }
                    break;
                }
            }
        }
        #endregion

        #region Diagonal Search At Left-Most Column
        //all diagonals starting at last col
        for (int row = 0; row < height - 1; row++)
        {
            int currentRow = row;
            int currentCol = matrix[0].Length - 1;
            int len = 1;
            string currentSequence = "";
            while (true)
            {
                if (currentCol - 1 >= 0 && currentRow + 1 < height)
                {
                    if (matrix[currentRow + 1][currentCol - 1] == matrix[currentRow][currentCol])
                    {
                        currentCol--;
                        currentRow++;
                        len++;
                        currentSequence += matrix[currentRow][currentCol];
                        currentSequence += " ";
                    }
                    else
                    {
                        if (len > bestLen)
                        {
                            bestLen = len;
                            currentSequence += matrix[currentRow][currentCol];
                            bestSequence = currentSequence;
                        }
                        break;
                    }
                }
                else
                {
                    if (len > bestLen)
                    {
                        bestLen = len;
                        currentSequence += matrix[currentRow][currentCol];
                        bestSequence = currentSequence;
                    }
                    break;
                }
            }
        }
        #endregion

        #endregion

        //OUTPUT
        Console.WriteLine();
        Console.WriteLine("Longest sequence of equal strings:");
        Console.WriteLine(bestSequence);
        Console.WriteLine();
        Console.WriteLine("Length of longest sequence:");
        Console.WriteLine(bestLen);
        Console.WriteLine();
    }
}
