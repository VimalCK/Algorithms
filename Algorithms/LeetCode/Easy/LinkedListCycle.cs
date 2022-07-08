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
            Add(new ListNode(3).Add(node).Add(0).Add(4).Add(node), true);
            node = new ListNode(-21).Add(10).Add(17).Add(8).Add(4).Add(26)
                 .Add(5).Add(35).Add(33).Add(-7).Add(-16).Add(27).Add(-12)
                 .Add(6).Add(29).Add(-12).Add(5).Add(9).Add(20).Add(14).Add(14)
                 .Add(2).Add(13).Add(-24).Add(21).Add(23).Add(-21).Add(5);

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
                slow = slow.next;
                fast = fast.next.next;

                if (fast == head)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
