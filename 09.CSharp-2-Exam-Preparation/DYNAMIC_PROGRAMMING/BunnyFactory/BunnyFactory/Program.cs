using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class BunnyFactory
{
    static void Main()
    {
        //INPUT
        List<int> bunnyCages = new List<int>();
        string line = Console.ReadLine();
        while (line != "END")
        {
            bunnyCages.Add(int.Parse(line));
            line = Console.ReadLine();
        }

        //SOLUTION
        int cycle = 1;
        int sum = cycle;
        int index = 0;
        while (true)
        {
            int currentSum = SumOfBunnies(bunnyCages, index, index + cycle);
            if (bunnyCages.Count < cycle)
            {
                break;
            }
            if (bunnyCages.Count - index < currentSum)
            {
                break;
            }
            index = index + sum;
            sum = currentSum;
            currentSum = SumOfBunnies(bunnyCages, index, index + sum);
            long product = ProductOfBunnies(bunnyCages, index, index + sum);
            index = index + sum;

            for (int i = 0; i < index; i++)
            {
                bunnyCages.RemoveAt(0);
            }

            bunnyCages.Reverse();

            while (product != 0)
            {
                bunnyCages.Add((int)(product % 10));
                product /= 10;
            }

            while (currentSum != 0)
            {
                bunnyCages.Add(currentSum % 10);
                currentSum /= 10;
            }
            while (bunnyCages.Contains(1) || bunnyCages.Contains(0))
            {
                bunnyCages.Remove(1);
                bunnyCages.Remove(0);
            }
            bunnyCages.Reverse();
            cycle++;
            index = 0;
            sum = cycle;
        }

        //OUTPUT
        Console.WriteLine(string.Join(" ", bunnyCages));
    }
    static int SumOfBunnies(List<int> cages, int startIndex, int endIndex)
    {
        int sum = 0;
        for (int i = startIndex; i < endIndex; i++)
        {
            sum += cages[i];
        }
        return sum;
    }

    static int ProductOfBunnies(List<int> cages, int startIndex, int endIndex)
    {
        int product = 1;
        for (int i = startIndex; i < endIndex; i++)
        {
            product *= cages[i];
        }
        return product;
    }

    static long Reverse(long x)
    {
        long rev = 0;
        while (x != 0)
        {
            rev = rev * 10 + x % 10;
            x = x / 10;
        }

        return rev;
    }
}