using System.Text.RegularExpressions;

namespace Udemy_CSharp.RegexTraining
{
    public class RegexAssignment
    {
        public static void PseudoMain()
        {
            // File stored in project
            string input = File.ReadAllText(@"C:\Users\Skowoo\Desktop\input2.txt");

            string pattern = @"\d{2,3}";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            string result = "";

            foreach (Match match in matches)
            {
                int parsed = int.Parse(match.Value);
                result += (char)parsed;
            }

            Console.WriteLine(result);
            //Result form this part:  of succes. It is part of ssuccess.
            //Combined result:        Failure is not the opposite of succes. It is part of ssuccess.
        }
    }
}
