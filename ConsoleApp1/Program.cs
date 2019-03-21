using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int x = 3;
            int y = 4;
            double result = await Counter(x, y);
        }

        static Task<double> Counter(int a, int b)
        {
            return Task.Run (() => Math.Sqrt((a * a) + b * b));
        }
    }
}
