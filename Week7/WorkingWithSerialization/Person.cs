using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithSerialization
{
    public class Person
    {
        public Person(decimal initialSalary)
        {
            Salary = initialSalary;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public HashSet<Person> Children { get; set; }
        protected decimal Salary { get; set; }
    }
}
