using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_Threads_SyncProblem
{
    class Program
    {
        static int Count = 0;
        static void Main(string[] args)
        {
            Stopwatch st = Stopwatch.StartNew();

            //CounterIncrement();
            //CounterIncrement();
            //CounterIncrement();
             Thread t1 = new Thread(new ThreadStart(Program.CounterIncrement));
             Thread t2 = new Thread(new ThreadStart(Program.CounterIncrement));
             Thread t3 = new Thread(new ThreadStart(Program.CounterIncrement));
            
             t1.Start();
             t2.Start();
             t3.Start();
            
             t1.Join();
             t2.Join();
             t3.Join();
            st.Stop();

            Console.WriteLine(Count);
            Console.WriteLine($" Elapsed ticks = {st.ElapsedTicks} Elapsed mls = {st.ElapsedMilliseconds}");

        }

        static void CounterIncrement()
        {
            for (int i = 0; i < 10000000; i++)
            {
                Count++;  // unsafe for Threads
            }
        }
    }
}
