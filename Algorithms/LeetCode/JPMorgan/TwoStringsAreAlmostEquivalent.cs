using Algorithms.LeetCode.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithms.LeetCode.JPMorgan
{
    /*   Two strings word1 and word2 are considered almost equivalent if the differences 
     *   between the frequencies of each letter from 'a' to 'z' between word1 and word2 is at most 3.
     *   Given two strings word1 and word2, each of length n, return true if word1 and word2 are almost 
     *   equivalent, or false otherwise.
     *   
     *   The frequency of a letter x is the number of times it occurs in the string. */

    public class TwoStringsAreAlmostEquivalent : TheoryData<string, string, bool>
    {
        public TwoStringsAreAlmostEquivalent()
        {
            Add("abcdeef", "abaaacc", true);
            Add("zzzyyy", "iiiiii", false);
        }

        [Theory]
        [ClassData(typeof(TwoStringsAreAlmostEquivalent))]
        public void CheckTwoStringsAreAlmostEquivalent(string word1, string word2, bool result)
        {
            var data = CheckAlmostEquivalent(word1, word2);

            Assert.Equal(result, data);

        }

        public bool CheckAlmostEquivalent(string word1, string word2)
        {
            var values = new Dictionary<char, int>();
            foreach (var item in word1)
            {
                values.TryGetValue(item, out var count);
                values[item] = ++count;
            }

            foreach (var item in word2)
            {
                values.TryGetValue(item, out var count);
                values[item] = --count;

            }

            foreach (var item in values)
            {
                if (Math.Abs(item.Value) > 3)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
