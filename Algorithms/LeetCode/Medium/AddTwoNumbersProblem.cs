using Xunit;

namespace Algorithms.LeetCode.Medium
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class AddTwoNumbersProblem : IAlogrithm
    {
        [Fact]
        public void Run()
        {
            var node1 = new ListNode(2);
            node1.next = new ListNode(4);
            node1.next.next = new ListNode(3);

            var node2 = new ListNode(5);
            node2.next = new ListNode(6);
            node2.next.next = new ListNode(4);

            var result = AddTwoNumbers(node1, node2);

            Assert.Equal(7, result.val);
            Assert.Equal(0, result.next.val);
            Assert.Equal(8, result.next.next.val);
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
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
