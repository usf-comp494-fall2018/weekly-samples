/******************************************************************************
    Person.cs
******************************************************************************/
using System;

namespace PeopleLibrary
{
    public class Person : IComparable<Person>
    {
        /****************************************
            Constructors
        ****************************************/
        public Person()
        {
            Name = string.Empty;
            Age = 0;
        }

        /****************************************
            Methods
        ****************************************/
        public void WriteToConsole()
        {
            Console.WriteLine($"{Name} is {Age} years old!");
        }

        /****************************************
            IComparable Implementation
        ****************************************/
        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }

        /****************************************
            Properties
        ****************************************/
        public string Name { get; set; }
        public byte Age { get; set; }
    }
}

/******************************************************************************
    Program.cs
******************************************************************************/

            Console.WriteLine("Use PersonComparer's IComparer implementation to sort:");
            Array.Sort(people, new PersonComparer());
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name}");
            }
