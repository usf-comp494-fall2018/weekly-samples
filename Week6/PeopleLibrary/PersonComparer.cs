using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleLibrary
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            // Compare the Name lengths
            int temp = x.Name.Length.CompareTo(y.Name.Length);
            // if they are equal
            if(temp == 0)
            {
                // then sort by the Names
                return x.Name.CompareTo(y.Name);
            }
            else
            {
                // otherwise sort by the lengths
                return temp;
            }
        }
    }
}
