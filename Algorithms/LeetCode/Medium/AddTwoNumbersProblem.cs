using Algorithms.Types;
using Xunit;

namespace Algorithms.LeetCode.Medium
{
    /*
     * You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, 
     * and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list. 
     * You may assume the two numbers do not contain any leading zero, except the number 0 itself.
     */
    public class AddTwoNumbersProblem : TheoryData<int[], int>
    {
        [Fact]
        public void AddTwoListNodeShouldReturnCorrectSum()
        {
            var node1 = new ListNode(2).Add(4).Add(3);
            var node2 = new ListNode(5).Add(6).Add(4);

            var result = AddTwoNumbers(node1, node2);

            Assert.Equal(7, result.val);
            Assert.Equal(0, result.next?.val);
            Assert.Equal(8, result.next?.next?.val);
        }

        private ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var node = new ListNode();
            var temp = node;

            while (l1 != null || l2 != null)
            {
                temp.val = (temp != null ? temp.val : 0) + (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0);
                if (temp.val >= 10)
                {
                    temp.next = new ListNode(temp.val / 10);
                    temp.val = temp.val % 10;
                }

                l1 = l1?.next;
                l2 = l2?.next;

                if ((l1 != null || l2 != null) && temp.next == null) temp.next = new ListNode();
                temp = temp.next;
            }

            return node;
        }
    }
}
