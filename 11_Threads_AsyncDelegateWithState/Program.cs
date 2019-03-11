using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11_Threads_AsyncDelegateWithState
{
    public class ThreadWithState
    {
        // State information used in the task.
        private string boilerplate;
        private int value;
        List<char> chars;

        // Delegate used to execute the callback method when the task is complete.
        private ExampleCallback callback;

        // The constructor obtains the state information and the callback delegate.
        public ThreadWithState(string text, int number, ExampleCallback callbackDelegate, List<char> chars)
        {
            boilerplate = text;
            value = number;
            callback = callbackDelegate;
            this.chars = chars;
        }

        public void ThreadProc()
        {
            Console.WriteLine(boilerplate, value);


            for (int i = 0; i < 10; i++)
            {
                value += 10;
                Thread.Sleep(10);
            }

            for (int i = 0; i < 200; i++)
            {
                if (i % 20 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write(chars[i % chars.Count]);
            }

            Console.WriteLine();

            //if (callback != null)
            //{
            //    callback.Invoke(1);
            //}


            callback?.Invoke(value);
        }
    }

    // Delegate that defines the signature for the callback method.
    public delegate void ExampleCallback(int lineCount);

    // Entry point for the example.
    public class Example
    {
        public static int myValue = 0;

        public static void Main()
        {
            ExampleCallback myCallBack = new ExampleCallback(ResultCallback);
            // Supply the state information required by the task.
            ThreadWithState tws = new ThreadWithState(
                "Hello Vlad!!! This report displays the number {0} "
                , 44
                , myCallBack
                , new List<char> { '£','$','%', '@', '(', (char)3 });

            Thread t = new Thread(tws.ThreadProc);
            t.Start();
            Console.WriteLine("Main thread does some work, then waits.");
            //
            //t.Join();
            Thread.Sleep(100);
            Console.WriteLine($"In main {myValue}");

            Console.WriteLine("Independent task has completed; main thread ends.");
        }

        // The callback method must match the signature of the callback delegate.
        public static void ResultCallback(int lineCount)
        {
            Console.WriteLine($"Independent task printed {lineCount} lines.");
            myValue = lineCount;
        }
    }
}
