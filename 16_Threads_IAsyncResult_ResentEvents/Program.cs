using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _16_Threads_IAsyncResult_ResentEvents
{
    class Program
    {
        //static AutoResetEvent waitHandler = new AutoResetEvent(true); // signalable at the start
        static AutoResetEvent[] pool = 
            { new AutoResetEvent(false), new AutoResetEvent(false) };

        static void Main(string[] args)
        {
            Thread myThread = new Thread(Count1);
            Thread myThread2 = new Thread(Count2);
            Thread myThread3 = new Thread(Count2);
            myThread.Name = "Thread 1";
            myThread2.Name = "Thread 2";
            myThread3.Name = "Thread 3";
            myThread.Start();
            myThread2.Start();
            myThread3.Start();

            Console.WriteLine("Press 1 to start first or 2 strart second thread");
            var choice = Int32.TryParse(Console.ReadLine(), out int res);

            if (choice)
            {
                if (res == 1)
                {
                    pool[0].Set();
                }
                if (res == 2)
                {
                    pool[1].Set();
                }
                if (res == 3)
                {
                    pool[0].Set();
                    pool[1].Set();
                }
            }

            //AutoResetEvent.WaitAll(pool);
            AutoResetEvent.WaitAll(pool);
            Console.WriteLine("Both threads are ended");

            //Console.ReadKey();
        }

        static void Count2() //HardWork for Thread2
        {
            //Console.WriteLine($"{Thread.CurrentThread.Name}: is waiting ...");
            pool[1].WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.Name}: entered");
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {i} ");
                Thread.Sleep(100);
            }
            pool[1].Set();
        }

        static void Count1() //HardWork for Thread1
        {
            //Console.WriteLine($"{Thread.CurrentThread.Name}: is waiting ...");
            pool[0].WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.Name}: entered");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
                Thread.Sleep(100);
            }
            pool[0].Set();
        }
    }
}
