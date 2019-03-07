using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_Threads_Suspend
{
    class Program
    {
        static void Main(string[] args)
        {

            ThreadStart ts = new ThreadStart(HardWork);
            Thread t = new Thread(ts);
            t.Start(); // thread start
            Console.WriteLine("Press any key to stop");
            Console.ReadKey();
            t.Suspend(); //thread pause
            Console.WriteLine("Thread stoped!");
            Console.WriteLine("Press any key to resume");
            Console.ReadKey();
            t.Resume(); // thread resume
        }

        static void HardWork()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
    }
}
