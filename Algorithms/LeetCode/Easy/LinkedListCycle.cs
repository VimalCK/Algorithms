using Algorithms.Types;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    public class LinkedListCycle : TheoryData<ListNode, bool>
    {
        public LinkedListCycle()
        {
            var node = new ListNode(2);
            Add(new ListNode(3).Add(node).Add(0, 4).Add(node), true);
            node = new ListNode(-21, 10, 17, 8, 4, 26, 5, 35, 33, -7, -16, 27, -12, 6, 29, -12, 5, 9, 20, 14, 14, 2, 13, -24, 21, 23, -21, 5);

            Add(node, false);

        }

        [Theory]
        [ClassData(typeof(LinkedListCycle))]
        public void Return_True_If_LinkedList_Cycle_Detected(ListNode node, bool expectedResult)
        {
            var result = HasCycle(node);

            Assert.Equal(expectedResult, result);
        }

        public bool HasCycle(ListNode head)
        {
            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow?.next;
                fast = fast.next.next;

                if (fast == slow)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
