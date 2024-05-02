using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true; // Flag to check if game is running
            Console.WriteLine("---Dice Game---");

            while (isRunning)
            {
                try // Exception handling to check valid input
                {
                    Console.WriteLine("\nOptions Menu");
                    Console.WriteLine("----------------");
                    Console.WriteLine("1. Sevens-Out Game\n" +
                        "2. Three-Or-More Game\n" +
                        "3. Statistics\n" +
                        "4. Perform Test\n" +
                        "5. EXIT");
                    Console.WriteLine("----------------");
                    string choice1 = Console.ReadLine().Trim();

                    // Switch statement allowing user to chose from menu
                    switch (choice1) 
                    {
                        case "1":
                            // Rules of Sevens Out
                            Console.Clear();
                            Console.WriteLine("Sevens-Out");
                            Console.WriteLine("----------------");
                            Console.WriteLine("If you roll a 7 the game stops.");
                            Console.WriteLine("If any other number is rolled," +
                                "\nthe scores are added to a total.");
                            Console.WriteLine("If a double is rolled," +
                                "\ndouble the score is added to the total. ");

                            new SevensGame().Play(); // Runs sevens out game
                            break;
                        case "2":
                            // Rules of Three Or More
                            Console.Clear();
                            Console.WriteLine("Three-Or-More");
                            Console.WriteLine("----------------");
                            Console.WriteLine("Roll all 5 dice hoping for a 3-of-a-kind or better.");
                            Console.WriteLine("If 2-of-a-kind is rolled, player may choose to rethrow all, " +
                                "or the remaining dice." +
                                "\n3-of-a-kind: 3 points" +
                                "\n4-of-a-kind: 6 points" +
                                "\n5-of-a-kind: 12 points" +
                                "\nFirst to a total of 20.");

                            new ThreeGame().Play(); // Runs three or more game
                            break;
                        case "3":
                            // Displays the game statistics
                            Console.Clear();
                            Console.WriteLine("---| Game Stats |---");
                            Console.WriteLine("--------------------");
                            Stats.ReadStats();
                            Console.WriteLine("--------------------");
                            System.Threading.Thread.Sleep(2000);
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine("Testing Games");
                            Testing.TestGame(); // Runs the testing class
                            break;
                        case "5":
                            Console.Clear();
                            Console.WriteLine("Goodbye!"); // Exits game 
                            System.Threading.Thread.Sleep(2000); // Allow for goodbye message to display
                            isRunning = false;
                            break;
                        default:
                            throw new ArgumentException("\nPlease pick a valid option.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    }
}
