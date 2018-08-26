using System;

namespace ReadingInput
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the Name
            Console.Write("Type your first name and press ENTER: ");
            string firstName = Console.ReadLine();
            // Read the Age - Later on we'll convert age to a number
            Console.Write("Type your age and press ENTER: ");
            string age = Console.ReadLine();
            // Display what we read from user
            Console.WriteLine($"Hello, {firstName}! You look good for {age}.");
        }
    }
}
