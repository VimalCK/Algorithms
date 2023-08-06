using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.JPMorgan
{
    public class CountNumberWithUniqueDigits : TheoryData<int, int>
    {
        /* Given an integer n, return the count of all numbers with unique digits, x, where 0 <= x < 10n. */

        public CountNumberWithUniqueDigits()
        {
            Add(0, 1);
            Add(1, 10);
            Add(2, 91);
            Add(3, 739);
            Add(4, 5275);
        }

        [Theory]
        [ClassData(typeof(CountNumberWithUniqueDigits))]
        public void CheckCountNumbersWithUniqueDigits(int n, int expectedResult)
        {
            var result = CountNumbersWithUniqueDigits(n);

            Assert.Equal(result, expectedResult);
        }

        public int CountNumbersWithUniqueDigits(int n)
        {
            int sum = 1;
            int product = 10;
            if (n >= 1)
            {
                sum = 10;
            }

            for (int i = 1; i < n; i++)
            {

            }

            return sum;
        }
    }
}
