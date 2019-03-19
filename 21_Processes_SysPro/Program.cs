using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _21_Processes_SysPro
{
    class Program
    {
        static void Main(string[] args)
        {
            var proc = Process.GetProcesses();
            int counter = 0;
            //foreach (Process item in proc.Where(p => p.ProcessName.Contains("dev")))
            //{
            //    foreach (var props in item.GetType().GetProperties())
            //    {
            //        try
            //        {
            //            Console.WriteLine($"{props.Name} - {props.GetValue(item)}");
            //        }
            //        catch (Exception)
            //        {
            //            Console.WriteLine($"{props.Name} - CAN'T GET IT! ");
            //        }

            //    }
            //    Console.WriteLine("Threads Collection");
            //    foreach (ProcessThread ths in item.Threads)
            //    {
            //        Console.WriteLine($"{ths.Id} {ths.PriorityLevel} {ths.StartTime} {ths.ThreadState }");
            //    }




            //    //foreach (ProcessModule mods in item.Modules)
            //    //{
            //    //    Console.WriteLine($"{mods.FileName} - {mods.FileVersionInfo} - {mods.ModuleMemorySize}");
            //    //    Console.ReadKey();
            //    //}

            //    counter++;
            //    if (counter % 15 == 0)
            //    {
            //        Console.ReadKey();
            //    }
            //}

            //var visualStudios = Process.GetProcessesByName("devenv"); //  (2264);


            //Console.ReadKey();
            //for (int i = 0; i < 30; i++)
            //{
            //    Process.Start("notepad");
            //    Process.Start("calc");
            //    Process.Start("mspaint");
            //}
            //Console.ReadKey();
            //var list = new List<string> { "notepad", "calculator", "mspaint"};
            //list.ForEach(n => Process.GetProcessesByName(n)
            //                         .ToList()
            //                         .ForEach(vs => vs.Kill() ));

            Console.ReadKey();
           // Process.Start(@"D:\Hello.txt");
           // Process.Start(@"C:\Users\thebe\Source\Repos\Threads_Syncronization\20_Threads_ThreadsPool\bin\Debug\20_Threads_ThreadsPool.exe");
            Process.Start("notepad", "Hello Virus!!!");

            //Console.WriteLine($"{proc.First(p => p.ProcessName.Contains("dev")).ProcessName}");

        }
    }
}
