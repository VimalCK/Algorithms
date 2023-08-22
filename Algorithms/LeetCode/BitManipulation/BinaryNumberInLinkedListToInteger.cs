using Algorithms.Types;
using Xunit;

namespace Algorithms.LeetCode.BitManipulation
{
    public class BinaryNumberInLinkedListToInteger : TheoryData<ListNode, int>
    {
        public BinaryNumberInLinkedListToInteger()
        {
            Add(new ListNode(1, 0, 1), 5);
            Add(new ListNode(0), 0);
        }

        [Theory]
        [ClassData(typeof(BinaryNumberInLinkedListToInteger))]
        public void ReturnBinaryNumberInLinkedListToInteger(ListNode listNode, int expected)
        {
            var result = GetDecimalValue(listNode);

            Assert.Equal(expected, result);
        }

        public int GetDecimalValue(ListNode head)
        {
            return 0;
        }
    }
}
