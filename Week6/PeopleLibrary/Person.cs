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
        public virtual void WriteToConsole()
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
