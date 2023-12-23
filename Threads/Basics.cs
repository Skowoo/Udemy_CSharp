namespace Threads
{
    internal static class Basics
    {
        public static void PseudoMain()
        {
            //// Creation of new thread
            //new Thread(() => {
            //    Console.WriteLine("Task from new thread");
            //}).Start();

            // Thread with task completion
            var taskCompletionSource = new TaskCompletionSource<bool>();

            Thread thread = new(()=>
            {
                Console.WriteLine($"Thread number {Thread.CurrentThread.ManagedThreadId} started");
                Thread.Sleep(1000);
                taskCompletionSource.TrySetResult(false);
                Console.WriteLine($"Thread number {Thread.CurrentThread.ManagedThreadId} stopped");
            });
            
            thread.Start();

            var test = taskCompletionSource.Task.Result;
            Console.WriteLine(test);
        }
    }
}
