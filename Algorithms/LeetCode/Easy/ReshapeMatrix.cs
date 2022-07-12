using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * In MATLAB, there is a handy function called reshape which can reshape an m x n matrix into a new one with a different size r x c 
     * keeping its original data. You are given an m x n matrix mat and two integers r and c representing the number of 
     * rows and the number of columns of the wanted reshaped matrix. The reshaped matrix should be filled with all the elements 
     * of the original matrix in the same row-traversing order as they were. If the reshape operation with given parameters is 
     * possible and legal, output the new reshaped matrix; Otherwise, output the original matrix.
     */
    public class ReshapeMatrix : TheoryData<int[][], int, int, int[][]>
    {
        public ReshapeMatrix()
        {
            var data1 = new int[3][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
            };

            var data2 = new int[2][]
           {
                new int[] { 1, 2 },
                new int[] { 3, 4 }
           };

            Add(data1, 3, 3, data1);
            Add(data2, 1, 4, new int[1][] { new int[] { 1, 2, 3, 4 } });
        }

        [Theory]
        [ClassData(typeof(ReshapeMatrix))]
        public void ReshapeGivenMatrix(int[][] data, int row, int column, int[][] expectedResult)
        {
            var result = MatrixReshape(data, row, column);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.True(result[i].SequenceEqual(expectedResult[i]));
            }
        }

        public int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            var matLength = mat.Length * mat[0].Length;
            if (matLength != r * c)
            {
                return mat;
            }

            var row = 0;
            var column = 0;
            var reshapedMatrix = new int[r][];
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (column == 0)
                    {
                        reshapedMatrix[row] = new int[c];
                    }

                    reshapedMatrix[row][column] = mat[i][j];
                    column++;
                    if (column == c)
                    {
                        row++;
                        column = 0;
                    }
                }
            }

            return reshapedMatrix;
        }
    }
}
