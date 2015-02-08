//Write a program that reads two integer numbers N and K and an array of N elements from the console.
//Find in the array those K elements that have maximal sum.

using System;
using System.Linq;
class MaximumKSum
{
    static void Main()
    {
        ////The more interesting solution.

        //INPUT
        Console.WriteLine("Enter number of elements for the array (an integer < 64):");
        int numOfArrayElements = int.Parse(Console.ReadLine());

        Console.WriteLine("Fill the array with integers on single line, separated by space:");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.WriteLine("Enter number of elements for the search of max sum:");
        int numOfElementsForMaxSum = int.Parse(Console.ReadLine());

        //SOLUTION

        //My idea is to use the bit representation of a number,
        //which I am going to increase at each iteration in a for-loop,
        //as a sieve /сито/ for selecting numbers from the array.
        //This is how: I am going to count all the ones from bit 0
        //all the way to bit N, and if this count is equal to K,
        //I am going to take those numbers from the array,
        //whose index corresponds to the bit position of the ones
        //in my sieve. What I am actually doing is going through
        //all the combinations from N elements and selecting
        //those combinations that include ONLY K out of those N
        //elements. I am going to work only with long integers (K < 64),
        //but it can be done even for BigIntegers, the program
        //is just going to run significantly slower going through
        //every possible combination. So, further, if I have N elements,
        //I don't need to go through ALL possible combinations,
        //but only to the last, involving K elements.
        //Example: N = 10, K = 3, maxSieve = 1110000000
        //N = 8, K = 5, maxSieve = 11111000
        //The logic behind it is that any larger number
        //will contain more than K bits,
        //which means I don't have to take them into account.
        //But since I am going to work with small numbers,
        //I am just going to go through from 1 to 2^N - 1
        //(all combinations).
        //This method works for finding ANY kind of sum,
        //not just the maximum.

        long bestSum = long.MinValue;
        string kSum = "";

        for (long sieve = 1; sieve <= (1 << numOfArrayElements) - 1; sieve++)
        {
            int bitCounter = 0;
            long currentSum = 0;

            //count all the one bits in the sieve
            for (int i = 0; i <= numOfArrayElements - 1; i++)
            {
                if (((sieve >> i) & 1) == 1)
                {
                    bitCounter++;
                }
            }

            //find the current sum of K elements
            if (bitCounter == numOfElementsForMaxSum)
            {
                for (int i = 0; i <= numOfArrayElements - 1; i++)
                {
                    if (((sieve >> i) & 1) == 1)
                    {
                        currentSum += numbers[i];
                    }
                }

                if (currentSum > bestSum)
                {
                    bestSum = currentSum;

                    //save the best sum to a string and delete last best sum
                    kSum = "";
                    for (int i = 0; i <= numOfArrayElements - 1; i++)
                    {
                        if (((sieve >> i) & 1) == 1)
                        {
                            kSum += numbers[i].ToString();
                            kSum += " ";
                        }
                    }
                }
            }
        }

        //OUTPUT
        Console.WriteLine("Best sum elements:");
        Console.WriteLine(kSum);

        Console.WriteLine("Best sum:");
        Console.WriteLine(bestSum);

        //The easiest solution for this problem
        Console.WriteLine("Again, the same. This is another solution.");

        //INPUT
        Console.WriteLine("Enter number of elements for the array:");
        numOfArrayElements = int.Parse(Console.ReadLine());

        Console.WriteLine("Fill the array with integers on single line, separated by space:");
        numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.WriteLine("Enter number of elements for the search of max sum:");
        numOfElementsForMaxSum = int.Parse(Console.ReadLine());

        //SOLUTION
        int[] bestKSumElements = new int[numOfElementsForMaxSum];
        int indexOfLargestElement = -1;
        bestSum = 0;
        
        //Find the K largest numbers in the array
        //and their sum will be the largest.
        for (int j = 0; j < numOfElementsForMaxSum; j++)
        {
            int largestElement = numbers[0];
            for (int i = 0; i < numOfArrayElements; i++)
            {

                if (numbers[i] >= largestElement)
                {
                    largestElement = numbers[i];
                    indexOfLargestElement = i;
                }
            }
            bestKSumElements[j] = largestElement;
            numbers[indexOfLargestElement] = int.MinValue;
            bestSum += largestElement;
        }
        
        //OUTPUT
        Console.WriteLine("Best sum elements:");
        Console.WriteLine(string.Join(" ",bestKSumElements));

        Console.WriteLine("Best sum:");
        Console.WriteLine(bestSum);
    }
}
