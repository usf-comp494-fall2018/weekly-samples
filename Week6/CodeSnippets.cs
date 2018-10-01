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
    Program.cs - PeopleSortApp
******************************************************************************/

            Console.WriteLine("Use PersonComparer's IComparer implementation to sort:");
            Array.Sort(people, new PersonComparer());
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name}");
            }

/******************************************************************************
    Program.cs - EmployeeApp
******************************************************************************/
            e1.EmloyeeCode = "JJ001";
            e1.HireDate = new DateTime(2014, 11, 23);
            Console.WriteLine($"{e1.Name} was hired on {e1.HireDate:dd/MM/yyyy}");

/******************************************************************************
    Employee.cs
******************************************************************************/
        public void WriteToConsole()
        {
            Console.WriteLine($"{Name}'s age is {Age} and hire date was {HireDate:dd/MM/yyyy}");
        }

        public string EmloyeeCode { get; set; }
        public DateTime HireDate { get; set; }
