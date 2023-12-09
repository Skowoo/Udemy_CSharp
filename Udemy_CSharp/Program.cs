using Udemy_CSharp.RegexTraining;

namespace Udemy_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] table = { 1, 1, 1, 2, 3, 4, 5, 2 };
            int result = TrainingExcercises.SumOfTwo(table, 2);
            Console.WriteLine(result == 1);
        }
    }
}