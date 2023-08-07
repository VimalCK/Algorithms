using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.JPMorgan
{
    /* You are given an integer array arr. Sort the integers in the array in ascending order by the number of 1's in their 
     * binary representation and in case of two or more integers have the same number of 1's you have to sort them in 
     * ascending order.
     * 
     * Return the array after sorting it. 
     */

    public class SortIntegersByNumberOfBits : TheoryData<int[], int[]>
    {
        public SortIntegersByNumberOfBits()
        {
            Add(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 0, 1, 2, 4, 8, 3, 5, 6, 7 });
        }

        [Theory]
        [ClassData(typeof(SortIntegersByNumberOfBits))]
        public void CheckSortByBits(int[] arr, int[] expectedResult)
        {
            var result = SortByBits(arr);

            arr.AreEqual(result);
        }

        public int[] SortByBits(int[] arr)
        {
            var values = new List<(int value, int count)>();
            
            Array.Sort(arr);

            // Binary shift method
            foreach (var number in arr)
            {
                var count = 0;
                var value = number;
                while (value > 0)
                {
                    count += value & 1;
                    value >>= 1;
                }

                values.Add((number, count));
            }

            // Linq approach

            foreach (var item in arr.OrderBy(x => x))
            {
                var binary = Convert.ToString(item, 2);
                values.Add((item, binary.Count(x => x == '1')));

            }

            return values.OrderBy(x => x.count).Select(x => x.value).ToArray();
        }
    }
}
