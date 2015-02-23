using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class AcademyTasks
{
    static void Main()
    {
        //INPUT
        int[] pleasantness = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int treshold = int.Parse(Console.ReadLine());

        //SOLUTION
        int max = pleasantness[0];
        int min = pleasantness[0];
        int minIndex = 0;
        int maxIndex = 0;
        bool foundSolution = false;
        for (int i = 0; i < pleasantness.Length; i++)
        {
            if (max < pleasantness[i])
            {
                max = pleasantness[i];
            }
            if (min > pleasantness[i])
            {
                min = pleasantness[i];
            }
            if (max - min >= treshold)
            {
                foundSolution = true;
                minIndex = pleasantness.ToList().IndexOf(min);
                maxIndex = pleasantness.ToList().IndexOf(max);
                break;
            }
        }

        if (!foundSolution)
        {
            Console.WriteLine(pleasantness.Length);
            return;
        }

        int solvedProblems = 1;
        if (maxIndex % 2 == 0 && minIndex % 2 == 0)
        {
            solvedProblems = Math.Max(maxIndex, minIndex) / 2 + 1;
        }
        else
        {
            if (Math.Min(maxIndex, minIndex) % 2 == 0)
            {
                solvedProblems += Math.Min(maxIndex, minIndex) / 2;
            }
            else
            {
                solvedProblems += Math.Min(maxIndex, minIndex) / 2 + 1;
            }

            if ((Math.Max(maxIndex, minIndex) - Math.Min(maxIndex, minIndex)) % 2 == 0)
            {
                solvedProblems += (Math.Max(maxIndex, minIndex) - Math.Min(maxIndex, minIndex)) / 2;
            }
            else
            {
                solvedProblems += (Math.Max(maxIndex, minIndex) - Math.Min(maxIndex, minIndex)) / 2 + 1;
            }
        }
        //OUTPUT
        int shortestLongestPath = 0;
        if (pleasantness.Length % 2 == 0)
        {
            shortestLongestPath = pleasantness.Length / 2;
        }
        else
        {
            shortestLongestPath = (pleasantness.Length + 1) / 2;
        }
        if (solvedProblems <= shortestLongestPath)
        {
            Console.WriteLine(solvedProblems);
        }
        else
        {
            Console.WriteLine(shortestLongestPath);
        }
    }
}