﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, 
     * representing the number of elements in nums1 and nums2 respectively. Merge nums1 and nums2 into a single array 
     * sorted in non-decreasing order. The final sorted array should not be returned by the function, 
     * but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the 
     * first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. 
     * nums2 has a length of n.
     */
    public class MergeTwoSortedArray : TheoryData<int[], int, int[], int, int[]>
    {
        public MergeTwoSortedArray()
        {
            Add(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3, new int[] { 1, 2, 2, 3, 5, 6 });
            Add(new int[] { 1 }, 1, new int[] { }, 0, new int[] { 1 });
            Add(new int[] { 0 }, 0, new int[] { 1 }, 1, new int[] { 1 });

        }

        [Theory]
        [ClassData(typeof(MergeTwoSortedArray))]
        public void ReturnMergedArray(int[] data1, int limit1, int[] data2, int limit2, int[] expectedResult)
        {
            var result = Merge(data1, limit1, data2, limit2);

            Assert.Equal(expectedResult, result);
        }

        private int[] Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int p1 = m - 1;
            int p2 = n - 1;

            for (int i = (m + n) - 1; i >= 0; i--)
            {
                if (p2 < 0)
                {
                    break;
                }

                nums1[i] = p1 >= 0 && nums1[p1] > nums2[p2] ? nums1[p1--] : nums2[p2--];
            }

            return nums1;
        }
    }
}
