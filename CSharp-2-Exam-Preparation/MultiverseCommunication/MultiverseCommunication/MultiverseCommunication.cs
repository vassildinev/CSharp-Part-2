using System;
using System.Collections.Generic;
class MultiverseCommunication
{
    static void Main()
    {
        //INPUT
        string message = Console.ReadLine();

        //SOLUTION
        string[] codeNames = {
                       "CHU","TEL","OFT","IVA", "EMY","VNB", "POQ","ERI", "CAD", "K-A", "IIA","YLO","PLA"
                   };
        List<int> code = new List<int>();
        for (int i = 0; i < message.Length; i += 3)
        {
            for (int j = 0; j < 13; j++)
            {
                if (codeNames[j][0] == message[i]
                    && codeNames[j][1] == message[i + 1]
                    && codeNames[j][2] == message[i + 2])
                {
                    code.Add(j);
                }
            }
        }
        long result = 0;
        for (int i = 0; i < code.Count; i++)
        {
            result += code[i] * (long)Math.Pow(13, code.Count - 1 - i);
        }

        //OUTPUT
        Console.WriteLine(result);
    }
}
