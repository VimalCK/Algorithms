using Algorithms.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.LeetCode.Medium
{
    /*
     * Given the head of a sorted linked list, delete all nodes that have duplicate numbers, 
     * leaving only distinct numbers from the original list. Return the linked list sorted as well.
     */

    public class RemoveDuplicatesFromSortedList : TheoryData<ListNode, ListNode>
    {
        public RemoveDuplicatesFromSortedList()
        {
            Add(new ListNode(1, 2, 3, 3, 4, 4, 5), new ListNode(1, 2, 5));
            Add(new ListNode(1, 1, 1, 2, 3), new ListNode(2, 3));
        }

        [Theory]
        [ClassData(typeof(RemoveDuplicatesFromSortedList))]
        public void RetunSortedListAfterRemovingDuplicates(ListNode input, ListNode expectedResult)
        {
            var result = DeleteDuplicates(input);

            Assert.True(result.AreEqual(expectedResult));
        }

        public ListNode? DeleteDuplicates(ListNode? head)
        {
            //Recursive

            if (head == null)
            {
                return head;
            }

            var result = DeleteDuplicates(head?.next);
            if (head != null && head.val != head.next?.val)
            {
                head.next = result;
                return head;
            }
            else
            {
                return result?.val == head?.val ? result?.next : result;
            }



            // Sentinel head + Predecessor

            var sentinel = new ListNode();
            sentinel.next = head;
            var pred = sentinel;

            while (head != null)
            {
                if (head.next != null && head.val == head.next.val)
                {
                    while (head.next != null && head.val == head.next.val)
                    {
                        head = head.next;
                    }
                  
                    pred.next = head.next;
                }
                else
                {
                    pred = pred.next;
                }

                head = head.next;
            }

            return sentinel.next;
        }
    }
}
