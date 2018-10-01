using System;

namespace PeopleLibrary
{
    public class Person
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
            Properties
        ****************************************/
        public string Name { get; set; }
        public byte Age { get; set; }
    }
}
