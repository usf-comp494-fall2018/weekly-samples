/*
    All code samples are from Chapter 3 in 
    Price (2017). C# 7.1 and .NET Core 2.0 - Modern Cross-Platform Development - Third Edition
    Packt, Birmingham, UK
*/
using System;
using System.IO;

namespace Week3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Bob", "Dana", "Julie", "Sarah", "Fred", "Waldo", "Jenny", "Cathy" };

            if (args.Length == 1)
            {
                switch (args[0])
                {
                    case "if":
                        TheIfStatement();
                        break;
                    case "switch":
                        TheSwitchStatement();
                        break;
                    case "while":
                        TheWhileStatement();
                        break;
                    case "do":
                        TheDoStatement();
                        break;
                    case "for":
                        TheForStatement();
                        break;
                    case "foreach":
                        TheForeachStatement();
                        break;
                    case "cast":
                        TheCastExample();
                        break;
                    case "convert":
                        TheConvertExample();
                        break;
                    case "round":
                        TheRoundExample();
                        break;
                    case "tostring":
                        TheToStringExample();
                        break;
                    case "parse":
                        TheParseExample();
                        break;
                    case "error":
                        TheErrorHandler();
                        break;
                    default:
                        Console.WriteLine($"{args[0]} is not a valid parameter.");
                        break;
                }
            }
        }

        private static void TheErrorHandler()
        {
            Console.WriteLine("Before parsing...");
            Console.Write("Enter your age: ");
            string input = Console.ReadLine();
            try
            {
                int age = int.Parse(input);
                Console.WriteLine($"You are {age} years old!");
            }
            catch(FormatException)
            {
                Console.WriteLine("The age you entered is not a valid number format.");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            Console.WriteLine("After parsing.");
        }

        private static void TheParseExample()
        {
            // The Parse Example
            int age = int.Parse("27");
            DateTime birthday = DateTime.Parse("4 July 1980");
            Console.WriteLine($"I was born {age} years ago.");
            Console.WriteLine($"My birthday is {birthday}");
            Console.WriteLine($"My birthday is {birthday:D}");
        }

        private static void TheToStringExample()
        {
            // The ToString Example
            int number = 12;
            Console.WriteLine(number.ToString());
            bool boolean = true;
            Console.WriteLine(boolean.ToString());
            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString());
            object me = new object();
            Console.WriteLine(me.ToString());
        }

        private static void TheRoundExample()
        {
            // The Round Example
            double i = 9.49;
            double j = 9.5;
            double k = 10.49;
            double l = 10.5;
            Console.WriteLine($"i is {i}, ToInt(i) is {Convert.ToInt32(i)}");
            Console.WriteLine($"j is {j}, ToInt(j) is {Convert.ToInt32(j)}");
            Console.WriteLine($"k is {k}, ToInt(k) is {Convert.ToInt32(k)}");
            Console.WriteLine($"l is {l}, ToInt(l) is {Convert.ToInt32(l)}");
        }

        private static void TheConvertExample()
        {
            // The Convert Example
            double g = 9.876;
            int h = Convert.ToInt32(g);
            Console.WriteLine($"g is {g} and h is {h}");
        }

        private static void TheCastExample()
        {
            // The Cast example
            int a = 10;
            double b = a;
            Console.WriteLine(b);

            double c = 9.876;
            int d = (int) c;
            Console.WriteLine(d);
        }

        private static void TheForeachStatement()
        {
            // The foreach statement
            string[] names = { "Adam", "Barry", "Charlie" };
            foreach (string name in names)
            {
                Console.WriteLine($"{name} has {name.Length} characters.");
            }
        }

        private static void TheForStatement()
        {
            // The for statement
            for (int y = 1; y <= 10; y++)
            {
                Console.WriteLine(y);
            }
        }

        private static void TheDoStatement()
        {
            // The do statement
            string password = string.Empty;
            do
            {
                Console.Write("Enter your password: ");
                password = Console.ReadLine();
            } while (password != "secret");
            Console.WriteLine("Correct!");

            /*
             * NOTE: This is NOT how you actually
             *      do a password, but simply an
             *      example of a do..while loop.
             */
        }

        private static void TheWhileStatement()
        {
            // The while statement
            int x = 0;
            while (x < 10)
            {
                Console.WriteLine(x);
                x++;
            }
        }

        private static void TheSwitchStatement()
        {
            // The switch statement
            string path = @"C:\Temp";
            Stream s = File.Open(Path.Combine(path, "file.txt"), FileMode.OpenOrCreate);

            switch(s)
            {
                case FileStream writeable when s.CanWrite:
                    Console.WriteLine("The stream is to a file that I can write to.");
                    break;
                case FileStream readOnlyFile:
                    Console.WriteLine("The stream is to a read-only file.");
                    break;
                case MemoryStream ms:
                    Console.WriteLine("The stream is to a memory address.");
                    break;
                default: // always evaluated last despite its current order
                    Console.WriteLine("The stream is some other type.");
                    break;
                case null:
                    Console.WriteLine("The stream is null");
                    break;
            }
        }

        private static void TheIfStatement()
        {
            // The if statement
            object o = "3";
            int j = 4;

            if (o is int i)
            {
                Console.WriteLine($"{i} x {j} = {i * j}");
            }
            else
            {
                Console.WriteLine("o is not an int so it cannot multiply");
            }
        }
    }
}
