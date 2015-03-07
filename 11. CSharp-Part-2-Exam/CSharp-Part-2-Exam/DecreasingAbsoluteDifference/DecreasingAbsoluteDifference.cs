using System;
using System.Collections.Generic;
using System.Linq;
class DecreasingAbsoluteDifference
{
    static void Main()
    {
        //INPUT, SOLUTION, OUTPUT
        int numberOfSequences = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfSequences; i++)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var differences = new List<int>();
            int currentNum = 0;
            int nextNum = 0;
            for (int j = 0; j < numbers.Length - 1; j++)
            {
                currentNum = numbers[j];
                nextNum = numbers[j + 1];
                differences.Add(Math.Max(currentNum, nextNum) - Math.Min(currentNum, nextNum));
            }
            Console.WriteLine(checkSequence(differences));
            differences.Clear();
        }
    }
    static bool checkSequence(List<int> list)
    {
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i - 1] >= list[i] && Math.Abs(list[i - 1] - list[i]) <= 1)
            {
                continue;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}
