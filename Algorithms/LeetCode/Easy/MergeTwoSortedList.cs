using Algorithms.Types;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    public class MergeTwoSortedList : TheoryData<ListNode, ListNode, ListNode>
    {
        public MergeTwoSortedList()
        {
            Add(new ListNode(1,2,4), new ListNode(1,3,4), new ListNode(1,1,2,3,4,4));
        }

        [Theory]
        [ClassData(typeof(MergeTwoSortedList))]
        public void Merge_Two_Sorted_LinkedList(ListNode listNode1, ListNode listNode2, ListNode expectedResult)
        {
            var result = MergeTwoLists(listNode1, listNode2);

        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var items = new Queue<ListNode>();
            while (list1 != null)
            {
                var temp = list1;
                temp.next = null;
                items.Enqueue(temp);
                list1 = list1.next;
            }

            while (items.Count > 0)
            {
                var node = items.Dequeue();
                var temp = list2;
                while (temp != null)
                {
                    if (node.val < temp.val)
                    {

                    }
                }
            }

            return list2;
        }
    }
}
