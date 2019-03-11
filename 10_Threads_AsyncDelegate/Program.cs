using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _10_Threads_AsyncDelegate
{
    public delegate void SumOfNumbersCallback(int SumOfNumbers);

    class Number
    {

        SumOfNumbersCallback _callbackMethod;
        int _target;

        public Number(int target, SumOfNumbersCallback callbackMethod)
        {
            _target = target;
            _callbackMethod = callbackMethod;
        }

        public void PrintSumOfNumbers()
        {
            int sum = 0;
            for (int i = 0; i < _target; i++)
            {
                sum += i;
            }
            Console.WriteLine($"HW Th =  {Thread.CurrentThread.ManagedThreadId }");

            //if (_callbackMethod != null)
            //{
            //    _callbackMethod.Invoke(sum);
            //}
            _callbackMethod?.Invoke(sum);
        }
    }
    class Program
    {
        static int? someSum = null;
        public static void PrintSum(int sum)
        {
            Console.WriteLine($"Summ = {sum.ToString()}");
            Console.WriteLine($"CB =  {Thread.CurrentThread.ManagedThreadId }");
            someSum = sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"MT =  {Thread.CurrentThread.ManagedThreadId }");

            SumOfNumbersCallback callback = new SumOfNumbersCallback(PrintSum);
            Number number = new Number(25, callback);
            Thread t1 = new Thread(number.PrintSumOfNumbers);
            t1.Start();


            Thread.Sleep(100);
            Console.WriteLine(someSum ?? 999);
        }
    }
}
