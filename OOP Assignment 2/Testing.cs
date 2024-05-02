using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_2
{
    internal class Testing
    {
        public static void TestSevens()
        {
            SevensGame game = new SevensGame(); // Creates a Sevens Out game object
            bool _gameEnded = false; // Marks the game end as false
            int sum = 8; // Sum set to 7 to allow error message to show
            if (sum == 7)
            {
                _gameEnded = true;
            }
            Debug.Assert(_gameEnded, "Game should end if sum of the dice is a 7."); // Prints error message as sum is set to 8

            Console.WriteLine("Testing Complete."); // Message is printed if sum is 7
        }
        public static void TestThree()
        {
            ThreeGame game = new ThreeGame();
            bool _gameEnded = false;
            int _playersTotal = 19;
            if (_playersTotal == 21)
            {
                _gameEnded = true;
            }
            Debug.Assert(_gameEnded, "Game should end if players total score is 20 or more.");

            Console.WriteLine("Testing Complete.");
        }

        public static void TestGame() // Menu allowing the user to choose which game to test
        {
            Console.WriteLine("Which game would you like to test?");
            Console.WriteLine("Sevens-Out | Three-Or-More (S/T)");
            string input = Console.ReadLine().ToUpper();
            switch (input)
            {
                case "S":
                    TestSevens();
                    break;
                case "T":
                    TestThree();
                    break;
                default:
                    Console.WriteLine("Please pick a valid option.");
                    break;
            }
        }
    }
}
