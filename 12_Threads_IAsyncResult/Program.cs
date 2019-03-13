using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace _12_Threads_IAsyncResult
{
    class Program
    {
        static void Main()
        {
            Console.ReadKey();
            Console.WriteLine($"Main Thread ID {Thread.CurrentThread.ManagedThreadId}");
            
            Stopwatch sw = new Stopwatch();

            List<Action> actions = new List<Action>();

            int thQty = 1000;
            for (int i = 0; i < thQty; i++)
            {
                actions.Add(new Action(Worker));
            }
            List<IAsyncResult> results = new List<IAsyncResult>();

            sw.Start();
            //1 with Generig delegate Action
            // Action myDelegate = new Action(Worker);// instance creation
            //IAsyncResult - ref for 

            for (int i = 0; i < thQty; i++)
            {
                results.Add(actions[i].BeginInvoke(null, null));
                //actions[i].EndInvoke(results[i]);
            }
            for (int i = 0; i < thQty; i++)
            {
                actions[i].EndInvoke(results[i]);
            }

            //IAsyncResult asyncResult = myDelegate.BeginInvoke(null, null);
            //myDelegate.EndInvoke(asyncResult);
                        
            //Thread th = new Thread(Worker);
            //th.Start();
            //th.Join();

            sw.Stop();
            Console.WriteLine($"Elapsed time - {sw.ElapsedMilliseconds}");
            Console.WriteLine($"Elapsed time - {sw.ElapsedTicks}"); //? Vlad <0.1 Taras 1,1  Anton 0.8 - 1 
            Console.WriteLine("Main Thread is working");
            Console.WriteLine("Main Thread is ended");
            //Console.ReadKey();
        }


        static void Worker()
        {
            Console.WriteLine("Async worker started");
            Console.WriteLine($"Current Thread ID {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} passed {i} steps ");
                Thread.Sleep(100);
            }
            Console.WriteLine("Async worker ended");
        }
    }
}
