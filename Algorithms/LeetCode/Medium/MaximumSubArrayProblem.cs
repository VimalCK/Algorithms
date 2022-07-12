using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.Medium
{
    /*
     * Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest 
     * sum and return its sum.
     * A subarray is a contiguous part of an array.
     */
    public class MaximumSubArrayProblem : TheoryData<int[], int>
    {
        public MaximumSubArrayProblem()
        {
            Add(new int[] { -1 }, -1);
            Add(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6);
            Add(new int[] { 1 }, 1);
            Add(new int[] { 5, 4, -1, 7, 8 }, 23);
        }

        [Theory]
        [ClassData(typeof(MaximumSubArrayProblem))]
        public void ReturnSubArrayWithMaximumSum(int[] data, int expectedResult)
        {
            var result = MaxSubArray(data);

            Assert.Equal(result, expectedResult);
        }

        public int MaxSubArray(int[] nums)
        {
            var sum = int.MinValue;
            var temp = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                temp = nums[i] + Math.Max(0, temp);
                sum = Math.Max(sum, temp);
            }

            return sum;
        }
    }
}
