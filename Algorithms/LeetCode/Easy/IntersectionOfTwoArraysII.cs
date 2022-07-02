using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    public class IntersectionOfTwoArraysII : TheoryData<int[], int[], int[]>
    {
        public IntersectionOfTwoArraysII()
        {
            Add(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 }, new int[] { 2, 2 });
            Add(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 }, new int[] { 9, 4 });
        }

        [Theory]
        [ClassData(typeof(IntersectionOfTwoArraysII))]
        public void ReturnArrayOfIntersectionOfTwoArray(int[] param1, int[] param2, int[] param3)
        {
            var result = Intersect(param1, param2);

            Assert.Equal(param3, result);
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                return Intersect(nums2, nums1);
            }

            var dictionary = new Dictionary<int, int>();
            foreach (var num in nums1)
            {
                dictionary.TryGetValue(num, out int value);
                dictionary[num] = value + 1;
            }

            int k = 0;
            foreach (var num in nums2)
            {
                dictionary.TryGetValue(num, out int cnt);
                if (cnt > 0)
                {
                    nums1[k++] = num;
                    dictionary[num] = cnt - 1;
                }
            }

            int[] result = new int[k];
            Array.Copy(nums1, 0, result, 0, k);
            return result;

        }
    }
}
