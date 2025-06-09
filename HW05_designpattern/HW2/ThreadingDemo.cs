using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class ThreadingDemo
    {
        public static void RunThreadingTest()
        {
            Console.WriteLine("\n----- THREADING TEST -----");
            Console.WriteLine("Creating logger instances from multiple threads...");

            // Create and start 5 threads
            Thread[] threads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(() =>
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: Getting logger instance");
                    Logger logger = Logger.GetInstance;
                    logger.LogInfo($"Log from thread {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(100); // Small delay
                });

                threads[i].Start();
            }

            // Wait for all threads to complete
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine($"Threading test complete. Instance count: {Logger.InstanceCount}");
            Console.WriteLine("----- END THREADING TEST -----\n");
        }
    }

}
