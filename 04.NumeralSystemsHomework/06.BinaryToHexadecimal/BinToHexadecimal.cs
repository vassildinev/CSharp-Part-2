//Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;
class BinToHexadecimal
{
    static string BinToHex(string binNumber)
    {
        string hexNumber = "";
        int padding = 4 - binNumber.Length % 4 + binNumber.Length;
        binNumber = binNumber.PadLeft(padding, '0');
        for (int i = 0; i < binNumber.Length - 3; i += 4)
        {
            string hexDigit = binNumber.Substring(i,4);
            switch (hexDigit)
            {
                case "0000":
                    hexNumber += "0";
                    break;
                case "0001":
                    hexNumber += "1";
                    break;
                case "0010":
                    hexNumber += "2";
                    break;
                case "0011":
                    hexNumber += "3";
                    break;
                case "0100":
                    hexNumber += "4";
                    break;
                case "0101":
                    hexNumber += "5";
                    break;
                case "0110":
                    hexNumber += "6";
                    break;
                case "0111":
                    hexNumber += "7";
                    break;
                case "1000":
                    hexNumber += "8";
                    break;
                case "1001":
                    hexNumber += "9";
                    break;
                case "1010":
                    hexNumber += "A";
                    break;
                case "1011":
                    hexNumber += "B";
                    break;
                case "1100":
                    hexNumber += "C";
                    break;
                case "1101":
                    hexNumber += "D";
                    break;
                case "1110":
                    hexNumber += "E";
                    break;
                case "1111":
                    hexNumber += "F";
                    break;
                default:
                    break;
            }
        }
        return hexNumber;
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a number in binary system:");
        string binNumber = Console.ReadLine();

        //OUTPUT
        Console.WriteLine("Number in hexadecimal system is:\n{0}", BinToHex(binNumber));
    }
}
