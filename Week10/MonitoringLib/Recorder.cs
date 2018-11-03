using System;
using System.Diagnostics;

namespace MonitoringLib
{
    public static class Recorder
    {
        static Stopwatch timer = new Stopwatch();
        static long bytesPhysicalBefore = 0;
        static long bytesVirtualBefore = 0;

        // Start our recorder - Clean out Garbage Collection, Save our before values, Restart the timer
        public static void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            bytesPhysicalBefore = Process.GetCurrentProcess().WorkingSet64;
            bytesVirtualBefore = Process.GetCurrentProcess().VirtualMemorySize64;
            timer.Restart();
        }

        // Stop our recorder - Stop the timer, Read our After values, Write out the results
        public static void Stop()
        {
            timer.Stop();
            long bytesPhysicalAfter = Process.GetCurrentProcess().WorkingSet64;
            long bytesVirtualAfter = Process.GetCurrentProcess().VirtualMemorySize64;
            Console.WriteLine("Stopped recording.");
            Console.WriteLine($"{bytesPhysicalAfter - bytesPhysicalBefore:N0} physical bytes used.");
            Console.WriteLine($"{bytesVirtualAfter - bytesVirtualBefore:N0} virtual bytes used.");
            Console.WriteLine($"{timer.Elapsed} time span elapsed.");
            Console.WriteLine($"{timer.ElapsedMilliseconds:N0} total milliseconds elapsed.");
        }
    }
}
