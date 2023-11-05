using System.Text.RegularExpressions;

namespace Udemy_CSharp.RegexTraining
{
    public class Regular_Expressions
    {
        public static void PseudoMain()
        {
            string pattern = @"\d";
            Regex regex = new Regex(pattern);

            string text = "Hi there, my number is 12314";

            MatchCollection matchCollection = regex.Matches(text);

            Console.WriteLine($"{matchCollection.Count} matches found:");
            foreach (Match match in matchCollection)
            {
                GroupCollection group = match.Groups;
                Console.WriteLine($"'{group[0].Value}' found at {group[0].Index}");
            }
        }
    }
}
