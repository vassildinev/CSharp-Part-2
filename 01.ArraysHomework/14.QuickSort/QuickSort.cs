//Write a program that sorts an array of strings using the Quick sort algorithm.
//i.e. a lexicographical sort, not case-sensitive.

using System;
using System.Collections.Generic;
using System.Linq;

class QuickSort
{
    public static void Quicksort(IComparable[] elements, int left, int right)
    {
        int i = left, j = right;
        IComparable pivot = elements[(left + right) / 2];

        while (i <= j)
        {
            while (elements[i].CompareTo(pivot) < 0)
            {
                i++;
            }

            while (elements[j].CompareTo(pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                // Swap
                IComparable tmp = elements[i];
                elements[i] = elements[j];
                elements[j] = tmp;

                i++;
                j--;
            }
        }

        // Recursive calls
        if (left < j)
        {
            Quicksort(elements, left, j);
        }

        if (i < right)
        {
            Quicksort(elements, i, right);
        }
    }
    static void Main()
    {
        //car bus stop mix song phone message csharp telerik ninja - example input
        //bus car csharp message mix ninja phone song stop telerik - example output

        // INPUT
        Console.WriteLine("Elements of string array on a single line, separated by space:");
        string[] input = Console.ReadLine().Split(' ');

        // SOLUTION
        Quicksort(input, 0, input.Length - 1);

        // OUTPUT
        Console.WriteLine();
        Console.WriteLine(string.Join(" ", input));
        Console.WriteLine();
    }
}