using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    public class RansomNote : TheoryData<string, string, bool>
    {
        public RansomNote()
        {
            Add("a", "b", false);
            Add("a", "ab", true);
            Add("aa", "ab", false);
            Add("aa", "aab", true);
            Add("aab", "baa", true);
            Add("bg", "efjbdfbdgfjhhaiigfhbaejahgfbbgbjagbddfgdiaigdadhcfcj", true);
        }

        [Theory]
        [ClassData(typeof(RansomNote))]
        public void Check_If_RansomNote_CanBe_Constructed(string ransomNote, string magazine, bool expectedResult)
        {
            var result = CanConstruct(ransomNote, magazine);

            Assert.Equal(expectedResult, result);
        }

        public bool CanConstruct(string ransomNote, string magazine)
        {
            var magazineArray = magazine.ToCharArray();

            foreach (var chr in ransomNote)
            {
                var index = Array.IndexOf(magazineArray, chr);
                if (index != -1)
                {
                    magazineArray[index] = '0';
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}
