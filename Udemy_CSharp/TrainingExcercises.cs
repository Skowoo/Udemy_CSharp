using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Udemy_CSharp
{
    internal class TrainingExcercises
    {

        //This time you have to write a method that will take two arguments:
        //a list of integers nums and an integer SumToFind.And it returns the number of
        //possible UNIQUE pares made from this list where the sum equals to SumToFind
        //Example:
        //SumOfTwo([1, 1, 1, 2, 3, 4, 5, 2], 2) 
        //It should return: 1
        //Explanation: there is only one pair sum of witch is equal to 2 (1,1)

        public static int SumOfTwo(int[] nums, int SumToFind)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int result = 0;

            foreach (int value in nums)
            {
                if (dic.ContainsKey(SumToFind - value) && dic[SumToFind - value] > 0)
                {
                    dic[SumToFind - value] -= 1;

                    result++;
                    continue;
                }
                if (dic.ContainsKey(value))
                {
                    dic[value] += 1;
                }
                else
                {
                    dic.Add(value, 1);
                }
            }
            return result;
        }

        public static int NotHungryCats(string kitchen)
        {
            var cats = kitchen.Replace(" ", "").Split('F');

            var leftCount = cats[0].Where((x, i) => i % 2 == 1).Count(x => x == '~');
            var rightCount = cats[1].Where((x, i) => i % 2 == 0).Count(x => x == '~');

            return leftCount + rightCount;
        }
    }
}
