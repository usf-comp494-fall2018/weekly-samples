using PeopleLibrary;
using System;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee
            {
                Name = "John Jones",
                Age = 25
            };
            e1.WriteToConsole();
        }
    }
}
