using System;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Given two strings s and t, return true if t is an anagram of s, and false otherwise. 
     * An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
     * typically using all the original letters exactly once.
     */
    public class ValidAnagram : TheoryData<string, string, bool>
    {
        public ValidAnagram()
        {
            Add("a", "ab", false);
            Add("aacc", "ccac", false);
        }

        [Theory]
        [ClassData(typeof(ValidAnagram))]
        public void Return_True_If_Valid_Anagram(string s, string t, bool expectedResult)
        {
            var result = IsAnagram(s, t);

            Assert.Equal(expectedResult, result);
        }

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            var array = s.ToCharArray();
            foreach (var chr in t)
            {
                var index = Array.IndexOf(array, chr);
                if (index != -1)
                {
                    array[index] = '0';
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}
