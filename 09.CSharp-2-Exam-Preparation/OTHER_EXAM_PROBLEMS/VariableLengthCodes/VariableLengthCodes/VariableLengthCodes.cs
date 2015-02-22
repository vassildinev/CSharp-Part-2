using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class VariableLengthCodes
{
    private static string ReadLine()
    {
        Stream inputStream = Console.OpenStandardInput(10000);
        byte[] bytes = new byte[10000];
        int outputLength = inputStream.Read(bytes, 0, 10000);
        char[] chars = Encoding.UTF7.GetChars(bytes, 0, outputLength);
        return new string(chars);
    }
    static void Main()
    {
        //INPUT
        var bitCodes = Console.ReadLine().Trim()
            .Split(' ')
            .Select(x => Convert.ToString(byte.Parse(x), 2))
            .ToList();

        int numberOfMembersInCodeTable = int.Parse(Console.ReadLine());

        string[] codeTable = new string[numberOfMembersInCodeTable];
        for (int i = 0; i < numberOfMembersInCodeTable; i++)
        {
            codeTable[i] = Console.ReadLine();
        }

        var codeTableCodes = codeTable
            .Select(x => x.Remove(0,1))
            .Select(int.Parse)
            .ToArray();

        var codeTableChars = codeTable
            .Select(x => x[0].ToString())
            .ToArray();

        //SOLUTION
        StringBuilder sb = new StringBuilder(4000);
        foreach (string bitCode in bitCodes)
        {
            sb.Append(bitCode.PadLeft(8,'0'));
        }

        string encodedMsg = sb.ToString().TrimEnd('0');

        string[] encodedChars = encodedMsg.Split(new char[] { '0' }, StringSplitOptions.RemoveEmptyEntries);

        sb.Clear();

        foreach (string encodedChar in encodedChars)
        {
            for (int i = 0; i < codeTableCodes.Length; i++)
            {
                if (codeTableCodes[i] == encodedChar.Length)
                {
                    Console.Write(codeTableChars[i]);
                }
            }
        }
    }
}