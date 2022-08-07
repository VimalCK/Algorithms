using Algorithms.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Given two strings s and t, return true if they are equal when both are typed into empty text editors. 
     * '#' means a backspace character.
     * 
     * Note that after backspacing an empty text, the text will continue empty.
     */

    public class BackspaceStringCompare : TheoryData<string, string, bool>
    {
        public BackspaceStringCompare()
        {
            Add("ab#c", "ad#c", true);
            Add("ab##", "c#d#", true);
            Add("a#c", "b", false);
        }

        [Theory]
        [ClassData(typeof(BackspaceStringCompare))]
        public void CompareStringsAreEqual(string s, string t, bool expectedResult)
        {
            var result = BackspaceCompare(s, t);

            Assert.Equal(expectedResult, result);
        }

        public bool BackspaceCompare(string s, string t)
        {
            return BuildString(s) == BuildString(t);
        }

        public string BuildString(string value)
        {
            var values = new Stack<char>();
            foreach (var item in value)
            {
                if (item != '#')
                {
                    values.Push(item);
                }
                else if(values.Count > 0)
                {
                    values.Pop();
                }
            }

            return new string(values.ToArray());
        }
    }
}
