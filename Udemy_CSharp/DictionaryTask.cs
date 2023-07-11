using System.Collections.Generic;

namespace Udemy_CSharp
{
    internal class DIctionaryTest
    {
        public static string Convert(int i)
        {
            Dictionary<int, string> numbers = new Dictionary<int, string>();
            numbers.Add(0, "zero");
            numbers.Add(1, "one");
            numbers.Add(2, "two");
            numbers.Add(3, "three");
            numbers.Add(4, "four");
            numbers.Add(5, "five");

            if (numbers.ContainsKey(i))
                return numbers[i];
            else return "nope";
        }
    }
}