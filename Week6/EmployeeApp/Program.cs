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
            e1.EmloyeeCode = "JJ001";
            e1.HireDate = new DateTime(2014, 11, 23);
            Console.WriteLine($"{e1.Name} was hired on {e1.HireDate:dd/MM/yyyy}");
            e1.WriteToConsole();
            Person p1 = e1;
            p1.WriteToConsole();
        }
    }
}
