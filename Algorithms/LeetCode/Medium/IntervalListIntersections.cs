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
     * 
     */

    public class IntervalListIntersections : TheoryData<int[][], int[][], int[][]>
    {
        public IntervalListIntersections()
        {
            Add(new int[][]
            {
                new int[]{ 0, 2 },
                new int[]{5, 10 },
                new int[]{13, 23 },
                new int[]{24, 25}
            },
            new int[][]
            {
                new int[]{1, 5 },
                new int[]{  8, 12 },
                new int[]{15, 24},
                new int[] {25, 26}
            },
            new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 5, 5 },
                new int[] { 8, 10 },
                new int[] { 15, 23 },
                new int[] { 24, 24 },
                new int[] { 25, 25 }
            });
        }

        [Theory]
        [ClassData(typeof(IntervalListIntersections))]
        public void ReturnIntersectionOfTwoIntervalList(int[][] firstList, int[][] secondList, int[][] expectedResult)
        {
            var result = IntervalIntersection(firstList, secondList);

            Assert.Equal(expectedResult, result);
        }

        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            return default;
        }
    }
}
