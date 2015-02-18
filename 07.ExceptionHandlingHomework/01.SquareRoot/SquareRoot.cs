//Write a program that reads an integer number and calculates and prints its square root.
//If the number is invalid or negative, print Invalid number.
//In all cases finally print Goodbye.
//Use try-catch-finally block.

using System;
class SquareRoot
{
    static void Main()
    {
        try
        {
            //INPUT
            Console.WriteLine("Enter an integer number:");
            int number = int.Parse(Console.ReadLine());

            //SOLUTION
            if (number < 0)
            {
                throw new ArgumentException();
            }
            double sqrt = Math.Sqrt(number);

            //OUTPUT
            Console.WriteLine("Square root:\n{0}\n", sqrt);
        }
        catch
        {
            Console.WriteLine("\nINVALID_NUMBER");
        }
        finally
        {
            Console.WriteLine("Goodbye.\n");
        }
    }
}
