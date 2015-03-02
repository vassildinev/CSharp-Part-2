using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.IO;
class TwoGirls
{
    private static string ReadLine()
    {
        Stream inputStream = Console.OpenStandardInput(1000000);
        byte[] bytes = new byte[100000];
        int outputLength = inputStream.Read(bytes, 0, 100000);
        //Console.WriteLine(outputLength);
        char[] chars = Encoding.UTF7.GetChars(bytes, 0, outputLength);
        return new string(chars);
    }
    static void Main()
    {
        //INPUT
        BigInteger[] pathCells = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(BigInteger.Parse)
            .ToArray();

        //SOLUTION
        int mollyIndex = 0;
        int dollyIndex = pathCells.Length - 1;

        BigInteger mollyFlowers = pathCells[mollyIndex];
        BigInteger dollyFlowers = pathCells[dollyIndex];

        if (pathCells[mollyIndex] == 0 && pathCells[dollyIndex] == 0)
        {
            Console.WriteLine("Draw");
            Console.WriteLine("{0} {1}", mollyFlowers, dollyFlowers);
            return;
        }
        else
        {
            if (pathCells[mollyIndex] == 0)
            {
                Console.WriteLine("Dolly");
                Console.WriteLine("{0} {1}", mollyFlowers, dollyFlowers);
                return;
            }
            else if (pathCells[dollyIndex] == 0)
            {
                Console.WriteLine("Molly");
                Console.WriteLine("{0} {1}", mollyFlowers, dollyFlowers);
                return;
            }
        }

        int oldMolly = mollyIndex;
        int oldDolly = dollyIndex;

        bool mollyFail = false;
        bool dollyFail = false;

        mollyIndex = (int)((mollyIndex + pathCells[mollyIndex]) % pathCells.Length);
        dollyIndex = (int)((dollyIndex - pathCells[dollyIndex]) % pathCells.Length);
        if (dollyIndex < 0)
        {
            dollyIndex = pathCells.Length + dollyIndex;
        }

        pathCells[oldMolly] = 0;
        pathCells[oldDolly] = 0;

        if (oldMolly == mollyIndex && oldDolly == dollyIndex)
        {
            Console.WriteLine("Draw");
            Console.WriteLine("{0} {1}", mollyFlowers, dollyFlowers);
            return;
        }
        else
        {
            if (oldMolly == mollyIndex)
            {
                Console.WriteLine("Dolly");
                dollyFlowers += pathCells[dollyIndex];
                Console.WriteLine("{0} {1}", mollyFlowers, dollyFlowers);
                return;
            }
            else if (oldDolly == dollyIndex)
            {
                Console.WriteLine("Molly");
                mollyFlowers += pathCells[mollyIndex];
                Console.WriteLine("{0} {1}", mollyFlowers, dollyFlowers);
                return;
            }
        }

        while (true)
        {
            int oldMollyIndex = mollyIndex;
            int oldDollyIndex = dollyIndex;

            if (mollyIndex == dollyIndex)
            {

                mollyFlowers += pathCells[mollyIndex] / 2;
                dollyFlowers += pathCells[dollyIndex] / 2;

                mollyIndex = (int)((mollyIndex + pathCells[mollyIndex]) % pathCells.Length);
                dollyIndex = (int)((dollyIndex - pathCells[dollyIndex]) % pathCells.Length);
                if (dollyIndex < 0)
                {
                    dollyIndex = pathCells.Length + dollyIndex;
                }

                if (pathCells[mollyIndex] == 0 && pathCells[dollyIndex] == 0)
                {
                    mollyFail = true;
                    dollyFail = true;
                    break;
                }
                else
                {
                    if (pathCells[mollyIndex] == 0)
                    {
                        mollyFail = true;
                        dollyFlowers += pathCells[dollyIndex];
                        break;
                    }
                    else if (pathCells[dollyIndex] == 0)
                    {
                        dollyFail = true;
                        mollyFlowers += pathCells[mollyIndex];
                        break;
                    }
                }

                if (pathCells[mollyIndex] % 2 == 1)
                {
                    pathCells[oldMollyIndex] = 1;
                }
                else
                {
                    pathCells[oldMollyIndex] = 0;
                }
                continue;
            }
            else
            {
                mollyFlowers += pathCells[mollyIndex];
                dollyFlowers += pathCells[dollyIndex];

                mollyIndex = (int)((mollyIndex + pathCells[mollyIndex]) % pathCells.Length);
                dollyIndex = (int)((dollyIndex - pathCells[dollyIndex]) % pathCells.Length);

                if (dollyIndex < 0)
                {
                    dollyIndex = pathCells.Length + dollyIndex;
                }

                if (pathCells[mollyIndex] == 0 && pathCells[dollyIndex] == 0)
                {
                    mollyFail = true;
                    dollyFail = true;
                    break;
                }
                else
                {
                    if (pathCells[mollyIndex] == 0)
                    {
                        mollyFail = true;
                        dollyFlowers += pathCells[dollyIndex];
                        break;
                    }
                    else if (pathCells[dollyIndex] == 0)
                    {
                        dollyFail = true;
                        mollyFlowers += pathCells[mollyIndex];
                        break;
                    }
                }

                pathCells[oldMollyIndex] = 0;
                pathCells[oldDollyIndex] = 0;

                if (oldMolly == mollyIndex && oldDolly == dollyIndex)
                {
                    Console.WriteLine("Draw");
                    Console.WriteLine("{0} {1}", mollyFlowers, dollyFlowers);
                    return;
                }
                else
                {
                    if (oldMolly == mollyIndex)
                    {
                        Console.WriteLine("Dolly");
                        dollyFlowers += pathCells[dollyIndex];
                        Console.WriteLine("{0} {1}", mollyFlowers, dollyFlowers);
                        return;
                    }
                    else if (oldDolly == dollyIndex)
                    {
                        Console.WriteLine("Molly");
                        mollyFlowers += pathCells[mollyIndex];
                        Console.WriteLine("{0} {1}", mollyFlowers, dollyFlowers);
                        return;
                    }
                }
            }
        }

        if (mollyFail && dollyFail)
        {
            Console.WriteLine("Draw");
            Console.WriteLine("{0} {1}", mollyFlowers, dollyFlowers);
        }
        else
        {
            if (mollyFail)
            {
                Console.WriteLine("Dolly");
                Console.WriteLine("{0} {1}", mollyFlowers, dollyFlowers);
            }
            else if (dollyFail)
            {
                Console.WriteLine("Molly");
                Console.WriteLine("{0} {1}", mollyFlowers, dollyFlowers);
            }
        }
    }
}