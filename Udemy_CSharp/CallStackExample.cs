using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy_CSharp
{
    internal static class CallStackExample
    {
        //Debug -> Windows -> Call Stack (ctrl + alt + c) - when exception thrown
        public static void PseudoMain()
        {
            Console.WriteLine(Metoda1(1));
            Console.WriteLine(Metoda1(3));
            Console.WriteLine(Metoda1(1));
        }

        public static string Metoda1(int cos) => Metoda2(cos);

        public static string Metoda2(int cos)
        {
            string[] test = { "a", "b", "c" };
            return test[cos];
        }
    }
}
