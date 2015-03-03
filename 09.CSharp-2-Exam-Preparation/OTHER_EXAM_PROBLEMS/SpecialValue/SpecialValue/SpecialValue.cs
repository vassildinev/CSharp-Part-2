using System;
using System.Collections.Generic;
using System.Linq;
class SpecialValue
{
    static void Main()
    {
        //INPUT
        var arrays = new List<int[]>();

        int numberOfArrays = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfArrays; i++)
        {
            var currentArray = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            arrays.Add(currentArray);
        }

        //SOLUTION
        long specialValue = 1;
        long bestSpecialValue = long.MinValue;
        int path = 0;

        int bestLen = GetBestArrayLength(arrays);

        bool[,] visited = new bool[arrays.Count, bestLen];

        for (int i = 0; i < arrays[0].Length; i++)
        {
            int currentValue = arrays[0][i];
            int nextValue = currentValue;
            int row = 0;
            while (true)
            {
                // check if path ends
                if (nextValue < 0)
                {
                    path++;
                    specialValue = path - nextValue;
                    if (specialValue > bestSpecialValue)
                    {
                        bestSpecialValue = specialValue;
                    }
                    specialValue = 0;
                    row = 0;
                    path = 0;
                    break;
                }
                else
                {
                    row++;
                    if (row == arrays.Count)
                    {
                        row = 0;
                    }
                    path++;
                    nextValue = arrays[row][currentValue];
                    if (nextValue >= 0 && visited[row, nextValue])
                    {
                        specialValue = 0;
                        path = 0;
                        if (specialValue > bestSpecialValue)
                        {
                            bestSpecialValue = specialValue;
                        }
                        break;
                    }
                    else
                    {
                        if (nextValue >= 0)
                        {
                            visited[row, nextValue] = true;
                        }
                    }
                    currentValue = nextValue;
                    continue;
                }
            }
        }

        //OUPTUT
        Console.WriteLine(bestSpecialValue);
    }

    static int GetBestArrayLength(List<int[]> list)
    {
        int bestLen = 0;
        for (int i = 0; i < list.Count; i++)
        {
            int currentLen = list[i].Length;
            if (currentLen > bestLen)
            {
                bestLen = currentLen;
            }
        }
        return bestLen;
    }
}
