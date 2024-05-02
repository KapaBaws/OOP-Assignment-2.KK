using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_2
{
    internal class Die
    {
        private int _DieValue { get; set; } // Allows for Die to be able to hold a value

        private static Random random = new Random(); // Creates a static class which is able to generate random numbers

        public int Roll() // A method which rolls the dice and gives it a value
        {
            _DieValue = random.Next(1, 7); // Generates a random number from 1-6 and assigns it to DieValue
            return _DieValue; // Returns the value of the die
        }
    }
}
