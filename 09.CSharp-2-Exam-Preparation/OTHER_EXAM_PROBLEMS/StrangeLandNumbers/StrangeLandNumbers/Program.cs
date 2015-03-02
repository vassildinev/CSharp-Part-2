using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace StrangeLandNumbers
{
    class Program
    {
        static List<string> strangeLandDigits = new List<string>()
            {
                "f",  "bIN",  "oBJEC", "mNTRAVL", "lPVKNQ", "pNWE", "hT"
            };
        static void Main(string[] args)
        {
            //INPUT
            string input = Console.ReadLine();

            //SOLUTION
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                foreach (string word in strangeLandDigits)
                {
                    if (i + word.Length - 1 < input.Length)
                    {
                        string digit = input.Substring(i, word.Length);
                        if (digit == word)
                        {
                            sb.Append(strangeLandDigits.IndexOf(word));
                        }
                    }
                }
            }

            BigInteger strangeLandNumber = BigInteger.Parse(sb.ToString());
            sb.Clear();

            BigInteger result = 0;
            int power = 0;

            while (strangeLandNumber!=0)
            {
                int digit = (int)(strangeLandNumber % 10);
                result += digit * (BigInteger)Math.Pow(7, power);
                power++;
                strangeLandNumber /= 10;
            }

            //OUTPUT
            Console.WriteLine(result);
        }
    }
}
