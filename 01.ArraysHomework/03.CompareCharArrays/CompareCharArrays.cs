//Write a program that compares two char arrays lexicographically (letter by letter).

using System;
class CompareCharArrays
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter first char array (call it A):");
        char[] firstArray = Console.ReadLine().ToCharArray();

        Console.WriteLine("Enter second char array (call it B):");
        char[] secondArray = Console.ReadLine().ToCharArray();

        //SOLUTION

        //A string /char array/ A is lexicographically greater than another string /char array/ B
        //if ordered in a dictionary A would come after B.

        int comparisonResult = string.Compare(new string(firstArray), new string(secondArray));

        //OUTPUT
        if (comparisonResult > 0)
        {
            Console.WriteLine("A is lexicographically greater than B.");
        }
        else if (comparisonResult < 0)
        {
            Console.WriteLine("B is lexicographically greater than A.");
        }
        else
        {
            Console.WriteLine("A = B lexicographically.");
        }
    }
}
