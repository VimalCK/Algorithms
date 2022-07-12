 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target. 
     * You may assume that each input would have exactly one solution, and you may not use the same element twice. 
     * You can return the answer in any order.
     */
    public class TwoSumProblem : TheoryData<int[], int>
    {
        public TwoSumProblem()
        {
            Add(new int[] { 2, 7, 11, 15 }, 9);
        }

        [Theory]
        [ClassData(typeof(TwoSumProblem))]
        public void TwonumbersInArray_Should_Return_SumNumber(int[] value1, int value2)
        {
            var result = TwoSum(value1, value2);

            Assert.True(result.Length == 2);
            Assert.Equal(0, result[0]);
            Assert.Equal(1, result[1]);
        }

        private int[] TwoSum(int[] nums, int target)
        {
            var dictionary = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var temp = nums[i];
                var diff = target - temp;
                if (dictionary.ContainsKey(diff))
                {
                    return new int[] { dictionary[diff], i };
                }

                dictionary[temp] = i;
            }

            return new int[] { };
        }
    }
}
