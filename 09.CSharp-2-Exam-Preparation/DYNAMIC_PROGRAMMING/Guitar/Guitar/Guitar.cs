using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Guitar
{
    static void Main()
    {
        //INPUT
        int[] numberOfSongs = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int startVolume = int.Parse(Console.ReadLine());
        int maxVolume = int.Parse(Console.ReadLine());

        //SOLUTION
        bool[] possibleVolumes = new bool[maxVolume + 1];
        possibleVolumes[startVolume] = true;

        bool[] lastPossibleVolumes = possibleVolumes;

        foreach (int volumeChange in numberOfSongs)
        {
            bool[] currentPossibleVolumes = new bool[maxVolume + 1];

            for (int i = 0; i < maxVolume + 1; i++)
            {
                if (lastPossibleVolumes[i])
                {
                    int lowerVolume = i - volumeChange;
                    int higherVolume = i + volumeChange;
                    if (lowerVolume < 0 && higherVolume > maxVolume && i == 0)
                    {
                        Console.WriteLine(-1);
                        return;
                    }
                    else
                    {
                        if (lowerVolume >= 0)
                        {
                            currentPossibleVolumes[lowerVolume] = true;
                        }
                        if (higherVolume <= maxVolume)
                        {
                            currentPossibleVolumes[higherVolume] = true;
                        }
                    }
                }
            }
            lastPossibleVolumes = new bool[maxVolume + 1];
            CopyValues(currentPossibleVolumes, lastPossibleVolumes);
            CopyValues(currentPossibleVolumes, possibleVolumes);
        }

        //OUTPUT
        bool empty = true;
        for (int i = maxVolume; i >= 0; i--)
        {
            if (possibleVolumes[i])
            {
                Console.WriteLine(i);
                empty = false;
                return;
            }
        }
        if (empty)
        {
            Console.WriteLine(-1);
        }
    }

    private static void CopyValues(bool[] newPossibleVolumes, bool[] possibleVolumes)
    {
        for (int i = 0; i < possibleVolumes.Length; i++)
        {
            possibleVolumes[i] = newPossibleVolumes[i];
        }
    }
}
