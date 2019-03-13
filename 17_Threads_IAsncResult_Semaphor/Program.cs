using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _17_Threads_IAsncResult_Semaphor
{
    class Program
    {
        static Semaphore semaphore;
        static readonly SemaphoreSlim slimS = new SemaphoreSlim(100);

        private static void Work(object number)
        {
            // semaphore.WaitOne();
            slimS.Wait();

            Console.WriteLine($"Critical section entered {number}");
            {
                Console.WriteLine($"Thread {number} locked slot");
                Thread.Sleep(1000);
                Console.WriteLine($"Thread {number} UN-locked slot");
            }
            Console.WriteLine($"Critical section passed {number}");
            slimS.Release();
            //semaphore.Release();
        }

        public static void Main()
        {
            // 1st arg - current slots <= 2nd arg max slots
            semaphore = new Semaphore(2, 4, "MySemafore", out bool created);

            for (int i = 1; i <= 20; i++)
            {
                Thread thread = new Thread(Work);
                thread.Start(i);
            }
            Thread.Sleep(1000);
            Console.WriteLine(created);
            //slimS.Release(10);


            Console.ReadKey();
        }
    }
}
