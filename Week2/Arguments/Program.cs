using System;

namespace Arguments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"There are {args.Length} arguments.");
        }

        #region for each loop
        //foreach(string arg in args)
        //{
        //    Console.WriteLine(arg);
        //}
        #endregion
        #region Console Colors
        //Console.ForegroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), args[0], true);
        //Console.BackgroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), args[1], true);
        //Console.WindowWidth = int.Parse(args[2]);
        //Console.WindowHeight = int.Parse(args[3]);
        #endregion
    }
}
