using PeopleLibrary;
using System;

namespace PeopleSortApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people =
            {
                new Person { Name = "Simon" },
                new Person { Name = "Jenny" },
                new Person { Name = "Adam" },
                new Person { Name = "Richard" },
            };

            Console.WriteLine("Initial list of people:");
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name}");
            }

            Console.WriteLine("Use Person's IComparable implementation to sort:");
            Array.Sort(people);
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name}");
            }

            Console.WriteLine("Use PersonComparer's IComparer implementation to sort:");
            Array.Sort(people, new PersonComparer());
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name}");
            }
        }
    }
}
