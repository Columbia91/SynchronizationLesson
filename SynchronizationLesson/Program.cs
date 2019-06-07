using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizationLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = new Counter();
            var threads = new Thread[20];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(counter.IncreaseNumber);
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            Console.ReadLine();
        }
    }
}
