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
     * Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that 
     * i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
     * Notice that the solution set must not contain duplicate triplets.
     *      Input: nums = [-1,0,1,2,-1,-4]
     *      Output: [[-1,-1,2],[-1,0,1]]
     *      Explanation: 
     *      nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
     *      nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
     *      nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
     *      The distinct triplets are [-1,0,1] and [-1,-1,2].
     *      Notice that the order of the output and the order of the triplets does not matter.
     */

    public class ThreeSumWithoutDuplicates : TheoryData<int[], IList<IList<int>>>
    {
        public ThreeSumWithoutDuplicates()
        {
            Add(new[] { 0, 1, 1 }, new int[][] { });
            Add(new[] { 0, 1, 1 }, new int[][] { });
            Add(new[] { 0, 0, 0, 0 }, new int[][] { new[] { 0, 0, 0 } });
            Add(new[] { -2, 0, 0, 2, 2 }, new int[][] { new[] { -2, 0, 2 } });
            Add(new[] { 0, 0, 0 }, new int[][] { new[] { 0, 0, 0 } });
        }

        [Theory]
        [ClassData(typeof(ThreeSumWithoutDuplicates))]
        public void ReturnAllTheTriplets(int[] input, IList<IList<int>> expectedResult)
        {
            var result = ThreeSum(input);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.True(expectedResult[i].OrderBy(i => i).AreEqual(result[i].OrderBy(i => i)));
            }
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();
            for (int i = 0; i < nums.Length && nums[i] <= 0; ++i)
                if (i == 0 || nums[i - 1] != nums[i])
                {
                    int left = i + 1;
                    int right = nums.Length - 1;
                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right];
                        if (sum < 0)
                        {
                            ++left;
                        }
                        else if (sum > 0)
                        {
                            --right;
                        }
                        else
                        {
                            result.Add(new int[] { nums[i], nums[left++], nums[right--] });
                            while (left < right && nums[left] == nums[left - 1])
                            {
                                ++left;
                            }
                        }
                    }
                }

            return result;
        }

    }
}
