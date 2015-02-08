//Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N].

using System;
using System.Collections.Generic;
using System.Linq;
class Permutations
{
    public static List<List<T>> GetPermutations<T>(List<T> list, int chainLimit)
    {
        if (list.Count() == 1)
            return new List<List<T>> { list };
        return list
            .Select((outer, outerIndex) =>
                        GetPermutations(list.Where((inner, innerIndex) => innerIndex != outerIndex).ToList(), chainLimit)
            .Select(perms => (new List<T> { outer }).Union(perms).Take(chainLimit)))
            .SelectMany<IEnumerable<IEnumerable<T>>, List<T>>(sub => sub.Select<IEnumerable<T>, List<T>>(s => s.ToList()))
            .Distinct(new PermutationComparer<T>()).ToList();
    }
    class PermutationComparer<T> : IEqualityComparer<List<T>>
    {
        public bool Equals(List<T> x, List<T> y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(List<T> obj)
        {
            return (int)obj.Average(o => o.GetHashCode());
        }
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Value for the upper limit N to generate a list of numbers\n"+
            "[1...N] and print all permutations:");
        List<int> numbers = Enumerable.Range(1, int.Parse(Console.ReadLine())).ToList();

        //SOLUTION
        List<List<int>> permutations = GetPermutations<int>(numbers, numbers.Count());

        //OUTPUT
        Console.WriteLine("\nPermutations:");
        foreach (var permutation in permutations)
        {
            Console.WriteLine(string.Join(" ", permutation));
        }
    }
}
