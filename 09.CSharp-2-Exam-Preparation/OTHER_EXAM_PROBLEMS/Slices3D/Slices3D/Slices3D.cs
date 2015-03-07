using System;
using System.Linq;
class Slices3D
{
    static int[, ,] cuboid;
    static long totalSum = 0;
    static int count = 0;
    static void Main()
    {
        //INPUT
        int[] dims = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int width = dims[0];
        int height = dims[1];
        int depth = dims[2];

        cuboid = new int[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string[] layer = Console.ReadLine()
                .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();
            for (int d = 0; d < depth; d++)
            {
                int[] currentWidthAlongDepth = layer[d]
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray(); ;

                for (int w = 0; w < width; w++)
                {
                    int currentCellAlongCurrentWidth = currentWidthAlongDepth[w];
                    totalSum += currentCellAlongCurrentWidth;
                    cuboid[w, h, d] = currentCellAlongCurrentWidth;
                }
            }
        }
        
        //SOLUTION

        // width slices
        int currentSum = 0;
        for (int w = 0; w < width - 1; w++)
        {
            for (int h = 0; h < height; h++)
            {
                for (int d = 0; d < depth; d++)
                {
                    currentSum += cuboid[w, h, d];
                }
            }
            if (currentSum + currentSum == totalSum)
            {
                count++;
            }
        }

        // height slices
        currentSum = 0;
        for (int h = 0; h < height - 1; h++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int d = 0; d < depth; d++)
                {
                    currentSum += cuboid[w, h, d];
                }
            }
            if (currentSum + currentSum == totalSum)
            {
                count++;
            }
        }

        // depth slices
        currentSum = 0;
        for (int d = 0; d < depth - 1; d++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    currentSum += cuboid[w, h, d];
                }
            }
            if (currentSum + currentSum == totalSum)
            {
                count++;
            }
        }

        //OUPTUT
        Console.WriteLine(count);
    }
}