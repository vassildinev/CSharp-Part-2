//Write a program that calculates the value of given arithmetical expression.
//The expression can contain the following elements only:
//  Real numbers, e.g. 5, 18.33, 3.14159, 12.6
//  Arithmetic operators: +, -, *, / (standard priorities)
//  Mathematical functions: ln(x), sqrt(x), pow(x,y)
//  Brackets (for changing the default priorities): (, )

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
class Arithmetics
{
    static List<char> arithmeticOperators = new List<char> { '+', '-', '*', '/' };
    static List<char> brackets = new List<char> { '(', ')' };
    static List<string> functions = new List<string> { "sqrt", "pow", "ln" };

    static int Priority(string arithmeticOperator)
    {
        if (arithmeticOperator == "+" || arithmeticOperator == "-")
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }
    static List<string> SeparateTokens(string input)
    {
        var result = new List<string>();
        var numbers = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '-' && (i == 0 || input[i - 1] == '(' || input[i - 1] == ','))
            {
                numbers.Append('-');
            }
            else if (char.IsDigit(input[i]) || input[i] == '.')
            {
                numbers.Append(input[i]);
            }
            else if (!char.IsDigit(input[i]) && !(input[i] == '.') && numbers.Length != 0)
            {
                result.Add(numbers.ToString());
                numbers.Clear();
                i--;
            }
            else if (arithmeticOperators.Contains(input[i]) || brackets.Contains(input[i]))
            {
                result.Add(input[i].ToString());
            }
            else if (input[i] == ',')
            {
                result.Add(input[i].ToString());
            }
            else if (i + 1 < input.Length && input.Substring(i, 2).ToLower() == "ln")
            {
                result.Add("ln");
                ++i;
            }
            else if (i + 2 < input.Length && input.Substring(i, 3).ToLower() == "pow")
            {
                result.Add("pow");
                i += 2;
            }
            else if (i + 3 < input.Length && input.Substring(i, 4).ToLower() == "sqrt")
            {
                result.Add("sqrt");
                i += 3;
            }
            else
            {
                Console.WriteLine("INVALID_EXPRESSION!");
            }
        }
        if (numbers.Length != 0)
        {
            result.Add(numbers.ToString());
        }
        return result;
    }
    static Queue<string> RPN(List<string> tokens)
    {
        Stack<string> stack = new Stack<string>();
        Queue<string> queue = new Queue<string>();

        for (int i = 0; i < tokens.Count(); i++)
        {
            var currentToken = tokens[i];
            double number;
            if (double.TryParse(currentToken, out number))
            {
                queue.Enqueue(currentToken);
            }
            else if (functions.Contains(currentToken))
            {
                stack.Push(currentToken);
            }
            else if (currentToken == ",")
            {
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("INVALID SEPARATOR OR BRACKET!");
                }
                while (stack.Peek() != "(")
                {
                    string currentOperator = stack.Pop();
                    queue.Enqueue(currentOperator);
                }
            }
            else if (arithmeticOperators.Contains(currentToken[0]))
            {
                while (stack.Count != 0 && arithmeticOperators.Contains(stack.Peek()[0]) && Priority(currentToken) <= Priority(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }
                stack.Push(currentToken);
            }
            else if (currentToken == "(")
            {
                stack.Push(currentToken);
            }
            else if (currentToken == ")")
            {
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("INVALID BRACKETS!");
                }
                while (stack.Peek() != "(")
                {
                    string currentOperator = stack.Pop();
                    queue.Enqueue(currentOperator);
                }
                stack.Pop();
                if (stack.Count != 0 && functions.Contains(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }
            }
        }
        while (stack.Count != 0)
        {
            if (brackets.Contains(stack.Peek()[0]))
            {
                throw new ArgumentException("INVALID BRACKETS!");
            }
            queue.Enqueue(stack.Pop());
        }
        return queue;
    }
    static double CalculateExpression(Queue<string> queue)
    {
        Stack<double> stack = new Stack<double>();
        while (queue.Count != 0)
        {
            string currentToken = queue.Dequeue();
            double number;
            if (double.TryParse(currentToken, out number))
            {
                stack.Push(number);
            }
            else if (arithmeticOperators.Contains(currentToken[0]) || functions.Contains(currentToken))
            {
                if (currentToken == "+")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("INVALID EXPRESSION!");
                    }
                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();
                    stack.Push(firstValue + secondValue);
                }
                else if (currentToken == "-")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("INVALID EXPRESSION!");
                    }
                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();
                    stack.Push(secondValue - firstValue);
                }
                else if (currentToken == "*")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("INVALID EXPRESSION!");
                    }
                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();
                    stack.Push(secondValue * firstValue);
                }
                else if (currentToken == "/")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("INVALID EXPRESSION!");
                    }
                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();
                    stack.Push(secondValue / firstValue);
                }
                else if (currentToken == "pow")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("INVALID EXPRESSION!");
                    }
                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();
                    stack.Push(Math.Pow(secondValue, firstValue));
                }
                else if (currentToken == "sqrt")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("INVALID EXPRESSION!");
                    }
                    double value = stack.Pop();
                    stack.Push(Math.Sqrt(value));
                }
                else if (currentToken == "ln")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("INVALID EXPRESSION!");
                    }
                    double value = stack.Pop();
                    stack.Push(Math.Log(value));
                }
            }
        }
        if (stack.Count == 1)
        {
            return stack.Pop();
        }
        else
        {
            throw new ArgumentException("INVALID EXPRESSION!");
        }
    }
    static void Main()
    {
        //INPUT
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        Console.WriteLine("Enter a math expression using operators +, -, *, / and functions sqrt, ln, pow:\n");
        string input = Console.ReadLine().Trim();

        //SOLUTION
        string trimmedInput = input.Replace(" ", string.Empty);
        var separatedTokens = SeparateTokens(trimmedInput);
        var reversePolishNotation = RPN(separatedTokens);
        var result = CalculateExpression(reversePolishNotation);

        //OUPTUT
        Console.WriteLine("\nResult after calculation:\n{0:0.00}\n", result);
    }
}
