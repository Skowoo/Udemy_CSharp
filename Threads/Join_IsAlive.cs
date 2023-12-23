namespace Threads
{
    internal static class Join_IsAlive
    {
        public static void PseudoMain()
        {
            Console.WriteLine("Main thread started");

            Thread thread1 = new Thread(ThreadFunction1);
            Thread thread2 = new Thread(ThreadFunction2);

            thread1.Start();
            thread2.Start();


            // int parameter of thread1.Join() specifies ammount of milliseconds of which main thread should wait for it's execution
            if (thread1.Join(1000))
                Console.WriteLine("Thread1 function done");
            else
                Console.WriteLine("Thread1 function not done in 1 second!");

            // Main thread will wait till thread1 will Join in (finish it's execution) - blocking calling thread
            thread2.Join();
            Console.WriteLine("Thread2 function done");

            if (thread1.IsAlive)
                Console.WriteLine(nameof(thread1) + " is still doing stuff");
            else
                Console.WriteLine(nameof(thread1) + " finished");

            if (thread2.IsAlive)
                Console.WriteLine(nameof(thread2) + " is still doing stuff");
            else
                Console.WriteLine(nameof(thread2) + " finished");

            Console.WriteLine("Main thread ended");
        }

        public static void ThreadFunction1()
        {
            Thread.Sleep(5000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thread function number 1");
            Console.ResetColor();
        }

        public static void ThreadFunction2()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Thread function number 2");
            Console.ResetColor();
        }
    }
}
