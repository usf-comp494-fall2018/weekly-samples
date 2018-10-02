using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleLibrary
{
    public class Employee : Person
    {
        public override void WriteToConsole()
        {
            Console.WriteLine($"{Name}'s age is {Age} and hire date was {HireDate:dd/MM/yyyy}");
        }

        public string EmloyeeCode { get; set; }
        public DateTime HireDate { get; set; }
    }
}
