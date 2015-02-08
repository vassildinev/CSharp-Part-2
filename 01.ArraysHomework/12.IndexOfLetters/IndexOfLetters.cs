//Write a program that creates an array containing all letters from the alphabet (A-Z).
//Read a word from the console and print the index of each of its letters in the array.

using System;
using System.Collections.Generic;
using System.Linq;
class IndexOfLetters
{
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a word:");
        string word = Console.ReadLine().ToUpper();

        //SOLUTION
        char[] letters = Enumerable.Range(65, 26).ToArray().Select(x => (char)x).ToArray();

        //Letters: A  B  C  D  E  F  G  H  I  J  K  L  M  N  O  P  Q  R  S  T  U  V  W  X  Y  Z
        //Indices: 0  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25

        //OUTPUT
        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 0; j < letters.Length; j++)
            {
                if (word[i] == letters[j])
                {
                    Console.WriteLine("{0} has index {1}", word[i], j);
                }
            }
        }
    }
}
