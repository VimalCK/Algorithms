using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    public class ContainsDuplicateProblem : TheoryData<int[], bool>
    {
        public ContainsDuplicateProblem()
        {
            Add(new int[] { 1, 2, 3, 1 }, true);
            Add(new int[] { 1, 2, 3, 4 }, false);
            Add(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, true);
        }

        [Theory]
        [ClassData(typeof(ContainsDuplicateProblem))]
        public void Return_True_If_ArrayContains_Duplicate(int[] data, bool expectedResult)
        {
            var result = ContainsDuplicate(data);

            Assert.Equal(expectedResult, result);
        }

        private bool ContainsDuplicate(int[] nums)
        {
            var items = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int value = nums[i];
                if (items.Contains(value))
                {
                    return true;
                }

                items.Add(value);
            }

            return false;
        }
    }
}
