using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Given an integer numRows, return the first numRows of Pascal's triangle. 
     * In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
     */

    public class PascalTriangle : TheoryData<int, IList<IList<int>>>
    {
        public PascalTriangle()
        {
            Add(5, new int[5][]
            {
                new int[]{ 1 },
                new int[]{ 1, 1 },
                new int[]{ 1, 2, 1 },
                new int[]{ 1, 3, 3, 1},
                new int[]{ 1, 4, 6, 4, 1}
            });
        }

        [Theory]
        [ClassData(typeof(PascalTriangle))]
        public void GeneratePascalTriangle(int numRows, IList<IList<int>> expectedResult)
        {
            var result = Generate(numRows);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.True(result[i].SequenceEqual(expectedResult[i]));
            }
        }

        public IList<IList<int>> Generate(int numRows)
        {
            var result = new int[numRows][];

            for (int i = 0; i < numRows; i++)
            {
                result[i] = new int[i + 1];
                result[i][0] = 1;
                result[i][i] = 1;
                for (int j = 1; j < i; j++)
                {
                    result[i][j] = result[i - 1][j - 1] + result[i - 1][j];
                }
            }

            return result;
        }
    }
}
