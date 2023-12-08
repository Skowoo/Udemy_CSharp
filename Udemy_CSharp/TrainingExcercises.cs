using System.Text.RegularExpressions;

namespace Udemy_CSharp
{
    internal class TrainingExcercises
    {
        public static int NotHungryCats(string kitchen)
        {
            var cats = kitchen.Replace(" ", "").Split('F');

            var leftCount = cats[0].Where((x, i) => i % 2 == 1).Count(x => x == '~');
            var rightCount = cats[1].Where((x, i) => i % 2 == 0).Count(x => x == '~');

            return leftCount + rightCount;
        }
    }
}
