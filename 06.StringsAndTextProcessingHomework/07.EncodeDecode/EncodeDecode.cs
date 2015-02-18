//Write a program that encodes and decodes a string using given encryption key (cipher).
//The key consists of a sequence of characters.
//The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string 
//with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.

using System;
using System.Text;
using System.Linq;
class EncodeDecode
{
    static string Encode(string input, string cipher)
    {
        char[] chars = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            chars[i] = (char)(input[i] ^ cipher[i % cipher.Length]);
        }
        return string.Join(string.Empty, chars);
    }
    static string Decode(string input, string cipher)
    {
        char[] chars = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            chars[i] = (char)(input[i] ^ cipher[i % cipher.Length]);
        }
        return string.Join(string.Empty, chars);
    }
    static void Main()
    {
        //INPUT
        Console.WriteLine("Enter a string to encode/decode.");
        string input = Console.ReadLine();

        Console.WriteLine("\nEnter a cipher to use for encoding/decoding:");
        string cipher = Console.ReadLine();

        //SOLUTION
        string encoded = Encode(input, cipher);
        string decoded = Decode(encoded, cipher);

        //OUTPUT
        Console.WriteLine("\nEncoded string:\n{0}\n", encoded);
        Console.WriteLine("Decoded string:\n{0}\n", decoded);
    }
}
