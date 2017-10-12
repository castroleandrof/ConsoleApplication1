using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class TwoTask_WaitAny
    {
        private static Stopwatch stopWatch1 = new Stopwatch();

        private static void MethodA() {
            Thread.SpinWait(int.MaxValue / 1);
            Console.WriteLine("Método A");
        }

        private static void MethodB()
        {
            Thread.SpinWait(int.MaxValue);
            Console.WriteLine("Método B");
        }

        static void Main(string[] args)
        {
            var taskA = Task.Factory.StartNew(MethodA);
            var taskB = Task.Factory.StartNew(MethodB);

            Console.WriteLine($"TaskA id = {taskA.Id}");
            Console.WriteLine($"TaskB id = {taskB.Id}");

            var tasks = new[] { taskA, taskB };
            var whichTask = Task.WaitAny(tasks);
            Console.WriteLine($"La tarea {tasks[whichTask].Id} es la tarea de oro.");

            Console.WriteLine("Presione enter para salir");
            Console.ReadLine();
        }

        static void StopWatch(TimeSpan ts)
        {
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}
