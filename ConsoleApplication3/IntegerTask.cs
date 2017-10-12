using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class IntegerTask
    {
        static void Main(string[] args)
        {
            var taskA = Task<int>.Factory.StartNew(val => ((string)val).Length, "Parallel Programming in Vistual studio");

            taskA.Wait();
            Console.WriteLine(taskA.Result);

            Console.WriteLine("Presione enter para salir");
            Console.ReadLine();
        }
    }
}
