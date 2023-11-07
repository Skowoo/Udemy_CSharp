namespace Udemy_CSharp
{
    public class Lambda_Expressions
    {
        public static void PseudoMain()
        {

        }

        public static void LambdaDeclaraion()
        {
            // this function gets an int argument and returns another int
            Func<int, int> PlusOne = a => a + 1;

            // it is the way you can call this function
            int res = PlusOne(3); //res = 4
        }

        #region Excercise 16

        //using System.Collections.Generic;

        //--------------- ANONYMOUS FUNCTION MUST BE DECLARED BEFORE DICTIONARY!!!!!----------------------------
        public static Func<float, float, float> Plus = (a, b) => a + b;
        public static Func<float, float, float> Minus = (a, b) => a - b;
        public static Func<float, float, float> Divide = (a, b) => a / b;
        public static Func<float, float, float> Multiply = (a, b) => a * b;

        public static Dictionary<string, Func<float, float, float>> Operators = new Dictionary<string, Func<float, float, float>>
        {
            { "+", Plus },
            { "-", Minus },
            { "*", Multiply },
            { "/", Divide }
        };

        public static Func<float, float, float> OperationGet(string input)
        {
            if (Operators.ContainsKey(input))
                return Operators[input];
            else
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        //Create a dictionary that will contain <string, Func<>> pairs.
        //The keys will be operation signs "+", "-", "/", "*"
        //and values will be the lambda expressions that will perform
        //the corresponding operation on two floats and return a result with type float.

        //Create a static method OperationGet that will get as input a string,
        //test if this string is a Key in the dictionary and if positive return function otherwise returns null.

        #endregion
    }
}
