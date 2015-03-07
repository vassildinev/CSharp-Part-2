using System;
using System.Linq;
using System.Numerics;
class LoverOf2
{
    static void Main()
    {
        //INPUT
        int matrixRows = int.Parse(Console.ReadLine());
        int matrixCols = int.Parse(Console.ReadLine());

        int coeff = Math.Max(matrixRows, matrixCols);

        BigInteger[,] matrix = new BigInteger[matrixRows, matrixCols];
        FillMatrix(matrix);

        BigInteger points = 0;

        int currentPawnR = matrixRows - 1;
        int currentPawnC = 0;

        points += matrix[currentPawnR, currentPawnC];
        matrix[currentPawnR, currentPawnC] = 0;
        int pawnPositions = int.Parse(Console.ReadLine());

        int[] coords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        for (int i = 0; i < coords.Length; i++)
        {
            int nextPawnR = (coords[i] / coeff) % matrixRows;
            int nextPawnC = (coords[i] % coeff) % matrixCols;

            // go the same column first
            for (int r = Math.Min(currentPawnR, nextPawnR); r <= Math.Max(currentPawnR, nextPawnR); r++)
            {
                points += matrix[r, currentPawnC];
                matrix[r, currentPawnC] = 0;
            }
            currentPawnR = nextPawnR;

            // then go the same row
            for (int c = Math.Min(currentPawnC, nextPawnC); c <= Math.Max(currentPawnC, nextPawnC); c++)
            {
                points += matrix[currentPawnR, c];
                matrix[currentPawnR, c] = 0;
            }
            currentPawnC = nextPawnC;

        }

        //OUTPUT

        Console.WriteLine(points);
    }

    private static void FillMatrix(BigInteger[,] matrix)
    {
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                matrix[matrix.GetLength(0) - 1 - r, c] = Power(2, r + c);
            }
        }
    }
    static BigInteger Power(ulong number, int power)
    {
        BigInteger result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= number;
        }
        return result;
    }
    static void PrintMatrix(BigInteger[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}