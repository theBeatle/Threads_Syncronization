using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp47
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart TS = new ThreadStart(HardWork);
            Thread T = new Thread(TS);
            Console.WriteLine("thread will start now");
            T.Start();
            //Thread.Sleep(2000);
            Console.WriteLine("Waiting for thread ending");
            T.Join(5000);
            if (T.IsAlive) Console.WriteLine("1 sec T is still working");
            T.Join(3000);
            if (T.IsAlive) Console.WriteLine("2 sec T is still working");
            T.Join(1000);
            if (T.IsAlive) Console.WriteLine("5 sec T is still working");

            T.Join();
            Console.WriteLine("Thread ended");
            Console.WriteLine("Program ended");



        }
        static void HardWork()
        {
            Console.WriteLine("Child Thread is working");
            Thread.Sleep(6000);
            Console.WriteLine("Child Thread ended");
        }
    }
}
