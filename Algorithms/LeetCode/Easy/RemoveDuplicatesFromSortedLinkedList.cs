using Algorithms.Types;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    public class RemoveDuplicatesFromSortedLinkedList : TheoryData<ListNode, ListNode>
    {
        public RemoveDuplicatesFromSortedLinkedList()
        {
            // Add(new ListNode(1, 1, 2), new ListNode(1, 2));
            Add(new ListNode(1, 1, 2, 3, 3), new ListNode(1, 2, 3));
        }

        [Theory]
        [ClassData(typeof(RemoveDuplicatesFromSortedLinkedList))]
        public void Remove_Duplicates_From_Sorted_LinkedList(ListNode node, ListNode expectedResult)
        {
            var result = DeleteDuplicates(node);

            Assert.True(result.AreEqual(expectedResult));
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var result = DeleteDuplicates(head.next);
            if (result.val != head.val)
            {
                head.next = result;
                result = head;
            }

            return result;

            //var current = head;
            //while (current != null && current.next != null)
            //{
            //    if (current.val == current.next.val)
            //    {
            //        current.next = current.next.next;
            //    }
            //    else
            //    {
            //        current = current.next;
            //    }
            //}

            //return head;

        }
    }
}
