namespace Threads
{
    internal static class ThreadPoolTutorial
    {
        public static void PseudoMain()
        {
            // Created 1000 cases of functions using ThreadPool
            Enumerable.Range(0, 1000).ToList().ForEach(x => 
            {
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    Console.WriteLine($"Thread number {Thread.CurrentThread.ManagedThreadId} started");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Thread number {Thread.CurrentThread.ManagedThreadId} stopped");
                });
            });

            Console.ReadKey();
        }
    }
}
