using System;

namespace PassingParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = 20;
            int z = 30;
            Console.WriteLine($"Before: x = {x}, y = {y}, z = {z}");
            ChangeThings(x, ref y, out z);
            Console.WriteLine($"After: x = {x}, y = {y}, z = {z}");
        }

        static void  ChangeThings(int a, ref int b, out int c)
        {
            c = 99;
            a++;
            b++;
            c++;
        }
    }
}
