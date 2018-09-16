using System;

namespace Factorials
{
    class Program
    {
        static void Main(string[] args)
        {
            RunFactorial();
        }

        static void RunFactorial()
        {
            Console.Write("Enter a number: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine($"{number:N0}! = {Factorial(number):N0}");
            }
            else
            {
                Console.WriteLine("You did not enter a valid number!");
            }
        }

        static int Factorial(int number)
        {
            if(number < 1)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }
    }
}
