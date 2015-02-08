//Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N].

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Combinations
{
    public static IEnumerable<IEnumerable<int>> GetPowerSet(List<int> list)
    {
        return from m in Enumerable.Range(0, 1 << list.Count)
               select
                   from i in Enumerable.Range(0, list.Count)
                   where (m & (1 << i)) != 0
                   select list[i];
    }
    static void Main(string[] args)
    {
        //INPUT
        Console.WriteLine("Value for the upper limit N to generate a list of numbers\n" +
            "[1...N] and print all combinations:");
        List<int> numbers = Enumerable.Range(1, int.Parse(Console.ReadLine())).ToList();

        Console.WriteLine("Value K for number of elements out of the N elements\nfor which to print combinations:");
        int classOfCombinations = int.Parse(Console.ReadLine());

        //SOLUTION
        IEnumerable<IEnumerable<int>> results = GetPowerSet(numbers);

        //OUTPUT
        foreach (var result in results)
        {
            if (result.Count() == classOfCombinations)
                Console.WriteLine(string.Join(" ", result));
        }
    }
}