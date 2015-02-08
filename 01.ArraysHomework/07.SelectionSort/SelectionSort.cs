//Use the Selection sort algorithm to sort an array:
//Find the smallest element, move it at the first position, 
//find the smallest from the rest, move it at the second position, etc.

using System;
using System.Linq;
class SelectionSort
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Array elements - on a single line, separated by space:");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        //SOLUTION
        for (int i = 0; i < numbers.Length; i++)
        {
            int smallestElement = numbers[i];
            int indexOfSmallestElement = i;

            //finds the smallest element without taking into account
            //the already sorted ones: j = i
            for (int j = i; j < numbers.Length; j++)
            {
                if (smallestElement > numbers[j])
                {
                    smallestElement = numbers[j];
                    indexOfSmallestElement = j;
                }
            }

            //switches the values of the current element and the current smallest value
            int temp = numbers[i];
            numbers[i] = numbers[indexOfSmallestElement];
            numbers[indexOfSmallestElement] = temp;
        }

        //OUTPUT
        Console.WriteLine(string.Join(" ", numbers));
    }
}