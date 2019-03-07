using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07_Threads_Sync_Interlock
{
    class Program
    {
        static int Count = 0;
        static void Main(string[] args)
        {

            Stopwatch stopwatch = Stopwatch.StartNew();
            // CounterIncrement();
            // CounterIncrement();
            // CounterIncrement();
            Thread t1 = new Thread(new ThreadStart(Program.CounterIncrement));
            Thread t2 = new Thread(new ThreadStart(Program.CounterIncrement));
            Thread t3 = new Thread(new ThreadStart(Program.CounterIncrement));
            ////t1.Priority = ThreadPriority.Highest;
            // t2.Priority = ThreadPriority.Normal;
            // t3.Priority = ThreadPriority.Lowest;

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            stopwatch.Stop();

            Console.WriteLine(Count);
            Console.WriteLine($"Elapsed mls = { stopwatch.ElapsedMilliseconds}");

        }

        static void CounterIncrement()
        {
            for (int i = 0; i < 10000000; i++)
            {
                //Count++;   unsafe for Threads
                Interlocked. .Increment(ref Count); // safe for Threads
                //Count++;
            }
        }
    }
}
