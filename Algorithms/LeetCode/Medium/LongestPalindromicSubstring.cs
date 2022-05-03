using System;
using System.Diagnostics;
using Xunit;
using Xunit.Sdk;

namespace Algorithms.LeetCode.Medium
{
    public class LongestPalindromicSubstring : TheoryData<string, string>
    {
        public LongestPalindromicSubstring()
        {
            Add("aacabdkacaa", "aca");
            //Add("aaaaa", "aaaaa");
            //Add("a", "a");
            //Add("babad", "bab");
            //Add("cbbd", "bb");
            //Add("ac", "a");
            //Add("bb", "bb");
            //Add("abb", "bb");
            //Add("bacabab", "bacab");
            //Add("xaabacxcabaaxcabaax", "xaabacxcabaax");
            //Add("aaabcaaaaa", "aaaaa");
            //Add("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        }

        [Theory]
        [ClassData(typeof(LongestPalindromicSubstring))]
        public void ShouldReturnLongestPalindrome(string value, string exprected)
        {
            var result = LongestPalindrome(value);

            Assert.Equal(exprected, result);
        }


        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
            {
                return s;
            }

            var palindrome = s[0].ToString();
            var isPalindrome = false;
            var lPosition = 0;
            var lIndex = 0;
            var rPosition = s.Length - 1;

            for (int rIndex = rPosition; rIndex >= lIndex;)
            {
                isPalindrome = s[lIndex] == s[rIndex];
                if (!isPalindrome)
                {
                    lIndex = lPosition;
                    for (int i = rPosition - 1; i >= lPosition; i--)
                    {
                        if (s[lPosition] == s[i])
                        {
                            rIndex = rPosition = i;
                            break;
                        }
                    }

                    if (rIndex == rPosition)
                    {
                        continue;
                    }
                }
                else if (rIndex - lPosition <= 1)
                {
                    palindrome = s.Substring(lPosition, (rPosition - lPosition) + 1);
                    lIndex = ++lPosition;
                    rIndex = rPosition = s.Length - 1;
                    continue;
                }

                rIndex--;
                lIndex++;
            }


            return s;
        }


    }
}
