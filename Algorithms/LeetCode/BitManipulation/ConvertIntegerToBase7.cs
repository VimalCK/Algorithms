using System;
using Xunit;

namespace Algorithms.LeetCode.BitManipulation
{
    //Given an integer num, return a string of its base 7 representation.

    public class ConvertIntegerToBase7 : TheoryData<int, string>
    {
        public ConvertIntegerToBase7()
        {
            Add(100, "202");
            Add(-7, "-10");
        }

        [Theory]
        [ClassData(typeof(ConvertIntegerToBase7))]
        public void ReturnConvertToBase7(int num, string expected)
        {
            var result = ConvertToBase7(num);

            Assert.Equal(expected, result);
        }

        public string ConvertToBase7(int num)
        {
            if (num == 0)
            {
                return "0";
            }

            var output = string.Empty;
            var result = Math.Abs(num);
            while (result > 0)
            {
                output = (result % 7) + output;
                result = result / 7;
            }

            return num > 0 ? output : "-" + output;
        }
    }
}
