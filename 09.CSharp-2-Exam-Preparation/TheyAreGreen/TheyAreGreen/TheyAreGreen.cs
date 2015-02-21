using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
static class TheyAreGreen
{
    static void Main(string[] args)
    {
        //INPUT
        int numberOfChars = int.Parse(Console.ReadLine());
        var letters = new List<char>(numberOfChars);

        for (int i = 0; i < numberOfChars; i++)
        {
            letters.Add(Console.ReadLine()[0]);
        }

        //SOLUTION
        var count = CountWords(letters.ToArray());

        //OUTPUT
        Console.WriteLine(count);
    }
    static bool IsGrisko(char[] text)
    {
        for (int i = 1; i < text.Length; i++)
        {
            if (text[i] == text[i - 1])
            {
                return false;
            }
        }
        return true;
    }
    private static int CountWords(char[] letters)
    {
        Array.Sort(letters);

        var count = 0;
        do
        {
            if (IsGrisko(letters))
            {
                count++;
            }
        }
        while (NextPermutation(letters));

        return count;
    }
    private static bool NextPermutation(char[] array)
    {
        for (int index = array.Length - 2; index >= 0; index--)
        {
            if (array[index] < array[index + 1])
            {
                int swapWithIndex = array.Length - 1;
                while (array[index] >= array[swapWithIndex])
                {
                    swapWithIndex--;
                }

                // Swap i-th and j-th elements
                var tmp = array[index];
                array[index] = array[swapWithIndex];
                array[swapWithIndex] = tmp;

                Array.Reverse(array, index + 1, array.Length - index - 1);
                return true;
            }
        }

        // No more permutations
        return false;
    }
}