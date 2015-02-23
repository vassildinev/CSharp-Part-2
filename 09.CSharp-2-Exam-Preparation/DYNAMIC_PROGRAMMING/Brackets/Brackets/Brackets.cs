using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Brackets
{
    static void Main()
    {
        //INPUT
        string input = Console.ReadLine();
        int length = input.Length;

        //SOLUTION
        BigInteger[][] matrix = new BigInteger[2][];
        matrix[0] = new BigInteger[length + 1 + 2];
        matrix[1] = new BigInteger[length + 1 + 2];

        matrix[0][1] = 1;

        for (int i = 0; i < length; i++)
        {
            for (int col = 1; col < length + 1 + 1; col++)
            {
                if (input[i]=='(')
                {
                    matrix[1][col] += matrix[0][col - 1];
                }
                else if (input[i]==')')
                {
                    matrix[1][col] += matrix[0][col + 1];
                }
                else if (input[i] == '?')
                {
                    matrix[1][col] += matrix[0][col - 1];
                    matrix[1][col] += matrix[0][col + 1];
                }
            }
            CopyRow(matrix[0], matrix[1]);
            matrix[1] = new BigInteger[length + 1 + 2];
        }

        Console.WriteLine(matrix[0][1]);
    }

    private static void CopyRow(BigInteger[] bigInteger1, BigInteger[] bigInteger2)
    {

        for (int i = 0; i < bigInteger1.Length; i++)
        {
            bigInteger1[i] = bigInteger2[i];
        }
    }
}