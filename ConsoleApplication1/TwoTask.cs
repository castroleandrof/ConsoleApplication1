using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ConsoleApplication1
{
    class TwoTask
    {
        static void Main(string[] args)
        {
            // Tarea1();
            //IntegerTask2();
            //TwoTask_WaitAny();
            GenerarNumeros();
        }

        private static Stopwatch stopWatch1 = new Stopwatch();

        static void MethodA()
        {
            Console.WriteLine("Método A");
            Thread.Sleep(1000);
        }

        static void MethodB()
        {
            Console.WriteLine("Método B");
            Thread.Sleep(3000);
        }

        static void Tarea1()
        {
            var TaskA = Task.Factory.StartNew(MethodA);
            var TaskB = Task.Factory.StartNew(MethodB);
            stopWatch1.Start();
            Task.WaitAll(TaskA, TaskB);
            stopWatch1.Stop();
            Utilidades.StopWatch(stopWatch1.Elapsed);
            Console.WriteLine("Presione enter para salir");
            Console.WriteLine("Task A id = {0}", TaskA.Id);
            Console.WriteLine("Task B id = {0}", TaskB.Id);
            Console.ReadLine();
        }

        static void TwoTask_WaitAny()
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

      
        static void IntegerTask()
        {
            {
                var taskA = Task<int>.Factory.StartNew(val => ((string)val).Length, "Parallel Programming in Vistual studio");

                taskA.Wait();
                Console.WriteLine(taskA.Result);

                Console.WriteLine("Presione enter para salir");
                Console.ReadLine();
            }
        }

        static int MethodB2(String message) {
            return message.Length;
        }

        static void IntegerTask2()
        {
            {
                String message = Console.ReadLine();   
                var taskA = Task<int>.Factory.StartNew(() => MethodB2(message));

                taskA.Wait();
                Console.WriteLine(taskA.Result);

                Console.WriteLine("Presione enter para salir");
                Console.ReadLine();
            }
        }

        static void GenerarNumeros() {
            stopWatch1.Start();
            for (int i = 0; i < 6; i++) {
                var Task1 = Task<int>.Factory.StartNew(() => Utilidades.GetNumber(0,45));
                Task1.Wait();
                Console.WriteLine($"La tarea {Task1.Id} dio el numero {Task1.Result}");
            }
            stopWatch1.Stop();
            Utilidades.StopWatch(stopWatch1.Elapsed);
            Console.ReadLine();

        }
    }
}