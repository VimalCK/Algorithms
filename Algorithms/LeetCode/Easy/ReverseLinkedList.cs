using Algorithms.Types;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Given the head of a singly linked list, reverse the list, and return the reversed list.
     */
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
            if (head == null || head.next == null)
            {
                return head;
            }

            var result = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return result;

            //ListNode current = head;
            //ListNode previous = null;

            //while (current != null)
            //{
            //    var temp = current.next;
            //    current.next = previous;
            //    previous = current;
            //    current = temp;
            //}

            //return previous;
        }
    }
}
