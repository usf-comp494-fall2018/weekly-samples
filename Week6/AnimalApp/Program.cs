using PeopleLibrary;
using System;

namespace AnimalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Animal a = new Animal())
            {
                // code that uses the animal instance
                // . . .
            } // we are done using animal instance a, so call dispose method
        }
    }
}
