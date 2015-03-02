using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Slides
{
    static void Main()
    {
        //INPUT

        // read dimensions
        int[] dimensions = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int width = dimensions[0];
        int height = dimensions[1];
        int depth = dimensions[2];

        // fill cube
        string[, ,] cube = new string[height, width, depth];

        for (int i = 0; i < height; i++)
        {
            string[] depthCells = Console.ReadLine()
                .Split('|')
                .Select(x => x.Trim())
                .ToArray();
            for (int k = 0; k < depth; k++)
            {
                string[] widthCells = depthCells[k]
                    .Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int j = 0; j < width; j++)
                {
                    string cell = widthCells[j];
                    cube[i, j, k] = cell;
                }
            }
        }

        // read ball start position
        int[] ball = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int ballW = ball[0];
        int ballH = 0;
        int ballD = ball[1];

        bool canDrop = true;

        string currentPos = cube[ballH, ballW, ballD];

        int newBallW = ballW;
        int newBallH = ballH;
        int newBallD = ballD;

        while (canDrop)
        {
            char command = currentPos[0];
            switch (command)
            {
                case 'B': canDrop = false; break;
                case 'E': newBallH++; break;
                case 'T':
                    {
                        int[] teleport = currentPos.Substring(2)
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
                        newBallW = teleport[0];
                        newBallD = teleport[1];
                        break;
                    }
                case 'S':
                    {
                        string slide = currentPos.Substring(2);
                        switch (slide)
                        {
                            case "L": newBallW--; newBallH++; break;
                            case "R": newBallW++; newBallH++; break;
                            case "F": newBallD--; newBallH++; break;
                            case "B": newBallD++; newBallH++; break;
                            case "FR": newBallD--; newBallW++; newBallH++; break;
                            case "FL": newBallD--; newBallW--; newBallH++; break;
                            case "BR": newBallD++; newBallW++; newBallH++; break;
                            case "BL": newBallD++; newBallW--; newBallH++; break;
                        }
                        break;
                    }
            }
            if ((newBallH < height)&&(newBallD < 0 || newBallH < 0 || newBallW < 0
              || newBallD >= depth || newBallW >= width))
            {
                canDrop = false;
                break;
            }
            else if(newBallH==height)
            {
                break;
            }
            currentPos = cube[newBallH, newBallW, newBallD];

            ballW = newBallW;
            ballH = newBallH;
            ballD = newBallD;
        }

        //OUTPUT
        if (canDrop)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
        Console.WriteLine("{0} {1} {2}", ballW, ballH, ballD);
    }
}
