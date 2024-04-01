using Algorithms.Types;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Xunit;

namespace Algorithms.Codility
{
    /* Write a function:

        class Solution { public int solution(int[] A); }
        
        that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.
        For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.
        
        Given A = [1, 2, 3], the function should return 4.
        Given A = [−1, −3], the function should return 1.
        
        Write an efficient algorithm for the following assumptions:
        
        N is an integer within the range [1..100,000];
        each element of array A is an integer within the range [−1,000,000..1,000,000].
    */

    public class MissingInteger : TheoryData<int[], int>
    {
        public MissingInteger()
        {
            Add(new[] { 1, 3, 6, 4, 1, 2 }, 5);
            //Add(new[] { 1, 2, 3 }, 4);
            //Add(new[] { -1, -3 }, 1);
        }

        [Theory]
        [ClassData(typeof(MissingInteger))]
        public void ReturnMissingInteger(int[] value, int expected)
        {
            var result = GetMissingInteger(value);

            Assert.Equal(expected, result);
        }

        public int GetMissingInteger(int[] value)
        {
            var result = 1;
            if (value == null)
            {
                return result;
            }

            Array.Sort(value);
            for (int i = 0; i <= value.Length - 2; i++)
            {
                var currentValue = value[i];
                if (currentValue < 1)
                {
                    continue;
                }

                var difference = value[i + 1] - value[i];
                result = difference < 2 ? value[i + 1] + 1 : value[i] + 1;
            }

            return result;
        }
    }
}
