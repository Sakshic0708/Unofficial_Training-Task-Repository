using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_OTTPlatform
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Netflix netflix = new Netflix();
            netflix.Title = "";
            netflix.Duration = 60;
            netflix.ReleaseYear = 2008;
            netflix.Play();
            netflix.Pause();

           
        }
    }

    public abstract class StreamingPlatform
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public int ReleaseYear { get; set; }

        public abstract void Play();
        public abstract void Pause();
    }

    public class Netflix : StreamingPlatform
    {
        public override void Play()
        {
            // Code to play a video on Netflix
        }

        public override void Pause()
        {
            // Code to pause a video on Netflix
        }
    }


}
