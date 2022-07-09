using Algorithms.Types;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    public class RemoveLinkedListItems : TheoryData<ListNode, int, ListNode>
    {
        public RemoveLinkedListItems()
        {
            // Add(new ListNode( 1, 2, 3, 4, 5), 6, new ListNode(1, 2, 3, 4, 5));
            Add(new ListNode(1, 2, 6, 3, 4, 5, 6), 6, new ListNode(1, 2, 3, 4, 5));
        }

        [Theory]
        [ClassData(typeof(RemoveLinkedListItems))]
        public void Remove_Item_From_LinkedList(ListNode head, int value, ListNode expectedResult)
        {
            var result = RemoveElements(head, value);
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null) return null;
            head.next = RemoveElements(head.next, val);
            return head.val == val ? head.next : head;

            //var result = new ListNode(int.MinValue);
            //result.next = head;

            //var previous = result;
            //var current = head;
            //while (current != null)
            //{
            //    if (current.val == val)
            //    {
            //        previous.next = current.next;
            //    }
            //    else
            //    {
            //        previous = current;
            //    }

            //    current = current.next;
            //}

            //return result.next;
        }
    }
}
