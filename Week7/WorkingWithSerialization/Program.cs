using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace WorkingWithSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // create an object graph
            var people = new List<Person>()
            {
                new Person(30000M) { FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateTime(1974, 3, 14) },
                new Person(40000M) { FirstName = "Bob", LastName = "Jones", DateOfBirth = new DateTime(1969, 11, 23) },
                new Person(20000M)
                {
                    FirstName = "Charlie", LastName = "Rose", DateOfBirth = new DateTime(1964, 5, 4),
                    Children = new HashSet<Person>
                    {
                        new Person(0M) { FirstName = "Sally", LastName = "Rose", DateOfBirth = new DateTime(1990, 7, 12) }
                    }
                }
            };

            // define a custom directory path
            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var customFolder = new string[]
            {
                userFolder, "Code", "Chapter09", "OutputFiles"
            };
            string dir = Path.Combine(customFolder);

            // create a file to write to
            string jsonPath = Path.Combine(dir, "people.json");

            using (StreamWriter jsonStream = File.CreateText(jsonPath))
            {
                var jss = new JsonSerializer();

                // serialize the object graph into a string
                jss.Serialize(jsonStream, people);
                jsonStream.Close(); // release the file lock
            }

            Console.WriteLine();
            Console.WriteLine($"Written {new FileInfo(jsonPath).Length} bytes of JSON to {jsonPath}");

            // Display the serialized object graph
            Console.WriteLine(File.ReadAllText(jsonPath));
        }
    }
}
