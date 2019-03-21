using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _22_Tasks
{

    // jakObjetTilkuChiSchoTam => iTutaVurazJakis6
    // nuTakeJkNapusav
    // jakVladSkazav
    // () => iCePishlo
    // ( input params ) => { code expression  }


    class Program
    {
        static void Main(string[] args)
        {
            Action ac = new Action(EasyWork);
            Action ac2 = new Action(SoftWork);
            Task ts = new Task(ac);

            var taskResult0 = Task.Run(ac);
            taskResult0.Wait();

            var taskResult1 = Task.Run(() => EasyWork());
            taskResult1.Wait();

            var taskResult2 = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Easy {i} Hello world!!!");
                    Thread.Sleep(100);
                    Console.WriteLine($"Current TH = {Thread.CurrentThread.ManagedThreadId}");
                }
            });
            taskResult2.Wait();

            var taskResult3 = Task.Run(() => { EasyWork(); SoftWork();});
            taskResult3.Wait();

            var taskResult4 = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Easy {i} Hello world!!!");
                    Thread.Sleep(100);
                    Console.WriteLine($"Current TH = {Thread.CurrentThread.ManagedThreadId}");
                }
                return true;
            });
            taskResult4.Wait();
            Console.WriteLine(taskResult4.Result);



            var taskResult5 = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Easy {i} Hello world!!!");
                    Thread.Sleep(100);
                    Console.WriteLine($"Current TH = {Thread.CurrentThread.ManagedThreadId}");
                }
                return true;
            });
            taskResult4.Wait();
            Console.WriteLine(taskResult4.Result);

            int a = 3;
            int b = 4;

            Task<double> thR = Task.Run(() => Counter(a, b));
            thR.Wait();
            Console.WriteLine(thR.Result);

            Console.WriteLine(new String('-',30));

            var res = Task<double>.Factory.StartNew(() => Counter(23, 34));
            Console.WriteLine(res.Result);

            Console.WriteLine(new String('-', 30));


            // Thread.Sleep(1000);
        }

        static void EasyWork()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Easy {i} Hello world!!!");
                Thread.Sleep(100);
                Console.WriteLine($"Current TH = {Thread.CurrentThread.ManagedThreadId}");
            }
        }

        static void SoftWork()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Soft {i} Hello world!!!");
                Thread.Sleep(100);
                Console.WriteLine($"Current TH = {Thread.CurrentThread.ManagedThreadId}");
            }
            //return 23;
        }

        static double Counter(int a, int b) => Math.Sqrt(a * a + b * b); 
    }
}
