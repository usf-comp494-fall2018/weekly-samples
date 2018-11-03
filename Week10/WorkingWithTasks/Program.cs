using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WorkingWithTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSynchronousWork();
            DoAsynchronousWork();
        }

        private static void MethodA()
        {
            Console.WriteLine("Starting Method A...");
            Thread.Sleep(3000); // Simulate 3 seconds of work
            Console.WriteLine("Finished Method A.");
        }

        private static void MethodB()
        {
            Console.WriteLine("Starting Method B...");
            Thread.Sleep(2000); // Simulate 2 seconds of work
            Console.WriteLine("Finished Method B.");
        }

        private static void MethodC()
        {
            Console.WriteLine("Starting Method C...");
            Thread.Sleep(1000); // Simulate 1 second of work
            Console.WriteLine("Finished Method C.");
        }

        private static void DoSynchronousWork()
        {
            var timer = Stopwatch.StartNew();

            Console.WriteLine("Running methods synchronously on one thread...");
            MethodA();
            MethodB();
            MethodC();
            Console.WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");
            Console.WriteLine("Press ENTER to end.");
            Console.ReadLine();
        }

        private static void DoAsynchronousWork()
        {
            var timer = Stopwatch.StartNew();

            Console.WriteLine("Running methods asynchronously on multiple threads...");
            Task taskA = new Task(MethodA);
            taskA.Start();
            Task taskB = Task.Factory.StartNew(MethodB);
            Task taskC = Task.Factory.StartNew(MethodC);
            Console.WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");
            Console.WriteLine("Press ENTER to end.");
            Console.ReadLine();
        }
    }
}
