using Algorithms.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Algorithms.LeetCode.Medium
{
    /*
     * A peak element is an element that is strictly greater than its neighbors.
     * Given a 0-indexed integer array nums, find a peak element, and return its index. 
     * If the array contains multiple peaks, return the index to any of the peaks.
     * You may imagine that nums[-1] = nums[n] = -∞. In other words, an element is always considered to 
     * be strictly greater than a neighbor that is outside the array.
     * You must write an algorithm that runs in O(log n) time.
     */

    public class FindPeakElementFromArray : TheoryData<int[], int>
    {
        public FindPeakElementFromArray()
        {
            Add(new int[] { 1 }, 0);
            Add(new int[] { 1, 2 }, 1);
            Add(new int[] { 1, 2, 1 }, 1);
            Add(new int[] { 3, 4, 3, 2, 1 }, 1);
            Add(new int[] { 1, 2, 3, 1 }, 2);
            Add(new int[] { 1, 2, 1, 3, 5, 6, 4 }, 5);
            Add(new int[] { 6, 5, 4, 3, 2, 3, 2 }, 0);
        }

        [Theory]
        [ClassData(typeof(FindPeakElementFromArray))]
        public void FindPeakElementFromArrayIfFound(int[] input, int expectedResult)
        {
            var result = FindPeakElement(input, input.GetLowerBound(0), input.GetUpperBound(0));

            Assert.Equal(expectedResult, result);
        }

        public int FindPeakElement(int[] nums, int left, int right)
        {
            if (left == right)
            {
                return left;
            }

            var mid = (left + right) / 2;
            if (nums[mid] > nums[mid + 1])
            {
                return FindPeakElement(nums, left, mid);
            }

            return FindPeakElement(nums, mid + 1, right);

            //left = 0;
            //right = nums.GetUpperBound(0);
            //while (left < right)
            //{
            //    var mid = (left + right) / 2;
            //    if (nums[mid] > nums[mid + 1])
            //    {
            //        right = mid;
            //        continue;
            //    }

            //    left = mid + 1;
            //}

            //return left;
        }
    }
}
