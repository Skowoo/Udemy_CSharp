namespace Udemy_CSharp
{
    internal class Null_Coalescing
    {
        public static void PseudoMain()
        {
            int? example = null;

            Console.WriteLine($"Example int? is null?: {example is null}, value: |{example}|");
            Console.WriteLine($"If Example IS NULL >>write/pass<< ( ?? ) value of 10: {example ?? 10}");
            Console.WriteLine($"Example int? is null?: {example is null}, value: |{example}|");
            Console.WriteLine($"If Example IS NULL >>assign<< ( ??= ) value of 10:  {example ??= 10}");
            Console.WriteLine($"If Example IS NULL >>assign<< ( ??= ) value of 200: {example ??= 200} (failed as Example is not null here)");
            Console.WriteLine($"Example int? is null?: {example is null}, value: |{example}|");
        }

        #region Microsoft example

        private static void MicrosoftExample() 
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.

            List<int>? numbers = null;

            Console.WriteLine((numbers is null)); // expected: true
                                                  // if numbers is null, initialize it. Then, add 5 to numbers
            (numbers ??= new List<int>()).Add(5);
            Console.WriteLine(string.Join(" ", numbers));  // output: 5
            Console.WriteLine((numbers is null)); // expected: false        


            int? a = null;

            Console.WriteLine(a is null); // expected: true

            // a ?? 3 - IF a IS NULL assign value of 3
            Console.WriteLine(a ?? 3); // expected: 3 since a is still null. if a is null then assign 0 to a and add a to the list
            Console.WriteLine(a);
            numbers.Add(a ??= 0);

            Console.WriteLine(a is null); // expected: false        
            Console.WriteLine(string.Join(" ", numbers));  // output: 5 0
            Console.WriteLine(a);  // output: 0	
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
        #endregion

    }
}
