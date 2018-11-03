using MonitoringLib;
using System;
using System.Linq;

namespace MonitoringApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Shows off our Recorder class in action
            //DemoRecorderClass();
            // Compare the performance of adding a string together vs using the string builder class
            CompareStringToStringBuilder();
        }

        private static void DemoRecorderClass()
        {
            // Start the recorder
            Console.Write("Press ENTER to start the timer: ");
            Console.ReadLine();
            Recorder.Start();

            // Generate an array of 10,000 integers
            int[] largeArrayOfInts = Enumerable.Range(1, 10000).ToArray();

            // Stop the recorder
            Console.Write("Press ENTER to stop the timer: ");
            Console.ReadLine();
            Recorder.Stop();
            Console.ReadLine();
        }

        private static void CompareStringToStringBuilder()
        {
            int[] numbers = Enumerable.Range(1, 50000).ToArray();
            Recorder.Start();
            Console.WriteLine("Using String...");
            string s = string.Empty;
            for(int i = 0; i < numbers.Length; i++)
            {
                s += numbers[i] + ", ";
            }
            Recorder.Stop();
            Recorder.Start();
            Console.WriteLine("Using String Builder...");
            var builder = new System.Text.StringBuilder();
            for (int i = 0; i < numbers.Length; i++)
            {
                builder.Append(numbers[i]);
                builder.Append(", ");
            }
            Recorder.Stop();
            Console.ReadLine();
        }
    }
}
