//Write a program that generates and prints to the console 10 random values in the range [100, 200].

using System;
class RandomNumbers
{
    static void Main()
    {
        //INPUT
        int lowValue = 100;
        int highValue = 200;
        int numberOfOutputs = 10;

        //SOLUTION
        Random rand = new Random();

        //OUTPUT
        Console.WriteLine("Ten random numbers in range [100, 200]:");
        for (int i = 0; i < numberOfOutputs; i++)
        {
            Console.WriteLine(rand.Next(lowValue, highValue + 1));
        }
    }
}