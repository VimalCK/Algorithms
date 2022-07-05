using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    public class FirstUniqueCharacter : TheoryData<string, int>
    {
        public FirstUniqueCharacter()
        {
            Add("leetcode", 0);
            Add("loveleetcode", 2);
            Add("aabb", -1);
            Add("dddccdbba", 8);
        }

        [Theory]
        [ClassData(typeof(FirstUniqueCharacter))]
        public void Return_First_Unique_Character_InaString(string input, int expectedResult)
        {
            var result = FirstUniqChar(input);

            Assert.Equal(expectedResult, result);
        }

        public int FirstUniqChar(string s)
        {
            int index = 0;
            var nonDuplicateItemIndex = new List<int>();
            var characters = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (!characters.ContainsKey(c))
                {
                    characters[c] = index;
                    nonDuplicateItemIndex.Add(index);
                }
                else
                {
                    nonDuplicateItemIndex.Remove(characters[c]);
                }

                index++;
            }

            var enumerator = nonDuplicateItemIndex.GetEnumerator();
            return enumerator.MoveNext() ? enumerator.Current : -1;
        }
    }
}
