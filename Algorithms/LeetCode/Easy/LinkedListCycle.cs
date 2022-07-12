using Algorithms.Types;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Given head, the head of a linked list, determine if the linked list has a cycle in it.
     * There is a cycle in a linked list if there is some node in the list that can be reached again by continuously 
     * following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. 
     * Note that pos is not passed as a parameter. 
     * 
     * Return true if there is a cycle in the linked list. Otherwise, return false.
     */


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
