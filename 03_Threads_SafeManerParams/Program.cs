using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_Threads_SafeManerParams
{
    class Number
    {
        private int _target;
        public Number(int target)
        {
            this._target = target;
        }

        public void PrintNumbers()
        {
            for (int i = 0; i < _target; i++)
            {
                Console.Write($"{i:00} ");
                if (i != 0 && (i + 1) % 10 == 0)
                {
                    Console.Write(Environment.NewLine);
                }
            }
            Console.Write(Environment.NewLine);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter target number");
            bool success = Int32.TryParse(Console.ReadLine(), out int digit);
            if (success)
            {
                Number number = new Number(digit);
                Thread thread1 = new Thread(number.PrintNumbers);
                thread1.Start();
                Thread.Sleep(1000);
                thread1.Join();
                Console.WriteLine('\n');
                Console.WriteLine(Environment.NewLine);
                //ParameterizedThreadStart del = new ParameterizedThreadStart(PrintNumbers);
                Thread thread2 = new Thread(PrintNumbers);
                thread2.Start(digit);

            }
        }

        static void PrintNumbers(object dig)
        {
            int _target = (int)dig;
            Thread.Sleep(1000);
            for (int i = 0; i < _target; i++)
            {
                Console.Write($"{i:00} ");
                if (i != 0 && (i + 1) % 10 == 0)
                {
                    Console.Write(Environment.NewLine);
                }
            }
            Console.Write(Environment.NewLine);
        }

    }
}
