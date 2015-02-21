using System;
using System.Collections.Generic;
using System.Linq;
class JoroTheRabbit
{
    static void Main()
    {
        //INPUT
        int[] terrain = Console.ReadLine()
            .Split(new char[]{' ', ','}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        //SOLUTION
        int bestLen = 0;

        for (int startIndex = 0; startIndex < terrain.Length; startIndex++)
        {
            for (int step = 1; step < terrain.Length; step++)
            {
                int currentIndex = startIndex;
                int currentLength = 1;

                while ((currentIndex + step) % terrain.Length != startIndex
                    && (terrain[(currentIndex + step) % terrain.Length] > terrain[currentIndex]))
                {
                    currentLength++;
                    currentIndex = (currentIndex + step) % terrain.Length;
                }

                if (currentLength > bestLen)
                {
                    bestLen = currentLength;
                }
            }
        }
        Console.WriteLine(bestLen);
    }
}
