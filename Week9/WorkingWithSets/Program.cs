using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithSets
{
    class Program
    {
        static void Main(string[] args)
        {
            var cohort1 = new string[] { "Rachel", "Gareth", "Jonathan", "George" };
            var cohort2 = new string[] { "Jack", "Stephen", "Daniel", "Jack", "Jared", };
            var cohort3 = new string[] { "Declan", "Jack", "Jack", "Jasmine", "Connor" };

            Output(cohort1, "Cohort 1");
            Output(cohort2, "Cohort 2");
            Output(cohort3, "Cohort 3");
            Console.WriteLine();

            Output(cohort2.Distinct(), "cohort2.Distinct(): removes duplicates");
            Console.WriteLine();
            Output(cohort2.Union(cohort3), "cohort2.Union(cohort3): combines and removes duplicates");
            Console.WriteLine();
            Output(cohort2.Concat(cohort3), "cohort2.Concat(cohort3): combines but leaves duplicates");
            Console.WriteLine();
            Output(cohort2.Intersect(cohort3), "cohort2.Insersect(cohort3): items that are in both sequences");
            Console.WriteLine();
            Output(cohort2.Except(cohort3), "cohort2.Except(cohort3): removes items from the fist sequence that are in the second sequence");
            Console.WriteLine();
            Output(cohort1.Zip(cohort2,(c1,c2) => $"{c1} matched with {c2}"), "cohort1.Zip(cohort2,(c1,c2) => $\"{c1} matched with {c2}\"): matches items based on position in the sequence");
            Console.WriteLine();
        }

        private static void Output(IEnumerable<string> cohort, string description = "")
        {
            if(!string.IsNullOrEmpty(description))
            {
                Console.WriteLine(description);
            }
            Console.Write("   ");
            Console.WriteLine(string.Join(", ", cohort.ToArray()));
        }
    }
}
