using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Threads_ThreadsPool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Diagnostics;

    namespace ConsoleApp49
    {
        class Program
        {
            static int lengthZ = 10;
            public static List<AutoResetEvent> events = new List<AutoResetEvent>();
            static void Main(string[] args)
            {
                for (int i = 0; i < lengthZ; i++)
                {
                    events.Add(new AutoResetEvent(false));
                }

                foreach (var item in Thread.CurrentContext.ContextProperties)
                {
                    Console.WriteLine($" {item.Name}");
                }
                Console.WriteLine(Thread.CurrentThread.ThreadState);
                Console.WriteLine(Thread.CurrentThread.CurrentUICulture);
                Console.WriteLine(Thread.CurrentThread.ExecutionContext);
                Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);

                ThreadPool.SetMaxThreads(10000, 2000);
                ThreadPool.GetAvailableThreads(out int x, out int y);
                Console.WriteLine($"workerthreads - {x} completionThreads - {y}");
                ThreadPool.GetMaxThreads(out int z, out int k);
                Console.WriteLine($"workerthreads - {z} completionThreads - {k}");

                Console.WriteLine($"workerthreads - {x} completionThreads - {y}");
                Console.WriteLine($"workerthreads - {z} completionThreads - {k}");


                Console.ReadKey();
                //ThreadPool.QueueUserWorkItem()

                //List<Thread> list = new List<Thread>();
                for (int i = 0; i < lengthZ; i++)
                {

                    //ThreadPool.QueueUserWorkItem( new WaitCallback(  delegate (object state)
                    //        { YourMethod(Param1, Param2, Param3); }), null);

                    //ThreadPool.QueueUserWorkItem(new WaitCallback(delegate (object state) { HardWork(); }));
                    ThreadPool.QueueUserWorkItem(new WaitCallback(delegate (object state) { HardWork(i); }));
                    //ThreadPool.QueueUserWorkItem( a  =>  { HardWork(i); });

                    //Task.Factory.StartNew(() => HardWork());

                    //Task.Run(() => HardWork());

                    //list.Add(new Thread(HardWork));
                    //list[i].Start();
                }
                //for (int i = 0; i < lengthZ; i++)
                //{
                //    events[i].Set();
                //}
                //Thread.Sleep(10000);
                //for (int i = 0; i < length; i++)
                //{
                //
                //}
                AutoResetEvent.WaitAll(events.ToArray());

            }





        }

        class Helper
        {
            public static void HardWork(int eventIndex)
            {
                Console.WriteLine(eventIndex);
                // events[eventIndex].Reset();
                events[eventIndex].WaitOne();

                List<string> mlist = new List<string>();
                for (int i = 0; i < 100; i++)
                {
                    if (i == 0)
                    {
                        mlist.Add($" ThreadID {Thread.CurrentThread.ManagedThreadId}" +
                            $" Iteration {i}");
                    }
                    else
                    {
                        mlist.Add($" ThreadID {Thread.CurrentThread.ManagedThreadId}" +
                       $" Iteration {i}" + mlist[i - 1]);
                    }
                    Console.WriteLine($" ThreadID {Thread.CurrentThread.ManagedThreadId}" +
                        $" Iteration {i}");


                    //Thread.Sleep(100);
                }
                events[eventIndex].Set();
            }
        }
    }

}
