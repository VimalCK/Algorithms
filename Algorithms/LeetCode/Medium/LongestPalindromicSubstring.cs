using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Algorithms.IAlogrithm;

namespace Algorithms.LeetCode.Medium
{
    public class LongestPalindromicSubstring : IAlgorithm<string>
    {
        [Theory]
        [InlineData("")]
        public void Run(string value)
        {

        }

        public string LongestPalindrome(string s)
        {
            return s;
        }


    }
}
