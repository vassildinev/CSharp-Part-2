//Write methods that calculate the surface of a triangle by given:
//Side and an altitude to it;
//Three sides;
//Two sides and an angle between them;
//Use System.Math.

using System;
class Surface
{
    static decimal TriangleArea(double side, double alt)
    {
        decimal area = (decimal)(side * alt / 2);
        return area;
    }

    static decimal TriangleArea(double sideA, double sideB, double sideC)
    {
        double halfPerimeter = (sideA + sideB + sideC) / 2D;
        decimal area = (decimal)Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
        return area;
    }

    static decimal TriangleArea(double sideA, double sideB, float angle)
    {
        decimal area = (decimal)(sideA * sideB * Math.Sin(angle / 180 * Math.PI) / 2);
        return area;
    }
    static void Main()
    {
        //INPUT AND OUTPUT
        Console.WriteLine("Enter for a triangle a side and an altitude to it:");
        Console.WriteLine("Area = {0:F3}", TriangleArea(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));

        Console.WriteLine();
        Console.WriteLine("Enter for a triangle three sides:");
        Console.WriteLine("Area = {0:F3}", TriangleArea(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));

        Console.WriteLine();
        Console.WriteLine("Enter for a triangle two sides and an angle between them in degrees:");
        Console.WriteLine("Area = {0:F3}", TriangleArea(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), float.Parse(Console.ReadLine())));

    }
}
