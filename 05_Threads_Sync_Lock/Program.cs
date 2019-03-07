using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_Threads_Sync_Lock
{
    class Program
    {
        static long Count = 0;
        static decimal _savingsBalance = 0, _checkBalance = 0;
        static void Main(string[] args)
        {

            Stopwatch stopwatch = Stopwatch.StartNew();
            //  CounterIncrement();
            // CounterIncrement();
            //  CounterIncrement();



            Thread t1 = new Thread(new ThreadStart(Program.CounterIncrement));
            Thread t2 = new Thread(new ThreadStart(Program.CounterIncrement));
            Thread t3 = new Thread(new ThreadStart(Program.CounterIncrement));

            t1.Start();
            t2.Start();
            t3.Start();

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //}

            t1.Join();
            t2.Join();
            t3.Join();

            stopwatch.Stop();

            Console.WriteLine(Count);
            Console.WriteLine($"Elapsed mls = {stopwatch.ElapsedMilliseconds}");

        }

        static readonly object _lock = new object();
        static void CounterIncrement()
        {
            for (int i = 0; i < 10000000; i++)
            {
                //Count++;   //unsafe for Threads

                // lock (_lock)
                // {
                //     _savingsBalance += new decimal(34.4D);
                //     _checkBalance += new decimal(45.6);
                // }

                lock (_lock) // safe for Threads 
                {
                    Count++;
                }
            }
        }
    }
}
