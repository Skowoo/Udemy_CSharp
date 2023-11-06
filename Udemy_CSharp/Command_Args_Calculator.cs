//using Udemy_CSharp.RegexTraining;

//namespace Udemy_CSharp
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            if (args.Length == 0)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Please insert command line arguments next time. If You need instructions write \"Help\"");
//                Console.ResetColor();
//                return;
//            }

//            if (args[0].ToUpper() == "HELP")
//            {
//                ShowHelp();
//                return;
//            }

//            if (args.Length != 3)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Wrong input. Type 'help' for manual");
//                Console.ResetColor();
//                if (Console.ReadLine().ToUpper() == "HELP")
//                    ShowHelp();
//                return;
//            }
//            else
//            {
//                bool firstParsed = double.TryParse(args[0], out double firstArgument);
//                bool secondParsed = double.TryParse(args[2], out double secondArgument);

//                if (!firstParsed || !secondParsed)
//                {
//                    ShowHelp();
//                    return;
//                }

//                double result;

//                switch (args[1].ToUpper())
//                {
//                    case "ADD":
//                        goto case "+";
//                    case "SUBTRACT":
//                        goto case "-";
//                    case "DIVIDE":
//                        goto case "/";
//                    case "MULTIPLY":
//                        goto case "*";
//                    case "+":
//                        result = firstArgument + secondArgument;
//                        break;
//                    case "-":
//                        result = firstArgument - secondArgument;
//                        break;
//                    case "/":
//                        result = firstArgument / secondArgument;
//                        break;
//                    case "*":
//                        result = firstArgument * secondArgument;
//                        break;
//                    default:
//                        Console.ForegroundColor = ConsoleColor.Red;
//                        Console.WriteLine("Wrong operation chosen!");
//                        ShowHelp();
//                        return;
//                }

//                Console.ForegroundColor = ConsoleColor.Green;
//                Console.WriteLine($"Result is: {result}");
//                Console.ResetColor();
//                return;
//            }
//        }

//        private static void ShowHelp()
//        {
//            Console.ForegroundColor = ConsoleColor.White;
//            Console.WriteLine(@"Instructions:
//This simple calculator uses command line arguments. To work properly it needs three things passes separated by space:
//1. first argument - numeric value
//2. Operation sign: add (+), subtract (-), divide (/), multiply (*)
//3. second argument - numeric value
//Try running this application again with input described as above. For example: '14 add 44' or '8 / 4'");
//            Console.ResetColor();
//            return;
//        }
//    }
//}