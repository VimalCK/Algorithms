using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
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

            return null;
        }
    }
}
