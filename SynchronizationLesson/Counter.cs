using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizationLesson
{
    [Synchronization]
    public class Counter : ContextBoundObject
    {
        private int number = -1;
        private object lockObject = new object();
        public void IncreaseNumber()
        {
            //lock (lockObject)
            //{
            //    while (number <= 20)
            //    {
            //        Console.WriteLine($"Поток начал работу ({Thread.CurrentThread.ManagedThreadId})");
            //        Console.WriteLine(number);
            //        number++;
            //        Thread.Sleep(5 * new Random().Next(100));
            //    }
            //}

            Monitor.Enter(lockObject);
            try
            {
                while (number <= 20)
                {
                    Console.WriteLine($"Поток начал работу ({Thread.CurrentThread.ManagedThreadId})");
                    Console.WriteLine(number);
                    number++;
                    Thread.Sleep(5 * new Random().Next(100));
                }

            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }
    }
}
