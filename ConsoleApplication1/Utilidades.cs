using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Utilidades
    {
        private static Random rnd = new Random();
        public static void StopWatch(TimeSpan ts)
        {
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }

        public static int GetNumber(int inicio, int fin)
        {
            int result = rnd.Next(inicio, fin);
            return result;
        }
    }
}
