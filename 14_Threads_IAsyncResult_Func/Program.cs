using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _14_Threads_IAsyncResult_Func
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"Main Thread ID {Thread.CurrentThread.ManagedThreadId}");

            var myDelegate = new Func<string>(Worker);               //Action(Worker);
            var callback = new AsyncCallback(HandleCompletion);

            //myDelegate.BeginInvoke(null, null);
            //myDelegate.BeginInvoke(param1, ... , param16 ,null, null);
            //myDelegate.BeginInvoke(callback, null);
            //myDelegate.BeginInvoke(callback, 100500);
            var asyncResult = myDelegate.BeginInvoke(callback, 100500);
            string result = myDelegate?.EndInvoke(asyncResult);
            //Console.WriteLine(result);


            //Console.WriteLine("Main Thread is working");
            //Console.ReadKey();
        }


        static string Worker()
        {
            Console.WriteLine("Async work started");
            Console.WriteLine($"Current Thread ID {Thread.CurrentThread.ManagedThreadId}");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} passed {i} steps ");
                Thread.Sleep(100);
            }
            Console.WriteLine("Async work ended");
            return "Work is done!!!";

        }

        // callback
        static void HandleCompletion(IAsyncResult asyncResult)
        {
            Console.WriteLine($"Callbac. Thread Id {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Callbac. State {asyncResult.AsyncState}");
        }
    }
}
