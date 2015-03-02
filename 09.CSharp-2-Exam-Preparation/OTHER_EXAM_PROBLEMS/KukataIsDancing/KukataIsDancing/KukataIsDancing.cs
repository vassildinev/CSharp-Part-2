using System;
class KukataIsDancing
{
    const int size = 3;
    static void Main()
    {
        //INPUT, SOLUTION & OUTPUT
        int numberOfDances = int.Parse(Console.ReadLine());

        int[,] matrix = new int[size, size];
        FillMatrix(matrix);

        for (int i = 0; i < numberOfDances; i++)
        {
            int kukataRow = 1;
            int kukataCol = 1;
            int kukataDir = 0;

            string dance = Console.ReadLine();
            foreach (char cmd in dance)
            {
                MoveKukata(cmd, ref kukataRow, ref kukataCol, ref kukataDir);
            }

            if (matrix[kukataRow, kukataCol] == 0)
            {
                Console.WriteLine("RED");
            }
            else if (matrix[kukataRow, kukataCol] == 1)
            {
                Console.WriteLine("BLUE");
            }
            else if (matrix[kukataRow, kukataCol] == 2)
            {
                Console.WriteLine("GREEN");
            }
        }
    }

    private static void FillMatrix(int[,] matrix)
    {
        // 0 = red
        // 1 = blue
        // 2 = green
        matrix[0, 0] = 0;
        matrix[0, 1] = 1;
        matrix[0, 2] = 0;
        matrix[1, 0] = 1;
        matrix[1, 1] = 2;
        matrix[1, 2] = 1;
        matrix[2, 0] = 0;
        matrix[2, 1] = 1;
        matrix[2, 2] = 0;
    }
    static void MoveKukata(char c, ref int kukataRow, ref int kukataCol, ref int kukataDir)
    {
        // rotation
        if (c == 'R')
        {
            kukataDir++;
            if (kukataDir == 4)
            {
                kukataDir = 0;
            }
        }
        if (c == 'L')
        {
            kukataDir--;
            if (kukataDir == -1)
            {
                kukataDir = 3;
            }
        }

        // forward movement
        if (c == 'W')
        {
            if (kukataDir == 0)
            {
                kukataCol++;
                if (kukataCol == 3)
                {
                    kukataCol = 0;
                }
            }
            if (kukataDir == 1)
            {
                kukataRow++;
                if (kukataRow == 3)
                {
                    kukataRow = 0;
                }
            }
            if (kukataDir == 2)
            {
                kukataCol--;
                if (kukataCol == -1)
                {
                    kukataCol = size - 1;
                }
            }
            if (kukataDir == 3)
            {
                kukataRow--;
                if (kukataRow == -1)
                {
                    kukataRow = size - 1;
                }
            }
        }
    }
}
