using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anilabel;

namespace Anilabel.Test
{
    class AnimeVideoTester
    {
        static void Main(string[] args)
        {
            //AnimeVideo video = new AnimeVideo("Fullmetal Alchemist Brotherhood - 15 - (1280 x 720)[TMD-ASU]");
            AnimeVideo video = new AnimeVideo("[AIF]Initial_D_Stage_01_Act_01_-_The_Ultimate_Tofu_Store_Drift_480p (noobs) [GoLdEnSuN][Dual_5.1][48ADF867][RAW]");
            if (1 == 2)
            {
                if (video.Resolution != String.Empty)
                {
                    Console.WriteLine(video.Resolution);
                    Console.WriteLine(video.ResolutionMatch);
                }
                else
                    Console.WriteLine("No Match");
            }
            if (1 == 2)
            {
                if (video.Subber != String.Empty)
                {
                    Console.WriteLine(video.Subber);
                    Console.WriteLine(video.SubberMatch);
                }
                else
                    Console.WriteLine("No Match");
            }
            if (1 == 2)
            {
                if (video.Raw != String.Empty)
                {
                    Console.WriteLine(video.Raw);
                    Console.WriteLine(video.RawMatch);
                }
                else
                    Console.WriteLine("No Match");
            }
            if (1 == 1)
            {
                if (video.Anime != String.Empty)
                    Console.WriteLine(video.Anime);
                else
                    Console.WriteLine("No Match");
            }









            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }
}
