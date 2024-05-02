using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_Assignment_2
{
    internal abstract class Game // Parent Class
    {
        protected int _sum;
        protected string[] _players = new string[2];// Array allowing for two maximum players
        public int[] _playersTotal = new int[2]; // Array to hold total for both players
        protected bool _computerPlayer; // Checks if one of the players is a computer
        public int _currentPlayer = 0; // Checks which player turn it is
        protected bool _gameEnd = false; // Checks if the game has ended or not
        bool _validChoice = false; // Checks if player input is valid
        string _playerChoice = ""; // initialises the variable 


        public abstract void StartGame(int _currentPlayer);
        protected string GetName(string _name) // Method which allows for player names to be chose
        {
            try // Exception handling to prevent whitespace 
            {
                Console.WriteLine($"Name: {_name}");
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) // Checks if _name is whitespace
                {
                    throw new ArgumentException("Name Cannot Be Empty.\n");
                }
                return input.ToUpper();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}"); // Error message from throw argument
                return GetName(_name); // Reprompts the user for a valid name
            }

        }
        protected void ShowFinalScores() // Method to show the final scores of the players and the winner
        {
            // Shows both players scores.
            Console.WriteLine("Final Scores");
            Console.WriteLine("----------------");
            Console.WriteLine($"{_players[0]}: {_playersTotal[0]}");
            Console.WriteLine($"{_players[1]}: {_playersTotal[1]}");

            // Checks which player has the higher score and prints corresponding win message
            if (_playersTotal[0] > _playersTotal[1])
            {
                Console.WriteLine($"Congratulations, {_players[0]} Wins!");
                Stats.GameStats(_playersTotal[0]);
            }
            else if (_playersTotal[1] > _playersTotal[0])
            {
                Console.WriteLine($"Congratulations, {_players[1]} Wins!");
                Stats.GameStats(_playersTotal[1]);
            }
            else
            {
                Console.WriteLine("Its a tie!"); // If the scores are the same the game ends with a tie
            }

            System.Threading.Thread.Sleep(3000); // Allows for the users to look at the score before returning to menu

        }
        public virtual void Play()
        {
            // Menu allowing for the player to choose who they play against
            while (!_validChoice) // Loop until a valid choice is entered
            {
                try
                {
                    Console.WriteLine("----------------\n");
                    Console.WriteLine("Who do you want to play against?");
                    Console.WriteLine("Human | Computer (H/C)\n");

                    _playerChoice = Console.ReadLine().ToUpper().Trim(); // Gets user input and removes whitespace

                    if (_playerChoice != "H" && _playerChoice != "C") // Validates input
                    {
                        throw new ArgumentException("Please pick a valid opponent.");
                    }

                    _validChoice = true; // Exit the loop if the choice is valid
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}"); 
                }
            }


            if (_playerChoice == "C")
            {
                //Playing against a computer
                _computerPlayer = true;
                _players[0] = GetName("");
                _players[1] = ("COMPUTER");
                Console.WriteLine("Playing against a computer...");
            }
            else
            {   
                //Gets both names for the players
                _computerPlayer = false;
                _players[0] = "Player 1: " + GetName("");
                _players[1] = "Player 2: " + GetName("");
            }

            Console.WriteLine("Press spacebar to roll the dice.\n");

            while (!_gameEnd) //Keeps looping untill _gameEnd = True
            {
                if (_currentPlayer == 1 && _computerPlayer) //Checks if the second player is a computer
                {
                    Console.WriteLine($"{_players[_currentPlayer]}'s turn...");
                    System.Threading.Thread.Sleep(2000); //Simuates the computer rolling the dice
                    StartGame(_currentPlayer); //Automaically rolls the dice for the computer
                }
                else
                {
                    var key = Console.ReadKey(true); //Checks to see if spacebar is pressed
                    if (key.KeyChar == ' ')
                    {
                        Console.Clear();
                        StartGame(_currentPlayer); // Runs game after input
                    }
                }
                _currentPlayer = (_currentPlayer + 1) % 2; // Switches players
            }
        }
    }

    //----------------------------------------------------------------------------------------------------

    internal class SevensGame : Game // Sevens game child class
    {
        public override void StartGame(int _currentPlayer)
        {   // Creates two dice objects
            int roll_1 = 0;
            int roll_2 = 0;
            try
            {
                Die die1 = new Die();
                Die die2 = new Die();

                // Rolls both the dice and calculates their total
                roll_1 = die1.Roll();
                roll_2 = die2.Roll();

                _sum = (roll_1 + roll_2);

                if (_sum < 2 || _sum > 12) // Exception handling to ensure _sum is within expected range of 2-12
                {
                    throw new InvalidOperationException("Die value out of range");
                }
                // Prints the value of both dice and their total
                Console.WriteLine($"{_players[_currentPlayer]}");
                Console.WriteLine("----------------");
                Console.WriteLine($"Die 1: {roll_1}\nDie 2: {roll_2}");
                Console.WriteLine($"You rolled: {_sum}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return;
            }

            if (_sum == 7) // Checks if the total is a 7
            {

                Console.WriteLine($"{_players[_currentPlayer]} rolled a 7!\n");
                ShowFinalScores(); // Displays the final scores
                _gameEnd = true; // Ends the game if a 7 is rolled
                return;
            }

            else if (roll_1 == roll_2)
            {
                _playersTotal[_currentPlayer] += _sum * 2; // Doubles the total if the dice are the same
                Console.WriteLine("You rolled a double!");
            }
            else
            {
                _playersTotal[_currentPlayer] += _sum; // Add the sum to the current players score
            }

            Console.WriteLine($"{_players[_currentPlayer]}'s Total Score: {_playersTotal[_currentPlayer]}\n"); //Shows the current players score
        }
    }

    //----------------------------------------------------------------------------------------------------

    internal class ThreeGame : Game // Three game child class
    {
        public override void StartGame(int _currentPlayer)
        {
            // Creates an array for 5 dice objects
            int[] dice = new int[5];
            Die die = new Die();

            for (int i = 0; i < 5; i++) // Loops through each die and rolls them 
            {
                dice[i] = die.Roll();
            }
            Console.WriteLine($"{_players[_currentPlayer]}");
            Console.WriteLine("----------------");

            for (int i = 0; i < 5; i++) // Prints the die number and corresponding value
            {
                Console.WriteLine($"Die {i + 1}: {dice[i]}");
            }

            int roundScore = CalcScore(dice); // Round score is determined by CalcScore method
            _playersTotal[_currentPlayer] += roundScore; // Player totals are summed through round score
            Console.WriteLine("\nRound score: " + roundScore);
            Console.WriteLine($"{_players[_currentPlayer]}'s Total Score: {_playersTotal[_currentPlayer]}\n"); //Shows the current players score

            if (_playersTotal[_currentPlayer] >= 20) // Checks if the score is greater than or equal to 20
            {    
                ShowFinalScores(); // Displays the final scores for both players
                _gameEnd = true; // Ends the game
            }
        }

        internal int CalcScore(int[] dice, bool rethrow = false) // Method to calculate score
        {
            _sum = 0; // Resets the score to 0
            var grouped = dice.GroupBy(d => d); // Groups the dice by their value
                
            foreach (var group in grouped) // Loops through groups of identical dice
            {
                int count = group.Count(); // Gets count of dice from group

                switch (count) // Switch based on count
                { 
                    // Adds specified value depending on group count 

                    case 2:
                        // Problems with correctly implementig rethrow option
                        break;
                    case 3: 
                        _sum += 3;
                        break;
                    case 4:
                        _sum += 6;
                        break;
                    case 5:
                        _sum += 12;
                        break;
                    default:
                        break;
                }
            }
            return _sum; // Returns calcualted score
        }  
    }
}