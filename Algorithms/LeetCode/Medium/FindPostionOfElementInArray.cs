using Algorithms.Types;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.Medium
{

    /*
     * Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.
     * If target is not found in the array, return [-1, -1].
     * You must write an algorithm with O(log n) runtime complexity.
     */

    public class FindPostionOfElementInArray : TheoryData<int[], int, int[]>
    {
        public FindPostionOfElementInArray()
        {
            Add(new int[] { 5, 7, 7, 8, 8, 10 }, 8, new int[] { 3, 4 });
            Add(new int[] { 5, 7, 7, 8, 8, 10 }, 6, new int[] { -1, -1 });
            Add(new int[] { }, 0, new int[] { -1, -1 });
            Add(new int[] { 1 }, 1, new int[] { 0, 0 });
        }

        [Theory]
        [ClassData(typeof(FindPostionOfElementInArray))]
        public void FindPositonOfElementInASortedArray(int[] data, int target, int[] expectedResult)
        {
           var result = SearchRange(data, target);

            Assert.Equal(expectedResult, result);
        }

        public int[] SearchRange(int[] nums, int target)
        {
            var result = new int[] { -1, -1 };
            result[0] = SearchRange(nums, target, 0, true);
            if (result[0] != -1)
            {
                result[1] = SearchRange(nums, target, result[0], false);
            }

            return result;
        }

        public int SearchRange(int[] nums, int target, int leftIndex, bool searchFirstIndex)
        {
            if (nums == null)
            {
                return -1;
            }

            var foundIndex = -1;
            var rightIndex = nums.GetUpperBound(0);
            while (rightIndex >= leftIndex)
            {
                var midIndex = (leftIndex + rightIndex) / 2;
                var midValue = nums[midIndex];

                if (target == midValue)
                {
                    foundIndex = midIndex;
                    if (searchFirstIndex)
                    {
                        rightIndex = --midIndex;
                        continue;
                    }

                    leftIndex = ++midIndex;
                }
                else if (target < midValue)
                {
                    rightIndex = --midIndex;
                }
                else
                {
                    leftIndex = ++midIndex;
                }
            }

            return foundIndex;
        }
    }
}
