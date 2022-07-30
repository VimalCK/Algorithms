using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithms.LeetCode.Medium
{
    /*
     * Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:
     *  1.  Each row must contain the digits 1-9 without repetition.
     *  2.  Each column must contain the digits 1-9 without repetition.
     *  3.  Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
*   
     *  Note:   A Sudoku board (partially filled) could be valid but is not necessarily solvable.
     *  Only the filled cells need to be validated according to the mentioned rules.
     *          
     *        |---|---|---||---|---|---||---|---|---|
     *        | 5 | 3 |   ||   | 7 |   ||   |   |   |
     *        |---|---|---||---|---|---||---|---|---|
     *        | 6 |   |   || 1 | 9 | 5 ||   |   |   |
     *        |---|---|---||---|---|---||---|---|---|
     *        |   | 9 | 8 ||   |   |   ||   | 6 |   |
     *       =========================================
     *        | 8 |   |   ||   | 6 |   ||   |   | 3 |
     *        |---|---|---||---|---|---||---|---|---|
     *        | 4 |   |   || 8 |   | 3 ||   |   | 1 |
     *        |---|---|---||---|---|---||---|---|---|
     *        | 7 |   |   ||   | 2 |   ||   |   | 6 |
     *        =========================================
     *        |   | 6 |   ||   |   |   || 2 | 8 |   |
     *        |---|---|---||---|---|---||---|---|---|
     *        |   |   |   || 4 | 1 | 9 ||   |   | 5 |
     *        |---|---|---||---|---|---||---|---|---|
     *        |   |   |   ||   | 8 |   ||   | 7 | 9 |
     *        |---|---|---||---|---|---||---|---|---|
     *     
     *          
     */
    public class ValidSudoku : TheoryData<char[][], bool>
    {
        public ValidSudoku()
        {
            var sudoku = new char[][]
            {
                new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };

            Add(sudoku, true);
        }

        [Theory]
        [ClassData(typeof(ValidSudoku))]
        public void Return_True_If_The_Table_satisfy_SudokuConditions(char[][] board, bool expectedResult)
        {
            var result = IsValidSudoku(board);

            Assert.Equal(expectedResult, result);
        }

        public bool IsValidSudoku(char[][] board)
        {
            var columnValues = new HashSet<char>();
            var rowValues = new HashSet<char>();
            var childTables = new Dictionary<string, HashSet<char>>()
            {
                { "00", new HashSet<char>() },
                { "01", new HashSet<char>() },
                { "02", new HashSet<char>() },
                { "10", new HashSet<char>() },
                { "11", new HashSet<char>() },
                { "12", new HashSet<char>() },
                { "20", new HashSet<char>() },
                { "21", new HashSet<char>() },
                { "22", new HashSet<char>() },
            };

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var rowItem = board[i][j];
                    var columnItem = board[j][i];
                    var horizontalKey = $"{i / 3}{j / 3}";

                    if (rowValues.Contains(rowItem) || columnValues.Contains(columnItem) ||
                        childTables[horizontalKey].Contains(rowItem))
                    {
                        return false;
                    }

                    if (IsValid(rowItem))
                    {
                        rowValues.Add(rowItem);
                        childTables[horizontalKey].Add(rowItem);
                    }

                    if (IsValid(columnItem))
                    {
                        columnValues.Add(columnItem);
                    }
                }

                columnValues.Clear();
                rowValues.Clear();
            }

            return true;
        }

        private bool IsValid(char value)
        {
            return (int)value is >= 49 and <= 57;
        }
    }
}
