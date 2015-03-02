using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class GreedyDwarf
{
    static void Main()
    {
        //INPUT
        long[] valley = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToArray();

        int numOfPatterns = int.Parse(Console.ReadLine());

        //SOLUTION
        var collectedCoins = new List<long>();

        for (int i = 0; i < numOfPatterns; i++)
        {
            int[] pattern = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            int index = 0;
            long coins = 0;

            int k = 0;

            bool[] visited = new bool[valley.Length];
            while (visited[index] != true)
            {
                coins += valley[index];
                visited[index] = true;

                index += pattern[k];
                if (index<0||index>valley.Length - 1)
                {
                    break;
                }

                k++;
                k = k % pattern.Length;
            }
            collectedCoins.Add(coins);
        }

        //OUTPUT
        Console.WriteLine(collectedCoins.Max());
    }
}
