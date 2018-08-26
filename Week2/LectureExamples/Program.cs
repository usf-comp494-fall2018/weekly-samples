using System;
using System.IO;
using System.Xml;

namespace LectureExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Single line comment
            /*
                Allows for multiple
                line comments
            */
        }

        // Blocks denote a section of code that goes together
        public void DoSomething()
        { // Begin block
            Console.WriteLine("Do Something!");
        } // End block

        // Different variable types and definitions
        public void Variables()
        {
            // Storing Text - Single letters
            char letter = 'A';
            char digit = '1';
            char symbol = '$';
            char userChoice = GetCharacterFromUser();

            // Storing Text - Multiple letters
            string firstName = "Bob";
            string lastName = "Smith";
            string phoneNumber = "800-555-1212";
            string address = GetAddressFromDatabase(id: 213);

            // Storing Numbers
            uint age = 18;
            int temperature = -12;
            double temperature2 = -12.39;
            decimal temperature3 = -12.39m;

            // Storing Booleans
            bool happy = true;
            bool sad = false;

            // Object can store any data type
            object height = 1.88; // storing double as object
            object name = "John"; // storing string as object
            int length1 = name.Length; // Compiler Error
            int length2 = ((string) name).Length; // Cast to access members

        }

        // Showing the scope of a local variable
        public void LocalVariableExample()
        {
            int population = 66_000_000; // 66 million in UK
            double weight = 1.88; // in kilograms
            decimal price = 4.99M; // in pounds sterling
            string fruit = "Apples"; // Strings use double-quotes
            char letter = 'z'; // chars use single quotes
            bool happy = true; // Booleans have value of true or false        
        }

        // Inferred Local Variables using var
        public void InferredLocalVariableExample()
        {
            var population = 66_000_000; // 66 million in UK
            var weight = 1.88; // in kilograms
            var price = 4.99M; // in pounds sterling
            var fruit = "Apples"; // Strings use double-quotes
            var letter = 'z'; // chars use single quotes
            var happy = true; // Booleans have value of true or false
        }

        // When to use and when not to use var
        public void UsingVarGoodAndBad()
        {
            // Good use of var
            var xmlDoc1 = new XmlDocument();
            // unnecessarily verbose repeating XmlDocument
            XmlDocument xmlDoc2 = new XmlDocument();

            // bad use of var; what data type is file1?
            var file1 = File.CreateText(@"C:\Temp\something.txt");
            // good use of specific type definition
            StreamWriter file2 = File.CreateText(@"C:\Temp\something.txt");
        }

        // Making value types nullable
        public void NullableValueTypes()
        {
            int iCannotBeNull = 4;
            int? iCouldBeNull = null;
            Console.WriteLine(iCouldBeNull.GetValueOrDefault()); // 0
            iCouldBeNull = 4;
            Console.WriteLine(iCouldBeNull.GetValueOrDefault()); // 4
        }

        // Storing Multiple values in an array
        public void ArrayExample1()
        {
            int[] scores = new int[4];
            scores[0] = 5;
            scores[1] = 2;
            scores[2] = 6;
            scores[3] = 9;
            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine(scores[i]);
            }
        }

        // Storing more values in a different array type
        public void ArrayExample2()
        {
            string[] names = new string[4];
            names[0] = "Kate";
            names[1] = "Jack";
            names[2] = "Rebecca";
            names[3] = "Tom";
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
        }

        // Read a character from the console
        public char GetCharacterFromUser()
        {
            char userInput = Console.ReadKey().KeyChar;
            return userInput;
        }

        // Lookup the address by id from the database
        public string GetAddressFromDatabase(int id)
        {
            string address = string.Empty;
            // Here is where we would make the database call
            return address;
        }
    }
}
