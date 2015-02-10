//Write a method that asks the user for his name and prints “Hello, <name>”
//Write a program to test this method.

using System;
    class SayHello
    {
        static void Hello()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Well, hello, {0}! What a pleasure to meet you!", name);
        }
        static void Main()
        {
            Hello();
        }
    }