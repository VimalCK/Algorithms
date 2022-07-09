using Algorithms.Types;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    public class MergeTwoSortedList : TheoryData<ListNode, ListNode, ListNode>
    {
        public MergeTwoSortedList()
        {
            Add(new ListNode(1, 2, 4), new ListNode(1, 3, 4), new ListNode(1, 1, 2, 3, 4, 4));
        }

        [Theory]
        [ClassData(typeof(MergeTwoSortedList))]
        public void Merge_Two_Sorted_LinkedList(ListNode listNode1, ListNode listNode2, ListNode expectedResult)
        {
            var result = MergeTwoLists(listNode1, listNode2);

        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null || list2 == null)
            {
                return list1 ?? list2;
            }
            if (list1.val <= list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }


            //var result = new ListNode(int.MinValue);
            //var previous = result;

            //while (list1 != null && list2 != null)
            //{
            //    if (list1.val <= list2.val)
            //    {
            //        previous.next = list1;
            //        list1 = list1.next;
            //    }
            //    else
            //    {
            //        previous.next = list2;
            //        list2 = list2.next;
            //    }

            //    previous = previous.next;
            //}

            //previous.next = list1 ?? list2;
            //return result.next; 
        }
    }
}
