using System;
using System.Linq;

namespace Week9
{
    class Program
    {
        static void Main(string[] args)
        {
            // Filter using explicit delegate instantiation
            LinqWithNamedFunction1();
            
            // Filter removing the explicit delegate instantiation
            //LinqWithNamedFunction2();

            // Filter using a Lambda Expression
            //LinqWithLambda();
            
            // Sort our Results
            //LinqWithLambdaAndSort();
        }

        static void LinqWithNamedFunction1()
        {
            var names = new string[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };
            var query = names.Where(new Func<string, bool>(NamesLongerThanFour));
            foreach (string item in query)
            {
                Console.WriteLine(item);
            }
        }

        static bool NamesLongerThanFour(string name)
        {
            return name.Length > 4;
        }

        static void LinqWithNamedFunction2()
        {
            var names = new string[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };
            var query = names.Where(NamesLongerThanFour);
            foreach (string item in query)
            {
                Console.WriteLine(item);
            }
        }

        static void LinqWithLambda()
        {
            var names = new string[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };
            var query = names.Where(n => n.Length > 4);
            foreach (string item in query)
            {
                Console.WriteLine(item);
            }
        }

        private static void LinqWithLambdaAndSort()
        {
            var names = new string[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };
            var query = names.Where(name => name.Length > 4)
                .OrderBy(name => name.Length);
            foreach (string item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
}
