using System;

namespace DisplayingOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare our variables
            var population = 66_000_000; // 66 million in UK
            var weight = 1.88; // in kilograms
            var price = 4.99M; // in pounds sterling
            var fruit = "Apples"; // Strings use double-quotes

            // Display our output
            Console.WriteLine($"The UK population is {population}.");
            Console.Write($"The UK population is {population:N0}.");
            Console.Write($" {weight}kg of {fruit} costs {price:C}.\n");
        }
    }
}
