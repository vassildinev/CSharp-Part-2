using System;
using System.Linq;
class Pattern
{
    static long[][] matrix;
    static void Main()
    {
        //INPUT
        int sizeOfMatrix = int.Parse(Console.ReadLine());

        matrix = new long[sizeOfMatrix][];
        for (int row = 0; row < sizeOfMatrix; row++)
        {
            matrix[row] = Console.ReadLine().Split().Select(long.Parse).ToArray();
        }

        //SOLUTION
        long bestSum = long.MinValue;
        bool foundPattern = false;

        long mainDiagonalSum = 0;
        for (int i = 0; i < sizeOfMatrix; i++)
        {
            for (int j = 0; j < sizeOfMatrix; j++)
            {
                if (i == j)
                {
                    mainDiagonalSum += matrix[i][j];
                }
            }
        }

        for (int row = 0; row < sizeOfMatrix - 2; row++)
        {
            for (int col = 0; col < sizeOfMatrix - 4; col++)
            {
                long a = matrix[row][col];
                long b = matrix[row][col + 1];
                long c = matrix[row][col + 2];
                long d = matrix[row + 1][col + 2];
                long f = matrix[row + 2][col + 2];
                long e = matrix[row + 2][col + 3];
                long g = matrix[row + 2][col + 4];

                if (a == b - 1 && b == c - 1 && c == d - 1 && d == f - 1 && f == e - 1 && e == g - 1)
                {
                    foundPattern = true;
                    long currentSum = a + b + c + d + f + e + g;
                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                    }
                }
            }
        }

        //OUTPUT
        if (foundPattern)
        {
            Console.WriteLine("YES {0}", bestSum);
        }
        else
        {
            Console.WriteLine("NO {0}", mainDiagonalSum);
        }
    }
}