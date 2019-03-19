using System;
using System.Collections.Generic;
using System.Threading;

namespace _20_Threads_ThreadsPool
{
    class Program
    {
        public static int lengthZ = 10;
        public static int innerIter = 100;
        public static int counterCurrent = 0;
        public static int counterMax = lengthZ * innerIter;
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
                var obj = new Helper(i);
                //ThreadPool.QueueUserWorkItem(new WaitCallback(delegate (object state) { HardWork(); }));
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate (object state) { obj.HardWork(); }));
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

        public class Helper
        {
            private readonly int index;
            public Helper() { }
            public Helper(int index)
            {
                this.index = index;
            }
            public void HardWork()
            {
                Console.WriteLine(index);
                // events[eventIndex].Reset();
                //events[index].WaitOne();

                List<string> mlist = new List<string>();
                for (int i = 0; i < innerIter; i++)
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
                    Console.WriteLine($"{counterCurrent++}/{counterMax} ThreadID {Thread.CurrentThread.ManagedThreadId}");
                    //Thread.Sleep(100);
                }
                events[index].Set();
            }
        }
    }

}
