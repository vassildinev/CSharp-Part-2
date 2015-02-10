//Write a method that adds two polynomials.
//Represent them as arrays of their coefficients.

using System;
using System.Collections.Generic;
using System.Linq;
class Polynomials
{
    static int[] AddPolynomials(int[] polynomialA, int[] polynomialB)
    {
        int[] result = new int[polynomialA.Length];
        for (int i = 0; i < polynomialA.Length; i++)
        {
            result[i] = polynomialA[i] + polynomialB[i];
        }
        return result;
    }
    static int[] SubtractPolynomials(int[] polynomialA, int[] polynomialB)
    {
        int[] result = new int[polynomialA.Length];
        for (int i = 0; i < polynomialA.Length; i++)
        {
            result[i] = polynomialA[i] - polynomialB[i];
        }
        return result;
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter degree of polynomials:\n(E.g. f(x) = 1*x^3 + 0*x^2 + 1*x - 2 has a degree deg(f) = 3)");
        int degree = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter coefficients for first polynomial on a single line separated by space:");
        int[] polynomialA = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.WriteLine("Enter coefficients for second polynomial on a single line separated by space:");
        int[] polynomialB = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        //OUPUT
        Console.WriteLine();
        Console.WriteLine("Coefficients of result after addition:");
        Console.WriteLine(string.Join(" ", AddPolynomials(polynomialA, polynomialB)));

        Console.WriteLine();
        Console.WriteLine("Coefficients of result after substraction:");
        Console.WriteLine(string.Join(" ", SubtractPolynomials(polynomialA, polynomialB)));
    }
}
