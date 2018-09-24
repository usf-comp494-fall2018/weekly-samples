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

/*############################################################################################### */

using System;

namespace MyLibrary
{
    public class People
    {
        /**********************************************************************
           Class Variables
        **********************************************************************/
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private byte _age;

        /**********************************************************************
           Constructors
        **********************************************************************/
        public People()
        {
            _firstName = string.Empty;
            _lastName = string.Empty;
            _emailAddress = string.Empty;
            _age = 0;
        }

        /**********************************************************************
           Methods 
        **********************************************************************/
        public void WritePersonToConsole()
        {
            Console.WriteLine($"{LastName}, {FirstName} with email {EmailAddress} is {Age} years old.");
        }

        /**********************************************************************
           Properties
        **********************************************************************/
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                _emailAddress = value;
            }
        }

        public byte Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }
    }
}
