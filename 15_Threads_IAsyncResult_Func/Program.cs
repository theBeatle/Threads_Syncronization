using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _15_Threads_IAsyncResult_Func
{
    class Program
    {
        static int Acumulate(int a, int b)
        {
            Console.WriteLine("Async work started");
            Console.WriteLine($"Current Thread ID {Thread.CurrentThread.ManagedThreadId}");
            int res = 1;
            for (int i = a; i < b; i++)
            {
                res *= i;
                Thread.Sleep(100);
            }
            Console.WriteLine("Async work ended");
            return res;
        }

        static void CallBack(IAsyncResult iAsyncResult)
        {
            AsyncResult asyncResult = (AsyncResult)iAsyncResult; //as AsyncResult;
            Func<int, int, int> caller = (Func<int, int, int>)asyncResult.AsyncDelegate;
            int acum = caller.EndInvoke(iAsyncResult);

            Console.WriteLine($"Callback. Result of async task: {iAsyncResult.AsyncState} = {acum}");
            Console.WriteLine($"CallBack Thread ID {Thread.CurrentThread.ManagedThreadId}");
        }

        static void Main()
        {
            Console.WriteLine($"Main Thread ID {Thread.CurrentThread.ManagedThreadId}");
            var myDelegate = new Func<int, int, int>(Acumulate);
            Console.WriteLine("Main Thread is working");

            myDelegate.BeginInvoke(10, 20, CallBack, "Acumulated number =");

            //string result = myDelegate?.EndInvoke(asyncResult); // get result
            //Console.WriteLine("Acumulated number is = " + result);


            Thread.Sleep(1000);
            Console.WriteLine("Main Thread is ended");
            Console.ReadKey();
        }
    }
}
