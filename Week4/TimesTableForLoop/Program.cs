using System;

namespace TimesTableForLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int row = 1; row <= 12; row++)
            {
                Console.WriteLine($"{row} X 12 = {row * 12}");
            }
        }
    }
}
