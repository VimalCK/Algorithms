using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Medium
{
    /*
     * Given a string s, find the length of the longest substring without repeating characters.
     */
    public class LongestSubstringWithoutRepeatingCharacters : TheoryData<string, int>
    {
        public LongestSubstringWithoutRepeatingCharacters()
        {
            Add("abcabcbb", 3);
            Add("bbbbb", 1);
            Add("pwwkew", 3);
        }

        [Theory]
        [ClassData(typeof(LongestSubstringWithoutRepeatingCharacters))]
        public void ShouldReturnLengthOfLongestSubstringWithoutRepeatingCharecter(string value1, int value2)
        {
            var result = LengthOfLongestSubstring(value1);

            Assert.Equal(value2, result);
        }


        private int LengthOfLongestSubstring(string s)
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
