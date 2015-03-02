using System;
using System.Collections.Generic;
using System.Linq;
class Laser
{
    static int[] dimensions;

    static int width;
    static int height;
    static int depth;
    static void Main()
    {
        //INPUT
        dimensions = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        width = dimensions[0];
        height = dimensions[1];
        depth = dimensions[2];

        int[] startCoordinates = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int startW = startCoordinates[0] - 1;
        int startH = startCoordinates[1] - 1;
        int startD = startCoordinates[2] - 1;

        int[] laserDirection = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int dirW = laserDirection[0];
        int dirH = laserDirection[1];
        int dirD = laserDirection[2];

        //SOLUTION
        int[, ,] cuboid = new int[width, height, depth];

        // mark start position
        cuboid[startW, startH, startD] = 1;

        int currentW = startW;
        int currentH = startH;
        int currentD = startD;

        int nextW = currentW;
        int nextH = currentH;
        int nextD = currentD;

        while (true)
        {

            // mark burnt edges
            MarkEdges(cuboid);

            // update current position
            nextW += dirW;
            nextH += dirH;
            nextD += dirD;

            // check for visited sub-cube
            if (cuboid[nextW, nextH, nextD] == 1)
            {
                break;
            }

            // else mark burnt sub-cube
            else
            {
                cuboid[nextW, nextH, nextD] = 1;
            }

            // implement reflection
            if (nextW == 0 || nextW == width - 1)
            {
                dirW *= -1;
            }
            if (nextH == 0 || nextH == height - 1)
            {
                dirH *= -1;
            }
            if (nextD == 0 || nextD == depth - 1)
            {
                dirD *= -1;
            }

            currentW = nextW;
            currentH = nextH;
            currentD = nextD;
        }

        // correct indexes
        currentW++;
        currentH++;
        currentD++;

        //OUTPUT
        Console.WriteLine("{0} {1} {2}", currentW, currentH, currentD);
    }

    private static void MarkEdges(int[, ,] cuboid)
    {
        // vertical edges
        for (int row = 0; row < width; row++)
        {
            cuboid[row, 0, 0] = 1;
            cuboid[row, height - 1, 0] = 1;
            cuboid[row, 0, depth - 1] = 1;
            cuboid[row, height - 1, depth - 1] = 1;
        }

        // side horizontal edges
        for (int aplicate = 0; aplicate < depth; aplicate++)
        {
            cuboid[0, 0, aplicate] = 1;
            cuboid[0, height - 1, aplicate] = 1;
            cuboid[width - 1, height - 1, aplicate] = 1;
            cuboid[width - 1, 0, aplicate] = 1;
        }

        // front/back horizontal edges
        for (int col = 0; col < height; col++)
        {
            cuboid[0, col, 0] = 1;
            cuboid[0, col, depth - 1] = 1;
            cuboid[width - 1, col, 0] = 1;
            cuboid[width - 1, col, depth - 1] = 1;
        }
    }
}