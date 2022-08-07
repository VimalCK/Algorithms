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
     * There is an integer array nums sorted in ascending order (with distinct values). 
     * Prior to being passed to your function, nums is possibly rotated at an unknown pivot 
     * index k (1 <= k < nums.length) such that the resulting array is 
     * [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). 
     * For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].
     * 
     * Given the array nums after the possible rotation and an integer target, return the index of target 
     * if it is in nums, or -1 if it is not in nums. You must write an algorithm with O(log n) runtime complexity.
     */

    public class SearchInRotatedSortedArray : TheoryData<int[], int, int>
    {
        public SearchInRotatedSortedArray()
        {
            Add(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4);
            Add(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1);
            Add(new int[] { 1 }, 0, -1);
        }

        [Theory]
        [ClassData(typeof(SearchInRotatedSortedArray))]
        public void SearchInARotatedSortedArray(int[] input, int target, int expectedResult)
        {
            var result = Search(input, target);

            Assert.Equal(expectedResult, result);
        }

        public int Search(int[] nums, int target)
        {

        }
    }
}
