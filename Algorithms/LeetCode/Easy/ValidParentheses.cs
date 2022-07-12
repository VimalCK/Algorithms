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
            Add("()", true);
            Add("()[]{}", true);
            Add("(]", false);
        }

        [Theory]
        [ClassData(typeof(ValidParentheses))]
        public void Return_True_If_Parentheses_Are_Valid()
        {

        }

        public bool IsValid(string s)
        {

        }
    }
}
