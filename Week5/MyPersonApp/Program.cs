using System;
using MyLibrary;

namespace MyPeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare a variable of type People and call the constructor
            var person = new People();
            // Assign some Field values
            person.FirstName = "Scott";
            person.LastName = "Walton";
            person.EmailAddress = "swalton@stfrancis.edu";
            person.Age = 45;
            // Call a Method
            person.WritePersonToConsole();
        }
    }
}
