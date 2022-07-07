using Algorithms.Types;
using Xunit;

namespace Algorithms.LeetCode.Medium
{
    public class AddTwoNumbersProblem : TheoryData<int[], int>
    {
        [Fact]
        public void AddTwoListNodeShouldReturnCorrectSum()
        {
            var node1 = new ListNode(2).Add(4).Add(3);
            var node2 = new ListNode(5).Add(6).Add(4);

            var result = AddTwoNumbers(node1, node2);

            Assert.Equal(7, result.Value);
            Assert.Equal(0, result.Next?.Value);
            Assert.Equal(8, result.Next?.Next?.Value);
        }

        private ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var node = new ListNode();
            var temp = node;

            while (l1 != null || l2 != null)
            {
                temp.Value = (temp != null ? temp.Value : 0) + (l1 != null ? l1.Value : 0) + (l2 != null ? l2.Value : 0);
                if (temp.Value >= 10)
                {
                    temp.Next = new ListNode(temp.Value / 10);
                    temp.Value = temp.Value % 10;
                }

                l1 = l1?.Next;
                l2 = l2?.Next;

                if ((l1 != null || l2 != null) && temp.Next == null) temp.Next = new ListNode();
                temp = temp.Next;
            }

            return node;
        }
    }
}
