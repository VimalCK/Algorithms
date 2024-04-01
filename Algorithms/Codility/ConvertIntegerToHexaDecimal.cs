using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.Codility
{
    public class ConvertIntegerToHexaDecimal : TheoryData<int, string>
    {
        public ConvertIntegerToHexaDecimal()
        {
            Add(26, "1a");
            Add(-1, "ffffffff");
        }

        [Theory]
        [ClassData(typeof(ConvertIntegerToHexaDecimal))]
        public void ReturnConvertToHexaDecimal(int num, string expected)
        {
            var result = ToHex(num);

            Assert.Equal(expected, result);
        }

        public string ToHex(int num)
        {
            if (num == 0)
            {
                return "0";
            }

            var letters = "0123456789abcdef".ToCharArray();

            var result = string.Empty;
            var remainder = (uint)num;
            var digits = new List<char>();
            while (remainder > 0)
            {
                var digit = remainder % 16;
                remainder /= 16;
                result = letters[digit] + result;
            }

            return result;
        }
    }
}
