using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*   
     
    Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    An input string is valid if:

    Open brackets must be closed by the same type of brackets.
    Open brackets must be closed in the correct order.
    
     */

    public class ValidParentheses : TheoryData<string, bool>
    {
        public ValidParentheses()
        {
            Add("([)]", false);
            //Add("]", false);
            //Add("()", true);
            //Add("()[]{}", true);
            //Add("(]", false);
        }

        [Theory]
        [ClassData(typeof(ValidParentheses))]
        public void Return_True_If_Parentheses_Are_Valid(string value, bool expectedResult)
        {
            var result = IsValid(value);

            Assert.Equal(expectedResult, result);
        }

        public bool IsValid(string s)
        {
            var parantheses = new Dictionary<char, char>()
            {
                {'(',')' },
                {'{','}' },
                {'[',']' }
            };

            var stack = new Stack<char>();
            foreach (var item in s)
            {
                if (parantheses.TryGetValue(item, out char chr))
                {
                    stack.Push(chr);
                    continue;
                }

                if (stack.Count != 0 && stack.Peek() == item)
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(item);
                    break;
                }
            }

            return stack.Count == 0;
        }
    }
}
