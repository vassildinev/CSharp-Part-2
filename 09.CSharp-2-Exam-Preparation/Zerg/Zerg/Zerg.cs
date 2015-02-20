using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Zerg
{
    static void Main()
    {
        //INPUT
        string message = Console.ReadLine();

        //SOLUTION
        string[] codeNames = {

                "Rawr","Rrrr","Hsst", "Ssst", "Grrr","Rarr", "Mrrr", "Psst","Uaah", "Uaha","Zzzz", "Bauu", "Djav", "Myau","Gruh"

                   };
        List<int> code = new List<int>();
        for (int i = 0; i < message.Length; i += 4)
        {
            for (int j = 0; j < 15; j++)
            {
                if (codeNames[j][0] == message[i]
                    && codeNames[j][1] == message[i + 1]
                    && codeNames[j][2] == message[i + 2]
                    && codeNames[j][3] == message[i + 3])
                {
                    code.Add(j);
                }
            }
        }
        long result = 0;
        for (int i = 0; i < code.Count; i++)
        {
            result += code[i] * (long)Math.Pow(15, code.Count - 1 - i);
        }

        //OUTPUT
        Console.WriteLine(result);
    }
}
