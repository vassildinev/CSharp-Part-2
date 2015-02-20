using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
static class MagicWords
{
    public static void Move(List<string> list, int currentIndex, int newIndex)
    {
        var item = list[currentIndex];
        list[currentIndex] = null;
        list.Insert(newIndex, item);
        list.Remove(null);
    }
    static void Main()
    {
        //INPUT
        int numberOfInputs = int.Parse(Console.ReadLine());
        var numbers = new List<string>();
        for (int i = 0; i < numberOfInputs; i++)
        {
            numbers.Add(Console.ReadLine());
        }

        //SOLUTION
        for (int i = 0; i < numbers.Count; i++)
        {
            Move(numbers, i, numbers[i].Length % (numberOfInputs + 1));
        }

        int maxLength = numbers.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length;

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < maxLength; i++)
        {
            foreach (string str in numbers)
            {
                if (str.Length - 1 >= i)
                {
                    sb.Append(str[i]);
                }
            }
        }

        //OUTPUT
        Console.WriteLine(sb.ToString());
    }
}