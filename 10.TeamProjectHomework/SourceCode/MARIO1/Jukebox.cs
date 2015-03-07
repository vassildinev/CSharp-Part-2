using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

class Jukebox
{
    SoundPlayer snd;

    public Jukebox(string path)
    {
        try
        {
            snd = new SoundPlayer(path);

        }
        catch
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("MUTE!!!1!");
        }
    }

    public void Play()
    {
        snd.PlayLooping();
    }

    public void Stop()
    {
        snd.Stop();
    }

    public void Dispose()
    {
        snd.Dispose();
    }

}