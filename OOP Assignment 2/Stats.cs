using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_2
{
    internal class Stats
    {
        public static void WriteStats(int highScore, int gamesPlayed)
        {
            using (StreamWriter sw = new StreamWriter("Statistics.txt"))
            {
                sw.WriteLine("High Score  : " + highScore);
                sw.WriteLine("Games Played: " + gamesPlayed);
            }
        }
        public static void ReadStats()
        {
            try
            {
                int highScore;
                int gamesPlayed;
                File.ReadAllText("Statistics.txt");
                using (StreamReader sr = new StreamReader("Statistics.txt"))
                {
                    highScore = int.Parse(sr.ReadLine().Split(':')[1].Trim());

                    gamesPlayed = int.Parse(sr.ReadLine().Split(':')[1].Trim());
                }
                Console.WriteLine("   | High Score: ");
                Console.WriteLine("   |     " + highScore);
                Console.WriteLine("   | Games Played: ");
                Console.WriteLine("   |      " + gamesPlayed);



            }
            catch (Exception)
            {
                Console.WriteLine("Doesn't Exist");
            }

        }
        public static void GameStats(int newhighScore)
        {
            try
            {
                int highScore;
                int gamesPlayed;
                File.ReadAllText("Statistics.txt");
                using (StreamReader sr = new StreamReader("Statistics.txt"))
                {
                    highScore = int.Parse(sr.ReadLine().Split(':')[1].Trim());

                    gamesPlayed = int.Parse(sr.ReadLine().Split(':')[1].Trim());

                }
                if (newhighScore > highScore)
                {
                    WriteStats(newhighScore, gamesPlayed + 1);
                }
                else
                {
                    WriteStats(highScore, gamesPlayed + 1);
                }
            }
            catch (Exception)
            {
                WriteStats(newhighScore, 1);
            }
            Console.WriteLine("Press Any Key To Return To Options Menu.");
            Console.ReadKey();
        }
    }
}

