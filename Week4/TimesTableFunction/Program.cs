using System;

namespace TimesTableFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTimesTable();
        }

        static void RunTimesTable()
        { 
            Console.WriteLine("Enter a number between 0 and 255: ");
            if(byte.TryParse(Console.ReadLine(), out byte number))
            {
                TimesTable(number);
            }
            else
            {
                Console.WriteLine("You did not enter a valid number!");
            }
        }

        static void TimesTable(byte number)
        {
            Console.WriteLine($"This is the {number} times table");
            for(int row = 1; row <=12; row++)
            {
                Console.WriteLine($"{row} X {number} = {row * number}");
            }
        }
    }
}
