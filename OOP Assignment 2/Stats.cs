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
        public static void WriteStats(int highScore, int gamesPlayed) // Method which writes stats to a file
        {
            using (StreamWriter sw = new StreamWriter("Statistics.txt"))
            {
                sw.WriteLine("High Score  : " + highScore); // Writes high score to a file
                sw.WriteLine("Games Played: " + gamesPlayed); // Writes games played to a file
            }
        }
        public static void ReadStats() // Method which reads stats from a file
        {
            try
            {
                int highScore; // Stores high score
                int gamesPlayed; // Stores games played
                File.ReadAllText("Statistics.txt"); // Checks if file exists
                using (StreamReader sr = new StreamReader("Statistics.txt"))
                {
                    highScore = int.Parse(sr.ReadLine().Split(':')[1].Trim()); //Reads high score from file
                    gamesPlayed = int.Parse(sr.ReadLine().Split(':')[1].Trim()); // Read games played from file
                }

                // Displays the statistics in console
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
        public static void GameStats(int newhighScore) // Method which updates game statistics
        {
            try
            {
                int highScore;
                int gamesPlayed;
                File.ReadAllText("Statistics.txt");
                using (StreamReader sr = new StreamReader("Statistics.txt"))
                {
                    highScore = int.Parse(sr.ReadLine().Split(':')[1].Trim()); // Checks current high score
                    gamesPlayed = int.Parse(sr.ReadLine().Split(':')[1].Trim()); // Checks current games played

                }
                if (newhighScore > highScore) // Updates the highscore if the new highscore is greater than the last
                {
                    WriteStats(newhighScore, gamesPlayed + 1); // Updates high score and increments games played
                }
                else
                {
                    WriteStats(highScore, gamesPlayed + 1); // Keeps high score and increments games played
                }
            }
            catch (Exception)
            {
                WriteStats(newhighScore, 1); // Creates a new file with a new high score and sets games played to 1
            }
            Console.WriteLine("Press Any Key To Return To Options Menu.");
            Console.ReadKey();
        }
    }
}

