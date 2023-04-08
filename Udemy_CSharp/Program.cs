using System.Security.Cryptography;

namespace Udemy_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Try Parse------------------------------------------------------------------------------------------------------------------
            //string input = Console.ReadLine();
            //bool success = int.TryParse(input, out int result);

            //if (success)
            //    Console.WriteLine($"Wynik był {success}, parsowana wartośc to: {result}.");
            //else
            //    Console.WriteLine("Wpadka");


            ////Tenary operators-----------------------------------------------------------------------------------------------------------
            //int temperature = -5;
            //string stateOfWatter = temperature > 100 ? "gas" : temperature < 0 ? "Liquid" : "Solid";
            //Console.WriteLine($"Temperature is {temperature} and state of water is {stateOfWatter}");
            //temperature = 5;
            //stateOfWatter = temperature > 100 ? "gas" : temperature < 0 ? "Liquid" : "Solid";
            //Console.WriteLine($"Temperature is {temperature} and state of water is {stateOfWatter}");
            //temperature = 105;
            //stateOfWatter = temperature > 100 ? "gas" : temperature < 0 ? "Liquid" : "Solid";
            //Console.WriteLine($"Temperature is {temperature} and state of water is {stateOfWatter}");

            //int[] Array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //foreach (int i in Array)
            //    if (i % 2 == 0)
            //        Console.WriteLine(i);

            //foreach (int i in Array)
            //    if (i % 2 != 0)
            //        Console.WriteLine(i);

            TicTacToe.Graj();
        }
    }
}