//Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;
class HexToBin
{
    static string HexToBinary(string hexNumber)
    {
        string binNumber = "";
        for (int i = 0; i < hexNumber.Length; i++)
        {
            switch (hexNumber[i])
            {
                case '0':
                    binNumber += "0000";
                    break;
                case '1':
                    binNumber += "0001";
                    break;
                case '2':
                    binNumber += "0010";
                    break;
                case '3':
                    binNumber += "0011";
                    break;
                case '4':
                    binNumber += "0100";
                    break;
                case '5':
                    binNumber += "0101";
                    break;
                case '6':
                    binNumber += "0110";
                    break;
                case '7':
                    binNumber += "0111";
                    break;
                case '8':
                    binNumber += "1000";
                    break;
                case '9':
                    binNumber += "1001";
                    break;
                case 'A':
                case 'a':
                    binNumber += "1010";
                    break;
                case 'B':
                case 'b':
                    binNumber += "1011";
                    break;
                case 'C':
                case 'c':
                    binNumber += "1100";
                    break;
                case 'D':
                case 'd':
                    binNumber += "1101";
                    break;
                case 'E':
                case 'e':
                    binNumber += "1110";
                    break;
                case 'F':
                case 'f':
                    binNumber += "1111";
                    break;
                default:
                    break;
            }
        }
        return binNumber;
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a number in hexadecimal system:");
        string hex = Console.ReadLine();

        //OUTPUT
        Console.WriteLine("Number in binary system is:\n{0}", HexToBinary(hex));
    }
}