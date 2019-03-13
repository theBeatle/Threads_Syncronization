using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _13_Threads_IAsyncResult
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"Main Thread ID {Thread.CurrentThread.ManagedThreadId}");

            //var myDelegate = new Func<int, int, string>(Acumulate);
            Func<int, int, int, string> myDelegate = new Func<int, int, int, string>(SomeFunc);

            Console.WriteLine("Main Thread is working");
            IAsyncResult asyncResult = myDelegate.BeginInvoke(1, 15, 100, null, null);
            string result = myDelegate?.EndInvoke(asyncResult); // get result
            Console.WriteLine("Acumulated number is = " + result);
            Console.WriteLine("Main Thread is ended");
            Console.ReadKey();
        }

        static string SomeFunc(int a, int b, int c) => "hi"; 

        static string Acumulate(int a, int b)
        {
            Console.WriteLine("Async work started");
            Console.WriteLine($"Current Thread ID {Thread.CurrentThread.ManagedThreadId}");
            int res = 1;
            for (int i = a; i < b; i++)
            {
                res *= i;
                //Thread.Sleep(100);
            }
            Console.WriteLine("Async work ended");
            return res.ToString();
        }
    }
}
