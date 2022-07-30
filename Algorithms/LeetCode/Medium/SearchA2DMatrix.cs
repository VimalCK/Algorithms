using Xunit;

namespace Algorithms.LeetCode.Medium
{
    /*
     * Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix. 
     * This matrix has the following properties: 
     * 
     * Integers in each row are sorted from left to right. 
     * The first integer of each row is greater than the last integer of the previous row.
     * 
     *      |-------|-------|-------|-------|
     *      |   1   |   3   |   5   |   7   |
     *      |-------|-------|-------|-------|
     *      |   10  |   11  |   16  |   20  |
     *      |-------|-------|-------|-------|
     *      |   23  |   30  |   34  |   60  |
     *      |-------|-------|-------|-------|
     */
    public class SearchA2DMatrix : TheoryData<int[][], int, bool>
    {
        public SearchA2DMatrix()
        {
            var data = new int[][]
            {
                new int[] { 1, 3, 5, 7 },
                new int[] { 10, 11, 16, 20 },
                new int[] {23, 30, 34, 60 }
            };

            Add(data, 13, false);
            Add(data, 60, true);
            Add(data, 3, true);
            Add(data, 30, true);
            Add(data, 45, false);
            Add(new int[][] { new int[] { 1 } }, 2, false);
        }

        [Theory]
        [ClassData(typeof(SearchA2DMatrix))]
        public void ReturnTrueIf2DMatrixFoundValue(int[][] matrix, int target, bool expectedResult)
        {
            var result = SearchMatrix(matrix, target);

            Assert.Equal(expectedResult, result);

        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix.Length == 0)
            {
                return false;
            }

            var left = 0;
            var rowPosition = 0;
            var right = matrix[0].Length - 1;
            while (rowPosition < matrix.Length && left <= right)
            {
                if (target > matrix[rowPosition][right])
                {
                    rowPosition++;
                    continue;
                }

                var midPoint = (left + right) / 2;
                var searchValue = matrix[rowPosition][midPoint];
                if (searchValue == target)
                {
                    return true;
                }

                if (target < searchValue)
                {
                    right = --midPoint;
                }
                else
                {
                    left = ++midPoint;
                }
            }

            return false;
        }
    }
}
