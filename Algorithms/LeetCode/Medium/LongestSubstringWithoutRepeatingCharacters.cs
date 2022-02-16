using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Algorithms.IAlogrithm;

namespace Algorithms.LeetCode.Medium
{
    public class LongestSubstringWithoutRepeatingCharacters : IAlgorithm<string, int>
    {
        public static IEnumerable<object[]> Parameters => new List<object[]>
        {
            new object[]{ "abcabcbb", 3 },
            new object[]{ "bbbbb", 1 },
            new object[]{ "pwwkew", 3 }
        };

        [Theory]
        [MemberData(nameof(Parameters))]
        public void Run(string value1, int value2)
        {
            var result = LengthOfLongestSubstring(value1);

            Assert.Equal(value2, result);
        }


        public int LengthOfLongestSubstring(string s)
        {
            int count = 0;
            string temp = string.Empty;
            foreach (char item in s)
            {
                if (temp.Contains(item))
                {
                    temp = temp.Substring(temp.IndexOf(item) + 1) + item;
                }
                else
                {
                    temp += item;
                    count = Math.Max(temp.Length, count);
                }
            }

            return count;
        }
    }
}
