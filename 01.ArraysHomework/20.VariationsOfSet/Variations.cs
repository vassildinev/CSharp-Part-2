//Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N].

using System;
using System.Collections.Generic;
using System.Linq;
class Variations
{
    public static List<List<T>> GetVariations<T>(List<T> elements, int k)
    {
        List<List<T>> result = new List<List<T>>();
        if (k == 1)
        {
            result.AddRange(elements.Select(element => new List<T>() { element }));
        }
        else
        {
            foreach (T element in elements)
            {
                List<T> subelements = elements.ToList();
                List<List<T>> subvariations = GetVariations(subelements, k - 1);
                foreach (List<T> subvariation in subvariations)
                {
                    subvariation.Add(element);
                    result.Add(subvariation);
                }
            }
        }
        return result;
    }
    static void Main(string[] args)
    {
        //INPUT
        Console.WriteLine("Value for the upper limit N to generate a list of numbers\n" +
            "[1...N] and print all variations:");
        List<int> numbers = Enumerable.Range(1, int.Parse(Console.ReadLine())).ToList();

        Console.WriteLine("Value K for number of elements out of the N elements\nfor which to print variations:");
        int classOfVariations = int.Parse(Console.ReadLine());

        //SOLUTION
        List<List<int>> variations = GetVariations<int>(numbers, classOfVariations);

        //OUTPUT
        foreach (var variation in variations)
        {
            Console.WriteLine(string.Join(" ", variation));
        }
    }
}