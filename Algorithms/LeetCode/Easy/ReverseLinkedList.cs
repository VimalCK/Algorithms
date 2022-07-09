using Algorithms.Types;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    public class ReverseLinkedList : TheoryData<ListNode, ListNode>
    {
        public ReverseLinkedList()
        {
            Add(new ListNode(1, 2, 3, 4, 5), new ListNode(5, 4, 3, 2, 1));
        }

        [Theory]
        [ClassData(typeof(ReverseLinkedList))]
        public void Reverse_LinkedList(ListNode node, ListNode expectedResult)
        {
            var result = ReverseList(node);

            Assert.True(result.AreEqual(expectedResult));
        }

        public ListNode ReverseList(ListNode head)
        {
            return head;
        }
    }
}
