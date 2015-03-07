using System;
using System.Linq;
class BombingCuboids
{
    static char[] separators = new char[] { ' ' };
    static int[] cubeColors = new int[91];
    const char Empty = ' ';
    static int totalHits = 0;
    static void Main()
    {
        //INPUT AND SOLUTION
        int[] dimensions = Console.ReadLine()
            .Split(separators, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int width = dimensions[0];
        int height = dimensions[1];
        int depth = dimensions[2];

        char[, ,] cuboid = new char[width, height, depth];

        ReadCuboid(cuboid);

        int bombsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < bombsCount; i++)
        {
            int[] bombParams = Console.ReadLine()
            .Split(separators, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            int bombWidth = bombParams[0];
            int bombHeight = bombParams[1];
            int bombDepth = bombParams[2];
            int bombPower = bombParams[3];

            // boom

            Boom(cuboid, bombWidth, bombHeight, bombDepth, bombPower);

            // fall down
            CubesFallDown(cuboid);
        }

        //OUTPUT
        PrintResult();
    }

    private static void PrintResult()
    {
        Console.WriteLine(totalHits);
        for (int i = 0; i < cubeColors.Length; i++)
        {
            if (cubeColors[i] != 0)
            {
                Console.WriteLine("{0} {1}", (char)i, cubeColors[i]);
            }
        }
    }

    private static void CubesFallDown(char[, ,] cuboid)
    {
        int width = cuboid.GetLength(0);
        int height = cuboid.GetLength(1);
        int depth = cuboid.GetLength(2);

        for (int pillarWidth = 0; pillarWidth < width; pillarWidth++)
        {
            for (int pillarDepth = 0; pillarDepth < depth; pillarDepth++)
            {
                int bottom = 0;
                for (int pillarHeight = 0; pillarHeight < height; pillarHeight++)
                {
                    if (cuboid[pillarWidth, pillarHeight, pillarDepth] != Empty)
                    {
                        if (pillarHeight != bottom)
                        {
                            cuboid[pillarWidth, bottom, pillarDepth] = cuboid[pillarWidth, pillarHeight, pillarDepth];
                            cuboid[pillarWidth, pillarHeight, pillarDepth] = Empty;
                        }
                        bottom++;
                    }
                }
            }
        }
    }

    private static void Boom(char[, ,] cuboid, int bombWidth, int bombHeight, int bombDepth, int bombPower)
    {
        int width = cuboid.GetLength(0);
        int height = cuboid.GetLength(1);
        int depth = cuboid.GetLength(2);

        for (int currentWidth = 0; currentWidth < width; currentWidth++)
        {
            for (int currentHeight = 0; currentHeight < height; currentHeight++)
            {
                for (int currentDepth = 0; currentDepth < depth; currentDepth++)
                {
                    char currentCube = cuboid[currentWidth, currentHeight, currentDepth];
                    if (currentCube == Empty)
                    {
                        continue;
                    }
                    int deltaDistanceSquared =
                        (currentWidth - bombWidth) * (currentWidth - bombWidth) +
                        (currentHeight - bombHeight) * (currentHeight - bombHeight) +
                        (currentDepth - bombDepth) * (currentDepth - bombDepth);

                    bool inRange = bombPower * bombPower >= deltaDistanceSquared;

                    if (inRange)
                    {
                        cubeColors[(int)currentCube]++;
                        cuboid[currentWidth, currentHeight, currentDepth] = Empty;
                        totalHits++;
                    }
                }
            }
        }
    }

    private static void ReadCuboid(char[, ,] cuboid)
    {
        int width = cuboid.GetLength(0);
        int height = cuboid.GetLength(1);
        int depth = cuboid.GetLength(2);

        for (int currentHeight = 0; currentHeight < height; currentHeight++)
        {
            string[] layerDepthWidths = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int currentDepth = 0; currentDepth < depth; currentDepth++)
            {
                string currentLayerDepthWidth = layerDepthWidths[currentDepth];
                for (int currentWidth = 0; currentWidth < width; currentWidth++)
                {
                    cuboid[currentWidth, currentHeight, currentDepth] = currentLayerDepthWidth[currentWidth];
                }
            }
        }
    }

    private static void PrintCuboid(char[, ,] cuboid)
    {
        int width = cuboid.GetLength(0);
        int height = cuboid.GetLength(1);
        int depth = cuboid.GetLength(2);

        for (int currentHeight = 0; currentHeight < height; currentHeight++)
        {
            for (int currentDepth = 0; currentDepth < depth; currentDepth++)
            {
                for (int currentWidth = 0; currentWidth < width; currentWidth++)
                {
                    Console.Write(cuboid[currentWidth, currentHeight, currentDepth]);
                }
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
