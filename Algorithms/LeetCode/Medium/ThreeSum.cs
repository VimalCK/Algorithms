using Algorithms.Types;
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

    public class Three3Sum : TheoryData<int[], IList<IList<int>>>
    {
        public Three3Sum()
        {
            Add(new[] { -1, 0, 1, 2, -1, -4 }, new int[][]
            {
                new int[]{ -1, -1, 2 },
                new int[]{ -1, 0, 1 }
            });

            Add(new[] { 0, 1, 1 }, new int[][] { });
            Add(new[] { 0, 0, 0 }, new int[][] { new int[] { 0, 0, 0 } });
        }

        [Theory]
        [ClassData(typeof(Three3Sum))]
        public void ReturnAllTheTriplets(int[] input, IList<IList<int>> expectedResult)
        {

        }
    }
}
