using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.JPMorgan
{
    /* Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses. */

    public class GenerateParentheses : TheoryData<int, List<string>>
    {
        public GenerateParentheses()
        {
            Add(3, new List<string>(new[] { "((()))", "(()())", "(())()", "()(())", "()()()" }));
            Add(1, new List<string>(new[] { "()" }));
        }

        [Theory]
        [ClassData(typeof(GenerateParentheses))]
        public void ParenthesesAreGenerated(int count, List<string> expectedResult)
        {
            var result = GenerateParenthesis(count);

            Assert.True(result.AreEqual(expectedResult));
        }

        public IList<string> GenerateParenthesis(int n)
        {
           
            return default;
        }

    }
}
