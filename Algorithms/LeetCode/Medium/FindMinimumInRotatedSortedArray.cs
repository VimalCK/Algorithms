using Algorithms.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.Medium
{
    /*
     * Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, 
     * the array nums = [0,1,2,4,5,6,7] might become:
     *  #   [4,5,6,7,0,1,2] if it was rotated 4 times.
     *  #   [0,1,2,4,5,6,7] if it was rotated 7 times.
     *  
     *  Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the 
     *  array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].
     *  
     *  Given the sorted rotated array nums of unique elements, return the minimum element of this array.
     *  You must write an algorithm that runs in O(log n) time.
     */

    public class FindMinimumInRotatedSortedArray : TheoryData<int[], int>
    {
        public FindMinimumInRotatedSortedArray()
        {
            Add(new int[] { 3, 4, 5, 1, 2 }, 1);
            Add(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0);
            Add(new int[] { 11, 13, 15, 17 }, 11);
        }

        [Theory]
        [ClassData(typeof(FindMinimumInRotatedSortedArray))]
        public void FinidMinimumInRotatedSortedArray(int[] input, int expectedResult)
        {
            var result = FindMin(input);

            Assert.Equal(expectedResult, result);
        }

        public int FindMin(int[] nums)
        {

        }
    }
}
